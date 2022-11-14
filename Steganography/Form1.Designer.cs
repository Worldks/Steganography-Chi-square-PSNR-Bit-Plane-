namespace Steganography
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chisquareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOfChannels = new System.Windows.Forms.Label();
            this.labelOfBitPlanes = new System.Windows.Forms.Label();
            this.comBoxOfBitPlanes = new System.Windows.Forms.ComboBox();
            this.comBoxOfChannels = new System.Windows.Forms.ComboBox();
            this.convertImage = new System.Windows.Forms.Button();
            this.allChannelsPicture = new System.Windows.Forms.Label();
            this.allChannelsButton = new System.Windows.Forms.Button();
            this.imageInformationLabel = new System.Windows.Forms.Label();
            this.textBoxEmbeddedMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(54, 84);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(560, 1080);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(400, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(616, 84);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(560, 1080);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(400, 400);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.attackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.allChannelsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.convertToolStripMenuItem.Text = "Преобразовать";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // allChannelsToolStripMenuItem
            // 
            this.allChannelsToolStripMenuItem.Name = "allChannelsToolStripMenuItem";
            this.allChannelsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.allChannelsToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.allChannelsToolStripMenuItem.Text = "\"Собранный\" вид";
            this.allChannelsToolStripMenuItem.Click += new System.EventHandler(this.allChannelsToolStripMenuItem_Click);
            // 
            // attackToolStripMenuItem
            // 
            this.attackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chisquareToolStripMenuItem,
            this.pSNRToolStripMenuItem});
            this.attackToolStripMenuItem.Name = "attackToolStripMenuItem";
            this.attackToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.attackToolStripMenuItem.Text = "Attack";
            // 
            // chisquareToolStripMenuItem
            // 
            this.chisquareToolStripMenuItem.Name = "chisquareToolStripMenuItem";
            this.chisquareToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.chisquareToolStripMenuItem.Text = "Chi-square";
            this.chisquareToolStripMenuItem.Click += new System.EventHandler(this.chisquareToolStripMenuItem_Click);
            // 
            // pSNRToolStripMenuItem
            // 
            this.pSNRToolStripMenuItem.Name = "pSNRToolStripMenuItem";
            this.pSNRToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.pSNRToolStripMenuItem.Text = "PSNR";
            this.pSNRToolStripMenuItem.Click += new System.EventHandler(this.pSNRToolStripMenuItem_Click);
            // 
            // labelOfChannels
            // 
            this.labelOfChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOfChannels.AutoSize = true;
            this.labelOfChannels.Location = new System.Drawing.Point(73, 585);
            this.labelOfChannels.Name = "labelOfChannels";
            this.labelOfChannels.Size = new System.Drawing.Size(58, 20);
            this.labelOfChannels.TabIndex = 5;
            this.labelOfChannels.Text = "Канал :";
            this.labelOfChannels.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelOfBitPlanes
            // 
            this.labelOfBitPlanes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOfBitPlanes.AutoSize = true;
            this.labelOfBitPlanes.Location = new System.Drawing.Point(293, 585);
            this.labelOfBitPlanes.Name = "labelOfBitPlanes";
            this.labelOfBitPlanes.Size = new System.Drawing.Size(147, 20);
            this.labelOfBitPlanes.TabIndex = 6;
            this.labelOfBitPlanes.Text = "Битовая плоскость :";
            this.labelOfBitPlanes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comBoxOfBitPlanes
            // 
            this.comBoxOfBitPlanes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comBoxOfBitPlanes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxOfBitPlanes.FormattingEnabled = true;
            this.comBoxOfBitPlanes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comBoxOfBitPlanes.Location = new System.Drawing.Point(446, 582);
            this.comBoxOfBitPlanes.Name = "comBoxOfBitPlanes";
            this.comBoxOfBitPlanes.Size = new System.Drawing.Size(73, 28);
            this.comBoxOfBitPlanes.TabIndex = 7;
            this.comBoxOfBitPlanes.SelectedIndexChanged += new System.EventHandler(this.comBoxOfBitPlanes_SelectedIndexChanged);
            // 
            // comBoxOfChannels
            // 
            this.comBoxOfChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comBoxOfChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxOfChannels.FormattingEnabled = true;
            this.comBoxOfChannels.Items.AddRange(new object[] {
            "A",
            "R",
            "G",
            "B"});
            this.comBoxOfChannels.Location = new System.Drawing.Point(137, 582);
            this.comBoxOfChannels.Name = "comBoxOfChannels";
            this.comBoxOfChannels.Size = new System.Drawing.Size(73, 28);
            this.comBoxOfChannels.TabIndex = 8;
            this.comBoxOfChannels.SelectedIndexChanged += new System.EventHandler(this.comBoxOfChannels_SelectedIndexChanged);
            // 
            // convertImage
            // 
            this.convertImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.convertImage.Location = new System.Drawing.Point(765, 582);
            this.convertImage.Name = "convertImage";
            this.convertImage.Size = new System.Drawing.Size(73, 28);
            this.convertImage.TabIndex = 9;
            this.convertImage.Text = ">";
            this.convertImage.UseVisualStyleBackColor = true;
            this.convertImage.Click += new System.EventHandler(this.convertImage_Click);
            // 
            // allChannelsPicture
            // 
            this.allChannelsPicture.AutoSize = true;
            this.allChannelsPicture.Location = new System.Drawing.Point(197, 45);
            this.allChannelsPicture.Name = "allChannelsPicture";
            this.allChannelsPicture.Size = new System.Drawing.Size(472, 20);
            this.allChannelsPicture.TabIndex = 10;
            this.allChannelsPicture.Text = "Представить в виде \"собранного\" изображения без альфа канала";
            // 
            // allChannelsButton
            // 
            this.allChannelsButton.Location = new System.Drawing.Point(675, 45);
            this.allChannelsButton.Name = "allChannelsButton";
            this.allChannelsButton.Size = new System.Drawing.Size(94, 29);
            this.allChannelsButton.TabIndex = 11;
            this.allChannelsButton.Text = "OK";
            this.allChannelsButton.UseVisualStyleBackColor = true;
            this.allChannelsButton.Click += new System.EventHandler(this.allChannelsButton_Click);
            // 
            // imageInformationLabel
            // 
            this.imageInformationLabel.AutoSize = true;
            this.imageInformationLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.imageInformationLabel.Location = new System.Drawing.Point(0, 648);
            this.imageInformationLabel.Name = "imageInformationLabel";
            this.imageInformationLabel.Size = new System.Drawing.Size(225, 20);
            this.imageInformationLabel.TabIndex = 12;
            this.imageInformationLabel.Text = "Информация об изображении";
            // 
            // textBoxEmbeddedMessage
            // 
            this.textBoxEmbeddedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmbeddedMessage.Location = new System.Drawing.Point(460, 104);
            this.textBoxEmbeddedMessage.Multiline = true;
            this.textBoxEmbeddedMessage.Name = "textBoxEmbeddedMessage";
            this.textBoxEmbeddedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEmbeddedMessage.Size = new System.Drawing.Size(150, 353);
            this.textBoxEmbeddedMessage.TabIndex = 13;
            this.textBoxEmbeddedMessage.Text = "Строки с возможным вложенным сообщением по методу Хи-квадрат";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1081, 668);
            this.Controls.Add(this.textBoxEmbeddedMessage);
            this.Controls.Add(this.imageInformationLabel);
            this.Controls.Add(this.allChannelsButton);
            this.Controls.Add(this.allChannelsPicture);
            this.Controls.Add(this.convertImage);
            this.Controls.Add(this.comBoxOfChannels);
            this.Controls.Add(this.comBoxOfBitPlanes);
            this.Controls.Add(this.labelOfBitPlanes);
            this.Controls.Add(this.labelOfChannels);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1259, 1080);
            this.MinimumSize = new System.Drawing.Size(1099, 715);
            this.Name = "Form1";
            this.Text = "StegAnaliz";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private Label labelOfChannels;
        private Label labelOfBitPlanes;
        private ComboBox comBoxOfBitPlanes;
        private ComboBox comBoxOfChannels;
        private Button convertImage;
        private Label allChannelsPicture;
        private Button allChannelsButton;
        private ToolStripMenuItem convertToolStripMenuItem;
        private ToolStripMenuItem allChannelsToolStripMenuItem;
        private Label imageInformationLabel;
        private ToolStripMenuItem attackToolStripMenuItem;
        private ToolStripMenuItem chisquareToolStripMenuItem;
        private ToolStripMenuItem pSNRToolStripMenuItem;
        private TextBox textBoxEmbeddedMessage;
    }
}