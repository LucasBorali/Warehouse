using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Warehouse.DB
{
    public static class DbExtensions
    {

        public static async Task<List<T>> GetAllAsync<T>(this AppDbContext context) where T : class
        {
            try
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter dados: {ex.Message}");
                return new List<T>();

            }
        }

        public static async Task AddAsyncData<T>(this AppDbContext context, T entity) where T : class
        {
            try
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar dados: {ex.Message}");
            }
        }

        public static async Task UpdateAsync<T>(this AppDbContext context, T entity) where T : class
        {
            try
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar dados: {ex.Message}");
            }
        }

        public static async Task DeleteAsync<T>(this AppDbContext context, T entity) where T : class
        {
            try
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar dados: {ex.Message}");
            }
        }




    }
}
