using Neo4J_Repository.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neo4J_Repository
{
    public partial class Form8 : Form
    {
        static string Prevoz;
        GraphClient clients;
        public Form8()
        {
            InitializeComponent();
        }
        public static Form8 genform8(GraphClient client, string a)
        {
            Prevoz = a;
            Form8 f8 = new Form8();
            f8.clients = client;
            f8.Show();
            return f8;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ime = textBox1.Text;
            string Br = textBox2.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("Prevoz", Prevoz);
            queryDict.Add("Ime", Ime);
            queryDict.Add("Br", Br);
            if (String.IsNullOrEmpty(Ime) || String.IsNullOrEmpty(Br))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                try
                {
                    var query = new CypherQuery("match(n: Prevoznik) Where n.Ime = {Prevoz}  set n.Ime = {Ime}, n.Vozila = {Br} return n",
                                                            queryDict, CypherResultMode.Set);

                List<Prevoznik> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Prevoznik>(query).ToList();

               
                    MessageBox.Show("Novo ime prevoznika: " + Prevoz + " je sada " + Ime + " i broj vozila je " + Br);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Greska!");
                }
            }
        }
    }
}
