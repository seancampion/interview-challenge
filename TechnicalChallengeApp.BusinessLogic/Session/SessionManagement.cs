using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TechnicalChallengeApp.DataRepository;
using TechnicalChallengeApp.DataRepository.Table;
using TechnicalChallengeApp.Model.Global;

namespace TechnicalChallengeApp.BusinessLogic.Session
{
    public class SessionManagement : ISessionManagement
    {
        /// <summary>
        /// Generates a unique session GUID for the user
        /// </summary>
        /// <returns>A unique GUID</returns>
        public async Task<ApiResponse<Guid>> GenerateSessionGuidAsync()
        {
            using (var db = new CalculatorDbContext())
            {
                var sessionId = Guid.NewGuid();

                var sessionData = new SessionData
                {
                    ButtonsPushed = 0,
                    SessionId = sessionId
                };

                db.Add(sessionData);
                await db.SaveChangesAsync();

                return new ApiResponse<Guid>
                {
                    Data = sessionId,
                    IsSuccess = true,
                    Message = "Session ID generated"
                };
            }
        }

        /// <summary>
        /// Increments the buttons pushed counter by one
        /// </summary>
        /// <param name="sessionId">The user's session identifier</param>
        /// <returns>The result of the counter increment operation and if it was a success or not</returns>
        public async Task<ApiResponse> IncrementButtonsPushedAsync(Guid sessionId)
        {
            using (var db = new CalculatorDbContext())
            {
                var sessionData = await db.SessionData
                    .AsNoTracking()
                    .FirstOrDefaultAsync(sd => sd.SessionId == sessionId);

                sessionData.ButtonsPushed++;

                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "Button counter incremented"
                };
            }
        }

        /// <summary>
        /// Returns the total amount of buttons pushed
        /// </summary>
        /// <param name="sessionId">The user's session identifier</param>
        /// <returns>The total button count amount and if it was a success or not</returns>
        public async Task<ApiResponse<int>> GetTotalButtonsPushedAsync(Guid sessionId)
        {
            using (var db = new CalculatorDbContext())
            {
                var sessionData = await db.SessionData
                    .AsNoTracking()
                    .FirstOrDefaultAsync(sd => sd.SessionId == sessionId);

                return new ApiResponse<int>
                {
                    Data = sessionData.ButtonsPushed,
                    IsSuccess = true,
                    Message = "Button counter incremented"
                };
            }
        }
    }
}