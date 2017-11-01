namespace ThreadTest.DotTraceDemo {
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
      this.tbDone = new System.Windows.Forms.TextBox();
      this.tbQueue = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btStart
      // 
      this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.btStart.Location = new System.Drawing.Point(12, 143);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(265, 70);
      this.btStart.TabIndex = 0;
      this.btStart.Text = "Start";
      this.btStart.UseVisualStyleBackColor = true;
      this.btStart.Click += new System.EventHandler(this.btStart_Click);
      // 
      // tbDone
      // 
      this.tbDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.tbDone.Location = new System.Drawing.Point(140, 12);
      this.tbDone.Name = "tbDone";
      this.tbDone.Size = new System.Drawing.Size(137, 50);
      this.tbDone.TabIndex = 1;
      // 
      // tbQueue
      // 
      this.tbQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.tbQueue.Location = new System.Drawing.Point(140, 68);
      this.tbQueue.Name = "tbQueue";
      this.tbQueue.Size = new System.Drawing.Size(137, 50);
      this.tbQueue.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.label1.Location = new System.Drawing.Point(4, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(121, 44);
      this.label1.TabIndex = 3;
      this.label1.Text = "Done:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
      this.label2.Location = new System.Drawing.Point(4, 71);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(145, 44);
      this.label2.TabIndex = 4;
      this.label2.Text = "Queue:";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(289, 225);
      this.Controls.Add(this.tbQueue);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbDone);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btStart);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.TextBox tbDone;
    private System.Windows.Forms.TextBox tbQueue;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

