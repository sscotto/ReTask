using System;

namespace ReTask.RetryPolicies
{
    public interface IDispatchAndForgetRetryPolicy<Ttype> where Ttype : class
    {
        void DispatchAndForget(Func<Ttype> func);
    }
}
