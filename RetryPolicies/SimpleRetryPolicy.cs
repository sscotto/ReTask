namespace ReTask.RetryPolicies
{
    public class SimpleRetryPolicy<Ttype> : AbstractRetryPolicy<Ttype> 
        where Ttype: class
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
