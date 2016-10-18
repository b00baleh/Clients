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
    //todo переделай доступ к данным через Code First, сейчас за тебя дизайнер код сгенерил
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = ClientRepository.GetClient();
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ClientRepository.AddClient(textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = ClientRepository.GetClient();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Edit_Click(object sender, EventArgs e)
        {

            ClientRepository.UpdateClient((int)dataGridView1.SelectedRows[0].Cells[0].Value,textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = ClientRepository.GetClient();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            ClientRepository.DeleteClient((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            dataGridView1.DataSource = ClientRepository.GetClient();
        }
    }
  
}
