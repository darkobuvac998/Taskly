using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Entities.QueryParameters
{
    public class QueryParameters
    {
        [FromQuery(Name = "userId")]
        public int? UserId { get; set; }
        [FromQuery(Name = "taskId")]
        public int? TaskId { get; set; }
        [FromQuery(Name = "boardId")]
        public int? BoardId { get; set; }
        public Expression<Func<T, bool>> FindExpression<T>()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "entity");

            List<MemberExpression> memberExpressions = new List<MemberExpression>();
            List<ConstantExpression> constantExpressions = new List<ConstantExpression>();
            List<BinaryExpression> binaryExpressions = new List<BinaryExpression>();
            foreach (var prop in GetType().GetProperties())
            {
                var value = prop.GetValue(this);
                if (value != null)
                {
                    memberExpressions.Add(Expression.Property(parameter, prop.Name));
                    constantExpressions.Add(Expression.Constant(value, typeof(int)));
                }
            }

            var res = constantExpressions.Zip(memberExpressions, (m, c) => new
            {
                Member = m,
                Constant = c,
            });

            foreach (var x in res)
            {
                binaryExpressions.Add(Expression.Equal(x.Member, x.Constant));
            }

            if (binaryExpressions.Count == 0)
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Constant(1), Expression.Constant(1)), parameter);
            }

            Expression conjuction = binaryExpressions[0];

            for (int i = 1; i < binaryExpressions.Count; i++)
            {
                conjuction = Expression.And(conjuction, binaryExpressions[i]);
            }

            return Expression.Lambda<Func<T, bool>>(conjuction, parameter);
        }
    }

    public class AdvancedSearch
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
    }

}
