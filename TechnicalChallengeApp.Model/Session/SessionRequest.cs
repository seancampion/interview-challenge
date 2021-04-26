using System;

namespace TechnicalChallengeApp.Model.Session
{
    /// <summary>
    /// Session data that is associated with requests
    /// </summary>
    public class SessionRequest
    {
        /// <summary>
        /// The user's session identifier
        /// </summary>
        public Guid SessionId { get; set; }
    }
}