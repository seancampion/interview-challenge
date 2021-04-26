using TechnicalChallengeApp.Model.Session;

namespace TechnicalChallengeApp.Model.Calculation
{
    public class CalculationRequest : SessionRequest
    {
        /// <summary>
        /// The type of calculation operation we will be performing
        /// </summary>
        public CalculationType CalculationType { get; set; }

        /// <summary>
        /// The last total value - aka the left value of the calculation operation
        /// </summary>
        public float LastTotal { get; set; }

        /// <summary>
        /// The value we are joining with <see cref="LastTotal"/> via the <see cref="CalculationType"/> operation
        /// </summary>
        public float ValueToApply { get; set; }
    }
}