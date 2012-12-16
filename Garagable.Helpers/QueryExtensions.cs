using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Garagable.Helpers {

    public static class QueryExtensions {

        /// <summary>
        /// Include multiple entities
        /// <code>
        /// var query = context.Customers
        ///           .IncludeMultiple(
        ///               c => c.Address,
        ///               c => c.Orders.Select(o => o.OrderItems));
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class {
            if (includes != null) {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

    }

}
