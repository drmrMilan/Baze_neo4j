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
    public partial class Form3 : Form
    {
        GraphClient clients;
        public Form3()
        {
            InitializeComponent();
        }
        public static Form3 genform3(GraphClient client)
        {
            Form3 f3 = new Form3();
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
                var query = new CypherQuery("CREATE (n:Prodavnica {Ime: {im}, Adresa: {ad}, Roba: {rb}}) return n",
                                                            queryDict, CypherResultMode.Set);

                List<Fabrika> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Fabrika>(query).ToList();

                foreach (Fabrika a in actors)
                {
                    MessageBox.Show("Dodata je prodavnica " + a.Ime + " u bazu podataka");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
