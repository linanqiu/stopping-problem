using System;

namespace StoppingProblem
{
    public static class StandardNormalDistribution
    {
        // Pdf scaling constant to prevent recalculation
        private static readonly double PdfConstScale = 1 / Math.Sqrt(2 * Math.PI);
        
        // Cdf scaling constant to prevent recalculation
        private static readonly double CdfConstScale = 1 / Math.Sqrt(2);

        // Erf constants
        private const double ErfConstA1 = 0.254829592;
        private const double ErfConstA2 = -0.284496736;
        private const double ErfConstA3 = 1.421413741;
        private const double ErfConstA4 = -1.453152027;
        private const double ErfConstA5 = 1.061405429;
        private const double ErfConstP = 0.3275911;

        /// <summary>
        /// Probability density function of a standard normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>PDF at x</returns>
        public static double Pdf(double x)
        {
            return PdfConstScale * Math.Exp(-0.5 * x * x);
        }

        /// <summary>
        /// Probability density function of a standard normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>PDF at x</returns>
        public static decimal Pdf(decimal x)
        {
            return (decimal) Pdf((double) x);
        }

        /// <summary>
        /// From Handbook of Mathematical Functions by Abramowitz and Stegun formula 7.1.26
        /// Computes error function with maximum error of 1.5E10-7
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>Error function from -x to x</returns>
        public static double Erf(double x)
        {
            var sign = 1;
            if (x < 0)
            {
                sign = -1;
            }
            x = Math.Abs(x);

            var t = 1.0 / (1.0 + ErfConstP * x);
            var y = 1.0 - (((((ErfConstA5 * t + ErfConstA4) * t) + ErfConstA3) * t + ErfConstA2) * t + ErfConstA1) * t * Math.Exp(-x * x);

            return sign * y;
        }

        /// <summary>
        /// From Handbook of Mathematical Functions by Abramowitz and Stegun formula 7.1.26
        /// Computes error function with maximum error of 1.5E10-7
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>Error function from -x to x</returns>
        public static decimal Erf(decimal x)
        {
            return (decimal) Erf((double) x);
        }

        /// <summary>
        /// Cumulative density function of a standard normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>CDF at x</returns>
        public static double Cdf(double x)
        {
            return 0.5 * (1 + Erf(x * CdfConstScale));
        }

        /// <summary>
        /// Cumulative density function of a standard normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <returns>CDF at x</returns>
        public static decimal Cdf(decimal x)
        {
            return (decimal) Cdf((double) x);
        }
    }
}