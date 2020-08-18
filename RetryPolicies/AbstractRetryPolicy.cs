using System;
using System.Threading.Tasks;

namespace ReTask.RetryPolicies
{
    public abstract class AbstractRetryPolicy:
        IRetryPolicy,
        IDispatchAndForgetRetryPolicy,
        IFetchRetryPolicy
    {
        protected int _currentAttempt = 0;
        protected int _maxAttemps;
        protected int _baseSleepTime;
        public Action<Exception> onAttempError;

        public void Dispatch(Action action, Action handleSuccess)
        {
            DoExecute(action, handleSuccess);
        }

        public void Dispatch(Action action)
        {
            DoExecute(action, null);
        }

        public void DispatchAndForget(Action action, Action handleSuccess)
        {
            Task.Run(() => DoExecute(action, handleSuccess));                        
            return;      
        }

        public void DispatchAndForget(Action action)
        {
            Task.Run(() => DoExecute(action, null));
            return;
        }

        private void DoExecute(Action action, Action handleSuccess)
        {
            _currentAttempt = 0;
            do
            {
                try
                {
                    action();
                    handleSuccess?.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    int sleepTime = CalculateSleepTime();
                    onAttempError?.Invoke(ex);
                    System.Threading.Thread.Sleep(sleepTime);
                }
                _currentAttempt++;
            } while (_currentAttempt < _maxAttemps);
        }

        public Ttype Fetch<Ttype>(Func<Ttype> fetch, Action<Ttype> handleSuccess) where Ttype : class
        {
            _currentAttempt = 0;
            do
            {
                try
                {
                    Ttype returnedObject = fetch();
                    handleSuccess?.Invoke(returnedObject);                   
                    return returnedObject;
                }
                catch (Exception ex)
                {
                    int sleepTime = CalculateSleepTime();
                    onAttempError?.Invoke(ex);
                    System.Threading.Thread.Sleep(sleepTime);
                }
                _currentAttempt++;
            } while (_currentAttempt < _maxAttemps);
            return null;
        }

        protected abstract int CalculateSleepTime();
    }
}
