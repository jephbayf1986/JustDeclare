# dotValidate
dotValidate is a syntactically simple way to declare validation rules in Dot Net!

## How to Use

### Installation

You can install dotValidate from Nuget Package Manager, or Nuget CLI:

```cli
nuget install dotValidate
```

Or you can use the dotnet cli:

```cli
dotnet add package dotValidate
```

### Getting Started

To write a set of validation rules, create a class that inherits from `ValidationRules<TRequest>` and call `DeclareRules()` inside the constuctor:

```cs
public class SimpleRequest
{
    public int? RequestNumber { get; set; }
    
    public string RequestName { get; set; }
}

public class SimpleRequestValidationRules : ValidationRules<SimpleRequest>
{
    public SimpleRequestValidationRules()
    {
        DeclareRules(
                      x => x.RequestNumber.MustNotBeNull(),
                      x => x.RequestName.MustNotBeBlank()
                  );
    }
}
```

Then you can simply call the `Validate(...)` method as follows:

```cs
var validator = new SimpleRequestValidationRules();

var result = validator.Validate(request);
```

...Or if injecting the `IValidator` interface, as follows:

```cs
 _validator.Validate(request)
           .Using<SimpleRequestValidationRules>();
```


## License, Copyright etc
dotValidate is created by Jeph & Georgina Bayfield and is licensed under the MIT license.
