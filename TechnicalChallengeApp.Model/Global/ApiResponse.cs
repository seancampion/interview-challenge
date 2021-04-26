namespace TechnicalChallengeApp.Model.Global
{
    /// <summary>
    /// Global shared general response model
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// If true, the action was completed succesfully
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Any message that may be used when returning back to the user
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Global shared general response model
    /// </summary>
    /// <typeparam name="tt">The type of data we are returning in the response</typeparam>
    public class ApiResponse<tt> : ApiResponse
    {
        /// <summary>
        /// The data being returned in the response
        /// </summary>
        public tt Data { get; set; }
    }
}