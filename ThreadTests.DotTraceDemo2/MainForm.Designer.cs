namespace ThreadTests.DotTraceDemo2 {
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
      this.btStart = new System.Windows.Forms.Button();
      this.btStop = new System.Windows.Forms.Button();
      this.tbOutput = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btStart
      // 
      this.btStart.Location = new System.Drawing.Point(20, 289);
      this.btStart.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(353, 97);
      this.btStart.TabIndex = 0;
      this.btStart.Text = "Start";
      this.btStart.UseVisualStyleBackColor = true;
      this.btStart.Click += new System.EventHandler(this.btStart_Click);
      // 
      // btStop
      // 
      this.btStop.Enabled = false;
      this.btStop.Location = new System.Drawing.Point(392, 289);
      this.btStop.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.btStop.Name = "btStop";
      this.btStop.Size = new System.Drawing.Size(353, 97);
      this.btStop.TabIndex = 1;
      this.btStop.Text = "Stop";
      this.btStop.UseVisualStyleBackColor = true;
      this.btStop.Click += new System.EventHandler(this.btStop_Click);
      // 
      // tbOutput
      // 
      this.tbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
      this.tbOutput.Location = new System.Drawing.Point(20, 12);
      this.tbOutput.Multiline = true;
      this.tbOutput.Name = "tbOutput";
      this.tbOutput.Size = new System.Drawing.Size(725, 264);
      this.tbOutput.TabIndex = 2;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 44F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(765, 405);
      this.Controls.Add(this.tbOutput);
      this.Controls.Add(this.btStop);
      this.Controls.Add(this.btStart);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.Button btStop;
    private System.Windows.Forms.TextBox tbOutput;
  }
}

