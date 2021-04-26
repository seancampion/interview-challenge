using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TechnicalChallengeApp.BusinessLogic.Calculation;
using TechnicalChallengeApp.BusinessLogic.Session;
using TechnicalChallengeApp.Model.Calculation;
using TechnicalChallengeApp.Model.Global;
using TechnicalChallengeApp.Model.Session;

namespace TechnicalChallengeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculationManagement _calculationManagement;
        private readonly ISessionManagement _sessionManagement;

        public CalculatorController(ICalculationManagement calculationManagement,
            ISessionManagement sessionManagement)
        {
            _calculationManagement = calculationManagement;
            _sessionManagement = sessionManagement;
        }

        /// <summary>
        /// Records a button push event
        /// </summary>
        /// <param name="request">The request information, which includes the values and calculation type</param>
        /// <returns>The result of the counter increment operation and if it was a success or not</returns>
        [HttpPost]
        [Route("Calculate")]
        public ApiResponse<CalculationResponse> PostCalculate(CalculationRequest request)
        {
            var calculateResponse = _calculationManagement.PerformCalculation(request);
            return calculateResponse;
        }

        /// <summary>
        /// Records a button push event
        /// </summary>
        /// <param name="request">The request object that contains the user's session identifier</param>
        /// <returns>The result of the counter increment operation and if it was a success or not</returns>
        [HttpPost]
        [Route("ButtonPush")]
        public async Task<ApiResponse> PostButtonPush(SessionRequest request)
        {
            var pushResponse = await _sessionManagement.IncrementButtonsPushedAsync(request.SessionId);
            return pushResponse;
        }

        /// <summary>
        /// Records a button push event
        /// </summary>
        /// <param name="sessionId">The user's session identifier</param>
        /// <returns>The result of the counter increment operation and if it was a success or not</returns>
        [HttpGet]
        [Route("ButtonPush")]
        public async Task<ApiResponse<int>> GetButtonPush(string sessionId)
        {
            var sessionIdGuid = Guid.Parse(sessionId);
            var pushResponse = await _sessionManagement.GetTotalButtonsPushedAsync(sessionIdGuid);

            return pushResponse;
        }
    }
}