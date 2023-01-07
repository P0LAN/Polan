

namespace Polan
{
    partial class Polan
    {

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Polan));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialMultiLineTextBox2 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialMultiLineTextBox1 = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.Settings = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.Main);
            this.materialTabControl1.Controls.Add(this.Settings);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 65);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(543, 307);
            this.materialTabControl1.TabIndex = 4;
            // 
            // Main
            // 
            this.Main.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.label1);
            this.Main.Controls.Add(this.materialLabel2);
            this.Main.Controls.Add(this.materialMultiLineTextBox2);
            this.Main.Controls.Add(this.materialMultiLineTextBox1);
            this.Main.ImageIndex = 1;
            this.Main.Location = new System.Drawing.Point(4, 24);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(535, 279);
            this.Main.TabIndex = 0;
            this.Main.Text = "Main";
            this.Main.Click += new System.EventHandler(this.Main_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "awake";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "output";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(70, 3);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(37, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "input";
            this.materialLabel2.Click += new System.EventHandler(this.materialLabel2_Click);
            // 
            // materialMultiLineTextBox2
            // 
            this.materialMultiLineTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialMultiLineTextBox2.Depth = 0;
            this.materialMultiLineTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox2.Location = new System.Drawing.Point(277, 27);
            this.materialMultiLineTextBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox2.Name = "materialMultiLineTextBox2";
            this.materialMultiLineTextBox2.Size = new System.Drawing.Size(208, 96);
            this.materialMultiLineTextBox2.TabIndex = 6;
            this.materialMultiLineTextBox2.Text = "";
            // 
            // materialMultiLineTextBox1
            // 
            this.materialMultiLineTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialMultiLineTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialMultiLineTextBox1.Depth = 0;
            this.materialMultiLineTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMultiLineTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialMultiLineTextBox1.Location = new System.Drawing.Point(70, 27);
            this.materialMultiLineTextBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialMultiLineTextBox1.Name = "materialMultiLineTextBox1";
            this.materialMultiLineTextBox1.ReadOnly = true;
            this.materialMultiLineTextBox1.Size = new System.Drawing.Size(188, 96);
            this.materialMultiLineTextBox1.TabIndex = 5;
            this.materialMultiLineTextBox1.Text = "";
            // 
            // Settings
            // 
            this.Settings.ImageIndex = 0;
            this.Settings.Location = new System.Drawing.Point(4, 24);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(535, 279);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "settings_FILL0_wght400_GRAD0_opsz48.png");
            this.imageList1.Images.SetKeyName(1, "home_FILL0_wght400_GRAD0_opsz48.png");
            // 
            // Polan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 372);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.DrawerUseColors = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Polan";
            this.Text = "Polan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage Main;
        private TabPage Settings;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox1;
        private Label label1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Label label2;
        private void materialButton1_Click(object sender, System.EventArgs e)
        {
            wake = true;
        }
    }
}