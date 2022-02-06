using dotValidate.Conditions;
using dotValidate.Main.Conditions;
using dotValidate.Main.ValidationChecks;
using dotValidate.Models;
using System;

namespace dotValidate
{
    /// <summary>
    /// Property Extensions for building Validation Rules with dotValidate
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// <b>When Not Null</b><br/>
        /// Allows a safety check for nullable objects whose rules only apply when not null
        /// <para>
        /// <i>Example:</i> <br />
        /// <code> 
        /// DeclareRules(
        ///     x => x.Id.<b>WhenNotNull</b>()
        ///              .MustBeGreaterThan(50)
        /// )
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="value">Property subject to validation rules</param>
        /// <returns>Not Null Condition - For chaining Must___() rules for nullable properties</returns>
        public static NotNullCondition<T> WhenNotNull<T>(this T value)
        {
            return new NotNullCondition<T>(value);
        }

        /// <summary>
        /// <b>When...</b><br/>
        /// Allows a conditional check to be done before running a rule
        /// <para>
        /// <i>Example:</i> <br />
        /// <code> 
        /// DeclareRules(
        ///     x => x.<b>When</b>(y => y.Id != null)
        ///           .Then(y => y.Name.MustNotBeNull())
        /// )
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="value">Property subject to validation rules</param>
        /// <param name="condition">Boolean condition to be checked occurs before continuing</param>
        /// <returns>Condition Chain - For chaining When().AndWhen().Then() rules</returns>
        public static ConditionChain<T> When<T>(this T value, Func<T, bool> condition)
        {
            var customCondition = new ValidationCondition<T>(condition);

            return new ConditionChain<T>(value, customCondition);
        }

        /// <summary>
        /// <b>And When...</b><br/>
        /// Allows more than one conditional check to be done before running a rule
        /// <para>
        /// <i>Example:</i> <br />
        /// <code> 
        /// DeclareRules(
        ///     x => x.When(y => y.Id != null)
        ///           .<b>AndWhen</b>(y => y.Id > 50)
        ///           .Then(y => y.Name.MustNotBeNull())
        /// )
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="currentConditions">Condition Chain - An existing chain of conditions containing When() and optionally one or more AndWhen()</param>
        /// <param name="condition">Boolean condition to be checked occurs before continuing</param>
        /// <returns>Condition Chain - For chaining When().AndWhen().Then() rules</returns>
        public static ConditionChain<T> AndWhen<T>(this ConditionChain<T> currentConditions, Func<T, bool> condition)
        {
            var customCondition = new ValidationCondition<T>(condition);

            currentConditions.AddCondition(customCondition);

            return currentConditions;
        }

        /// <summary>
        /// <b>Then...</b><br/>
        /// Allows the final rule decleration after a chain of When(), AndWhen() conditions.
        /// <para>
        /// <i>Example:</i> <br />
        /// <code> 
        /// DeclareRules(
        ///     x => x.When(y => y.Id != null)
        ///           .AndWhen(y => y.Id > 50)
        ///           .<b>Then</b>(y => y.Name.MustNotBeNull())
        /// )
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="T">Type of property subject to validation rule</typeparam>
        /// <param name="currentConditions">Condition Chain - An existing chain of conditions containing When() and optionally one or more AndWhen()</param>
        /// <param name="conditionFunc">Expression with Validation Check output</param>
        /// <returns>Validation Check</returns>
        public static ValidationCheck Then<T>(this ConditionChain<T> currentConditions, Func<T, ValidationCheck> conditionFunc)
        {
            if (!currentConditions.AllConditionsPassed())
                return new Dummy();

            return conditionFunc(currentConditions.CarryOverValue);
        }
    }
}