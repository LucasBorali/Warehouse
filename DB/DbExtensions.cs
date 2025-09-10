using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.DB;

namespace Warehouse.DB
{
    public static class DbExtensions
    {

        public static async Task <List<T>> GetAllAsync<T>(this AppDbContext context) where T : class
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public static async Task AddAsync<T>(this AppDbContext context, T entity) where T : class
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public static async Task UpdateAsync<T>(this AppDbContext context, T entity) where T : class
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public static async Task DeleteAsync<T>(this AppDbContext context, T entity) where T : class
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }




    }
}
