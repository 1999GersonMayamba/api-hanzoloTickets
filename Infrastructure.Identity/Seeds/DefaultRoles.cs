using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Enums;
using Domain.Identity.Entities;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Medico.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Laboratorio.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Recepcao.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.INP.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SAC.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SCT.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SDS.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SIN.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.SINT.ToString()));
        }
    }
}
