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
    public partial class Form5 : Form
    {
        GraphClient clients;
        public Form5()
        {
            InitializeComponent();
        }
        public static Form5 genform5(GraphClient client)
        {
            Form5 f5 = new Form5();
            f5.clients = client;
            f5.Show();
            return f5;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string imeIs = textBox1.Text;
            string brVoz = textBox2.Text;
            string fab = textBox3.Text;
            string prz = textBox4.Text;
            string pr = textBox5.Text;
            int god, mes, dan, godis, mesis, danis;
            try
            {
                god = int.Parse(textBox6.Text);
                mes = int.Parse(textBox7.Text);
                dan = int.Parse(textBox8.Text);
                godis = int.Parse(textBox9.Text);
                mesis = int.Parse(textBox10.Text);
                danis = int.Parse(textBox11.Text);
            }
            catch
            {
                god = -2;
                mes = -2;
                dan = -2;
                godis = -2;
                mesis = -2;
                danis = -2;
            }
            string tez = textBox12.Text;
            string rbr = textBox13.Text;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("imeIs", imeIs);
            queryDict.Add("brVoz", brVoz);
            queryDict.Add("fab", fab);
            queryDict.Add("prz", prz);
            queryDict.Add("pr", pr);
            queryDict.Add("god", god);
            queryDict.Add("mes", mes);
            queryDict.Add("dan", dan);
            queryDict.Add("godis", godis);
            queryDict.Add("mesis", mesis);
            queryDict.Add("danis", danis);
            queryDict.Add("rbr", rbr);
            queryDict.Add("tez", tez);
            if (String.IsNullOrEmpty(imeIs) || god == -2 || mes == -2 || dan == -2 || godis == -2 || mesis == -2 
                || danis == -2 || String.IsNullOrEmpty(brVoz) || String.IsNullOrEmpty(prz) || String.IsNullOrEmpty(fab) || String.IsNullOrEmpty(pr)
                || String.IsNullOrEmpty(tez)
                || String.IsNullOrEmpty(rbr))
            {
                MessageBox.Show("Morate uneti tekst u polja!");
            }
            else
            {
                var query = new CypherQuery("match(n: Fabrika), (m: Prevoznik) Where n.Ime = {fab} "+
                    "AND m.Ime = {prz}  MERGE "+
                    "(n)-[:UTOVAR {Godina: {god}, Mesec: {mes}, Dan: {dan}, Tezina: {tez}}]->(i: Isporuka "+
                "{ IdIsporuke: {imeIs}, IdVozila: {brVoz}})-[:OD_STRANE]->(m) return i",
                                                            queryDict, CypherResultMode.Set);

                var query1 = new CypherQuery("match(n: Fabrika), (g:Prodavnica) Where n.Ime = {fab} " +
                    " AND g.Ime = {pr} MERGE (i: Isporuka { IdIsporuke: {imeIs}, IdVozila: {brVoz}})" +
                    "MERGE (i)-[:ISTOVAR { Godina: {godis}, Mesec: {mesis}, Dan: {danis}, RedniBr: {rbr}}]->(g) return i", queryDict, CypherResultMode.Set);

                List <Isporuka> actors = ((IRawGraphClient)clients).ExecuteGetCypherResults<Isporuka>(query).ToList();
                List<Isporuka> actors1 = ((IRawGraphClient)clients).ExecuteGetCypherResults<Isporuka>(query1).ToList();

                try
                {
                    MessageBox.Show("Dodata je isporuka " + actors[0].IdIsporuke + " u bazu podataka");
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
