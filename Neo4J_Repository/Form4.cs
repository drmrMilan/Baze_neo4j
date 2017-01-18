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
    public partial class Form4 : Form
    {
        GraphClient clients;
        public Form4()
        {
            InitializeComponent();
        }
        public static Form4 genform4(GraphClient client)
        {
            Form4 f4 = new Form4();
            f4.clients = client;
            f4.Show();
            return f4;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string im = textBox1.Text;
            int br;
            try
            {
                br = int.Parse(textBox2.Text);
            }
            catch
            {
                br = -2;
            }
            string fab = textBox3.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("im", im);
            queryDict.Add("br", br);
            queryDict.Add("fab", fab);
            if (String.IsNullOrEmpty(im) || br==-2 || String.IsNullOrEmpty(fab))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                var query = new CypherQuery("match(n: Fabrika)Where n.Ime = {fab}  MERGE(P: Prevoznik { Ime: {im}, Vozila: {br}})-[:PREVOZI_ZA]->(n) return P",
                                                            queryDict, CypherResultMode.Set);

                List<Prevoznik> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Prevoznik>(query).ToList();

                try
                {
                    MessageBox.Show("Dodat je prevoznik " + actors[0].Ime + " u bazu podataka");
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
