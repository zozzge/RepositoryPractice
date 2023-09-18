using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace repository
{
    public class OrderRepository: Repository<Order>
    {
        public OrderRepository(AppDbContext _dbContext) : base(_dbContext)
        {

        }

        public IQueryable<Order> WithDetails()
        {
            return dbContext.Set<Order>().Include(o => o.Items);
        }

    }
}
