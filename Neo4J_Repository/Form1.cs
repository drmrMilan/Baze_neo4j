using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Neo4J_Repository.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;
using RedisDataLayer;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace Neo4J_Repository
{
    public partial class Form1 : Form
    {
        private GraphClient client;
        public static readonly RedisClient redis = new RedisClient(Config.SingleHost);
        public Form1()
        {
            InitializeComponent();
            Sync();
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
        public void Sync()
        {
            redis.Del("lista1");
            redis.Del("lista2");
            redis.Del("lista3");
            redis.Del("lista4");
            redis.Del("lista5");
            redis.Del("lista6");
            redis.Del("lista7");
            redis.Del("lista8");
            redis.Del("lista9");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Prevoznik> prevoznik = new List<Prevoznik>();
            if (redis.LLen("lista6") == 0)
            {
                var query = new CypherQuery("match (n:Prevoznik) return n",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                prevoznik = ((IRawGraphClient)client).ExecuteGetCypherResults<Prevoznik>(query).ToList();

                foreach (Prevoznik u in prevoznik)
                {
                    MessageBox.Show(u.Ime);
                }
                foreach (Prevoznik p in prevoznik)
                {
                    redis.PushItemToList("lista6", p.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista6", 0, 100))
                {
                    Prevoznik v = (Prevoznik)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Prevoznik));
                    prevoznik.Add(v);
                }

                foreach (Prevoznik p in prevoznik)
                {
                    MessageBox.Show(p.Ime);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Idvoz = actorNameTextBox.Text;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("voz", Idvoz);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Isporuka) and exists(n.IdVozila) and n.IdVozila =~ {voz} return n",
                                                            queryDict, CypherResultMode.Set);
            List<Isporuka> isporuke = ((IRawGraphClient)client).ExecuteGetCypherResults<Isporuka>(query).ToList();
            foreach (Isporuka i in isporuke)
            {
                MessageBox.Show("ID VOZILA: " + i.IdVozila + "\n" + "ID ISPORUKE: " + i.IdIsporuke);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string fabrikaIme = movieNameTextBox.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("fab", fabrikaIme);
            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Prevoznik)<-[:UTOVAR]-(a:Fabrika) where a.Ime =~ {fab} return distinct n",
                                                            queryDict, CypherResultMode.Set);
            List<Prevoznik> prevoznik = ((IRawGraphClient)client).ExecuteGetCypherResults<Prevoznik>(query).ToList();
            foreach (Prevoznik a in prevoznik)
            {
                MessageBox.Show(a.Ime);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            List<Isporuka> isporuka = new List<Isporuka>();
            if (redis.LLen("lista5") == 0)
            {
                var query = new Neo4jClient.Cypher.CypherQuery("match (n:Isporuka) return n",
                                                             new Dictionary<string, object>(), CypherResultMode.Set);
               isporuka = ((IRawGraphClient)client).ExecuteGetCypherResults<Isporuka>(query).ToList();

                foreach (Isporuka u in isporuka)
                {
                    MessageBox.Show(u.IdIsporuke);
                }
                foreach (Isporuka i in isporuka)
                {
                    redis.PushItemToList("lista5", i.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista5", 0, 100))
                {
                    Isporuka v = (Isporuka)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Isporuka));
                    isporuka.Add(v);
                }

                foreach (Isporuka i in isporuka)
                {
                    MessageBox.Show(i.IdIsporuke);
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {

            List<Prodavnica> prodavnica = new List<Prodavnica>();
            if (redis.LLen("lista4") == 0)

            {
                var query = new Neo4jClient.Cypher.CypherQuery("match (n:Prodavnica) return n",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                prodavnica = ((IRawGraphClient)client).ExecuteGetCypherResults<Prodavnica>(query).ToList();

                foreach (Prodavnica u in prodavnica)
                {
                    MessageBox.Show(u.Ime);
                }
                foreach (Prodavnica u in prodavnica)
                {
                    redis.PushItemToList("lista4", u.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista4", 0, 100))
                {
                    Prodavnica v = (Prodavnica)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Prodavnica));
                    prodavnica.Add(v);
                }

                foreach (Prodavnica p in prodavnica)
                {
                    MessageBox.Show(p.Ime);
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            List<Fabrika> fabrika = new List<Fabrika>();
            if (redis.LLen("lista3") == 0)
            {

                var query = new Neo4jClient.Cypher.CypherQuery("match (n:Fabrika) return n",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                fabrika = ((IRawGraphClient)client).ExecuteGetCypherResults<Fabrika>(query).ToList();

                foreach (Fabrika f in fabrika)
                {
                    MessageBox.Show(f.Ime);
                }
                foreach (Fabrika u in fabrika)
                {
                    redis.PushItemToList("lista3", u.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista3", 0, 100))
                {
                    Fabrika v = (Fabrika)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Fabrika));
                    fabrika.Add(v);
                }

                foreach (Fabrika f in fabrika)
                {
                    MessageBox.Show(f.Ime);
                }
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
                MessageBox.Show(a.Ime);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            string fabrikaIme = directorTextBox.Text;
            string input = textBox1.Text;
            string[] prodavnice = new string[5];
            queryDict.Add("fab", fabrikaIme);
            prodavnice[0] = "";
            prodavnice[1] = "";
            prodavnice[2] = "";
            prodavnice[3] = "";
            var query = new Neo4jClient.Cypher.CypherQuery("", null, CypherResultMode.Set);
            prodavnice[4] = "";
            prodavnice = input.Split(',');
            if (prodavnice.Count() == 0)
            {
                MessageBox.Show("Niste uneli ni jednu prodavnicu!");
            }
            if (prodavnice.Count() == 1)
            {
                queryDict.Add("pr1", prodavnice[0]);
                query = new Neo4jClient.Cypher.CypherQuery("MATCH(fabrika: Fabrika { Ime: {fab}})-[:UTOVAR] - (n:Isporuka)-[:ISTOVAR] " 
                    + "-(p1: Prodavnica { Ime: {pr1}}) WHERE(fabrika) -[:UTOVAR] - (n) AND (n) -[:ISTOVAR] - (p1) RETURN n", queryDict, CypherResultMode.Set);

            }
            if (prodavnice.Count() == 2)
            {
                queryDict.Add("pr1", prodavnice[0]);
                queryDict.Add("pr2", prodavnice[1]);
                query = new Neo4jClient.Cypher.CypherQuery("MATCH(fabrika: Fabrika { Ime: {fab}})-[:UTOVAR] - (n:Isporuka)-[:ISTOVAR] "
                    +"-(p1: Prodavnica { Ime: {pr1}}),(p2:Prodavnica { Ime: {pr2}}) WHERE(fabrika) -[:UTOVAR] - (n)AND(n) -[:ISTOVAR] "
                    +"- (p2)AND(n) -[:ISTOVAR] - (p1) RETURN n", queryDict, CypherResultMode.Set);

            }
            if (prodavnice.Count() == 3)
            {
                queryDict.Add("pr1", prodavnice[0]);
                queryDict.Add("pr2", prodavnice[1]);
                queryDict.Add("pr3", prodavnice[2]);
                query = new Neo4jClient.Cypher.CypherQuery("MATCH(fabrika: Fabrika { Ime: {fab}})-[:UTOVAR] - (n:Isporuka)-[:ISTOVAR] "
                    +"-(p1: Prodavnica { Ime: {pr1}}),(p2:Prodavnica { Ime: {pr2}}),(p3:Prodavnica { Ime: {pr3}}) WHERE(fabrika) -[:UTOVAR] "
                    +"- (n)AND(n) -[:ISTOVAR] - (p2)AND(n) -[:ISTOVAR] - (p1)AND(n) -[:ISTOVAR] - (p3) RETURN n", queryDict, CypherResultMode.Set);

            }
            if (prodavnice.Count() == 4)
            {
                queryDict.Add("pr1", prodavnice[0]);
                queryDict.Add("pr2", prodavnice[1]);
                queryDict.Add("pr3", prodavnice[2]);
                queryDict.Add("pr4", prodavnice[3]);
                query = new Neo4jClient.Cypher.CypherQuery("MATCH(fabrika: Fabrika { Ime: {fab}})-[:UTOVAR] - (n:Isporuka)-[:ISTOVAR] "
                    +"-(p1: Prodavnica { Ime: {pr1}}),(p2:Prodavnica { Ime: {pr2}}),(p3:Prodavnica { Ime: {pr3}}), (p4:Prodavnica { Ime: {pr4}}) "
                    +" WHERE(fabrika) -[:UTOVAR] - (n)AND(n) -[:ISTOVAR] - (p2)AND(n) -[:ISTOVAR] - (p1)AND(n) -[:ISTOVAR] - (p3)AND(n) -[:ISTOVAR] "
                    +"- (p4) RETURN n", queryDict, CypherResultMode.Set);
            }
            if (prodavnice.Count() == 5)
            {
                queryDict.Add("pr1", prodavnice[0]);
                queryDict.Add("pr2", prodavnice[1]);
                queryDict.Add("pr3", prodavnice[2]);
                queryDict.Add("pr4", prodavnice[3]);
                queryDict.Add("pr5", prodavnice[4]);
                query = new Neo4jClient.Cypher.CypherQuery("MATCH(fabrika: Fabrika { Ime: {fab}})-[:UTOVAR] - (n:Isporuka)-[:ISTOVAR] "
                    +"-(p1: Prodavnica { Ime: {pr1}}),(p2:Prodavnica { Ime: {pr2}}),(p3:Prodavnica { Ime: {pr3}}), (p4:Prodavnica { Ime: {pr4}}),"
                    +" (p4:Prodavnica { Ime: {pr4}}) WHERE(fabrika) -[:UTOVAR] - (n)AND(n) -[:ISTOVAR] - (p2)AND(n) -[:ISTOVAR] - (p1)AND(n) "
                    +"-[:ISTOVAR] - (p3)AND(n) -[:ISTOVAR] - (p4)AND(n) -[:ISTOVAR] - (p5) RETURN n", queryDict, CypherResultMode.Set);
            }
            List<Isporuka> prevoznik = ((IRawGraphClient)client).ExecuteGetCypherResults<Isporuka>(query).ToList();
            try
            {
                if (prevoznik.Count() == 0)
                {
                    MessageBox.Show("Ne postoji");   
                }
                else
                {
                    foreach (Isporuka i in prevoznik)
                    {
                        MessageBox.Show(i.IdIsporuke);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ne postoji");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            NovaFabrika.genform2(client);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            NovaProdavnica.genform3(client);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NoviPrevoznik.genform4(client);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            NovaIsporuka.genform5(client);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            List<Isporuka> prodavnica = new List<Isporuka>();
            List<Utovar> uto = new List<Utovar>();
            if (redis.LLen("lista1") == 0 || redis.LLen("lista2") == 0)
            {
                var query = new CypherQuery("match (n:Isporuka)-[b:UTOVAR] -(a) return n order by b.Tezina Desc",
                                                          new Dictionary<string, object>(), CypherResultMode.Set);
                prodavnica = ((IRawGraphClient)client).ExecuteGetCypherResults<Isporuka>(query).ToList();
                var query1 = new CypherQuery("match (n:Isporuka)-[b:UTOVAR] -(a) return b order by b.Tezina Desc LIMIT 3",
                                                               new Dictionary<string, object>(), CypherResultMode.Set);
                uto = ((IRawGraphClient)client).ExecuteGetCypherResults<Utovar>(query1).ToList();

                for (int i = 0; i < uto.Count(); i++)
                {
                    MessageBox.Show("ID ISPORUKE: " + prodavnica[i].IdIsporuke + "\nID VOZILA: " + prodavnica[i].IdVozila + "\nTEZINA ISPORUKE: " + uto[i].Tezina);
                }
                foreach (Utovar u in uto)
                {
                    redis.PushItemToList("lista1", u.ToJsonString());
                }

                foreach (Isporuka i in prodavnica)
                {
                    redis.PushItemToList("lista2", i.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista2", 0, 100))
                {
                    Isporuka v = (Isporuka)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Isporuka));
                    prodavnica.Add(v);
                }

                foreach (string jsonUtovarString in redis.GetRangeFromList("lista1", 0, 100))
                {
                    Utovar v = (Utovar)JsonSerializer.DeserializeFromString(jsonUtovarString, typeof(Utovar));
                    uto.Add(v);
                }

                for (int i = 0; i < 3; i++)
                {
                    MessageBox.Show("ID ISPORUKE: " + prodavnica[i].IdIsporuke + "\nID VOZILA: " + prodavnica[i].IdVozila + "\nTEZINA ISPORUKE: " + uto[i].Tezina);
                }
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            List<Prodavnica> uto = new List<Prodavnica>();
            if (redis.LLen("lista7") == 0)
            {
                var query1 = new Neo4jClient.Cypher.CypherQuery("match (a:Isporuka)-[z:ISTOVAR]->(h:Prodavnica) return h order by z.Godina DESC, z.Mesec DESC, z.Dan DESCENDING LIMIT 3",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                uto = ((IRawGraphClient)client).ExecuteGetCypherResults<Prodavnica>(query1).ToList();
                foreach (Prodavnica u in uto)
                {
                    MessageBox.Show("IME PRODAVNICE: " + u.Ime + "\nROBA: " + u.Roba);
                }
                foreach (Prodavnica u in uto)
                {
                    redis.PushItemToList("lista7", u.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista7", 0, 100))
                {
                    Prodavnica v = (Prodavnica)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Prodavnica));
                    uto.Add(v);
                }
                for (int i = 0; i < 3; i++)
                {
                    MessageBox.Show("IME PRODAVNICE: " + uto[i].Ime + "\nROBA: " + uto[i].Roba);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string fabrikaIme = textBox2.Text;
            try
            {
                var results = client.Cypher
                    .Match("()-[g: PREVOZI_ZA]-(n: Fabrika)-[r: UTOVAR]-()")
                    .Where((Fabrika n) => n.Ime == fabrikaIme).Delete("r, g, n")
                    .Return((n, r) => new { prod = n.As<Node<Fabrika>>().Data.Ime, veza = r.As<Node<Utovar>>().Data.Godina}).Results ;
                MessageBox.Show("Prodavnica " + fabrikaIme + " je obrisana iz baze podataka");
                textBox2.Clear();
            }
            catch
            {
                MessageBox.Show("Greska!");
                textBox2.Clear();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string prodavnicaIme = textBox3.Text;
            try
            {
                var results = client.Cypher
                    .Match("(n: Prodavnica)<-[r: ISTOVAR]-()")
                    .Where((Prodavnica n) => n.Ime == prodavnicaIme).Delete("r, n")
                    .Return((n, r) =>new { prod = n.As<Node<Prodavnica>>().Data.Ime, veza = r.As<Node<Istovar>>().Data.Godina }).Results;
                MessageBox.Show("Prodavnica " + prodavnicaIme + " je obrisana iz baze podataka");
                textBox3.Clear();
            }
            catch
            {
                MessageBox.Show("Greska!");
                textBox3.Clear();
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string prevoznikIme = textBox4.Text;
            try
            {
                var results = client.Cypher
                    .Match("()-[g:PREVOZI_ZA]-(n: Prevoznik)-[r: OD_STRANE]-()")
                    .Where((Prevoznik n) => n.Ime == prevoznikIme).Delete("r, g, n")
                    .Return((n) => new { prod = n.As<Node<Prevoznik>>().Data.Ime}).Results;
                if (results.Count() == 0) {
                }
                MessageBox.Show("Prevoznik " + prevoznikIme + " je obrisan iz baze podataka");
                textBox4.Clear();
            }
            catch
            {
                MessageBox.Show("Greska!");
                textBox4.Clear();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string isporukaIme = textBox5.Text;
            try
            {
                var results = client.Cypher
                    .Match("()-[g]-(n: Isporuka)-[r]-()")
                    .Where((Isporuka n) => n.IdIsporuke == isporukaIme).Delete("r, g, n")
                    .Return((n) => new { prod = n.As<Node<Isporuka>>().Data.IdIsporuke }).Results;
                MessageBox.Show("Isporuka sa brojem:  " + isporukaIme + " je obrisana iz baze podataka");
                textBox5.Clear();
            }
            catch
            {
                MessageBox.Show("Greska!");
                textBox5.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string a = textBox6.Text;
            if (!String.IsNullOrEmpty(a))
                IzmeniFabriku.genform6(client, a);
            else
                MessageBox.Show("Morate uneti text!");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string a = textBox7.Text;
            if (!String.IsNullOrEmpty(a))
                IzmeniProd.genform7(client, a);
            else
                MessageBox.Show("Morate uneti text!");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string a = textBox8.Text;
            if (!String.IsNullOrEmpty(a))
                IzmeniPrevoznika.genform8(client, a);
            else
                MessageBox.Show("Morate uneti text!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Prevoznik> uto = new List<Prevoznik>();
            if (redis.LLen("lista8") == 0)
            {
                var query1 = new Neo4jClient.Cypher.CypherQuery("match(n: Prevoznik) return n order by n.Vozila DESC LIMIT 3",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                uto = ((IRawGraphClient)client).ExecuteGetCypherResults<Prevoznik>(query1).ToList();
                foreach (Prevoznik u in uto)
                {
                    MessageBox.Show("IME PREVOZNIKA: " + u.Ime + "\nBROJ VOZILA: " + u.Vozila);
                }
                foreach (Prevoznik u in uto)
                {
                    redis.PushItemToList("lista8", u.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista8", 0, 100))
                {
                    Prevoznik v = (Prevoznik)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Prevoznik));
                    uto.Add(v);
                }
                for (int i = 0; i < uto.Count%3; i++)
                {
                    MessageBox.Show("IME PREVOZNIKA: " + uto[i].Ime + "\nBROJ VOZILA: " + uto[i].Vozila);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            List<Fabrika> uto = new List<Fabrika>();
            if (redis.LLen("lista9") == 0)
            {
                var query1 = new Neo4jClient.Cypher.CypherQuery("match(n: Fabrika) return n order by n.BrRadnika DESC LIMIT 3",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                uto = ((IRawGraphClient)client).ExecuteGetCypherResults<Fabrika>(query1).ToList();
                foreach (Fabrika u in uto)
                {
                    MessageBox.Show("IME PREVOZNIKA: " + u.Ime + "\nBROJ RADNIKA: " + u.BrRadnika);
                }
                foreach (Fabrika u in uto)
                {
                    redis.PushItemToList("lista9", u.ToJsonString());
                }
            }
            else
            {
                foreach (string jsonIsporukaString in redis.GetRangeFromList("lista9", 0, 100))
                {
                    Fabrika v = (Fabrika)JsonSerializer.DeserializeFromString(jsonIsporukaString, typeof(Fabrika));
                    uto.Add(v);
                }
                for (int i = 0; i < uto.Count%3; i++)
                {
                    MessageBox.Show("IME PREVOZNIKA: " + uto[i].Ime + "\nBROJ RADNIKA: " + uto[i].BrRadnika);
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {

        }
    }
}

