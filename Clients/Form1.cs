using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clients
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = ClientsGet.Get();
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ClientsUpdate.Add(textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = ClientsGet.Get();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Edit_Click(object sender, EventArgs e)
        {

            ClientsUpdate.Update((int)dataGridView1.SelectedRows[0].Cells[0].Value,textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = ClientsGet.Get();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            ClientsUpdate.Delete((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            dataGridView1.DataSource = ClientsGet.Get();
        }
    }

    public static class ClientsGet
    {
        public static object Get()
        {
            using (var context = new MyBaseEntities())
            {
                var data = context.ClientsSet.Select(x => new { Id = x.Id, Name = x.Name, Email = x.Email });
                return data.ToList();
            }
        }

    }
    public static class ClientsUpdate
    {
        private static readonly log4net.ILog log =
log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Add(string Name, string Email)
        {
            var c = new Clients { Name = Name, Email = Email };
            using (var context = new MyBaseEntities())
            {
                context.ClientsSet.Add(c);
                context.SaveChanges();
            }
            string message = "Add Client. Name: "+ Name+ "; Email: " + Email;
            log.Info(message);
        }
        public static void Update(int id, string Name, string Email)
        {
            string oldName, oldEmail;
            using (var context = new MyBaseEntities())
            {
                var c = context.ClientsSet.SingleOrDefault(x => x.Id == id);
                oldName = c.Name;
                oldEmail = c.Email;
                c.Name = Name;
                c.Email = Email;
                context.SaveChanges();
            }
            string message = "Update Client. Name " + oldName + " -> " + Name + "; Email: " + oldEmail + " -> " + Email;
            log.Info(message);
        }
        public static void Delete(int id)
        {
            string Name, Email;
            using (var context = new MyBaseEntities())
            {
                var c = context.ClientsSet.SingleOrDefault(x => x.Id == id);
                Name = c.Name;
                Email = c.Email;
                context.ClientsSet.Remove(c);
                context.SaveChanges();
            }
            string message = "Delete Client. Name: " + Name + "; Email: " + Email;
            log.Info(message);
        }
    }
}
