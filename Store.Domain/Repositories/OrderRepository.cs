﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        protected override IQueryable<Order> GetQuery(int currentUserId, Expression<Func<Order, bool>> predicate = null)
        {
            var query = GetBaseQuery(currentUserId, predicate)
                .Include(x => x.OrderItems)
                .Include(x => x.OrderStatus);

            return query;
        }
    }
}
