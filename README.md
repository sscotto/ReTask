# ReTask
Performs Operations with Retry Policies

## Installation 
https://www.nuget.org/packages/ReTask/

## Usage

### Create Simple Retry Policy and dispatch synchronous action
```csharp
  SimpleRetryPolicy retryPolicy = RetryPoliciesFactory.CreateSimpleRetryPolicy(maxAttempts: 3, baseSleepTime: 2000);
  retryPolicy.Dispatch(() => { Console.WriteLine($"Dispatching at {DateTime.Now.ToString("HH:mm:ss")}"); });
```

### Create Simple Retry Policy, dispatch synchronous action and handle error on each attempt.
```csharp
  SimpleRetryPolicy retryPolicy = RetryPoliciesFactory.CreateSimpleRetryPolicy(maxAttempts: 3, baseSleepTime: 2000);
  retryPolicy.onAttempError = (Exception) =>
  {
      Console.WriteLine($"New Exception {Exception.Message} at  {DateTime.Now.ToString("HH:mm:ss")}");
  };

  retryPolicy.Dispatch(() => { throw new Exception("Testing"); });
```
  
  
  ### Create Added Retry Policy, dispatch synchronous action and handle success.

```csharp
  AddedRetryPolicy retryPolicy = RetryPoliciesFactory.CreateAddedRetryPolicy(maxAttempts: 3, baseSleepTime: 10000);

  Action handleSuccess = () =>
  {
      Console.WriteLine($"Successfully Dispatched at {DateTime.Now.ToString("HH:mm:ss")}");
  };

  retryPolicy.onAttempError = (exception) =>
  {
      Console.WriteLine($"Exception {exception.Message} at {DateTime.Now.ToString("HH:mm:ss")}");
  };

  retryPolicy.Dispatch(
      () => {
          Console.WriteLine($"Dispatching at {DateTime.Now.ToString("HH:mm:ss")}");                                        
      },
      handleSuccess
  );
```

### Create Exponential Retry Policy and Fetch some user.
```csharp
  List<User> lsUsers = new List<User>()
  {
      new User() { IdUser = 1, Name = "Rudy"},
      new User() { IdUser = 2, Name = "Jack"},
      new User() { IdUser = 3, Name = "Cecilia"},
      new User() { IdUser = 4, Name = "Calamity Jane"},
      new User() { IdUser = 5, Name = "Boomerang"},
  };

  ExponentialRetryPolicy retryPolicy = RetryPoliciesFactory.CreateExponentialRetryPolicy(maxAttempts: 3, baseSleepTime: 2000);

  Action handleSuccess = () =>
  {
      Console.WriteLine("Successfully Dispatched");
  };

  retryPolicy.Fetch<User>(() => { return lsUsers.Find(x => x.IdUser == 3); },
      (user) =>
      {
          Console.WriteLine($"Found User - Id: {user.IdUser} ; Name: {user.Name}");
      });
```

### Create Added Retry Policy, dispatch and forget.
```csharp
  AddedRetryPolicy retryPolicy = RetryPoliciesFactory.CreateAddedRetryPolicy(maxAttempts: 3, baseSleepTime: 10000);

  Action handleSuccess = () =>
  {
      Console.WriteLine($"Successfully Dispatched at {DateTime.Now.ToString("HH:mm:ss")}");
  };

  retryPolicy.onAttempError = (exception) =>
  {
      Console.WriteLine($"Exception {exception.Message} at {DateTime.Now.ToString("HH:mm:ss")}");
  };

  //non-blocking action
  retryPolicy.DispatchAndForget(
      () => {
          Console.WriteLine($"Dispatching at {DateTime.Now.ToString("HH:mm:ss")}");
          System.Threading.Thread.Sleep(2000);
      },
      handleSuccess
  );
  Console.ReadLine();
  ```
