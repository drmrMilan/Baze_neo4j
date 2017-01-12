using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Neo4J_Repository.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace Neo4J_Repository
{
    public partial class Form1 : Form
    {
        private GraphClient client;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "micamica");
            try
            {
                client.Connect();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Prevoznik) return n",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
            List<Prevoznik> prevoznik = ((IRawGraphClient)client).ExecuteGetCypherResults<Prevoznik>(query).ToList();

            foreach (Prevoznik u in prevoznik)
            {
                MessageBox.Show(u.Ime);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
                        string Idvoz =  actorNameTextBox.Text ;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("voz", Idvoz);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Isporuka) and exists(n.IdVozila) and n.IdVozila =~ {voz} return n",
                                                            queryDict, CypherResultMode.Set);
            List<Isporuka> isporuke = ((IRawGraphClient)client).ExecuteGetCypherResults<Isporuka>(query).ToList();
            foreach (Isporuka i in isporuke)
            {
                //DateTime bday = a.getBirthday();
                MessageBox.Show("ID VOZILA: " + i.IdVozila + "\n"+ "ID ISPORUKE: " + i.IdIsporuke);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string fabrikaIme = movieNameTextBox.Text;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("fab", fabrikaIme);

            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Prevoznik)<-[r:UTOVAR]-(a:Fabrika) where a.Ime =~ {fab} return distinct n",
                                                            queryDict, CypherResultMode.Set);

            List<Prevoznik> prevoznik = ((IRawGraphClient)client).ExecuteGetCypherResults<Prevoznik>(query).ToList();

            foreach (Prevoznik a in prevoznik)
            {
                MessageBox.Show(a.Ime);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Isporuka) return n",
                                                             new Dictionary<string, object>(), CypherResultMode.Set);
            List<Isporuka> isporuka = ((IRawGraphClient)client).ExecuteGetCypherResults<Isporuka>(query).ToList();

            foreach (Isporuka u in isporuka)
            {
                MessageBox.Show(u.IdIsporuke);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Prodavnica) return n",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
            List<Prodavnica> prodavnica = ((IRawGraphClient)client).ExecuteGetCypherResults<Prodavnica>(query).ToList();

            foreach (Prodavnica u in prodavnica)
            {
                MessageBox.Show(u.Ime);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Fabrika) return n",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
            List<Fabrika> fabrika = ((IRawGraphClient)client).ExecuteGetCypherResults<Fabrika>(query).ToList();

            foreach (Fabrika u in fabrika)
            {
                MessageBox.Show(u.Ime);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            string fabrikaIme = movieNameTextBox.Text;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("fab", fabrikaIme);

            var query = new Neo4jClient.Cypher.CypherQuery("match (b: Prevoznik) -[:PREVOZI_ZA]->(a:Fabrika) where a.Ime =~ {fab} return distinct b",
                                                            queryDict, CypherResultMode.Set);

            List<Prevoznik> prevoznik = ((IRawGraphClient)client).ExecuteGetCypherResults<Prevoznik>(query).ToList();

            foreach (Prevoznik a in prevoznik)
            {
                //DateTime bday = a.getBirthday();
                MessageBox.Show(a.Ime);
            }
        }

        //        private void button4_Click(object sender, EventArgs e)
        //        {
        //            string directorName = ".*" + directorTextBox.Text + ".*";

        //            Dictionary<string, object> queryDict = new Dictionary<string, object>();
        //            queryDict.Add("directorName", directorName);



        //            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m) where exists(n.name) and n.name =~ {directorName} return m",
        //                                                            queryDict, CypherResultMode.Set);

        //            List<Movie> movies = ((IRawGraphClient)client).ExecuteGetCypherResults<Movie>(query).ToList();

        //            foreach (Movie m in movies)
        //            {
        //                MessageBox.Show(m.title);
        //            }
        //        }

        //        private void button5_Click(object sender, EventArgs e)
        //        {
        //            string directorName = ".*" + directorActorsTextBox.Text + ".*";

        //            Dictionary<string, object> queryDict = new Dictionary<string, object>();
        //            queryDict.Add("directorName", directorName);



        //            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m)<-[r1:ACTS_IN]-(a) where exists(n.name) and n.name =~ {directorName} return a",
        //                                                            queryDict, CypherResultMode.Set);

        //            List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

        //            foreach (Actor a in actors)
        //            {
        //                MessageBox.Show(a.name);
        //            }
        //        }

        //        private void button6_Click(object sender, EventArgs e)
        //        {
        //            AddActor addActorForm = new AddActor();
        //            addActorForm.client = client;
        //            addActorForm.ShowDialog();
        //        }

        //        private void button7_Click(object sender, EventArgs e)
        //        {

        //            string actorName = ".*student.*";

        //            Dictionary<string, object> queryDict = new Dictionary<string, object>();
        //            queryDict.Add("actorName", actorName);

        //            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Actor) and exists(n.name) and n.name =~ {actorName} delete n",
        //                                                            queryDict, CypherResultMode.Projection);

        //            List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

        //            foreach (Actor a in actors)
        //            {
        //                MessageBox.Show(a.name);
        //            }
        //        }

        //        private void button8_Click(object sender, EventArgs e)
        //        {
        //            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Actor) and has(n.name) and n.name =~ \".*student.*\" set n.biography = 'mnogo dobar student' return n",
        //                                                            new Dictionary<string, object>(), CypherResultMode.Set);

        //            List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

        //            foreach (Actor a in actors)
        //            {
        //                MessageBox.Show(a.biography);
        //            }
        //        }
    }
}

