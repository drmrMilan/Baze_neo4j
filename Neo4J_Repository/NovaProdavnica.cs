using Neo4J_Repository.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Neo4J_Repository
{
    public partial class NovaProdavnica : Form
    {
        GraphClient clients;
        public NovaProdavnica()
        {
            InitializeComponent();
        }
        public static NovaProdavnica genform3(GraphClient client)
        {
            NovaProdavnica f3 = new NovaProdavnica();
            f3.clients = client;
            f3.Show();
            return f3;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string im = textBox1.Text;
            string ad = textBox2.Text;
            string rb = textBox3.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("im", im);
            queryDict.Add("ad", ad);
            queryDict.Add("rb", rb);
            if (String.IsNullOrEmpty(im) || String.IsNullOrEmpty(ad) || String.IsNullOrEmpty(rb))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                try
                {
                    var query = new CypherQuery("CREATE (n:Prodavnica {Ime: {im}, Adresa: {ad}, Roba: {rb}}) return n",
                                                                queryDict, CypherResultMode.Set);
                    List<Prodavnica> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Prodavnica>(query).ToList();
                    MessageBox.Show("Dodata je prodavnica " + actors[0].Ime + " u bazu podataka");
                    Form1.redis.Del("lista4");
                }
                catch
                {
                    MessageBox.Show("Greska!");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
