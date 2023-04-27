using Members.Domain.Interfaces;

namespace Members.Infraestrucutre.Data
{
    public class DBSettings : IDBSettings
    {
        public string ConnectionString { get; set; }

        public string DataBase { get; set; }
    }
}
