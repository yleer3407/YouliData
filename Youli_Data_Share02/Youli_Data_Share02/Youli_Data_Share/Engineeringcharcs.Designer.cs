namespace Youli_Data_Share
{
    partial class Engineeringcharcs
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Engineeringcharcs));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.客户 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.产品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.问题归类 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.问题描述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.解决方案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.提交端 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.详细 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.youli_dateDataSet = new Youli_Data_Share.Youli_dateDataSet();
            this.problemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.problemsTableAdapter = new Youli_Data_Share.Youli_dateDataSetTableAdapters.problemsTableAdapter();
            this.youli_dateDataSet1 = new Youli_Data_Share.Youli_dateDataSet1();
            this.problems02BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.problems02TableAdapter = new Youli_Data_Share.Youli_dateDataSet1TableAdapters.problems02TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.youli_dateDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.youli_dateDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problems02BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 534);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Image = global::Youli_Data_Share.Properties.Resources.提交成功;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(769, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "提交";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1160, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Youli_Data_Share.Properties.Resources.查找;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "查找";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Youli_Data_Share.Properties.Resources.筛选;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton3.Text = "未解决";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.时间,
            this.状态,
            this.客户,
            this.产品名称,
            this.问题归类,
            this.问题描述,
            this.解决方案,
            this.提交端,
            this.详细});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 505);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // 时间
            // 
            this.时间.DataPropertyName = "时间";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.时间.DefaultCellStyle = dataGridViewCellStyle1;
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "状态";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.状态.DefaultCellStyle = dataGridViewCellStyle2;
            this.状态.HeaderText = "状态";
            this.状态.Items.AddRange(new object[] {
            "问题暴露",
            "正在解决",
            "结束问题"});
            this.状态.Name = "状态";
            this.状态.Width = 80;
            // 
            // 客户
            // 
            this.客户.DataPropertyName = "客户";
            this.客户.HeaderText = "客户";
            this.客户.Name = "客户";
            this.客户.Width = 80;
            // 
            // 产品名称
            // 
            this.产品名称.DataPropertyName = "产品名称";
            this.产品名称.HeaderText = "产品名称";
            this.产品名称.Name = "产品名称";
            this.产品名称.Width = 150;
            // 
            // 问题归类
            // 
            this.问题归类.DataPropertyName = "问题归类";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.问题归类.DefaultCellStyle = dataGridViewCellStyle3;
            this.问题归类.HeaderText = "问题归类";
            this.问题归类.Items.AddRange(new object[] {
            "1.模具",
            "2.PCB板",
            "3.程序",
            "4.材料",
            "5.整机配合",
            "6.工艺"});
            this.问题归类.Name = "问题归类";
            this.问题归类.Width = 80;
            // 
            // 问题描述
            // 
            this.问题描述.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.问题描述.DataPropertyName = "问题描述";
            this.问题描述.FillWeight = 50F;
            this.问题描述.HeaderText = "问题描述";
            this.问题描述.Name = "问题描述";
            // 
            // 解决方案
            // 
            this.解决方案.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.解决方案.DataPropertyName = "解决方案";
            this.解决方案.FillWeight = 50F;
            this.解决方案.HeaderText = "解决方案";
            this.解决方案.Name = "解决方案";
            // 
            // 提交端
            // 
            this.提交端.DataPropertyName = "问题发起人";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.提交端.DefaultCellStyle = dataGridViewCellStyle4;
            this.提交端.HeaderText = "提交端";
            this.提交端.Name = "提交端";
            this.提交端.ReadOnly = true;
            // 
            // 详细
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "详细>>";
            this.详细.DefaultCellStyle = dataGridViewCellStyle5;
            this.详细.HeaderText = "详细";
            this.详细.Name = "详细";
            this.详细.Width = 50;
            // 
            // youli_dateDataSet
            // 
            this.youli_dateDataSet.DataSetName = "Youli_dateDataSet";
            this.youli_dateDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // problemsBindingSource
            // 
            this.problemsBindingSource.DataMember = "problems";
            this.problemsBindingSource.DataSource = this.youli_dateDataSet;
            // 
            // problemsTableAdapter
            // 
            this.problemsTableAdapter.ClearBeforeFill = true;
            // 
            // youli_dateDataSet1
            // 
            this.youli_dateDataSet1.DataSetName = "Youli_dateDataSet1";
            this.youli_dateDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // problems02BindingSource
            // 
            this.problems02BindingSource.DataMember = "problems02";
            this.problems02BindingSource.DataSource = this.youli_dateDataSet1;
            // 
            // problems02TableAdapter
            // 
            this.problems02TableAdapter.ClearBeforeFill = true;
            // 
            // Engineeringcharcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 534);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Engineeringcharcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工程问题记录";
            this.Load += new System.EventHandler(this.Engineeringcharcs_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.youli_dateDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.youli_dateDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problems02BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Youli_dateDataSet youli_dateDataSet;
        private System.Windows.Forms.BindingSource problemsBindingSource;
        private Youli_dateDataSetTableAdapters.problemsTableAdapter problemsTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private Youli_dateDataSet1 youli_dateDataSet1;
        private System.Windows.Forms.BindingSource problems02BindingSource;
        private Youli_dateDataSet1TableAdapters.problems02TableAdapter problems02TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewComboBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户;
        private System.Windows.Forms.DataGridViewTextBoxColumn 产品名称;
        private System.Windows.Forms.DataGridViewComboBoxColumn 问题归类;
        private System.Windows.Forms.DataGridViewTextBoxColumn 问题描述;
        private System.Windows.Forms.DataGridViewTextBoxColumn 解决方案;
        private System.Windows.Forms.DataGridViewTextBoxColumn 提交端;
        private System.Windows.Forms.DataGridViewButtonColumn 详细;
    }
}