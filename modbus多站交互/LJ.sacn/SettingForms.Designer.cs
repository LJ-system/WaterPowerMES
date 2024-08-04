namespace LJ.sacn
{
    partial class SettingForms
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
            this.gbSerial = new System.Windows.Forms.GroupBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.cboBaudRates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStopBIts = new System.Windows.Forms.ComboBox();
            this.cboPrarity = new System.Windows.Forms.ComboBox();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSerial
            // 
            this.gbSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gbSerial.Controls.Add(this.cboBaudRates);
            this.gbSerial.Controls.Add(this.label1);
            this.gbSerial.Controls.Add(this.label2);
            this.gbSerial.Controls.Add(this.cboStopBIts);
            this.gbSerial.Controls.Add(this.cboPrarity);
            this.gbSerial.Controls.Add(this.cboPorts);
            this.gbSerial.Controls.Add(this.cboDataBits);
            this.gbSerial.Controls.Add(this.label3);
            this.gbSerial.Controls.Add(this.label5);
            this.gbSerial.Controls.Add(this.label4);
            this.gbSerial.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbSerial.Location = new System.Drawing.Point(-2, 0);
            this.gbSerial.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbSerial.Name = "gbSerial";
            this.gbSerial.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbSerial.Size = new System.Drawing.Size(807, 352);
            this.gbSerial.TabIndex = 26;
            this.gbSerial.TabStop = false;
            this.gbSerial.Text = "串口设置：";
            // 
            // uiButton1
            // 
            this.uiButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiButton1.FillHoverColor = System.Drawing.Color.Yellow;
            this.uiButton1.FillPressColor = System.Drawing.Color.Yellow;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ForeColor = System.Drawing.Color.Black;
            this.uiButton1.ForeHoverColor = System.Drawing.Color.Black;
            this.uiButton1.ForePressColor = System.Drawing.Color.Black;
            this.uiButton1.ForeSelectedColor = System.Drawing.Color.Black;
            this.uiButton1.LightColor = System.Drawing.Color.Transparent;
            this.uiButton1.Location = new System.Drawing.Point(751, 360);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 20;
            this.uiButton1.Size = new System.Drawing.Size(54, 27);
            this.uiButton1.TabIndex = 69;
            this.uiButton1.Text = "退出";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.TipsForeColor = System.Drawing.Color.Transparent;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // cboBaudRates
            // 
            this.cboBaudRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRates.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboBaudRates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboBaudRates.FormattingEnabled = true;
            this.cboBaudRates.Location = new System.Drawing.Point(420, 43);
            this.cboBaudRates.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.cboBaudRates.Name = "cboBaudRates";
            this.cboBaudRates.Size = new System.Drawing.Size(167, 33);
            this.cboBaudRates.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(321, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率：";
            // 
            // cboStopBIts
            // 
            this.cboStopBIts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBIts.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboStopBIts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboStopBIts.FormattingEnabled = true;
            this.cboStopBIts.Location = new System.Drawing.Point(121, 147);
            this.cboStopBIts.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.cboStopBIts.Name = "cboStopBIts";
            this.cboStopBIts.Size = new System.Drawing.Size(152, 33);
            this.cboStopBIts.TabIndex = 8;
            // 
            // cboPrarity
            // 
            this.cboPrarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrarity.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPrarity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboPrarity.FormattingEnabled = true;
            this.cboPrarity.Location = new System.Drawing.Point(420, 93);
            this.cboPrarity.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.cboPrarity.Name = "cboPrarity";
            this.cboPrarity.Size = new System.Drawing.Size(167, 33);
            this.cboPrarity.TabIndex = 9;
            // 
            // cboPorts
            // 
            this.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPorts.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPorts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(121, 43);
            this.cboPorts.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(152, 33);
            this.cboPorts.TabIndex = 12;
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDataBits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(121, 93);
            this.cboDataBits.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(152, 33);
            this.cboDataBits.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(16, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "数据位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(16, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "停止位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(321, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "检验位：";
            // 
            // SettingForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 386);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.gbSerial);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SettingForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingForms";
            this.gbSerial.ResumeLayout(false);
            this.gbSerial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSerial;
        private System.Windows.Forms.ComboBox cboBaudRates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStopBIts;
        private System.Windows.Forms.ComboBox cboPrarity;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UIButton uiButton1;
    }
}