using System;
using System.Threading.Tasks;

namespace ReTask.RetryPolicies
{
    public abstract class AbstractRetryPolicy<Ttype> : 
        IRetryPolicy<Ttype>, 
        IDispatchAndForgetRetryPolicy<Ttype>
        where Ttype : class
    {
        protected int _currentAttempt = 0;
        protected int _maxAttemps;
        protected int _baseSleepTime;
        public Action<Exception> onAttempError;
        public Action<Ttype> onSuccess;
        public void Execute(Func<Ttype> func)
        {
            DoExecute(func);
        }

        public void DispatchAndForget(Func<Ttype> func)
        {
            Task.Run(() => DoExecute(func));                        
            return;      
        }

        private void DoExecute(Func<Ttype> action)
        {
            _currentAttempt = 0;
            do
            {
                try
                {                    
                    Ttype returnedObject = action();
                    onSuccess?.Invoke(returnedObject);
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

        protected abstract int CalculateSleepTime();
    }
}
