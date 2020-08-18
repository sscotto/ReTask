using System;

namespace ReTask.RetryPolicies
{
    public interface IFetchRetryPolicy
    {
        Ttype Fetch<Ttype>(Func<Ttype> fetch, Action<Ttype> handleSuccess) where Ttype : class;        
    }
}
