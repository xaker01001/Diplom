namespace Diplom_Chikushev
{
    partial class Zakaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zakaz));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Addbutton = new System.Windows.Forms.Button();
            this.Updatebutton = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfIssue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CirculationTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Id_service,
            this.id_manager,
            this.id_material,
            this.id_client,
            this.DateOfIssue,
            this.CirculationTerm,
            this.Width,
            this.Height,
            this.Kol,
            this.Price_material});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(766, 372);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Addbutton
            // 
            this.Addbutton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Addbutton.Location = new System.Drawing.Point(147, 393);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(190, 36);
            this.Addbutton.TabIndex = 2;
            this.Addbutton.Text = "Добавить заказ";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Updatebutton
            // 
            this.Updatebutton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Updatebutton.Location = new System.Drawing.Point(391, 393);
            this.Updatebutton.Name = "Updatebutton";
            this.Updatebutton.Size = new System.Drawing.Size(223, 36);
            this.Updatebutton.TabIndex = 3;
            this.Updatebutton.Text = "Редактировать заказ";
            this.Updatebutton.UseVisualStyleBackColor = true;
            this.Updatebutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Id_service
            // 
            this.Id_service.HeaderText = "Id_service";
            this.Id_service.Name = "Id_service";
            this.Id_service.ReadOnly = true;
            this.Id_service.Visible = false;
            // 
            // id_manager
            // 
            this.id_manager.HeaderText = "id_manager";
            this.id_manager.Name = "id_manager";
            this.id_manager.ReadOnly = true;
            this.id_manager.Visible = false;
            // 
            // id_material
            // 
            this.id_material.HeaderText = "id_material";
            this.id_material.Name = "id_material";
            this.id_material.ReadOnly = true;
            this.id_material.Visible = false;
            // 
            // id_client
            // 
            this.id_client.HeaderText = "id_client";
            this.id_client.Name = "id_client";
            this.id_client.ReadOnly = true;
            this.id_client.Visible = false;
            // 
            // DateOfIssue
            // 
            this.DateOfIssue.HeaderText = "Дата обращения";
            this.DateOfIssue.Name = "DateOfIssue";
            this.DateOfIssue.ReadOnly = true;
            // 
            // CirculationTerm
            // 
            this.CirculationTerm.HeaderText = "Количество дней на выполнение";
            this.CirculationTerm.Name = "CirculationTerm";
            this.CirculationTerm.ReadOnly = true;
            // 
            // Width
            // 
            this.Width.HeaderText = "Ширина";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            // 
            // Height
            // 
            this.Height.HeaderText = "Высота";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            // 
            // Kol
            // 
            this.Kol.HeaderText = "Количество";
            this.Kol.Name = "Kol";
            this.Kol.ReadOnly = true;
            // 
            // Price_material
            // 
            this.Price_material.HeaderText = "Цена";
            this.Price_material.Name = "Price_material";
            this.Price_material.ReadOnly = true;
            // 
            // Zakaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 457);
            this.Controls.Add(this.Updatebutton);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Zakaz";
            this.Text = "Заказы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Zakaz_FormClosing);
            this.Load += new System.EventHandler(this.Zakaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button Updatebutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CirculationTerm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price_material;
    }
}