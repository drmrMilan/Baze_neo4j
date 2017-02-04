using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Neo4J_Repository.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace Neo4J_Repository
{
    public partial class NovaFabrika : Form
    {
        GraphClient clients;
        public NovaFabrika()
        {
            InitializeComponent();
        }
        public static NovaFabrika genform2(GraphClient client)
        {
            NovaFabrika f2 = new NovaFabrika();
            f2.clients = client;
            f2.Show();
            return f2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string im = textBox1.Text;
            string ad = textBox2.Text;
            int rad;
            try
            {
                rad = int.Parse(textBox3.Text);
            }
            catch
            {
                rad = -2;
            }
            string pr = textBox4.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("im", im);
            queryDict.Add("ad", ad);
            queryDict.Add("rad", rad);
            queryDict.Add("pr", pr);
            if (String.IsNullOrEmpty(im) || String.IsNullOrEmpty(ad) || rad == -2 || String.IsNullOrEmpty(pr))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                try
                {
                    var query = new CypherQuery("CREATE (n:Fabrika {Ime: {im}, Adresa: {ad}, BrRadnika: {rad}, Proizvodnja: {pr}}) return n",
                                                                     queryDict, CypherResultMode.Set);
                    List<Fabrika> fabrika = ((IRawGraphClient)clients).ExecuteGetCypherResults<Fabrika>(query).ToList();
                    MessageBox.Show("Dodata je fabrika " + fabrika[0].Ime + " u bazu podataka");
                    Form1.redis.Del("lista3");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Greška!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
