using Homework.Plugins.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Homework.CurrencyManagement.Utils
{
    public static class FilterExtensions
    {
        public static IEnumerable<T> Filter<T>(
        this IEnumerable<T> src,
        Expression<Func<T, bool>> predicate)
        {
            return src.AsQueryable().Where(predicate).AsEnumerable();
        }

        public static IEnumerable<T> OrderBy<T>(
           this IEnumerable<T> src,
        Expression<Func<T, string>> predicate, OrderType orderType)
        {
            return
                 orderType == OrderType.Ascending
                ? src.AsQueryable().OrderBy(predicate)
                : src.AsQueryable().OrderByDescending(predicate);
        }
    }
    
}
