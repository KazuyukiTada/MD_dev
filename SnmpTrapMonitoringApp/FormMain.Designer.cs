namespace SnmpTrapMonitoringApp
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonKanshi = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPath1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxPath2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.Black;
			this.textBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox1.ForeColor = System.Drawing.Color.Gold;
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(684, 309);
			this.textBox1.TabIndex = 4;
			// 
			// buttonKanshi
			// 
			this.buttonKanshi.BackColor = System.Drawing.Color.Black;
			this.buttonKanshi.BackgroundImage = global::SnmpTrapMonitoringApp.Properties.Resources.kanshi;
			this.buttonKanshi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.buttonKanshi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonKanshi.ForeColor = System.Drawing.Color.Black;
			this.buttonKanshi.Location = new System.Drawing.Point(714, 13);
			this.buttonKanshi.Name = "buttonKanshi";
			this.buttonKanshi.Size = new System.Drawing.Size(83, 34);
			this.buttonKanshi.TabIndex = 5;
			this.toolTip1.SetToolTip(this.buttonKanshi, "監視ステータス");
			this.buttonKanshi.UseVisualStyleBackColor = false;
			this.buttonKanshi.Visible = false;
			// 
			// buttonStop
			// 
			this.buttonStop.BackColor = System.Drawing.Color.Black;
			this.buttonStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStop.BackgroundImage")));
			this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonStop.ForeColor = System.Drawing.Color.Black;
			this.buttonStop.Location = new System.Drawing.Point(714, 13);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(83, 34);
			this.buttonStop.TabIndex = 3;
			this.toolTip1.SetToolTip(this.buttonStop, "監視ステータス");
			this.buttonStop.UseVisualStyleBackColor = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Black;
			this.button1.BackgroundImage = global::SnmpTrapMonitoringApp.Properties.Resources.wmp_11;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(704, 262);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(101, 83);
			this.button1.TabIndex = 2;
			this.toolTip1.SetToolTip(this.button1, "ボタンクリックでTrap監視スタート");
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.Yellow;
			this.label1.Location = new System.Drawing.Point(698, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "Until the end time";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.Black;
			this.textBox2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBox2.ForeColor = System.Drawing.Color.Yellow;
			this.textBox2.Location = new System.Drawing.Point(725, 112);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(59, 25);
			this.textBox2.TabIndex = 7;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip1.SetToolTip(this.textBox2, "Tshark終了までの時間");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.Yellow;
			this.label2.Location = new System.Drawing.Point(706, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "Tshark Capture";
			// 
			// textBoxPath1
			// 
			this.textBoxPath1.BackColor = System.Drawing.Color.Black;
			this.textBoxPath1.ForeColor = System.Drawing.Color.White;
			this.textBoxPath1.Location = new System.Drawing.Point(124, 330);
			this.textBoxPath1.Name = "textBoxPath1";
			this.textBoxPath1.Size = new System.Drawing.Size(228, 19);
			this.textBoxPath1.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.Yellow;
			this.label3.Location = new System.Drawing.Point(8, 331);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 18);
			this.label3.TabIndex = 10;
			this.label3.Text = "Capture File Path :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.Yellow;
			this.label4.Location = new System.Drawing.Point(366, 331);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 18);
			this.label4.TabIndex = 12;
			this.label4.Text = "Copy to Folder :";
			// 
			// textBoxPath2
			// 
			this.textBoxPath2.BackColor = System.Drawing.Color.Black;
			this.textBoxPath2.ForeColor = System.Drawing.Color.White;
			this.textBoxPath2.Location = new System.Drawing.Point(467, 330);
			this.textBoxPath2.Name = "textBoxPath2";
			this.textBoxPath2.Size = new System.Drawing.Size(229, 19);
			this.textBoxPath2.TabIndex = 11;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(815, 356);
			this.Controls.Add(this.textBoxPath2);
			this.Controls.Add(this.textBoxPath1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonKanshi);
			this.Name = "FormMain";
			this.Text = "SNMP Trap monitoring Application     【 Version : 1.0.0.0 】";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button buttonKanshi;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPath1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxPath2;
    }
}

