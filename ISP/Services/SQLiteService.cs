using SQLite;
using ISP.Entities;

namespace ISP.Services
{

    public class SQLiteService : IDbService
    {
        SQLiteConnection database;
        private string databasePath = "ProcedureGroups.db";

        public SQLiteService()
        {
            bool databaseExists = File.Exists(databasePath);

            database = new SQLiteConnection(
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            databasePath),
        storeDateTimeAsTicks: true);

            if (!databaseExists)
            {
                database.CreateTable<ProcedureGroups>();
                database.CreateTable<Procedures>();
                Init();
            }
        }

        public void Init()
        {
            var procedureGroups = new List<ProcedureGroups>
            {
                new ProcedureGroups { Name = "Лечебные массажи" },
                new ProcedureGroups { Name = "SPA-уходы" },
                new ProcedureGroups { Name = "Парения" },
                new ProcedureGroups { Name = "Фирменные программы" },
            };

            foreach (var procedureGroup in procedureGroups)
            {
                database.Insert(procedureGroup);
            }

            var procedures = new List<Procedures>
            {
                new Procedures { Name = "Массаж шеи", ProcedureGroupId = 1 },
                new Procedures { Name = "Массаж спины", ProcedureGroupId = 1 },
                new Procedures { Name = "Массаж ног", ProcedureGroupId = 1 },

                new Procedures { Name = "Уходы за телом", ProcedureGroupId = 2 },
                new Procedures { Name = "SPA-уходы за лицом", ProcedureGroupId = 2 },
                new Procedures { Name = "Иглоукалывание", ProcedureGroupId = 2 },

                new Procedures { Name = "Экспресс-парения", ProcedureGroupId = 3 },
                new Procedures { Name = "Авторские программы", ProcedureGroupId = 3 },
                new Procedures { Name = "Пивная баня", ProcedureGroupId = 3 },

                new Procedures { Name = "Программа для двоих", ProcedureGroupId = 4 },
                new Procedures { Name = "Комплексный уход за телом", ProcedureGroupId = 4 },
                new Procedures { Name = "Круизы", ProcedureGroupId = 4 },
            };

            foreach (var procedure in procedures)
            {
                database.Insert(procedure);
            }
        }

        public IEnumerable<ProcedureGroups> GetAllProcedureGroups()
        {
            return database.Table<ProcedureGroups>().ToList();
        }

        public IEnumerable<Procedures> GetAllProcedures(int id)
        {
            return database.Table<Procedures>().Where(procedures => procedures.ProcedureGroupId == id).ToList();
        }

    }
}