# dotValidate Unity Extensions
dotValidate is a syntactically simple way to declare validation rules in Dot Net!

## Unity Extensions
This project has a simple extension for registering dotValidate and it's dependency injection interfaces within a Unit Container.

### Installation

You can install dotValidate with Unity from Nuget Package Manager

```cli
nuget install dotValidate.Unity
```

Or you can use the dotnet cli:

```cli
dotnet add package dotValidate.Unity
```

### Usage

```cs
public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // register all your components with the container here
        // it is NOT necessary to register your controllers

        // e.g. container.RegisterType<ITestService, TestService>();

        container.RegisterDotValidate();

        //...
    }
}
```
Then you can inject the interface `IValidator` and use *dotValidate* as per the instructions [here](https://github.com/jephbayf1986/dotVALIDATE)

```cs

public class MyService : IMyService
{
    private readonly IValidator _validator;

    public MyService(IValidator validator)
    {
        _validator = validator;
    }
    
    ///...
}

```

## License, Copyright etc
dotValidate is created by Jeph & Georgina Bayfield and is licensed under the MIT license.
