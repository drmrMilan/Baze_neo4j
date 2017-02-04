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
    public partial class IzmeniPrevoznika : Form
    {
        static string Prevoz;
        GraphClient clients;
        public IzmeniPrevoznika()
        {
            InitializeComponent();
        }
        public static IzmeniPrevoznika genform8(GraphClient client, string a)
        {
            Prevoz = a;
            IzmeniPrevoznika f8 = new IzmeniPrevoznika();
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
            int Br;
            try
            {
                Br = int.Parse(textBox2.Text);
            }
            catch
            {
                Br = -2;
            }
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("Prevoz", Prevoz);
            queryDict.Add("Ime", Ime);
            queryDict.Add("Br", Br);
            if (String.IsNullOrEmpty(Ime) || Br == -2)
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
                    Form1.redis.Del("lista6");
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
