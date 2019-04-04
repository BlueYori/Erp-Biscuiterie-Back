using Erp_Biscuiterie_Back.Business.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erp_Biscuiterie_Back.Business.Helpers
{
    public class ExternalSqlActions
    {
        //Singleton to instantiate the class only one time
        public DbContextOptionsBuilder optionsBuilder;
        public static DatabaseContext _context;

        private static ExternalSqlActions _instance = null;
        private static object chekLock = new object();
        private ExternalSqlActions()
        { }

        public static ExternalSqlActions Instance
        {
            get
            {
                lock (chekLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ExternalSqlActions();
                        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                        optionsBuilder.UseMySql(Startup.ConnectionString);
                        _context = new DatabaseContext(optionsBuilder.Options);
                    }
                    return _instance;
                }
            }
        }

        public string GetRole(int id)
        {
            var role = _context.Role.SingleOrDefault(x => x.Id == id);
            return role.Name;
        }

    }
}

