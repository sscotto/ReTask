using System;

namespace ReTask.RetryPolicies
{
    public interface IRetryPolicy<Ttype> where Ttype : class
    {
        void Execute(Func<Ttype> func);
    }
}
