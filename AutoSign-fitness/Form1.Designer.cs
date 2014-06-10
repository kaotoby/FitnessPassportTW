namespace AutoSign_fitness
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logtbx = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tryico = new System.Windows.Forms.NotifyIcon(this.components);
            this.run_btn = new System.Windows.Forms.Button();
            this.timep = new System.Windows.Forms.Panel();
            this.mtbx = new System.Windows.Forms.NumericUpDown();
            this.htbx = new System.Windows.Forms.NumericUpDown();
            this.timep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.htbx)).BeginInit();
            this.SuspendLayout();
            // 
            // logtbx
            // 
            this.logtbx.Location = new System.Drawing.Point(4, 75);
            this.logtbx.Multiline = true;
            this.logtbx.Name = "logtbx";
            this.logtbx.ReadOnly = true;
            this.logtbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logtbx.Size = new System.Drawing.Size(386, 186);
            this.logtbx.TabIndex = 4;
            this.logtbx.WordWrap = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "hour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "minute";
            // 
            // tryico
            // 
            this.tryico.Icon = ((System.Drawing.Icon)(resources.GetObject("tryico.Icon")));
            this.tryico.Text = "notifyIcon1";
            this.tryico.Visible = true;
            this.tryico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tryico_MouseClick);
            // 
            // run_btn
            // 
            this.run_btn.Location = new System.Drawing.Point(215, 30);
            this.run_btn.Name = "run_btn";
            this.run_btn.Size = new System.Drawing.Size(103, 23);
            this.run_btn.TabIndex = 7;
            this.run_btn.Text = "RUN NOW!";
            this.run_btn.UseVisualStyleBackColor = true;
            this.run_btn.Click += new System.EventHandler(this.run_btn_Click);
            // 
            // timep
            // 
            this.timep.Controls.Add(this.mtbx);
            this.timep.Controls.Add(this.htbx);
            this.timep.Controls.Add(this.label2);
            this.timep.Controls.Add(this.label1);
            this.timep.Location = new System.Drawing.Point(97, 13);
            this.timep.Name = "timep";
            this.timep.Size = new System.Drawing.Size(103, 50);
            this.timep.TabIndex = 8;
            // 
            // mtbx
            // 
            this.mtbx.Location = new System.Drawing.Point(54, 21);
            this.mtbx.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.mtbx.Name = "mtbx";
            this.mtbx.Size = new System.Drawing.Size(41, 20);
            this.mtbx.TabIndex = 8;
            this.mtbx.Value = new decimal(new int[] {
            37,
            0,
            0,
            0});
            // 
            // htbx
            // 
            this.htbx.Location = new System.Drawing.Point(7, 21);
            this.htbx.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.htbx.Name = "htbx";
            this.htbx.Size = new System.Drawing.Size(41, 20);
            this.htbx.TabIndex = 7;
            this.htbx.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 263);
            this.Controls.Add(this.timep);
            this.Controls.Add(this.run_btn);
            this.Controls.Add(this.logtbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoSign-fitness";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.timep.ResumeLayout(false);
            this.timep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.htbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logtbx;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon tryico;
        private System.Windows.Forms.Button run_btn;
        private System.Windows.Forms.Panel timep;
        private System.Windows.Forms.NumericUpDown mtbx;
        private System.Windows.Forms.NumericUpDown htbx;
    }
}

