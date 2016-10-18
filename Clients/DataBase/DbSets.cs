using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
        public class MyBase : DbContext
        {
            public MyBase() : base("MyBase")
            {
                
            }
            public DbSet<Client> Client { get; set; }
            public object Clients { get; set; }
        }
    
}
