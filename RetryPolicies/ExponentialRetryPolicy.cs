using System;

namespace ReTask.RetryPolicies
{
    public class ExponentialRetryPolicy<Ttype> : AbstractRetryPolicy<Ttype>
        where Ttype : class
    {
        private double _power;
        public ExponentialRetryPolicy(int maxAttempts, int baseSleepTime, double power = 2)
        {
            _maxAttemps = maxAttempts;
            _baseSleepTime = baseSleepTime;
            _power = power;
        }
        protected override int CalculateSleepTime()
        {
            return Convert.ToInt32(Math.Truncate(_baseSleepTime * Math.Pow(_power, (double)_currentAttempt)));
        }
    }
}
