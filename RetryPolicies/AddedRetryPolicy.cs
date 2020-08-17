namespace ReTask.RetryPolicies
{
    public class AddedRetryPolicy<Ttype> : AbstractRetryPolicy<Ttype>
        where Ttype: class
    {
        public AddedRetryPolicy(int maxAttempts, int baseSleepTime)
        {
            _maxAttemps = maxAttempts;
            _baseSleepTime = baseSleepTime;
        }
        protected override int CalculateSleepTime()
        {
            return (_currentAttempt + 1) * _baseSleepTime;
        }
    }
}
