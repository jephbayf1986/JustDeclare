# dotValidate Dependency Injection Extensions
dotValidate is a syntactically simple way to declare validation rules in .Net!

## Dependency Injection Extensions
This project has a simple extension for registering dotValidate and it's dependency injection interfaces within an IServiceCollection.

### Installation

You can install dotValidate with Dependency Injection from Nuget Package Manager, or Nuget CLI:

```cli
nuget install dotValidate.DependencyInjection
```

Or you can use the dotnet cli:

```cli
dotnet add package dotValidate.DependencyInjection
```

### Usage

Start by registering dotValidate in your `startup` class:

```cs

using dotValidate.Registration;
// using...

namespace MyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.RegisterDotValidate();
            
            //...
        }
        
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
dotValidate and all associated packages are created by Jeph & Georgina Bayfield and is licensed under the MIT license.
