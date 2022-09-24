using Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Seeds
{
	public static class SeedUserDescriptions
	{
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Department
            modelBuilder.Entity<TipoUtilizador>()
                .HasData(
                   new TipoUtilizador { IdTipoUtilizador = 1, Descricao = "HR" }
            );
        }
    }
}
