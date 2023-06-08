using Data.Context;
using Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class RepositoryGenerico<TEntity> : IRepositoryGenerico<TEntity> where TEntity : class
    {
        private readonly MyContext _context;

        public RepositoryGenerico(MyContext context)
        {
            _context = context;
        }

        public async Task Atualizar(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                var entity = await PegarPeloId(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(string id)
        {
            try
            {
                var entity = await PegarPeloId(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Inserir(TEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> PegarPeloId(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> PegarPeloId(string id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> PegarTodos()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
