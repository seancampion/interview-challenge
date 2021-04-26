using System;
using System.ComponentModel.DataAnnotations;

namespace TechnicalChallengeApp.DataRepository.Table
{
    public class SessionData
    {
        /// <summary>
        /// The user's unique session instance identifier, which is
        /// URL based and can be shared so other people can use it
        /// </summary>
        [Key]
        public Guid SessionId { get; set; }

        /// <summary>
        /// How many times a button has been pushed during the session
        /// </summary>
        public int ButtonsPushed { get; set; }
    }
}