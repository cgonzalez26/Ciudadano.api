using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ciudadano.Api.Models
{
    public class ParameterReplaceVisitor : ExpressionVisitor
    {
        public ParameterExpression Target { get; set; }
        public ParameterExpression Replacement { get; set; }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == Target ? Replacement : base.VisitParameter(node);
        }
    }

    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null || right == null) return left;

            var visitor = new ParameterReplaceVisitor()
            {
                Target = right.Parameters[0],
                Replacement = left.Parameters[0],
            };

            var rewrittenRight = visitor.Visit(right.Body);
            var andExpression = Expression.AndAlso(left.Body, rewrittenRight);
            return Expression.Lambda<Func<T, bool>>(andExpression, left.Parameters);

            //if (left == null) return right;
            //var and = Expression.AndAlso(left.Body, right.Body);
            //return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null || right == null) return left;

            var visitor = new ParameterReplaceVisitor()
            {
                Target = right.Parameters[0],
                Replacement = left.Parameters[0],
            };

            var rewrittenRight = visitor.Visit(right.Body);
            var orExpression = Expression.OrElse(left.Body, rewrittenRight);
            return Expression.Lambda<Func<T, bool>>(orExpression, left.Parameters);

            //if (left == null) return right;
            //var and = Expression.OrElse(left.Body, right.Body);
            //return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
        }
    }
}
