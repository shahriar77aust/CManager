namespace CoachingManagement
{
    partial class ResultPrintPreview
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.StudentResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coachingmanagementDataSet = new CoachingManagement.coachingmanagementDataSet();
            this.StudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coachingmanagementDataSet4 = new CoachingManagement.coachingmanagementDataSet4();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StudentResultTableAdapter = new CoachingManagement.coachingmanagementDataSetTableAdapters.StudentResultTableAdapter();
            this.StudentTableAdapter = new CoachingManagement.coachingmanagementDataSet4TableAdapters.StudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentResultBindingSource
            // 
            this.StudentResultBindingSource.DataMember = "StudentResult";
            this.StudentResultBindingSource.DataSource = this.coachingmanagementDataSet;
            // 
            // coachingmanagementDataSet
            // 
            this.coachingmanagementDataSet.DataSetName = "coachingmanagementDataSet";
            this.coachingmanagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentBindingSource
            // 
            this.StudentBindingSource.DataMember = "Student";
            this.StudentBindingSource.DataSource = this.coachingmanagementDataSet4;
            // 
            // coachingmanagementDataSet4
            // 
            this.coachingmanagementDataSet4.DataSetName = "coachingmanagementDataSet4";
            this.coachingmanagementDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.StudentResultBindingSource;
            reportDataSource2.Name = "Information";
            reportDataSource2.Value = this.StudentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CoachingManagement.MarkSheet.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.Size = new System.Drawing.Size(659, 687);
            this.reportViewer1.TabIndex = 0;
            // 
            // StudentResultTableAdapter
            // 
            this.StudentResultTableAdapter.ClearBeforeFill = true;
            // 
            // StudentTableAdapter
            // 
            this.StudentTableAdapter.ClearBeforeFill = true;
            // 
            // ResultPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 687);
            this.Controls.Add(this.reportViewer1);
            this.MaximumSize = new System.Drawing.Size(800, 726);
            this.MinimumSize = new System.Drawing.Size(500, 726);
            this.Name = "ResultPrintPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultPrintPreview";
            this.Load += new System.EventHandler(this.ResultPrintPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StudentResultBindingSource;
        private coachingmanagementDataSet coachingmanagementDataSet;
        private coachingmanagementDataSetTableAdapters.StudentResultTableAdapter StudentResultTableAdapter;
        private System.Windows.Forms.BindingSource StudentBindingSource;
        private coachingmanagementDataSet4 coachingmanagementDataSet4;
        private coachingmanagementDataSet4TableAdapters.StudentTableAdapter StudentTableAdapter;
    }
}