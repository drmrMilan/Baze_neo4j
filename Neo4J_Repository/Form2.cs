using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4J_Repository.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace Neo4J_Repository
{
    public partial class Form2 : Form
    {
        GraphClient clients;
        public Form2()
        {
            InitializeComponent();
        }
        public static Form2 genform2(GraphClient client)
        {
            Form2 f2 = new Form2();
            f2.clients = client;
            f2.Show();
            return f2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string im = this.textBox1.Text;
            string ad = this.textBox2.Text;
            string rad = this.textBox3.Text;
            string pr = this.textBox4.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("im", im);
            queryDict.Add("ad", ad);
            queryDict.Add("rad", rad);
            queryDict.Add("pr", pr);
            if (String.IsNullOrEmpty(im) || String.IsNullOrEmpty(ad) || String.IsNullOrEmpty(rad) || String.IsNullOrEmpty(pr))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                var query = new CypherQuery("CREATE (n:Fabrika {Ime: {im}, Adresa: {ad}, BrRadnika: {rad}, Proizvodnja: {pr}}) return n",
                                                                queryDict, CypherResultMode.Set);

                List<Fabrika> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Fabrika>(query).ToList();

                foreach (Fabrika a in actors)
                {
                    MessageBox.Show("Dodata je fabrika " + a.Ime + " u bazu podataka");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
