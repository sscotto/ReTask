using ReTask.RetryPolicies;

namespace ReTask.Factory
{
    public static class RetryPoliciesFactory
    {
        public static SimpleRetryPolicy CreateSimpleRetryPolicy(int maxAttempts, int baseSleepTime)
        {
            return new SimpleRetryPolicy(maxAttempts, baseSleepTime);
        }

        public static ExponentialRetryPolicy CreateExponentialRetryPolicy(int maxAttempts, int baseSleepTime, int power = 2)
        {
            return new ExponentialRetryPolicy(maxAttempts, baseSleepTime, power);
        }

        public static AddedRetryPolicy CreateAddedRetryPolicy(int maxAttempts, int baseSleepTime)
        {
            return new AddedRetryPolicy(maxAttempts, baseSleepTime);
        }
    }
}
