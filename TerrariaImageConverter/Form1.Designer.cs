
namespace TerrariaImageConverter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ImageLoad = new System.Windows.Forms.Button();
            this.ImagePath = new System.Windows.Forms.TextBox();
            this.SaveJson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PixelX = new System.Windows.Forms.NumericUpDown();
            this.PixelY = new System.Windows.Forms.NumericUpDown();
            this.Pixellation = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(283, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 720);
            this.label1.TabIndex = 4;
            this.label1.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n" +
    "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r" +
    "\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "-------------------------------------------";
            // 
            // ImageLoad
            // 
            this.ImageLoad.AutoSize = true;
            this.ImageLoad.Location = new System.Drawing.Point(217, 36);
            this.ImageLoad.Name = "ImageLoad";
            this.ImageLoad.Size = new System.Drawing.Size(43, 23);
            this.ImageLoad.TabIndex = 1;
            this.ImageLoad.Text = "Load";
            this.ImageLoad.UseVisualStyleBackColor = true;
            this.ImageLoad.Click += new System.EventHandler(this.ImageLoad_Click);
            // 
            // ImagePath
            // 
            this.ImagePath.Location = new System.Drawing.Point(14, 38);
            this.ImagePath.Name = "ImagePath";
            this.ImagePath.ReadOnly = true;
            this.ImagePath.Size = new System.Drawing.Size(199, 21);
            this.ImagePath.TabIndex = 2;
            // 
            // SaveJson
            // 
            this.SaveJson.Enabled = false;
            this.SaveJson.Location = new System.Drawing.Point(217, 65);
            this.SaveJson.Name = "SaveJson";
            this.SaveJson.Size = new System.Drawing.Size(43, 23);
            this.SaveJson.TabIndex = 3;
            this.SaveJson.Text = "Save";
            this.SaveJson.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "-------------------------------------------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "-------------------------------------------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "PixelX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "PixelY";
            // 
            // PixelX
            // 
            this.PixelX.Location = new System.Drawing.Point(169, 130);
            this.PixelX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PixelX.Name = "PixelX";
            this.PixelX.Size = new System.Drawing.Size(91, 21);
            this.PixelX.TabIndex = 13;
            this.PixelX.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // PixelY
            // 
            this.PixelY.Location = new System.Drawing.Point(169, 157);
            this.PixelY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PixelY.Name = "PixelY";
            this.PixelY.Size = new System.Drawing.Size(91, 21);
            this.PixelY.TabIndex = 14;
            this.PixelY.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // Pixellation
            // 
            this.Pixellation.Enabled = false;
            this.Pixellation.Location = new System.Drawing.Point(185, 196);
            this.Pixellation.Name = "Pixellation";
            this.Pixellation.Size = new System.Drawing.Size(75, 23);
            this.Pixellation.TabIndex = 15;
            this.Pixellation.Text = "Pixellation";
            this.Pixellation.UseVisualStyleBackColor = true;
            this.Pixellation.Click += new System.EventHandler(this.Pixellation_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "-------------------------------------------";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1564, 721);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Pixellation);
            this.Controls.Add(this.PixelY);
            this.Controls.Add(this.PixelX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveJson);
            this.Controls.Add(this.ImagePath);
            this.Controls.Add(this.ImageLoad);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Image2Json";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ImageLoad;
        private System.Windows.Forms.TextBox ImagePath;
        private System.Windows.Forms.Button SaveJson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown PixelX;
        private System.Windows.Forms.NumericUpDown PixelY;
        private System.Windows.Forms.Button Pixellation;
        private System.Windows.Forms.Label label9;
    }
}

