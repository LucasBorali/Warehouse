using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Warehouse.DB
{
    public static class DbExtensions
    {

        public static async Task<List<T>> GetAllAsync<T>() where T : class
        {
            var context = new AppDbContext();
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

        public static async Task AddAsyncData<T>(T entity) where T : class
        {
            var context = new AppDbContext();
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

        public static async Task UpdateAsync<T>( T entity) where T : class
        {
            using var context = new AppDbContext();
            try
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar dados: {ex.Message}");
            }
        }

        public static async Task DeleteAsync<T>( T entity) where T : class
        {
            var context = new AppDbContext();
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
