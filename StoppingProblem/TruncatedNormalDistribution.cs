namespace StoppingProblem
{
    public static class TruncatedNormalDistribution
    {
        /// <summary>
        /// Probability density function of a truncated normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <param name="mean">mean of underlying normal distribution</param>
        /// <param name="sd">standard deviation of underlying normal distribution</param>
        /// <param name="a">support lower bound</param>
        /// <param name="b">support upper bound</param>
        /// <returns>PDF of a truncated normal distribution</returns>
        public static double Pdf(double x, double mean, double sd, double a, double b)
        {
            var xNorm = (x - mean) / sd;
            var aNorm = (a - mean) / sd;
            var bNorm = (b - mean) / sd;
            var z = StandardNormalDistribution.Cdf(aNorm) - StandardNormalDistribution.Cdf(bNorm);
            return StandardNormalDistribution.Pdf(xNorm) / (sd * z);
        }

        /// <summary>
        /// Probability density function of a truncated normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <param name="mean">mean of underlying normal distribution</param>
        /// <param name="sd">standard deviation of underlying normal distribution</param>
        /// <param name="a">support lower bound</param>
        /// <param name="b">support upper bound</param>
        /// <returns>PDF of a truncated normal distribution</returns>
        public static decimal Pdf(decimal x, decimal mean, decimal sd, decimal a, decimal b)
        {
            return (decimal) Pdf((double) x, (double) mean, (double) sd, (double) a, (double) b);
        }

        /// <summary>
        /// Cumulative density function of a truncated normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <param name="mean">mean of underlying normal distribution</param>
        /// <param name="sd">standard deviation of underlying normal distribution</param>
        /// <param name="a">support lower bound</param>
        /// <param name="b">support upper bound</param>
        /// <returns>CDF of a truncated normal distribution</returns>
        public static double Cdf(double x, double mean, double sd, double a, double b)
        {
            var xNorm = (x - mean) / sd;
            var aNorm = (a - mean) / sd;
            var bNorm = (b - mean) / sd;
            var z = StandardNormalDistribution.Cdf(aNorm) - StandardNormalDistribution.Cdf(bNorm);
            return StandardNormalDistribution.Cdf(xNorm) - StandardNormalDistribution.Cdf(aNorm) / z;
        }
        
        /// <summary>
        /// Cumulative density function of a truncated normal distribution
        /// </summary>
        /// <param name="x">parameter</param>
        /// <param name="mean">mean of underlying normal distribution</param>
        /// <param name="sd">standard deviation of underlying normal distribution</param>
        /// <param name="a">support lower bound</param>
        /// <param name="b">support upper bound</param>
        /// <returns>CDF of a truncated normal distribution</returns>
        public static decimal Cdf(decimal x, decimal mean, decimal sd, decimal a, decimal b)
        {
            return (decimal) Cdf((double) x, (double) mean, (double) sd, (double) a, (double) b);
        }

        /// <summary>
        /// Mean of a truncated normal distribution
        /// </summary>
        /// <param name="mean">mean of underlying normal distribution</param>
        /// <param name="sd">standard devition of underlying normal distribution</param>
        /// <param name="a">support lower bound</param>
        /// <param name="b">support upper bound</param>
        /// <returns></returns>
        public static double Mean(double mean, double sd, double a, double b)
        {
            var aNorm = (a - mean) / sd;
            var bNorm = (b - mean) / sd;
            var z = StandardNormalDistribution.Cdf(aNorm) - StandardNormalDistribution.Cdf(bNorm);
            return mean + (StandardNormalDistribution.Pdf(aNorm) - StandardNormalDistribution.Pdf(bNorm)) / z * sd;
        }

        /// <summary>
        /// Mean of a truncated normal distribution
        /// </summary>
        /// <param name="mean">mean of underlying normal distribution</param>
        /// <param name="sd">standard devition of underlying normal distribution</param>
        /// <param name="a">support lower bound</param>
        /// <param name="b">support upper bound</param>
        /// <returns></returns>
        public static decimal Mean(decimal mean, decimal sd, decimal a, decimal b)
        {
            return (decimal) Mean((double) mean, (double) sd, (double) a, (double) b);
        }
    }
}