using Microsoft.EntityFrameworkCore;
using TruckManager.Domain.Entity;
using TruckManager.Infrastructure.Context;

namespace TruckManager.Presentation.Seed
{
    public static class TruckManagerContextSeed
    {
        public static async Task SeedAsync(this TruckManagerContext context, bool runSeed = false)
        {
            if (runSeed)
            {
                await SeedModelo(context);
            }
        }

        private static async Task SeedModelo(TruckManagerContext context)
        {
            if (await context.Modelo.AnyAsync()) return;

            await context.Modelo.AddRangeAsync(
                new List<Modelo>() { 
                    new Modelo() { Nome = "VM", Ativo = false },
                    new Modelo() { Nome = "FH", Ativo = true },
                    new Modelo() { Nome = "FM", Ativo = true },
                    new Modelo() { Nome = "FMX", Ativo = false }
                });

            await context.SaveChangesAsync();
        }
    }
}
