using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer
{
    internal static class SpecificationEvaluator
    {
        // create Query 
        //_dbContext.Set<TEntity>.where(p=>p.Id == id &&  ).Include(p=>p.ProductBrand).Include(p=>p.ProductType)

        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery , ISpecifications<TEntity,TKey> specifications)
                                                                                         where TEntity:BaseEntity<TKey>
        {
            var query = inputQuery;
            if(specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            #region Ordering
            if (specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            if (specifications.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);

            }

            #endregion

            #region Includes
            if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
                query = specifications.IncludeExpressions.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));

            #endregion

            #region Pagination
            if (specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }

            #endregion



            return query;
        }

    }
}
