namespace Steganography
{
    partial class resizeForm
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
            this.resizeOkBtn = new System.Windows.Forms.Button();
            this.resizeCancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthValue = new System.Windows.Forms.TextBox();
            this.heightValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resizeOkBtn
            // 
            this.resizeOkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(214)))), ((int)(((byte)(22)))));
            this.resizeOkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resizeOkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.resizeOkBtn.FlatAppearance.BorderSize = 0;
            this.resizeOkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeOkBtn.Font = new System.Drawing.Font("Google Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resizeOkBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.resizeOkBtn.Location = new System.Drawing.Point(102, 148);
            this.resizeOkBtn.Name = "resizeOkBtn";
            this.resizeOkBtn.Size = new System.Drawing.Size(93, 42);
            this.resizeOkBtn.TabIndex = 0;
            this.resizeOkBtn.Text = "RESIZE";
            this.resizeOkBtn.UseVisualStyleBackColor = false;
            // 
            // resizeCancelBtn
            // 
            this.resizeCancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(32)))), ((int)(((byte)(18)))));
            this.resizeCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resizeCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.resizeCancelBtn.FlatAppearance.BorderSize = 0;
            this.resizeCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeCancelBtn.Font = new System.Drawing.Font("Google Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resizeCancelBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.resizeCancelBtn.Location = new System.Drawing.Point(201, 148);
            this.resizeCancelBtn.Name = "resizeCancelBtn";
            this.resizeCancelBtn.Size = new System.Drawing.Size(93, 42);
            this.resizeCancelBtn.TabIndex = 1;
            this.resizeCancelBtn.Text = "CANCEL";
            this.resizeCancelBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Google Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Google Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // widthValue
            // 
            this.widthValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.widthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthValue.ForeColor = System.Drawing.Color.White;
            this.widthValue.Location = new System.Drawing.Point(116, 36);
            this.widthValue.Name = "widthValue";
            this.widthValue.Size = new System.Drawing.Size(178, 20);
            this.widthValue.TabIndex = 4;
            // 
            // heightValue
            // 
            this.heightValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.heightValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightValue.ForeColor = System.Drawing.Color.White;
            this.heightValue.Location = new System.Drawing.Point(116, 80);
            this.heightValue.Name = "heightValue";
            this.heightValue.Size = new System.Drawing.Size(178, 20);
            this.heightValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(26, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Không nên resize lớn hơn kích thước ban đầu!";
            // 
            // resizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(322, 216);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.heightValue);
            this.Controls.Add(this.widthValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resizeCancelBtn);
            this.Controls.Add(this.resizeOkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "resizeForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "resizeForm";
            this.Load += new System.EventHandler(this.resizeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resizeOkBtn;
        private System.Windows.Forms.Button resizeCancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox widthValue;
        public System.Windows.Forms.TextBox heightValue;
        private System.Windows.Forms.Label label3;
    }
}