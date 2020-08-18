using System;

namespace ReTask.RetryPolicies
{
    public interface IDispatchAndForgetRetryPolicy
    {
        void DispatchAndForget(Action action, Action handleSuccess);

        void DispatchAndForget(Action action);
    }
}
