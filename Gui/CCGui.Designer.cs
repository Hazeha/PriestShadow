namespace CustomClassTemplate.Gui
{
    partial class CCGui
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
            this.foodlb = new System.Windows.Forms.Label();
            this.drinklb = new System.Windows.Forms.Label();
            this.foodTb = new System.Windows.Forms.TextBox();
            this.drinkTb = new System.Windows.Forms.TextBox();
            this.meleelb = new System.Windows.Forms.Label();
            this.castlb = new System.Windows.Forms.Label();
            this.meleeNud = new System.Windows.Forms.NumericUpDown();
            this.castNud = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.meleeNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.castNud)).BeginInit();
            this.SuspendLayout();
            // 
            // foodlb
            // 
            this.foodlb.AutoSize = true;
            this.foodlb.Location = new System.Drawing.Point(12, 13);
            this.foodlb.Name = "foodlb";
            this.foodlb.Size = new System.Drawing.Size(68, 13);
            this.foodlb.TabIndex = 0;
            this.foodlb.Text = "Food Name: ";
            // 
            // drinklb
            // 
            this.drinklb.AutoSize = true;
            this.drinklb.Location = new System.Drawing.Point(11, 41);
            this.drinklb.Name = "drinklb";
            this.drinklb.Size = new System.Drawing.Size(69, 13);
            this.drinklb.TabIndex = 1;
            this.drinklb.Text = "Drink Name: ";
            // 
            // foodTb
            // 
            this.foodTb.Location = new System.Drawing.Point(86, 10);
            this.foodTb.Name = "foodTb";
            this.foodTb.Size = new System.Drawing.Size(100, 20);
            this.foodTb.TabIndex = 2;
            // 
            // drinkTb
            // 
            this.drinkTb.Location = new System.Drawing.Point(86, 38);
            this.drinkTb.Name = "drinkTb";
            this.drinkTb.Size = new System.Drawing.Size(100, 20);
            this.drinkTb.TabIndex = 3;
            // 
            // meleelb
            // 
            this.meleelb.AutoSize = true;
            this.meleelb.Location = new System.Drawing.Point(11, 66);
            this.meleelb.Name = "meleelb";
            this.meleelb.Size = new System.Drawing.Size(87, 13);
            this.meleelb.TabIndex = 4;
            this.meleelb.Text = "Melee Distance: ";
            // 
            // castlb
            // 
            this.castlb.AutoSize = true;
            this.castlb.Location = new System.Drawing.Point(12, 92);
            this.castlb.Name = "castlb";
            this.castlb.Size = new System.Drawing.Size(79, 13);
            this.castlb.TabIndex = 5;
            this.castlb.Text = "Cast Distance: ";
            // 
            // meleeNud
            // 
            this.meleeNud.Location = new System.Drawing.Point(121, 64);
            this.meleeNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.meleeNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.meleeNud.Name = "meleeNud";
            this.meleeNud.Size = new System.Drawing.Size(66, 20);
            this.meleeNud.TabIndex = 6;
            this.meleeNud.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // castNud
            // 
            this.castNud.Location = new System.Drawing.Point(121, 90);
            this.castNud.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.castNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.castNud.Name = "castNud";
            this.castNud.Size = new System.Drawing.Size(66, 20);
            this.castNud.TabIndex = 7;
            this.castNud.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(16, 137);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(107, 137);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(75, 23);
            this.reloadBtn.TabIndex = 9;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // CCGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 174);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.castNud);
            this.Controls.Add(this.meleeNud);
            this.Controls.Add(this.castlb);
            this.Controls.Add(this.meleelb);
            this.Controls.Add(this.drinkTb);
            this.Controls.Add(this.foodTb);
            this.Controls.Add(this.drinklb);
            this.Controls.Add(this.foodlb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CCGui";
            this.Text = "EmuPriest - Thanks z0mg";
            ((System.ComponentModel.ISupportInitialize)(this.meleeNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.castNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label foodlb;
        private System.Windows.Forms.Label drinklb;
        private System.Windows.Forms.TextBox foodTb;
        private System.Windows.Forms.TextBox drinkTb;
        private System.Windows.Forms.Label meleelb;
        private System.Windows.Forms.Label castlb;
        private System.Windows.Forms.NumericUpDown meleeNud;
        private System.Windows.Forms.NumericUpDown castNud;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button reloadBtn;
    }
}