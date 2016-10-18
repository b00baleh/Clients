using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using static Clients.DataBase.DbSets;

namespace Clients
{
    class ClientRepository
    {

        private static readonly ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void AddClient(string name, string email)
        {
            var c = new DataBase.Client {Name = name, Email = email};
            using (var context = new MyBase())
            {
                context.Client.Add(c);
                context.SaveChanges();
            }
            string message = "Add Client. name: " + name + "; email: " + email;
            Log.Info(message);
        }

        public static void UpdateClient(int id, string name, string email)
        {
            string oldName, oldEmail;
            using (var context = new MyBase())
            {
                var c = context.Client.SingleOrDefault(x => x.Id == id);
                oldName = c.Name;
                oldEmail = c.Email;
                c.Name = name;
                c.Email = email;
                context.SaveChanges();
            }
            string message = "Update Client. name " + oldName + " -> " + name + "; email: " + oldEmail + " -> " + email;
            Log.Info(message);
        }

        public static void DeleteClient(int id)
        {
            string name, email;
            using (var context = new MyBase())
            {
                var c = context.Client.SingleOrDefault(x => x.Id == id);
                name = c.Name;
                email = c.Email;
                context.Client.Remove(c);
                context.SaveChanges();
            }
            string message = "Delete Client. name: " + name + "; email: " + email;
            Log.Info(message);
        }

        public static object GetClient()
        {
            using (var context = new MyBase())
            {
                var data = context.Client.Select(x => new { Id = x.Id, Name = x.Name, Email = x.Email });
                return data.ToList();
            }
        }
    }
}