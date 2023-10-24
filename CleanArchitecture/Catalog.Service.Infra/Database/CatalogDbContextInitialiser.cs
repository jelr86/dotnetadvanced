using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Service.Infra.Database
{
    public class CatalogDbContextInitialiser
    {
        private readonly ILogger<CatalogDbContextInitialiser> _logger;
        private readonly CatalogDbContext _context;

        public CatalogDbContextInitialiser(ILogger<CatalogDbContextInitialiser> logger, CatalogDbContext context)
        {
            _logger = logger;
            _context = context;
            
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
    }

}