namespace MCLauncher
{
    partial class LauncherForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
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
            TopPanel = new Panel();
            label1 = new Label();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            dreamTextBox1 = new ReaLTaiizor.Controls.DreamTextBox();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            crownComboBox1 = new ReaLTaiizor.Controls.CrownComboBox();
            foreverButton1 = new ReaLTaiizor.Controls.ForeverButton();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            progressBar1 = new ProgressBar();
            TopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.BackColor = Color.FromArgb(64, 64, 64);
            TopPanel.Controls.Add(label1);
            TopPanel.Controls.Add(nightControlBox1);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(925, 33);
            TopPanel.TabIndex = 1;
            TopPanel.MouseDown += TopPanel_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(171, 17);
            label1.TabIndex = 0;
            label1.Text = "DEFINETELY NOT A MINER";
            label1.Click += label1_Click;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(786, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 5;
            // 
            // dreamTextBox1
            // 
            dreamTextBox1.BackColor = Color.FromArgb(41, 41, 41);
            dreamTextBox1.BorderStyle = BorderStyle.FixedSingle;
            dreamTextBox1.ColorA = Color.FromArgb(31, 31, 31);
            dreamTextBox1.ColorB = Color.FromArgb(41, 41, 41);
            dreamTextBox1.ColorC = Color.FromArgb(51, 51, 51);
            dreamTextBox1.ColorD = Color.FromArgb(0, 0, 0, 0);
            dreamTextBox1.ColorE = Color.FromArgb(25, 255, 255, 255);
            dreamTextBox1.ColorF = Color.Black;
            dreamTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dreamTextBox1.ForeColor = Color.Gray;
            dreamTextBox1.Location = new Point(30, 83);
            dreamTextBox1.Name = "dreamTextBox1";
            dreamTextBox1.Size = new Size(199, 29);
            dreamTextBox1.TabIndex = 6;
            dreamTextBox1.Text = "Sosunok228";
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(30, 46);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(99, 25);
            foreverLabel1.TabIndex = 7;
            foreverLabel1.Text = "Никнейм";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(30, 141);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(213, 20);
            headerLabel1.TabIndex = 10;
            headerLabel1.Text = "RAM(оператива): RAMValue";
            // 
            // crownComboBox1
            // 
            crownComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            crownComboBox1.FormattingEnabled = true;
            crownComboBox1.Location = new Point(30, 184);
            crownComboBox1.Name = "crownComboBox1";
            crownComboBox1.Size = new Size(121, 24);
            crownComboBox1.TabIndex = 11;
            crownComboBox1.SelectedIndexChanged += crownComboBox1_SelectedIndexChanged;
            // 
            // foreverButton1
            // 
            foreverButton1.BackColor = Color.Transparent;
            foreverButton1.BaseColor = Color.FromArgb(35, 168, 109);
            foreverButton1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            foreverButton1.Location = new Point(30, 325);
            foreverButton1.Name = "foreverButton1";
            foreverButton1.Rounded = false;
            foreverButton1.Size = new Size(310, 64);
            foreverButton1.TabIndex = 12;
            foreverButton1.Text = "ЗАПУСКАЙ!";
            foreverButton1.TextColor = Color.FromArgb(243, 243, 243);
            foreverButton1.MouseClick += foreverButton1_MouseClick;
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 25F);
            bigLabel1.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel1.Location = new Point(30, 404);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(0, 46);
            bigLabel1.TabIndex = 14;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(30, 467);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(696, 23);
            progressBar1.TabIndex = 15;
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 46, 46);
            ClientSize = new Size(925, 524);
            Controls.Add(progressBar1);
            Controls.Add(bigLabel1);
            Controls.Add(foreverButton1);
            Controls.Add(crownComboBox1);
            Controls.Add(headerLabel1);
            Controls.Add(foreverLabel1);
            Controls.Add(dreamTextBox1);
            Controls.Add(TopPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel TopPanel;
        private Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.CrownComboBox crownComboBox1;
        private ReaLTaiizor.Controls.ForeverButton foreverButton1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ProgressBar progressBar1;
    }
}
