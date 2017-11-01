namespace ThreadTest.TaskDeadlock {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.btDownload = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btDownload
      // 
      this.btDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.btDownload.Location = new System.Drawing.Point(13, 13);
      this.btDownload.Name = "btDownload";
      this.btDownload.Size = new System.Drawing.Size(237, 64);
      this.btDownload.TabIndex = 0;
      this.btDownload.Text = "Download";
      this.btDownload.UseVisualStyleBackColor = true;
      this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(262, 89);
      this.Controls.Add(this.btDownload);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btDownload;
  }
}

