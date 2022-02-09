# dotValidate
dotValidate is a syntactically simple way to declare validation rules in Dot Net!

The package is designed to create clear, human readable rules to help make code more manageable. The technical design was inspired by the way [Shouldly](https://github.com/shouldly/shouldly) uses expressions to handle multiple rule declarations. 

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

### Validation Result
The model `ValidationResult` returned by either `IValidator.Validate()` or `ValidationRules<>.Validate()` has the following public properties and methods which can be utilised by the user to determine how the failure might be handled:
 - `HasFailures` Property indicates true or false as to whether the overrall test has failed or not.
 - `NumberOfFailures` Property indicates the number, if any of failures that have caused the overrall test to fail.
 - `FailureSummary()` Gathers the list of failures into 1 readable string.
 - `Failures` Property contains a list of each individual failure, each one containing a `PropertyName` and `FailureDescription`.

### Simple rules
As already seen above, to declare a simple rule, just call the request property with any of the available Must___() extension methods. The below code includes some examples of the available extension methods, however this list is not exhaustive and more will be added in future versions:

```cs
DeclareRules(
              // General:
              x => x.NullableProperty.MustNotBeNull(),
              
              // Boolean
              x => x.IsActive.MustBeTrue(),
              
              // Numeric
              x => x.Id.MustNotBeZero(),
              x => x.Age.MustBeGreaterOrEqualTo(18),
              x => x.Height.MustBeLessThan(1.8M),
              x => x.Score.MustNotBeInRange(0, 20),
              
              // String
              x => x.FirstName.MustNotBeBlank(),
              x => x.LastName.MustBeNoShorterThan(2),
              x => x.UserName.MustStartWith("ABC"),
              x => x.Nationality.MustNotContain("ZZ"),
              x => x.BankAccount.MustMatchPattern("^[0-9]+$")
          );
```
*Note: The majority of extension methods have an opposite, eg. `MustNotBeNull()` and `MustBeNull()` are both available*

### Conditional Rules
You can ensure a validation rule only runs on certain conditions. The available conditional methods are `WhenNotNull()`, `When()` and `AndWhen()`. See below for examples of their use:

```cs
DeclareRules(
              // When Not Null...
              x => x.MiddleName.WhenNotNull()
                               .MustBeNoLongerThan(100),
              
              // When... Then...
              x => x.When(y => y.Age >= 18)
                    .Then(y => y.PaymentDetails.MustNotBeNull()),
              
              // When... AndWhen... Then...
              x => x.When(y => y.Age < 18)
                    .AndWhen(y => y.ParentPaymentDetails == null)
                    .Then(y => y.GuardianPaymentDetails.MustNotBeNull())
          );
```
As seen above, after the conditional methods, the `Then()` method should be used to declare the rule which depends upon the conditions.

*Note: `WhenNotNull()` and `When()` can only be declared once per rule but `AndWhen()` can be chained as many times as required.*

### Nested Rules
When multiple rules are applicable to a single property (especially useful for a nested object) you can use the extension `MustObeyTheseRules()`:

```cs
DeclareRules(
              // When Not Null...
              x => x.Full Name.MustObeyTheseRules(
                                                    y => y.MustNotBeBlank(),
                                                    y => y.MustBeLongerThan(5),
                                                    y => y.MustBeShorterThan(150),
                                                    y => y.MustContain(" ")
                                                ),
              
              // Nested Object with When Not Null for safety:
              x => x.PaymentDetails.WhenNotNull()
                                   .MustObeyTheseRules(
                                                    y => y.Address.MustNotBeNull().
                                                    y => y.CardNumber.MustBeLongerThan(15),
                                                    y => y.CardNumber.MustBeShorterThan(17),
                                                    y => y.ExpiryDate.MustMatchPattern("^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$")
                                                )
          );
```

### Custom Error Messages
Every rule has a built in error message, such as the following from `MustNotBeNull()`:
>A value was not provided for [PropertyName], which is required

You can override this message however and return your own custom message, by using the `UseCustomMessage()` extension method after declaring the rule, as follows:
```cs
DeclareRules(
              // Custom Message Example
              x => x.Full Name.MustBeShorterThan(150)
                              .UseCustomMessage("Full Name has a 150 character limit")
          );
```

### Preventing Cascading Errors
Consider the following code, in the event that the property *PaymentDetails* is null:
```cs
DeclareRules(
              // Preventing Cascading Errors Example
              x => x.PaymentDetails.MustNotBeNull(),
              x => x.PaymentDetails.CardHolderName.ShouldNotBeBlank()
          );
```
By default the validator will fail the first test as the property is null, but then try to run the second as well, to give a complete list of validaiton failures. In this case you will receive a [NullReferenceException](https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception?view=net-6.0) as it tries to resolve a property within a null instance. As expressions are being used, a [null conditional operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-) is not valid.

Instead, you can prevent the validator from contiuing by using the `StopValidationOnFailure()` extension method:
```cs
DeclareRules(
              x => x.PaymentDetails.MustNotBeNull()
                                   .StopValidationOnFailure(),
              x => x.PaymentDetails?.CardHolderName.ShouldNotBeBlank()
          );
```

*Notes:*
1. *Using `WhenNotNull()` is alternative way of preventing the above unhandled exceptions, but note the difference in behavior - `WhenNotNull()` will prevent the single rule it's part of from running, whereas `StopValidationOnFailure()` will stop all subsequent rules from running.*
2. *By default any request which is null and passed into the validator will fail validation. To prevent this, use `WhenNotNull()` extension method*

## License, Copyright etc
dotValidate is created by Jeph & Georgina Bayfield and is licensed under the MIT license.
