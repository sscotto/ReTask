using System;

namespace ReTask.RetryPolicies
{
    public interface IRetryPolicy
    {
        void Dispatch(Action action, Action handleSuccess);

        void Dispatch(Action action);
    }
}
