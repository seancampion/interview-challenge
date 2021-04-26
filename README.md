# Technical Interview Challenge

Thank you for participating in the technical interview challenge! This challenge is designed to test your skill set for feature design and bug fixes in the following areas:

* Code quality
* User interface design
* Ability to understand existing code
* Communication (either in questions if they come up, comments, or commit messages)

## The Project

Your challenge involves a fairly simple application: A calculator. This calculator performs all of its operations server side and returns the results through an API layer within the application.

### Requirements to Run:
Visual Studio 2019 (Community)

### Commit Message Requirements
Your commit messages are your own and should be written in a way that you think is appropriate, but please include a reference to the feature, bug, or extra credit that is related to your commit message.

### Time Expectations

This is designed to be a quick project that should take no longer than an afternoon, at most. Please try to return your results within two business days of receiving this challenge. If you need to take longer, please contact your interviewer and let them know.

### Upon Completion of Project

If you have completed making all of your changes and have tested them, please upload your final branch of code into a GitLab repository under your account, and then email your interviewer a link to the repository.

## The Challenge

### Feature #1: Keyboard Functionality

Right now, the calculator requires the user to press the buttons in the user interface in order to perform mathematical operations.

We would like to add support so the user can use the numerical keypad on their keyboard instead of clicking buttons on the screen.

### Feature #2: Retaining the Last Total

If the user refreshes the screen, the last total value in the screen is wiped out.

We would like to add support so, upon a page refresh, the last total is still visible. This would require adding a new database column to the SessionData table in the database to store the last calculated value, then making a request for that value when the page is loaded.

### Bug #1: Button Increment Count Not Storing

We log every time a button is pressed in the user interface. We do not currently output this into the user interface, but have support for it in API calls. Currently though, this is purely used for reporting purposes.

A user has reported that the data in the database is empty -- all button counts are "zero". We need to identify why the value is not updating and correct it.

### Bug #2: Dividing By Zero Returns "Infinity"

A user reported an issue where, when they divide by zero, they were expecting a "divide by zero" error message to appear, but instead the application is returning "Infinity".

We need to identify why this is happening, and implement a correction so it properly returns the relevant message.

## Extra Credits

These are all optional and are not expected of anyone participating in this stage of the interview. Just some fun items if you have spare time available.

### Extra Credit #1: Find Areas of Improvement

There are likely one or more areas of the code base where things could be optimized, improved, or a potential bug could be exposed if certain steps aren't taken in the correct order.

Feel free to look around the code and make changes you think may improve the system.

### Extra Credit #2: Implement a New Framework (frontend or backend)

This application is fairly basic, using no special technologies other than what is needed for it to operate.

Look at implementing a new framework of your choice either in the frontend or backend of the system that provides advantages for future features that have yet to be determined (ex: adding Angular).

### Extra Credit #3: Add Historical Calculation Tracking:

All of the other calculators on the market keep track of your historical calculations. We would like to add support into this application for doing the same.

* Add a new database table to track each calculation operation (left value, right value, and which operator was used), the session associated with the calculation, and the result from that operation.
* Add API support for getting the calculation operation history from the database
* Add javascript support for querying the API and pulling in the item(s) from the historical table
* Add a user interface element to display all of the historical calculation operations

### Extra Credit #4: Improve Session Management

Right now sessions are purely based on the `sessionId` stored as a URL parameter. If the user deletes that parameter or comes back to the calculator from the main page, they lose their data.

Migrate the session management to be cookie-based, either implemented using a third party library or a custom design of your own.