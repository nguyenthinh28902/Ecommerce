using Authentication.Admin.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private string _errorMessage = string.Empty;
        public AuthenticationUserDbContext _context { get; }
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(AuthenticationUserDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }


        public async Task CommitAsync()
        {
            await _context.Database.BeginTransactionAsync().Result.CommitAsync();
        }

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task RollbackAsync()
        {
            await _context.Database.BeginTransactionAsync().Result.RollbackAsync();
            await _context.Database.BeginTransactionAsync().Result.DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {

            try
            {
                await _context.SaveChangesAsync();
                await _context.Database.BeginTransactionAsync().Result.CommitAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.EntityFrameworkCore.DbUpdateException innerException
                  && innerException.InnerException is Microsoft.Data.SqlClient.SqlException sqlException)
                {
                    _errorMessage = $"SQL error occurred: {sqlException.Message} {Environment.NewLine}";
                }
                else
                {
                    _errorMessage = $"Error occurred: {ex.Message}  {Environment.NewLine}";
                }
                throw new Exception(_errorMessage, ex);
            }
        }
        protected virtual async Task Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    await _context.DisposeAsync();
            _disposed = true;
        }
    }
}
