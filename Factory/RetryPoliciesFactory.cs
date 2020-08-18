using ReTask.RetryPolicies;

namespace ReTask.Factory
{
    public static class RetryPoliciesFactory<Ttype> where Ttype : class
    {
        public static SimpleRetryPolicy<Ttype> CreateSimpleRetryPolicy(int maxAttempts, int baseSleepTime)
        {
            return new SimpleRetryPolicy<Ttype>(maxAttempts, baseSleepTime);
        }

        public static ExponentialRetryPolicy<Ttype> CreateExponentialRetryPolicy(int maxAttempts, int baseSleepTime, int power = 2)
        {
            return new ExponentialRetryPolicy<Ttype>(maxAttempts, baseSleepTime, power);
        }

        public static AddedRetryPolicy<Ttype> CreateAddedRetryPolicy(int maxAttempts, int baseSleepTime)
        {
            return new AddedRetryPolicy<Ttype>(maxAttempts, baseSleepTime);
        }
    }
}
