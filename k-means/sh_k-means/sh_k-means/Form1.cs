using System;
using System.IO;
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
    public partial class Form1 : Form
    {
        public string[,] data = new string[151, 6];                          //150 экземпляров + 1 строка с названиями колонок 
        public double[,] centroids;
        public double[] metrics = new double[151];

        public int[] elements_count;
        public int cluster_count = 0;

        public Boolean data_load = false;
        public Boolean clustered = false;
        public Boolean[] change_cluster = new Boolean[151];
        
        Form2 f2 = new Form2();
        
        public Form1()
        {
            InitializeComponent();
            data_grid.ColumnCount = 5;
            data_grid.Columns[0].Name = "Длина чашелистика";
            data_grid.Columns[1].Name = "Ширина чашелистика";
            data_grid.Columns[2].Name = "Длина лепестка";
            data_grid.Columns[3].Name = "Ширина лепестка";
            data_grid.Columns[4].Name = "Вид ириса";
            data_grid.Columns[0].Width = 80; data_grid.Columns[1].Width = 80; data_grid.Columns[2].Width = 80;
            data_grid.Columns[3].Width = 80; data_grid.Columns[4].Width = 80;
            clustered_grid.ColumnCount = 6;
            clustered_grid.Columns[0].Name = "Длина чашелистика";
            clustered_grid.Columns[1].Name = "Ширина чашелистика";
            clustered_grid.Columns[2].Name = "Длина лепестка";
            clustered_grid.Columns[3].Name = "Ширина лепестка";
            clustered_grid.Columns[4].Name = "Вид ириса";
            clustered_grid.Columns[5].Name = "Номер кластера";
            clustered_grid.Columns[0].Width = 80; clustered_grid.Columns[1].Width = 80; clustered_grid.Columns[2].Width = 80;
            clustered_grid.Columns[3].Width = 80; clustered_grid.Columns[4].Width = 80; clustered_grid.Columns[5].Width = 80;
        }

        private void data_button_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog data_file = new OpenFileDialog();
            if (data_file.ShowDialog() == DialogResult.OK)
            {
                filePath = data_file.FileName;
                string[] allLines = File.ReadAllLines(filePath);
                data_grid.Rows.Clear();
                data_load = true;
                string[] parsedline;
                for (int i = 1; i <= 150; i++)
                {
                    parsedline = ParseCsvRow(allLines[i]);
                    data_grid.Rows.Add(parsedline);
                    for (int j = 0; j < 5; j++)
                    {
                        data[i, j] = parsedline[j];
                    }
                }
            }
        }

        private void clustering_button_Click(object sender, EventArgs e)
        {
            clustered_grid.Rows.Clear();
            cluster_statistic_box.Clear();

            int[] seeds;
            int cluster_id = 0;
            int iteration_count = 0;

            Boolean cluster_changed = true;
            Boolean get_new_random = false;
            Boolean metric_chosen = false;
            Boolean correct_parametrs = false;
            Boolean normal_cluster_count = false;

            /*if (cluster_num.Text != "")
                cluster_count = Convert.ToInt32(cluster_num.Text);
            int parametrs_count = 0;
            if (l_petal_check.Checked == true)
                parametrs_count++;
            if (l_sepal_check.Checked == true)
                parametrs_count++;
            if (w_petal_check.Checked == true)
                parametrs_count++;
            if (w_sepal_check.Checked == true)
                parametrs_count++;
            if (l_petal_check.Checked == false && l_sepal_check.Checked == false
                && w_petal_check.Checked == false && w_sepal_check.Checked == false || parametrs_count == 1)
                correct_parametrs = false;
            else
                correct_parametrs = true;
            if (Manhattan_check.Checked == true || Euclidean_check.Checked == true)
                metric_chosen = true;
            if (cluster_count >= 2 && cluster_count <= 150)
                normal_cluster_count = true;
            if (correct_parametrs == false)
                MessageBox.Show("Вы должны выбрать минимум два праметра для кластеризации!");
            if (data_load == false)
                MessageBox.Show("Данные не загружены! Нажмите кнопку \"Исходные данные\"");
            if (metric_chosen == false)
                MessageBox.Show("Метрика не выбрана! Задайте одну из двух метрик");
            if (normal_cluster_count == false)
                MessageBox.Show("Число кластеров должно быть больше 2-ух, но меньше 150!");
            
            if (normal_cluster_count && metric_chosen && correct_parametrs && data_load)*/
            if (check_entered_data())
            {
                seeds = new int[cluster_count];

                Random new_seed = new Random();
                centroids = new double[cluster_count, 4];
                int current_cluster;
                for (int i = 0; i < cluster_count; i++)     //генерируем n случайных значний, n - число кластеров
                {
                    do {                                    //цикл do будет генерировать не повторяющиеся начальные центроиды
                        seeds[i] = new_seed.Next(1, 151);
                        if (i > 0)
                        {
                            get_new_random = false;
                            for (int k = 0; k < i; k++)
                            {
                                if (seeds[i] == seeds[k])
                                {
                                    get_new_random = true;
                                    break;
                                }
                            }
                        }
                    } while (get_new_random == true);
                    cluster_id++;
                    data[seeds[i], 5] = Convert.ToString(cluster_id);
                    for (int j = 0; j < 4; j++)
                    {
                            centroids[i, j] = Convert.ToDouble(data[seeds[i], j]);
                    }
                }
                for (int i = 1; i <= 150; i++)
                {
                    change_cluster[i] = true;
                }
                do
                {
                    iteration_count++;
                    double best_metric = 99999;
                    double current_metric = 0;
                    for (int i = 1; i <= 150; i++)
                    {
                        best_metric = 99999;
                        current_metric = 0;
                        current_cluster = Convert.ToInt32(data[i, 5]);
                        for (int j = 0; j < cluster_count; j++)
                        {
                            if (Manhattan_check.Checked == true)
                            {
                                current_metric = manhattan_metric(j, i);
                            }
                            else if (Euclidean_check.Checked == true)
                            {
                                current_metric = euclidean_metric(j, i);
                            }
                            if (current_metric < best_metric)
                            {
                                best_metric = current_metric;
                                data[i, 5] = Convert.ToString(j + 1);
                            }
                        }
                        metrics[i] = best_metric;
                        if (current_cluster == Convert.ToInt32(data[i, 5]))
                        {
                            change_cluster[i] = false;
                        }
                        else
                        {
                            change_cluster[i] = true;
                        }
                    }
                    for (int i = 1; i <= 150; i++)
                    {
                        if (change_cluster[i] == true)
                        {
                            cluster_changed = true;
                            break;
                        }
                        else 
                        {
                            cluster_changed = false;
                        }
                    }                   
                    new_centroid();
                } while (cluster_changed == true);
                for (int i = 1; i <= 150; i++)
                {
                    clustered_grid.Rows.Add();
                    for (int j = 0; j <= 5; j++)
                    {
                        clustered_grid.Rows[i - 1].Cells[j].Value = data[i, j];
                    }
                
                }
                clustered_grid.Sort(clustered_grid.Columns[5], ListSortDirection.Ascending);
                elements_count = new int[cluster_count];
                for (int i = 0; i  < cluster_count; i++) {
                    elements_count[i] = elements_count_in_cluster(i + 1);
                }
                clustered = true;
            }
            if (clustered == true)
            {
                iteration_count_lable.Text = "  Кол-во итераций - " + Convert.ToString(iteration_count);
                exemplar_count_lable.Text = "Кол-во экземпляров - " + Convert.ToString(data.GetLength(0) - 1);
                for (int i = 1; i <= cluster_count; i++)
                {
                    cluster_statistic_box.Text += "Кол-во экземпляров в кластере " + i + ":\t              "
                        + elements_count_in_cluster(i) + Environment.NewLine + "---------------------------------------------------" + Environment.NewLine;
                }
            }
        }
       //----Расчёт метрик-------------------------------------------------------------------------
       //Манхэттенское расстояние:
        public double manhattan_metric(int seed, int exemplar)
        {
            double metric = 0;
            for (int i = 0; i < 4; i++)
            {
                /*
                 *0 - Длина чашелистика
                 *1 - Ширина чашелистика
                 *2 - Длина лепестка
                 *3 - Ширина лепестка
                 */
                if (i == 0 && l_sepal_check.Checked == true || i == 1 && w_sepal_check.Checked == true
                    || i == 2 && l_petal_check.Checked == true || i == 3 && w_petal_check.Checked == true)
                    metric += Math.Abs(Convert.ToDouble(data[exemplar, i]) - Convert.ToDouble(centroids[seed, i]));
            }
            return metric;
        }
        //Евклидово расстояние:
        public double euclidean_metric(int seed, int exemplar)
        {
            double metric = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0 && l_sepal_check.Checked == true || i == 1 && w_sepal_check.Checked == true
                    || i == 2 && l_petal_check.Checked == true || i == 3 && w_petal_check.Checked == true)
                    metric += Math.Pow(Convert.ToDouble(data[exemplar, i]) - Convert.ToDouble(centroids[seed, i]), 2);
            }
            return Math.Sqrt(metric);
        }
        //Вычисление нового центроида-----------------------------------------------------------
        public void new_centroid()
        {
            int exemplaers_num = 0;
            for (int i = 0; i < centroids.GetLength(0); i++)
            {
                for (int k = 0; k < centroids.GetLength(1); k++)
                {
                    centroids[i, k] = 0;
                    exemplaers_num = 0;
                    for (int j = 1; j <= 150; j++)            //ТУТ БЫЛО 150!
                    {
                        if (Convert.ToDouble(data[j, 5]) == i + 1)
                        {
                            centroids[i, k] += Convert.ToDouble(data[j, k]);
                            exemplaers_num++;
                        }
                    }
                    centroids[i, k] = centroids[i, k] / (exemplaers_num);
                }
            }
        }
        //Вычисление суммы квадрата ошибок:
        public double sum_of_squared_errors()
        {
            double error = 0;
            if (Euclidean_check.Checked == true)
            {
                for (int i = 1; i <= 150; i++)
                {
                    error += Math.Pow(metrics[i], 2);
                }
            }
            else if (Manhattan_check.Checked == true)
            {
                for (int i = 1; i <= 150; i++) {
                    for (int j = 0; j < 4; j++)  {
                        error += Math.Pow( Convert.ToDouble(centroids[Convert.ToInt32(data[i,5]) - 1, j]) - Convert.ToDouble(data[i, j]), 2);
                    }
            }
            }
            return error;
        }
        //Вычисление количества элементов в кластере:
        public int elements_count_in_cluster(int cluster)
        {
            int count = 0;
            for (int i = 1; i <= 150; i++)
            {
                if (Convert.ToInt32(data[i, 5]) == cluster)
                {
                    count++;
                }
            }
            return count;
        }
        //----Вспомогательные функции---------------------------------------------------------------
        //Парсер .csv файлов:
        public string[] ParseCsvRow(string r)
        {
            string[] c;
            //string t;
            List<string> resp = new List<string>();
            bool cont = false;
            string cs = "";
            c = r.Split(new char[] { ';' }, StringSplitOptions.None);
            foreach (string y in c)
            {
                string x = y;
                if (cont)
                {
                    // End of field
                    if (x.EndsWith("\""))
                    {
                        cs += "," + x.Substring(0, x.Length - 1);
                        resp.Add(cs);
                        cs = "";
                        cont = false;
                        continue;
                    }
                    else
                    {
                        // Field still not ended
                        cs += "," + x;
                        continue;
                    }
                }
                // Fully encapsulated with no comma within
                if (x.StartsWith("\"") && x.EndsWith("\""))
                {
                    if ((x.EndsWith("\"\"") && !x.EndsWith("\"\"\"")) && x != "\"\"")
                    {
                        cont = true;
                        cs = x;
                        continue;
                    }
                    resp.Add(x.Substring(1, x.Length - 2));
                    continue;
                }
                // Start of encapsulation but comma has split it into at least next field
                if (x.StartsWith("\"") && !x.EndsWith("\""))
                {
                    cont = true;
                    cs += x.Substring(1);
                    continue;
                }
                // Non encapsulated complete field
                resp.Add(x);
            }
            return resp.ToArray();
        }
        //Проверка на корректность выбора checkBox'ов и ввод данных в textBoxы:
        public Boolean check_entered_data()
        {
            Boolean correct = false;
            Boolean metric_chosen = false;
            Boolean correct_parametrs = false;
            Boolean normal_cluster_count = false;
            if (cluster_num.Text != "")
                cluster_count = Convert.ToInt32(cluster_num.Text);
            int parametrs_count = 0;
            if (l_petal_check.Checked == true)
                parametrs_count++;
            if (l_sepal_check.Checked == true)
                parametrs_count++;
            if (w_petal_check.Checked == true)
                parametrs_count++;
            if (w_sepal_check.Checked == true)
                parametrs_count++;
            if (l_petal_check.Checked == false && l_sepal_check.Checked == false
                && w_petal_check.Checked == false && w_sepal_check.Checked == false || parametrs_count == 1)
                correct_parametrs = false;
            else
                correct_parametrs = true;
            if (Manhattan_check.Checked == true || Euclidean_check.Checked == true)
                metric_chosen = true;
            if (cluster_count >= 2 && cluster_count <= 150)
                normal_cluster_count = true;
            if (correct_parametrs == false)
                MessageBox.Show("Вы должны выбрать минимум два праметра для кластеризации!");
            if (data_load == false)
                MessageBox.Show("Данные не загружены! Нажмите кнопку \"Исходные данные\"");
            if (metric_chosen == false)
                MessageBox.Show("Метрика не выбрана! Задайте одну из двух метрик");
            if (normal_cluster_count == false)
                MessageBox.Show("Число кластеров должно быть больше 2-ух, но меньше 150!");
            if (normal_cluster_count && metric_chosen && correct_parametrs && data_load)
            {
                correct = true;
            }
            else
            {
                correct = false;
            }
            return correct;
        }
        //Проверка на ввод только цифр в cluster_num и show_cluster_text (textBox через который задаётся число кластеров)
        private void cluster_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void show_cluster_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        //Тригер для переключения checkBox'ов метрик (одна только метрика быть может):
        private void Euclidean_check_CheckStateChanged(object sender, EventArgs e)
        {
            if (Euclidean_check.Checked == true)
                Manhattan_check.Checked = false;
        }
        private void Manhattan_check_CheckStateChanged(object sender, EventArgs e)
        {
            if (Manhattan_check.Checked == true)
                Euclidean_check.Checked = false;
        }
        //Загрузка файла с данными
        private void load_button_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
        }
        public void show_cluster_button_Click(object sender, EventArgs e)
        {
            if (show_cluster_text.Text != "" && clustered && Convert.ToUInt32(show_cluster_text.Text) <= cluster_count && Convert.ToInt32(show_cluster_text.Text) != 0)
            {
                f2.Owner = this;
                f2.ShowDialog();
                //f2.Show();
            }
            else if ((show_cluster_text.Text == "" || ((Convert.ToInt32(show_cluster_text.Text) > cluster_count) && Convert.ToInt32(show_cluster_text.Text) != 0)
                || Convert.ToInt32(show_cluster_text.Text) == 0) && clustered && show_cluster_text.Text != "")
            {
                MessageBox.Show("Такого кластера не существует!");
            }
            else if (show_cluster_text.Text == "" && clustered)
            {
                MessageBox.Show("Введиет номер кластера.");
            }
            else
            {
                MessageBox.Show("Кластеризация не произведена! Загрузите данные и проведите кластеризацию.");
            }
        }
    }
}
