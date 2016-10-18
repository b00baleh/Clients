using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.DataBase
{
    class DbSets
    {
        public class MyBase : DbContext
        {
            public DbSet<Client> Client { get; set; }
            public object Clients { get; set; }
        }
    }
}
