namespace PruebaSagrario2.Vistas.Personas
{
    partial class TablaPersonas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditarPer = new System.Windows.Forms.Button();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnElimianrPer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(669, 268);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnEditarPer
            // 
            this.btnEditarPer.Location = new System.Drawing.Point(240, 35);
            this.btnEditarPer.Name = "btnEditarPer";
            this.btnEditarPer.Size = new System.Drawing.Size(121, 50);
            this.btnEditarPer.TabIndex = 1;
            this.btnEditarPer.Text = "Editar Persona";
            this.btnEditarPer.UseVisualStyleBackColor = true;
            this.btnEditarPer.Click += new System.EventHandler(this.btnEditarPer_Click);
            // 
            // btnPersonas
            // 
            this.btnPersonas.Location = new System.Drawing.Point(64, 40);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(144, 44);
            this.btnPersonas.TabIndex = 2;
            this.btnPersonas.Text = "Crear Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // btnElimianrPer
            // 
            this.btnElimianrPer.Location = new System.Drawing.Point(399, 40);
            this.btnElimianrPer.Name = "btnElimianrPer";
            this.btnElimianrPer.Size = new System.Drawing.Size(123, 44);
            this.btnElimianrPer.TabIndex = 3;
            this.btnElimianrPer.Text = "Eliminar Persona";
            this.btnElimianrPer.UseVisualStyleBackColor = true;
            this.btnElimianrPer.Click += new System.EventHandler(this.btnElimianrPer_Click);
            // 
            // TablaPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 491);
            this.Controls.Add(this.btnElimianrPer);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnEditarPer);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TablaPersonas";
            this.Text = "TablaPersonas";
            this.Activated += new System.EventHandler(this.TablaPersonas_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEditarPer;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button btnElimianrPer;
    }
}