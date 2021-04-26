using System;
using TechnicalChallengeApp.Model.Calculation;
using TechnicalChallengeApp.Model.Global;

namespace TechnicalChallengeApp.BusinessLogic.Calculation
{
    public class CalculationManagement : ICalculationManagement
    {
        /// <summary>
        /// Performs the calculation operation
        /// </summary>
        /// <param name="request">The request information, which includes the values and calculation type</param>
        /// <returns>The calculated value</returns>
        public ApiResponse<CalculationResponse> PerformCalculation(CalculationRequest request)
        {
            var left = request.LastTotal;
            var right = request.ValueToApply;

            var apiResponse = new ApiResponse<CalculationResponse>
            {
                Data = new CalculationResponse(),
                IsSuccess = true,
                Message = "Calculation operation completed"
            };

            switch (request.CalculationType)
            {
                case CalculationType.Add:
                    apiResponse.Data.Total = left + right;
                    break;

                case CalculationType.Subtract:
                    apiResponse.Data.Total = left - right;
                    break;

                case CalculationType.Multiply:
                    apiResponse.Data.Total = left * right;
                    break;

                case CalculationType.Divide:
                    try
                    {
                        apiResponse.Data.Total = left / right;
                    }
                    catch (DivideByZeroException)
                    {
                        apiResponse.IsSuccess = false;
                        apiResponse.Message = "You cannot divide by zero";
                    }
                    break;
            }

            return apiResponse;
        }
    }
}