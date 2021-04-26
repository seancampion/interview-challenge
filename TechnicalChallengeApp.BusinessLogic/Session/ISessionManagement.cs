using System;
using System.Threading.Tasks;
using TechnicalChallengeApp.Model.Global;

namespace TechnicalChallengeApp.BusinessLogic.Session
{
    public interface ISessionManagement
    {
        /// <summary>
        /// Generates a unique session GUID for the user
        /// </summary>
        /// <returns>A unique GUID</returns>
        Task<ApiResponse<Guid>> GenerateSessionGuidAsync();

        /// <summary>
        /// Increments the buttons pushed counter by one
        /// </summary>
        /// <param name="sessionId">The user's session identifier</param>
        /// <returns>The result of the counter increment operation and if it was a success or not</returns>
        Task<ApiResponse> IncrementButtonsPushedAsync(Guid sessionId);

        /// <summary>
        /// Returns the total amount of buttons pushed
        /// </summary>
        /// <param name="sessionId">The user's session identifier</param>
        /// <returns>The total button count amount and if it was a success or not</returns>
        Task<ApiResponse<int>> GetTotalButtonsPushedAsync(Guid sessionId);
    }
}