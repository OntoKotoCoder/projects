namespace sh_k_means
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.current_cluster_grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.current_cluster_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // current_cluster_grid
            // 
            this.current_cluster_grid.AllowUserToAddRows = false;
            this.current_cluster_grid.AllowUserToDeleteRows = false;
            this.current_cluster_grid.BackgroundColor = System.Drawing.Color.White;
            this.current_cluster_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.current_cluster_grid.Location = new System.Drawing.Point(12, 12);
            this.current_cluster_grid.Name = "current_cluster_grid";
            this.current_cluster_grid.ReadOnly = true;
            this.current_cluster_grid.RowHeadersWidth = 20;
            this.current_cluster_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.current_cluster_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.current_cluster_grid.Size = new System.Drawing.Size(439, 558);
            this.current_cluster_grid.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 582);
            this.Controls.Add(this.current_cluster_grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Кластер №";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.current_cluster_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView current_cluster_grid;
    }
}