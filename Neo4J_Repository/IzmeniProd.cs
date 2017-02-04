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
    public partial class IzmeniProd : Form
    {
        GraphClient clients;
        static string Prod;
        public IzmeniProd()
        {
            InitializeComponent();
        }
        public static IzmeniProd genform7(GraphClient client, string a)
        {
            Prod = a;
            IzmeniProd f7 = new IzmeniProd();
            f7.clients = client;
            f7.Show();
            return f7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ime = textBox1.Text;
            string Adr = textBox2.Text;
            string Roba = textBox3.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("Prod", Prod);
            queryDict.Add("Ime", Ime);
            queryDict.Add("Adr", Adr);
            queryDict.Add("Roba", Roba);
            if (String.IsNullOrEmpty(Ime) || String.IsNullOrEmpty(Roba) || String.IsNullOrEmpty(Adr))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                try
                {
                    var query = new CypherQuery("match(n: Prodavnica) Where n.Ime = {Prod}  set n.Ime = {Ime}, n.Adresa = {Adr}, n.Roba = {Roba} return n",
                                                            queryDict, CypherResultMode.Set);

                    List<Prodavnica> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Prodavnica>(query).ToList();


                    MessageBox.Show("Novo ime prodavnice: " + Prod + " je sada " + Ime + " i adresa je " + Adr + " i roba je" + Roba);
                    Form1.redis.Del("lista4");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Greska!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
