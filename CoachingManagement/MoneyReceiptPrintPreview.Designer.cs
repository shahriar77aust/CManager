namespace CoachingManagement
{
    partial class MoneyReceiptPrintPreview
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
            this.FeeReceiptVeiwer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.coachingmanagementDataSet6 = new CoachingManagement.coachingmanagementDataSet6();
            this.StudentFeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StudentFeeTableAdapter = new CoachingManagement.coachingmanagementDataSet6TableAdapters.StudentFeeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentFeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FeeReceiptVeiwer
            // 
            this.FeeReceiptVeiwer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FeeReceiptData";
            reportDataSource1.Value = this.StudentFeeBindingSource;
            this.FeeReceiptVeiwer.LocalReport.DataSources.Add(reportDataSource1);
            this.FeeReceiptVeiwer.LocalReport.ReportEmbeddedResource = "CoachingManagement.FeeReceipt.rdlc";
            this.FeeReceiptVeiwer.Location = new System.Drawing.Point(0, 0);
            this.FeeReceiptVeiwer.Name = "FeeReceiptVeiwer";
            this.FeeReceiptVeiwer.Size = new System.Drawing.Size(384, 687);
            this.FeeReceiptVeiwer.TabIndex = 0;
            // 
            // coachingmanagementDataSet6
            // 
            this.coachingmanagementDataSet6.DataSetName = "coachingmanagementDataSet6";
            this.coachingmanagementDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentFeeBindingSource
            // 
            this.StudentFeeBindingSource.DataMember = "StudentFee";
            this.StudentFeeBindingSource.DataSource = this.coachingmanagementDataSet6;
            // 
            // StudentFeeTableAdapter
            // 
            this.StudentFeeTableAdapter.ClearBeforeFill = true;
            // 
            // MoneyReceiptPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 687);
            this.Controls.Add(this.FeeReceiptVeiwer);
            this.MaximumSize = new System.Drawing.Size(400, 726);
            this.Name = "MoneyReceiptPrintPreview";
            this.Text = "MoneyReceiptPrintPreview";
            this.Load += new System.EventHandler(this.MoneyReceiptPrintPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentFeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer FeeReceiptVeiwer;
        private System.Windows.Forms.BindingSource StudentFeeBindingSource;
        private coachingmanagementDataSet6 coachingmanagementDataSet6;
        private coachingmanagementDataSet6TableAdapters.StudentFeeTableAdapter StudentFeeTableAdapter;
    }
}