using JustDeclare.Exceptions;
using JustDeclare.Main.Models;
using JustDeclare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JustDeclare.Main.Helpers
{
    internal static class ExpressionHelper
    {
        public static IEnumerable<ValidationTestContainer<TInput>> CreateValidationTestFuncs<TInput>(this IEnumerable<Expression<Func<TInput, ValidationCheck>>> expressions)
        {
            return expressions.Select(r =>
            {
                MemberExpression ruleInput = GetFirstMemberExpression((MethodCallExpression)r.Body);

                if (ruleInput == null)
                    throw ValidationSetupException.NoArgumentsToMethodCall();

                var propertyName = ruleInput.Member.Name;

                return new ValidationTestContainer<TInput>
                {
                    PropertyName = propertyName,
                    CreateTest = r.Compile()
                };
            });
        }

        private static MemberExpression GetFirstMemberExpression(MethodCallExpression methodCall)
        {
            var firstNonConditionalArgument = methodCall.Arguments.FirstOrDefault(x => !x.IsWhenMethod());

            if (firstNonConditionalArgument is MemberExpression)
                return (MemberExpression)firstNonConditionalArgument;

            if (firstNonConditionalArgument is MethodCallExpression)
                return GetFirstMemberExpression((MethodCallExpression)firstNonConditionalArgument);

            if (firstNonConditionalArgument is UnaryExpression)
            {
                var unaryInput = ((UnaryExpression)firstNonConditionalArgument).Operand;

                if (unaryInput is MemberExpression)
                    return (MemberExpression)unaryInput;
            }

            if (firstNonConditionalArgument is LambdaExpression)
            {
                var firstArgLambda = (LambdaExpression)firstNonConditionalArgument;

                if (firstArgLambda.Body is MethodCallExpression)
                    return GetFirstMemberExpression((MethodCallExpression)firstArgLambda.Body);
            }

            return null;
        }

        private static bool IsWhenMethod(this Expression expression)
        {
            if (!(expression is MethodCallExpression))
                return false;

            var methodCall = expression as MethodCallExpression;

            return WhenMethodNames.Contains(methodCall.Method.Name);
        }

        private static string[] WhenMethodNames = new string[] { "When", "AndWhen" };
    }
}