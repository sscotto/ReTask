namespace ReTask.RetryPolicies
{
    public class SimpleRetryPolicy: AbstractRetryPolicy
    {
        public SimpleRetryPolicy(int maxAttempts, int baseSleepTime)
        {
            _maxAttemps = maxAttempts;
            _baseSleepTime = baseSleepTime;
        }
        protected override int CalculateSleepTime()
        {
            return _baseSleepTime;
        }
    }
}
