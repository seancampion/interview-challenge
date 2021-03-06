const initialize = () =>
{
    /**
     * The user's session identifier
     */
    const sessionIdValue = document.getElementById('session-id').value;

    /**
     * The value we are currently creating for
     * the calculator. Stored as a string so we
     * can properly handle decimal points and render
     * them, as parseFloat will delete them if there is
     * no value on the right side of the decimal
     */
    let calculatingValue = null;

    /**
     * The last total that was generated by the calculator
     */
    let lastTotal = null;

    /**
     * The last operator button pushed (except equals)
     */
    let lastOperator = null;

    /**
     * Updates the display field for the calculator
     * with the latest value
     * @param {number} value The value to render on screen
     */
    const updateCalculatorDisplay = (value) =>
    {
        document.getElementById('calculator-screen-value').innerText = value;
    }

    /**
     * Sets up the event handlers for all of the buttons
     * within the interface
     */
    const setupEventHandlers = () =>
    {
        //
        // Event listener for all numerical buttons
        //
        const numericalButtons = document.querySelectorAll('.calculator-number-item');
        numericalButtons.forEach((item, _) =>
        {
            item.addEventListener('click', async event =>
            {
                const incomingValue = event.target.innerText;
                const currentValue = (calculatingValue ?? '').toString();

                //
                // Only allow processing of a single decimal point
                //
                if (incomingValue === '.' && currentValue.indexOf('.') !== -1)
                {
                    return;
                }

                calculatingValue = currentValue + incomingValue;
                updateCalculatorDisplay(calculatingValue);

                await logButtonPress();
            });
        });

        //
        // Event listener for numerical keypress
        //
        const body = document.querySelector('body');
        body.addEventListener('keydown', async event => {
            const incomingKeypress = event.key;
            const operatorRegex = '([/*+-])+';
            const executionRegex = '([Enter])+';

            // Check if the key pressed was a number
            if (!isNaN(incomingKeypress))
            {
                const incomingValue = incomingKeypress;
                const currentValue = (calculatingValue ?? '').toString();

                //
                // Only allow processing of a single decimal point
                //
                if (incomingValue === '.' && currentValue.indexOf('.') !== -1) {
                    return;
                }

                calculatingValue = currentValue + incomingValue;
                updateCalculatorDisplay(calculatingValue);

                await logButtonPress();
            }

            //Check if keypress is an operator
            if (incomingKeypress.match(operatorRegex))
            {
                const operatorValue = incomingKeypress;

                if (calculatingValue === null) {
                    lastOperator = operatorValue;
                    return;
                }

                if (lastTotal === null) {
                    lastTotal = calculatingValue;
                }

                //
                // If there is a value here, we have not hit
                // the equals button, meaning we need to complete
                // the last operator action, then prepare for
                // the next one
                //
                if (lastOperator !== null) {
                    await performCalculationRequestAsync();
                }

                //Set lastOperator based on it's enum value
                if (operatorValue == '+')
                {
                    lastOperator = "add";
                }

                if (operatorValue == '-')
                {
                    lastOperator = "subtract";
                }

                if (operatorValue == '*')
                {
                    lastOperator = "multiply";
                }

                if (operatorValue == '/')
                {
                    lastOperator = "divide";
                }
                calculatingValue = null;

                await logButtonPress();
            }

            //Checks for enter key being pressed in order to execute
            if (incomingKeypress.match(executionRegex))
            {
                if (lastOperator === null || calculatingValue === null) {
                    return;
                }

                await performCalculationRequestAsync();
                await logButtonPress();
            }
            
        });

        //
        // Event listener for all operator buttons
        //
        const operatorButtons = document.querySelectorAll('.calculator-operator-item');
        operatorButtons.forEach((item, _) =>
        {
            item.addEventListener('click', async event =>
            {
                const operatorValue = event.target.dataset.operation;

                if (calculatingValue === null)
                {
                    lastOperator = operatorValue;
                    return;
                }

                if (lastTotal === null)
                {
                    lastTotal = calculatingValue;
                }

                //
                // If there is a value here, we have not hit
                // the equals button, meaning we need to complete
                // the last operator action, then prepare for
                // the next one
                //
                if (lastOperator !== null)
                {
                    await performCalculationRequestAsync();
                }

                lastOperator = operatorValue;
                calculatingValue = null;

                await logButtonPress();
            });
        });

        //
        // Event listener for the execution (equals) button
        //
        const executorButton = document.querySelector('.calculator-execution-item');
        executorButton.addEventListener('click', async _ =>
        {
            if (lastOperator === null || calculatingValue === null)
            {
                return;
            }

            await performCalculationRequestAsync();
            await updateLastTotal();
            await logButtonPress();
        });
    }

    const updateLastTotal = async () => {
        const request =
        {
            sessionId: sessionIdValue,
            data: parseFloat(lastTotal)
        };

        await fetch('/api/calculator/updatelasttotal', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        });
    }

    const getLastTotal = async () =>
    {
        const request =
        {
            sessionId: sessionIdValue
        }; 

        const response = await fetch('/api/calculator/getlasttotal', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        });

        const responseBody = await response.json();

        lastTotal = responseBody.data;
        updateCalculatorDisplay(lastTotal);
    }

    /**
     * Logs a button press event to the server
     */
    const logButtonPress = async () =>
    {
        const request =
        {
            sessionId: sessionIdValue
        };

        await fetch('/api/calculator/buttonpush', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        });
    }

    /**
     * Sends the calculation request to the server and
     * displays the results
     */
    const performCalculationRequestAsync = async () =>
    {
        const request =
        {
            sessionId: sessionIdValue,
            calculationType: lastOperator,
            lastTotal: parseFloat(lastTotal),
            valueToApply: parseFloat(calculatingValue)
        };

        const response = await fetch('/api/calculator/calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        });

        const responseBody = await response.json();
        if (responseBody.isSuccess)
        {
            lastTotal = responseBody.data.total;
            updateCalculatorDisplay(lastTotal);
        }
        else
        {
            updateCalculatorDisplay(responseBody.message);
        }

        calculatingValue = null;
    }

    setupEventHandlers();
};

initialize();