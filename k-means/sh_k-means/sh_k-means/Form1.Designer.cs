namespace sh_k_means
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.data_button = new System.Windows.Forms.Button();
            this.cluster_num = new System.Windows.Forms.TextBox();
            this.metric_group = new System.Windows.Forms.GroupBox();
            this.Manhattan_check = new System.Windows.Forms.CheckBox();
            this.Euclidean_check = new System.Windows.Forms.CheckBox();
            this.variable_group = new System.Windows.Forms.GroupBox();
            this.w_petal_check = new System.Windows.Forms.CheckBox();
            this.l_petal_check = new System.Windows.Forms.CheckBox();
            this.w_sepal_check = new System.Windows.Forms.CheckBox();
            this.l_sepal_check = new System.Windows.Forms.CheckBox();
            this.cluster_group = new System.Windows.Forms.GroupBox();
            this.data_grid = new System.Windows.Forms.DataGridView();
            this.clustered_grid = new System.Windows.Forms.DataGridView();
            this.clustering_button = new System.Windows.Forms.Button();
            this.show_cluster_group = new System.Windows.Forms.GroupBox();
            this.show_cluster_button = new System.Windows.Forms.Button();
            this.show_cluster_text = new System.Windows.Forms.TextBox();
            this.statistic_group = new System.Windows.Forms.GroupBox();
            this.cluster_statistic_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iteration_count_lable = new System.Windows.Forms.Label();
            this.exemplar_count_lable = new System.Windows.Forms.Label();
            this.metric_group.SuspendLayout();
            this.variable_group.SuspendLayout();
            this.cluster_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clustered_grid)).BeginInit();
            this.show_cluster_group.SuspendLayout();
            this.statistic_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_button
            // 
            this.data_button.Location = new System.Drawing.Point(457, 254);
            this.data_button.Name = "data_button";
            this.data_button.Size = new System.Drawing.Size(175, 23);
            this.data_button.TabIndex = 2;
            this.data_button.Text = "Исходные данные";
            this.data_button.UseVisualStyleBackColor = true;
            this.data_button.Click += new System.EventHandler(this.data_button_Click);
            // 
            // cluster_num
            // 
            this.cluster_num.Location = new System.Drawing.Point(6, 19);
            this.cluster_num.Name = "cluster_num";
            this.cluster_num.Size = new System.Drawing.Size(163, 20);
            this.cluster_num.TabIndex = 3;
            this.cluster_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cluster_num_KeyPress);
            // 
            // metric_group
            // 
            this.metric_group.Controls.Add(this.Manhattan_check);
            this.metric_group.Controls.Add(this.Euclidean_check);
            this.metric_group.Location = new System.Drawing.Point(457, 12);
            this.metric_group.Name = "metric_group";
            this.metric_group.Size = new System.Drawing.Size(175, 67);
            this.metric_group.TabIndex = 5;
            this.metric_group.TabStop = false;
            this.metric_group.Text = "Метрика:";
            // 
            // Manhattan_check
            // 
            this.Manhattan_check.AutoSize = true;
            this.Manhattan_check.Location = new System.Drawing.Point(6, 43);
            this.Manhattan_check.Name = "Manhattan_check";
            this.Manhattan_check.Size = new System.Drawing.Size(149, 17);
            this.Manhattan_check.TabIndex = 1;
            this.Manhattan_check.Text = "Расстояние Манхэттена";
            this.Manhattan_check.UseVisualStyleBackColor = true;
            this.Manhattan_check.CheckStateChanged += new System.EventHandler(this.Manhattan_check_CheckStateChanged);
            // 
            // Euclidean_check
            // 
            this.Euclidean_check.AutoSize = true;
            this.Euclidean_check.Location = new System.Drawing.Point(6, 20);
            this.Euclidean_check.Name = "Euclidean_check";
            this.Euclidean_check.Size = new System.Drawing.Size(143, 17);
            this.Euclidean_check.TabIndex = 0;
            this.Euclidean_check.Text = "Евклидово расстояние";
            this.Euclidean_check.UseVisualStyleBackColor = true;
            this.Euclidean_check.CheckStateChanged += new System.EventHandler(this.Euclidean_check_CheckStateChanged);
            // 
            // variable_group
            // 
            this.variable_group.Controls.Add(this.w_petal_check);
            this.variable_group.Controls.Add(this.l_petal_check);
            this.variable_group.Controls.Add(this.w_sepal_check);
            this.variable_group.Controls.Add(this.l_sepal_check);
            this.variable_group.Location = new System.Drawing.Point(457, 85);
            this.variable_group.Name = "variable_group";
            this.variable_group.Size = new System.Drawing.Size(175, 112);
            this.variable_group.TabIndex = 6;
            this.variable_group.TabStop = false;
            this.variable_group.Text = "Переменные кластеризации:";
            // 
            // w_petal_check
            // 
            this.w_petal_check.AutoSize = true;
            this.w_petal_check.Location = new System.Drawing.Point(6, 88);
            this.w_petal_check.Name = "w_petal_check";
            this.w_petal_check.Size = new System.Drawing.Size(115, 17);
            this.w_petal_check.TabIndex = 3;
            this.w_petal_check.Text = "Ширина лепестка";
            this.w_petal_check.UseVisualStyleBackColor = true;
            // 
            // l_petal_check
            // 
            this.l_petal_check.AutoSize = true;
            this.l_petal_check.Location = new System.Drawing.Point(6, 65);
            this.l_petal_check.Name = "l_petal_check";
            this.l_petal_check.Size = new System.Drawing.Size(109, 17);
            this.l_petal_check.TabIndex = 2;
            this.l_petal_check.Text = "Длина лепестка";
            this.l_petal_check.UseVisualStyleBackColor = true;
            // 
            // w_sepal_check
            // 
            this.w_sepal_check.AutoSize = true;
            this.w_sepal_check.Location = new System.Drawing.Point(6, 42);
            this.w_sepal_check.Name = "w_sepal_check";
            this.w_sepal_check.Size = new System.Drawing.Size(134, 17);
            this.w_sepal_check.TabIndex = 1;
            this.w_sepal_check.Text = "Ширина чашелистика";
            this.w_sepal_check.UseVisualStyleBackColor = true;
            // 
            // l_sepal_check
            // 
            this.l_sepal_check.AutoSize = true;
            this.l_sepal_check.Location = new System.Drawing.Point(6, 19);
            this.l_sepal_check.Name = "l_sepal_check";
            this.l_sepal_check.Size = new System.Drawing.Size(128, 17);
            this.l_sepal_check.TabIndex = 0;
            this.l_sepal_check.Text = "Длина чашелистика";
            this.l_sepal_check.UseVisualStyleBackColor = true;
            // 
            // cluster_group
            // 
            this.cluster_group.Controls.Add(this.cluster_num);
            this.cluster_group.Location = new System.Drawing.Point(457, 203);
            this.cluster_group.Name = "cluster_group";
            this.cluster_group.Size = new System.Drawing.Size(175, 45);
            this.cluster_group.TabIndex = 6;
            this.cluster_group.TabStop = false;
            this.cluster_group.Text = "Количество кластеров";
            // 
            // data_grid
            // 
            this.data_grid.AllowUserToAddRows = false;
            this.data_grid.AllowUserToDeleteRows = false;
            this.data_grid.BackgroundColor = System.Drawing.Color.White;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Location = new System.Drawing.Point(12, 12);
            this.data_grid.Name = "data_grid";
            this.data_grid.ReadOnly = true;
            this.data_grid.RowHeadersWidth = 20;
            this.data_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.data_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data_grid.Size = new System.Drawing.Size(439, 652);
            this.data_grid.TabIndex = 7;
            // 
            // clustered_grid
            // 
            this.clustered_grid.AllowUserToAddRows = false;
            this.clustered_grid.AllowUserToDeleteRows = false;
            this.clustered_grid.BackgroundColor = System.Drawing.Color.White;
            this.clustered_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clustered_grid.Location = new System.Drawing.Point(638, 12);
            this.clustered_grid.Name = "clustered_grid";
            this.clustered_grid.ReadOnly = true;
            this.clustered_grid.RowHeadersWidth = 20;
            this.clustered_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.clustered_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clustered_grid.Size = new System.Drawing.Size(519, 652);
            this.clustered_grid.TabIndex = 8;
            // 
            // clustering_button
            // 
            this.clustering_button.Location = new System.Drawing.Point(457, 283);
            this.clustering_button.Name = "clustering_button";
            this.clustering_button.Size = new System.Drawing.Size(175, 23);
            this.clustering_button.TabIndex = 9;
            this.clustering_button.Text = "Провести кластеризацию";
            this.clustering_button.UseVisualStyleBackColor = true;
            this.clustering_button.Click += new System.EventHandler(this.clustering_button_Click);
            // 
            // show_cluster_group
            // 
            this.show_cluster_group.Controls.Add(this.show_cluster_button);
            this.show_cluster_group.Controls.Add(this.show_cluster_text);
            this.show_cluster_group.Location = new System.Drawing.Point(458, 313);
            this.show_cluster_group.Name = "show_cluster_group";
            this.show_cluster_group.Size = new System.Drawing.Size(174, 76);
            this.show_cluster_group.TabIndex = 11;
            this.show_cluster_group.TabStop = false;
            this.show_cluster_group.Text = "Показать кластер:";
            // 
            // show_cluster_button
            // 
            this.show_cluster_button.Location = new System.Drawing.Point(7, 47);
            this.show_cluster_button.Name = "show_cluster_button";
            this.show_cluster_button.Size = new System.Drawing.Size(161, 23);
            this.show_cluster_button.TabIndex = 1;
            this.show_cluster_button.Text = "Показать";
            this.show_cluster_button.UseVisualStyleBackColor = true;
            this.show_cluster_button.Click += new System.EventHandler(this.show_cluster_button_Click);
            // 
            // show_cluster_text
            // 
            this.show_cluster_text.Location = new System.Drawing.Point(7, 20);
            this.show_cluster_text.Name = "show_cluster_text";
            this.show_cluster_text.Size = new System.Drawing.Size(161, 20);
            this.show_cluster_text.TabIndex = 0;
            this.show_cluster_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.show_cluster_text_KeyPress);
            // 
            // statistic_group
            // 
            this.statistic_group.Controls.Add(this.cluster_statistic_box);
            this.statistic_group.Controls.Add(this.label3);
            this.statistic_group.Controls.Add(this.iteration_count_lable);
            this.statistic_group.Controls.Add(this.exemplar_count_lable);
            this.statistic_group.Location = new System.Drawing.Point(458, 396);
            this.statistic_group.Name = "statistic_group";
            this.statistic_group.Size = new System.Drawing.Size(174, 268);
            this.statistic_group.TabIndex = 12;
            this.statistic_group.TabStop = false;
            this.statistic_group.Text = "Статистика:";
            // 
            // cluster_statistic_box
            // 
            this.cluster_statistic_box.Location = new System.Drawing.Point(9, 77);
            this.cluster_statistic_box.Multiline = true;
            this.cluster_statistic_box.Name = "cluster_statistic_box";
            this.cluster_statistic_box.Size = new System.Drawing.Size(159, 185);
            this.cluster_statistic_box.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Статистика по кластерам: ";
            // 
            // iteration_count_lable
            // 
            this.iteration_count_lable.AutoSize = true;
            this.iteration_count_lable.Location = new System.Drawing.Point(27, 38);
            this.iteration_count_lable.Name = "iteration_count_lable";
            this.iteration_count_lable.Size = new System.Drawing.Size(103, 13);
            this.iteration_count_lable.TabIndex = 0;
            this.iteration_count_lable.Text = "Кол-во итераций -  ";
            // 
            // exemplar_count_lable
            // 
            this.exemplar_count_lable.AutoSize = true;
            this.exemplar_count_lable.Location = new System.Drawing.Point(6, 16);
            this.exemplar_count_lable.Name = "exemplar_count_lable";
            this.exemplar_count_lable.Size = new System.Drawing.Size(121, 13);
            this.exemplar_count_lable.TabIndex = 0;
            this.exemplar_count_lable.Text = "Кол-во экземпляров - ";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1168, 675);
            this.Controls.Add(this.statistic_group);
            this.Controls.Add(this.show_cluster_group);
            this.Controls.Add(this.clustering_button);
            this.Controls.Add(this.clustered_grid);
            this.Controls.Add(this.data_grid);
            this.Controls.Add(this.cluster_group);
            this.Controls.Add(this.variable_group);
            this.Controls.Add(this.metric_group);
            this.Controls.Add(this.data_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "k-means";
            this.metric_group.ResumeLayout(false);
            this.metric_group.PerformLayout();
            this.variable_group.ResumeLayout(false);
            this.variable_group.PerformLayout();
            this.cluster_group.ResumeLayout(false);
            this.cluster_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clustered_grid)).EndInit();
            this.show_cluster_group.ResumeLayout(false);
            this.show_cluster_group.PerformLayout();
            this.statistic_group.ResumeLayout(false);
            this.statistic_group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button data_button;
        private System.Windows.Forms.TextBox cluster_num;
        private System.Windows.Forms.GroupBox metric_group;
        private System.Windows.Forms.GroupBox variable_group;
        private System.Windows.Forms.GroupBox cluster_group;
        private System.Windows.Forms.DataGridView data_grid;
        private System.Windows.Forms.DataGridView clustered_grid;
        private System.Windows.Forms.Button clustering_button;
        private System.Windows.Forms.CheckBox Manhattan_check;
        private System.Windows.Forms.CheckBox Euclidean_check;
        private System.Windows.Forms.CheckBox w_petal_check;
        private System.Windows.Forms.CheckBox l_petal_check;
        private System.Windows.Forms.CheckBox w_sepal_check;
        private System.Windows.Forms.CheckBox l_sepal_check;
        public System.Windows.Forms.GroupBox show_cluster_group;
        private System.Windows.Forms.Button show_cluster_button;
        public System.Windows.Forms.TextBox show_cluster_text;
        private System.Windows.Forms.GroupBox statistic_group;
        private System.Windows.Forms.TextBox cluster_statistic_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label iteration_count_lable;
        private System.Windows.Forms.Label exemplar_count_lable;
    }
}

