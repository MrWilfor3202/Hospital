using Hospital.Core.Abstract.UnitOfWork;
using Hospital.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Implementations.UnitOfWork.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HospitalDbContext _context;

        public EFUnitOfWork(HospitalDbContext context) 
        {
            _context = context;
        }

        public async Task CommitAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
