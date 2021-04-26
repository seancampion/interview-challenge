using TechnicalChallengeApp.Model.Calculation;
using TechnicalChallengeApp.Model.Global;

namespace TechnicalChallengeApp.BusinessLogic.Calculation
{
    public interface ICalculationManagement
    {
        /// <summary>
        /// Performs the calculation operation
        /// </summary>
        /// <param name="request">The request information, which includes the values and calculation type</param>
        /// <returns>The calculated value</returns>
        ApiResponse<CalculationResponse> PerformCalculation(CalculationRequest request);
    }
}