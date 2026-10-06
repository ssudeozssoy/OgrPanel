using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrPanel;

namespace OgrPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            OBSEntities tarsus = new OBSEntities();
            dataGridView1.DataSource = tarsus.Obs.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Obs ogr = new Obs();
            ogr.Ad = txtAd.Text;
            ogr.Soyad = txtSoyad.Text;
            ogr.Numara = txtNumara.Text;
            
            OBSEntities tarsus = new OBSEntities();
            tarsus.Obs.Add(ogr);
            tarsus.SaveChanges();
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                OBSEntities tarsus = new OBSEntities();
                var silinecek = tarsus.Obs.Find(secilenID);
                if (silinecek != null)
                {
                    tarsus.Obs.Remove(silinecek);
                    tarsus.SaveChanges();
                    listele();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                OBSEntities tarsus = new OBSEntities();

                var guncellenecek = tarsus.Obs.Find(secilenID);
                if (guncellenecek != null)
                {
                    guncellenecek.Ad = txtAd.Text;
                    guncellenecek.Soyad = txtSoyad.Text;
                    guncellenecek.Numara = txtNumara.Text;

                    tarsus.SaveChanges();
                    listele();
                }
            }
         }

        private void btnAra_Click(object sender, EventArgs e)
        {
            OBSEntities tarsus = new OBSEntities();

            var aranan = tarsus.Obs.Where(x => x.Ad == txtAd.Text).ToList();
            dataGridView1.DataSource = aranan;
        }
    }
}
