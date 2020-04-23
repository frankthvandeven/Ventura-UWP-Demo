using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ventura.Helpers
{
    public static class LambdaHelper
    {

        public static string GetMemberName(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)expression).Member.Name;
                case ExpressionType.Convert:
                    return GetMemberName(((UnaryExpression)expression).Operand);
                default:
                    throw new NotSupportedException(expression.NodeType.ToString());
            }
        }

        /// <summary>
        /// var myCustomerInstance = new Customer();
        /// myCustomerInstance.SetPropertyValue(c => c.Title, "Mr"); 
        /// </summary>
        public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T, TValue>> memberLambda, TValue value)
        {
            var memberSelectorExpression = memberLambda.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }

    }
}
