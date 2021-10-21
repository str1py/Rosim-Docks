using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RosreestDocks.Models;
using RosreestDocks.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace RosreestDocks.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DbSet<ArticlesModel> Articles { get; set; }
        public DbSet<AgencyAcronymModel> Acronyms { get; set; }
        public DbSet<AgencyModel> Agency { get; set; }
        public DbSet<ManageRightsModel> ManageRights { get; set; }
        public DbSet<TypeOfPropertyModel> TypeOfPropertyModels { get; set; }
        public DbSet<FoivModel> Foiv { get; set; }
        public DbSet<DocCategoryModel> DocCategories { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<DirectorModel> Director { get; set; }
        public DbSet<DockStatusModel> DocStatus { get; set; }
        public DbSet<DockTypeModel> DocType { get; set; }
        public DbSet<AppealModel> Appeals { get; set; }
        public DbSet<RequestModel> Request { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseMySql(configuration.GetConnectionString("77RosimDbContext"), ServerVersion.AutoDetect(configuration.GetConnectionString("77RosimDbContext")), null);
            
        }
    }
}
