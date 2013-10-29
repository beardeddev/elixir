using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Data.Mapping
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="lambda">The lambda.</param>
        /// <returns>The MemberInfo of property from LambdaExpression.</returns>
        public static MemberInfo GetProperty(this LambdaExpression lambda)
        {
            Expression expr = lambda;
            while (1 == 1)
            {
                switch (expr.NodeType)
                {
                    case ExpressionType.Lambda:
                        expr = ((LambdaExpression)expr).Body;
                        break;
                    case ExpressionType.Convert:
                        expr = ((UnaryExpression)expr).Operand;
                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpression = (MemberExpression)expr;
                        MemberInfo mi = memberExpression.Member;
                        return mi;
                    default:
                        return null;
                }
            }
        }
    }
}
