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
    public partial class Form6 : Form
    {
        GraphClient clients;
        static string Fabr;
        public Form6()
        {
            InitializeComponent();
        }
        public static Form6 genform6(GraphClient client, string a)
        {
            Fabr = a;
            Form6 f6 = new Form6();
            f6.clients = client;
            f6.Show();
            return f6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ime = textBox1.Text;
            string Adr = textBox2.Text;
            string Br = textBox3.Text;
            string Proiz = textBox4.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("Fabr", Fabr);
            queryDict.Add("Ime", Ime);
            queryDict.Add("Adr", Adr);
            queryDict.Add("Br", Br);
            queryDict.Add("Proiz", Proiz);
            if (String.IsNullOrEmpty(Ime) || String.IsNullOrEmpty(Proiz) || String.IsNullOrEmpty(Adr) || String.IsNullOrEmpty(Br))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                try
                {
                    var query = new CypherQuery("match(n: Fabrika) Where n.Ime = {Fabr}  set n.Ime = {Ime}, n.Adresa = {Adr}, n.BrRadnika = {Br}, n.Proizvodnja = {Proiz} return n",
                                                            queryDict, CypherResultMode.Set);

                    List<Prodavnica> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Prodavnica>(query).ToList();


                    MessageBox.Show("Novo ime fabrike: " + Fabr + " je sada " + Ime + " i adresa je " + Adr + " i proizvodnja je" + Proiz + " i broj radnika je: " + Br);
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
