using System;

namespace StoppingProblem
{
    public class StoppingProblem
    {
        private double?[,] _values;

        private int CandidatesMax
        {
            get { return _values.GetLength(0); }
        }

        private int TrialsMax
        {
            get { return _values.GetLength(1); }
        }

        private readonly double _mean;
        private readonly double _sd;
        private readonly double _minCost;
        private readonly double _maxCost;

        public StoppingProblem(int candidatesInit, int trialsInit, double mean, double sd, double minCost,
            double maxCost)
        {
            _values = new double?[candidatesInit + 1, trialsInit + 1];
            _mean = mean;
            _sd = sd;
            _minCost = minCost;
            _maxCost = maxCost;
        }

        public double GetCost(int candidate, int trials)
        {
            return CalculateCost(candidate, trials);
        }

        private double CalculateCost(int candidate, int trials)
        {
            if (candidate >= CandidatesMax || trials >= TrialsMax)
            {
                Resize(Math.Max(candidate, CandidatesMax), Math.Max(trials, TrialsMax));
            }
            if (_values[candidate, trials].HasValue)
            {
                return _values[candidate, trials].Value;
            }

            if (trials <= candidate)
            {
                // base case
                _values[candidate, trials] = _mean;
            }
            else
            {
                // recursive
                var rawExpectedCostLater = CalculateCost(candidate, trials - 1);
                var expectedCostLater = Math.Min(rawExpectedCostLater, _maxCost);
                var expectedCostNow = TruncatedNormalDistribution.Mean(_mean, _sd, _minCost, expectedCostLater);
                var probNow = StandardNormalDistribution.Cdf(expectedCostLater);
                var probLater = (1 - probNow);
                var value = probNow * expectedCostNow + probLater * expectedCostLater;
                _values[candidate, trials] = value;
            }

            return _values[candidate, trials].Value;
        }

        private void Resize(int newCandidatesMax, int newTrialsMax)
        {
            var newValues = new double?[newCandidatesMax + 1, newTrialsMax + 1];
            for (var i = 0; i < CandidatesMax; i++)
            {
                for (var j = 0; j < TrialsMax; j++)
                {
                    newValues[i, j] = _values[i, j];
                }
            }
            _values = newValues;
        }
    }
}