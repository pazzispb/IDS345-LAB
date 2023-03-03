namespace Ejercicio2
{
    partial class Service1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fwsMonitor = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fwsMonitor)).BeginInit();
            // 
            // fwsMonitor
            // 
            this.fwsMonitor.EnableRaisingEvents = true;
            this.fwsMonitor.Path = "C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\Monitor";
            this.fwsMonitor.Changed += new System.IO.FileSystemEventHandler(this.fwsMonitor_Changed);
            this.fwsMonitor.Created += new System.IO.FileSystemEventHandler(this.fwsMonitor_Created);
            this.fwsMonitor.Deleted += new System.IO.FileSystemEventHandler(this.fwsMonitor_Deleted);
            this.fwsMonitor.Renamed += new System.IO.RenamedEventHandler(this.fwsMonitor_Renamed);
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.fwsMonitor)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher fwsMonitor;
    }
}
