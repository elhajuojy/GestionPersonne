using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ado.Net2tdi1ADO
{
    public partial class GestionPersonne : Form
    {
        public GestionPersonne()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection ctn = new SqlConnection(@"Data Source=elhajuojy-lapto\mehdi;Initial Catalog=GestionPersonneControleWith9raytiFclick;Integrated Security=True");
        BindingSource bs = new BindingSource();
        DataTable table = new DataTable();
        private void GestionPersonne_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Personne", ctn);
           
            


            ctn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            table.Load(dr);
           
            bs.DataSource = table;
            dataGridView1.DataSource = bs;

            ctn.Close();
           
        }

        private void btnPerimer_Click(object sender, EventArgs e)
        {
            //bs.MoveFirst();
            afficher(0);
        }

        private void btnPrecedant_Click(object sender, EventArgs e)
        {
            //bs.MovePrevious();
            int index = RechercheIndex();
            if (index >0)
            {
                afficher(index - 1);
            }
            else
            {
                MessageBox.Show("Permier est c'est personne");
            }

            
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            //bs.MoveNext();
            int index = RechercheIndex();
            if (index >= table.Rows.Count - 1)
            {
                MessageBox.Show("la darnier personne");
            }
            else
            {
                afficher(index + 1);
            }



        }

        private void btnDernier_Click(object sender, EventArgs e)
        {
            //bs.MoveLast();
            afficher(table.Rows.Count-1);

        }
        
        public int RechercheIndex()
        {
            int pos = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][0].ToString() == textCin.Text)
                {
                    pos = i;
                };

                

            };
            return pos;

        }
        public void afficher(int pos)
        {
            if(pos== -1)
            {
                MessageBox.Show("la personne n'existe pas !");
            }
            else
            {
                textCin.Text = table.Rows[pos][0].ToString();
                TextNom.Text = table.Rows[pos][1].ToString();
                TextPrenom.Text = table.Rows[pos][2].ToString();
                TextAge.Text = table.Rows[pos][4].ToString();
                TextTelephone.Text = table.Rows[pos][5].ToString();
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {

        }
    }
}
