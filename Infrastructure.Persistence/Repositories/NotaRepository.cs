using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class NotaRepository :  GenericRepositoryAsync<NotaUtilizador>, INotaUtilizadorRepository
    {
        private readonly DbSet<NotaUtilizador> _nota;

        public NotaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _nota = dbContext.Set<NotaUtilizador>();
        }

        public async Task<List<NotaUtilizador>> GetByIdUser(string idUser)
        {
            return await this._nota.Where(u => u.IdUtilizador.Equals(idUser)).ToListAsync();//Cuidado ao usar Include
            //return await this._nota.Include(u=>u.Id).Where(u=>u.IdUtilizador.Equals(idUser)).ToListAsync();//Cuidado ao usar Include
        }
    }
}
