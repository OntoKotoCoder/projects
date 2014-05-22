using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sh_k_means
{
    
    public partial class Form2 : Form

    {
        public Form2 ()
        {
            InitializeComponent();
            current_cluster_grid.ColumnCount = 5;
            current_cluster_grid.Columns[0].Name = "Длина чашелистика";
            current_cluster_grid.Columns[1].Name = "Ширина чашелистика";
            current_cluster_grid.Columns[2].Name = "Длина лепестка";
            current_cluster_grid.Columns[3].Name = "Ширина лепестка";
            current_cluster_grid.Columns[4].Name = "Вид ириса";
            current_cluster_grid.Columns[0].Width = 80; current_cluster_grid.Columns[1].Width = 80; current_cluster_grid.Columns[2].Width = 80;
            current_cluster_grid.Columns[3].Width = 80; current_cluster_grid.Columns[4].Width = 80;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            current_cluster_grid.Rows.Clear();
            Form1 main = this.Owner as Form1;
            int cluster = 0;
            int elemets_count = 0;
            int next_row = 0;
            if (main != null)
            {
                cluster = Convert.ToInt32(main.show_cluster_text.Text);
                this.Text = "Кластер № - " + cluster;
                elemets_count = main.elements_count[cluster-1];
                for (int i = 1; i <= 150; i++)
                {
                    if (Convert.ToInt32(main.data[i, 5]) == cluster)
                    {
                        current_cluster_grid.Rows.Add();
                        for (int j = 0; j < (main.data.GetLength(1) - 1); j++)
                            current_cluster_grid.Rows[next_row].Cells[j].Value = main.data[i, j];
                        next_row++;
                    }
                }
            }
        }

    }
}
