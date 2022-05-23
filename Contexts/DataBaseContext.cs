using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RosreestDocks.Models;
using RosreestDocks.Models.Common;

using System.IO;

namespace RosreestDocks.Contexts
{
    public class DataBaseContext : IdentityDbContext
    {
        //Статьи
        public DbSet<ArticlesModel> Articles { get; set; }
        //Акроными
        public DbSet<AgencyAcronymModel> Acronyms { get; set; }
        //Учреждения
        public DbSet<AgencyModel> Agency { get; set; }
        //Права управления
        public DbSet<ManageRightsModel> ManageRights { get; set; }
        //Тип имущества
        public DbSet<TypeOfPropertyModel> TypeOfPropertyModels { get; set; }
        //Фед. органы исп. власти
        public DbSet<FoivModel> Foiv { get; set; }
        //Тип документов - в сохраненных документах
        public DbSet<DocCategoryModel> DocCategories { get; set; }
        //Сохраненные документы
        public DbSet<DocumentModel> Documents { get; set; }
        //Позиции руководителей
        public DbSet<Position> Positions { get; set; }
        //Руководители
        public DbSet<DirectorModel> Director { get; set; }
        //Статус рассмотрения документы
        public DbSet<DockStatusModel> DocStatus { get; set; }
        //Тип документа для рассмотрения
        public DbSet<DockTypeModel> DocType { get; set; }
        //
        public DbSet<AppealModel> Appeals { get; set; }
        //Обращения
        public DbSet<RequestModel> Request { get; set; }
        //Важность заметки
        public DbSet<ImportanceState> Importance { get; set; }
        //Заметки
        public DbSet<NoteModel> Notes { get; set; }
        // ВЯ-08/2882 или 374
        public DbSet<RequestType> RequestType { get; set; }
        public DbSet<User> AppUser { get; set; }
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
