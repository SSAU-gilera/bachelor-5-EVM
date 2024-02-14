namespace Lr3
{
    partial class lab4
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.completedordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shoppDataSet1 = new Lr3.ShoppDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.completed_ordersTableAdapter = new Lr3.ShoppDataSet1TableAdapters.Completed_ordersTableAdapter();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.completedordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // completedordersBindingSource
            // 
            this.completedordersBindingSource.DataMember = "Completed_orders";
            this.completedordersBindingSource.DataSource = this.shoppDataSet1;
            // 
            // shoppDataSet1
            // 
            this.shoppDataSet1.DataSetName = "ShoppDataSet1";
            this.shoppDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.completedordersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lr3.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1001, 468);
            this.reportViewer1.TabIndex = 0;
            // 
            // completed_ordersTableAdapter
            // 
            this.completed_ordersTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Items.AddRange(new object[] {
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015"});
            this.comboBox_year.Location = new System.Drawing.Point(51, 10);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(121, 24);
            this.comboBox_year.TabIndex = 1;
            // 
            // comboBox_month
            // 
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.comboBox_month.Location = new System.Drawing.Point(248, 10);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(121, 24);
            this.comboBox_month.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Месяц";
            // 
            // button_confirm
            // 
            this.button_confirm.AutoSize = true;
            this.button_confirm.Location = new System.Drawing.Point(404, 10);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(91, 27);
            this.button_confirm.TabIndex = 5;
            this.button_confirm.Text = "Применить";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.Button_confirm_Click);
            // 
            // lab4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 520);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_month);
            this.Controls.Add(this.comboBox_year);
            this.Controls.Add(this.reportViewer1);
            this.Name = "lab4";
            this.Text = "lab4";
            this.Load += new System.EventHandler(this.Lab4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.completedordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ShoppDataSet1 shoppDataSet1;
        private System.Windows.Forms.BindingSource completedordersBindingSource;
        private ShoppDataSet1TableAdapters.Completed_ordersTableAdapter completed_ordersTableAdapter;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_confirm;
    }
}