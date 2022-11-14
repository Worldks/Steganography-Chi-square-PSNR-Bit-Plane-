namespace Steganography
{
    public partial class Form1 : Form
    {

        //  ���������� ������ ����������� ���������� ���� �����. ��� ����� ����������� � ��� ������� ���������.
        private string channel;
        private byte bitPlane;
        private byte channelNumber;
        private byte lastPressOption;

        public Form1()
        {
            InitializeComponent();            
        }

        //��������� ��������� ��� ������ ����� � �������� �����������       ����� ���������� � �����(����������)
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ������ ��� ������ �����
            OpenFileDialog ofd = new OpenFileDialog();
            // ������ �������� ������
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // ���� � ������� ���� ������ ������ ��
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // ��������� �����������
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    
                    FileInfo file = new FileInfo($"{ofd.FileName}");                    
                    imageInformationLabel.Text = file.Name;

                    //file.LastWriteTime
                    imageInformationLabel.Text += "  |   " + file.Length / 1024 + "KB    |  " + file.CreationTime + "    Data created   |   " + file.Extension + "  Extension   |   " + file.LastWriteTime + "   LastWriteTime " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height;

                }
                catch // � ������ ������ ������� MessageBox
                {
                    MessageBox.Show("���������� ������� ��������� ����", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //��������� ��������� ��� ���������� ���������������� ����� �� Picturebox2 � �������� �����������
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) // ���� ����������� � pictureBox2 �������
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "��������� �������� ���...";
                sfd.OverwritePrompt = true; // ���������� �� "������������ ����" ���� ������������ ��������� ��� �����, ������� ��� ����������
                sfd.CheckPathExists = true; // ���������� �� ���������� ���� ��������������, ���� ������������ ��������� ����, ������� �� ����������
                                            // ������ �������� ������
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                sfd.ShowHelp = true; // ������������ �� ������ ������� � ���������� ����
                                     // ���� � ������� ���� ������ ������ ��
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // ��������� �����������
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch // � ������ ������ ������� MessageBox
                    {
                        MessageBox.Show("���������� ��������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("���������� ��������� �����������", "������",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ��������� �������� ����� �����������
        private void comBoxOfChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            channel = comBoxOfChannels.Text;
            //MessageBox.Show($"{channel}", "������",
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //������������� �������� ������� � ��� byte
            switch (channel)
            {
                case "A":
                    channelNumber = 0;
                    break;
                case "R":
                    channelNumber = 1;
                    break;
                case "G":
                    channelNumber = 2;
                    break;
                case "B":
                    channelNumber = 3;
                    break;
            }
        }

        // ��������� �������� ������� ��������� �����������
        private void comBoxOfBitPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bitPlane = byte.Parse(comBoxOfBitPlanes.Text);
            //MessageBox.Show($"{bitPlane}", "������",
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);

            //
            if(lastPressOption == 1)
            {
                checkBoxAllChannelsPressMoreThenOnes();
            }else if(lastPressOption == 2)
            {
                SomeChannelPressMoreThenOnes();
            }

        }

        //���������� ����������� � Picturebox2 ��� ������� �� ��
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Image != null)
            {
                Form2 imageForm = new Form2(pictureBox2.Image);
                imageForm.Show();
            }
        }

        //���������� ����������� � Picturebox1 ��� ������� �� ��
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {                
                Form2 imageForm = new Form2(pictureBox1.Image);
                imageForm.Show();
            }
           
        }

        //������� ������ ����������� ����������� �� ��������� ������� (������ �� ��������)
        private void convertImage_Click(object sender, EventArgs e)
        {
            if (channel != null && bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //�� ������ ��������� ��������� �����
                lastPressOption = 2;

                // ������ Bitmap �� �����������, ������������ � pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // ������ Bitmap ��� �����-������ �����������
                Bitmap output = new Bitmap(input.Width, input.Height);
                // ���������� � ������ ��� ������� ��������� �����������
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // �������� ���� (i, j) ������� ��������� �����������
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                        // ��������� ������� ��������� ������������ ������
                        if (bitPlane != 1)
                        {
                            byte chek = (byte)(argbOfPexel[channelNumber] & (byte)Math.Pow(2, bitPlane - 1));
                            if (chek == 0)
                            {
                                output.SetPixel(i, j, Color.FromName("Black"));
                            }
                            else
                            {
                                output.SetPixel(i, j, Color.FromName("White"));
                            }
                        }
                        else if (bitPlane == 1)
                        {
                            byte chek = (byte)(argbOfPexel[channelNumber] & 1);
                            if (chek == 0)
                            {
                                output.SetPixel(i, j, Color.FromName("Black"));
                            }
                            else
                            {
                                output.SetPixel(i, j, Color.FromName("White"));
                            }
                        }
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("�� �� ����� ��� ����������� ��������� ��� �������������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //������� ������ ����������� ����������� �� ���� ������� (������ � ����� �����)
        private void allChannelsButton_Click(object sender, EventArgs e)
        {
            if (bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //�� ������ ��������� ��� ������
                lastPressOption = 1;

                // ������ Bitmap �� �����������, ������������ � pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // ������ Bitmap ��� �����-������ �����������
                Bitmap output = new Bitmap(input.Width, input.Height);
                // ���������� � ������ ��� ������� ��������� �����������
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // �������� ���� (i, j) ������� ��������� �����������
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };
                        int[] rgbNewPixel = new int[3] { 0, 0, 0 };

                        // ��������� ������� ��������� ������������ ������
                        if (bitPlane != 1)
                        {
                            for (int c = 1; c < 4; c++)
                            {
                                byte chek = (byte)(argbOfPexel[c] & (byte)Math.Pow(2, bitPlane - 1));
                                if (chek == 0)
                                {
                                    //output.SetPixel(i, j, Color.FromName("Black"));
                                    rgbNewPixel[c - 1] = 0;
                                }
                                else
                                {
                                    //output.SetPixel(i, j, Color.FromName("White"));
                                    rgbNewPixel[c - 1] = 255;
                                }
                            }
                        }
                        else if (bitPlane == 1)
                        {
                            for (int c = 1; c < 4; c++)
                            {
                                byte chek = (byte)(argbOfPexel[c] & 1);
                                if (chek == 0)
                                {
                                    //output.SetPixel(i, j, Color.FromName("Black"));
                                    rgbNewPixel[c - 1] = 0;
                                }
                                else
                                {
                                    //output.SetPixel(i, j, Color.FromName("White"));
                                    rgbNewPixel[c - 1] = 255;
                                }
                            }
                        }
                        // ���������� ����� �������� ������� � ����������� �-� �����������
                        output.SetPixel(i, j, Color.FromArgb(rgbNewPixel[0], rgbNewPixel[1], rgbNewPixel[2]));
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("�� �� ����� ��� ����������� ��������� ��� �������������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //����� ������ ����������� ����������� (�� ���� �������) ����� �������� ������� ������ �-� comBoxOfBitPlanes_SelectedIndexChanged ����� ��������� �� ������ ������ ��� ��������� ������
        private void checkBoxAllChannelsPressMoreThenOnes()
        {
            if (bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //�� ������ ��������� ��� ������
                lastPressOption = 1;

                // ������ Bitmap �� �����������, ������������ � pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // ������ Bitmap ��� �����-������ �����������
                Bitmap output = new Bitmap(input.Width, input.Height);
                // ���������� � ������ ��� ������� ��������� �����������
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // �������� ���� (i, j) ������� ��������� �����������
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };
                        int[] rgbNewPixel = new int[3] { 0, 0, 0 };

                        // ��������� ������� ��������� ������������ ������
                        if (bitPlane != 1)
                        {
                            for (int c = 1; c < 4; c++)
                            {
                                byte chek = (byte)(argbOfPexel[c] & (byte)Math.Pow(2, bitPlane - 1));
                                if (chek == 0)
                                {
                                    //output.SetPixel(i, j, Color.FromName("Black"));
                                    rgbNewPixel[c - 1] = 0;
                                }
                                else
                                {
                                    //output.SetPixel(i, j, Color.FromName("White"));
                                    rgbNewPixel[c - 1] = 255;
                                }
                            }
                        }
                        else if (bitPlane == 1)
                        {
                            for (int c = 1; c < 4; c++)
                            {
                                byte chek = (byte)(argbOfPexel[c] & 1);
                                if (chek == 0)
                                {
                                    //output.SetPixel(i, j, Color.FromName("Black"));
                                    rgbNewPixel[c - 1] = 0;
                                }
                                else
                                {
                                    //output.SetPixel(i, j, Color.FromName("White"));
                                    rgbNewPixel[c - 1] = 255;
                                }
                            }
                        }
                        // ���������� ����� �������� ������� � ����������� �-� �����������
                        output.SetPixel(i, j, Color.FromArgb(rgbNewPixel[0], rgbNewPixel[1], rgbNewPixel[2]));
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("�� �� ����� ��� ����������� ��������� ��� �������������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //����� ������ ����������� ����������� (�� ��������� �������) ����� �������� ������� ������ �-� comBoxOfBitPlanes_SelectedIndexChanged ����� ��������� �� ������ ������ ��� ��������� ������
        private void SomeChannelPressMoreThenOnes()
        {
            if (channel != null && bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //�� ������ ��������� ��������� �����
                lastPressOption = 2;

                // ������ Bitmap �� �����������, ������������ � pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // ������ Bitmap ��� �����-������ �����������
                Bitmap output = new Bitmap(input.Width, input.Height);
                // ���������� � ������ ��� ������� ��������� �����������
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // �������� ���� (i, j) ������� ��������� �����������
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                        // ��������� ������� ��������� ������������ ������
                        if (bitPlane != 1)
                        {
                            byte chek = (byte)(argbOfPexel[channelNumber] & (byte)Math.Pow(2, bitPlane - 1));
                            if (chek == 0)
                            {
                                output.SetPixel(i, j, Color.FromName("Black"));
                            }
                            else
                            {
                                output.SetPixel(i, j, Color.FromName("White"));
                            }
                        }
                        else if (bitPlane == 1)
                        {
                            byte chek = (byte)(argbOfPexel[channelNumber] & 1);
                            if (chek == 0)
                            {
                                output.SetPixel(i, j, Color.FromName("Black"));
                            }
                            else
                            {
                                output.SetPixel(i, j, Color.FromName("White"));
                            }
                        }
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("�� �� ����� ��� ����������� ��������� ��� �������������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //����� ������ ����������� ����������� (�� ��������� �������) ����� �������� ������� ������ �-� ���� ����(��������� ��������� ������ - �������) 
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (channel != null && bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //�� ������ ��������� ��������� �����
                lastPressOption = 2;

                // ������ Bitmap �� �����������, ������������ � pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // ������ Bitmap ��� �����-������ �����������
                Bitmap output = new Bitmap(input.Width, input.Height);
                // ���������� � ������ ��� ������� ��������� �����������
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // �������� ���� (i, j) ������� ��������� �����������
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                        // ��������� ������� ��������� ������������ ������
                        if (bitPlane != 1)
                        {
                            byte chek = (byte)(argbOfPexel[channelNumber] & (byte)Math.Pow(2, bitPlane - 1));
                            if (chek == 0)
                            {
                                output.SetPixel(i, j, Color.FromName("Black"));
                            }
                            else
                            {
                                output.SetPixel(i, j, Color.FromName("White"));
                            }
                        }
                        else if (bitPlane == 1)
                        {
                            byte chek = (byte)(argbOfPexel[channelNumber] & 1);
                            if (chek == 0)
                            {
                                output.SetPixel(i, j, Color.FromName("Black"));
                            }
                            else
                            {
                                output.SetPixel(i, j, Color.FromName("White"));
                            }
                        }
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("�� �� ����� ��� ����������� ��������� ��� �������������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ////����� ������ ����������� ����������� (�� ���� �������) ����� �������� ������� ������ �-� ���� ����(��������� ��������� ������ - �������) 
        private void allChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //�� ������ ��������� ��� ������
                lastPressOption = 1;

                // ������ Bitmap �� �����������, ������������ � pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // ������ Bitmap ��� �����-������ �����������
                Bitmap output = new Bitmap(input.Width, input.Height);
                // ���������� � ������ ��� ������� ��������� �����������
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // �������� ���� (i, j) ������� ��������� �����������
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };
                        int[] rgbNewPixel = new int[3] { 0, 0, 0 };

                        // ��������� ������� ��������� ������������ ������
                        if (bitPlane != 1)
                        {
                            for (int c = 1; c < 4; c++)
                            {
                                byte chek = (byte)(argbOfPexel[c] & (byte)Math.Pow(2, bitPlane - 1));
                                if (chek == 0)
                                {
                                    //output.SetPixel(i, j, Color.FromName("Black"));
                                    rgbNewPixel[c - 1] = 0;
                                }
                                else
                                {
                                    //output.SetPixel(i, j, Color.FromName("White"));
                                    rgbNewPixel[c - 1] = 255;
                                }
                            }
                        }
                        else if (bitPlane == 1)
                        {
                            for (int c = 1; c < 4; c++)
                            {
                                byte chek = (byte)(argbOfPexel[c] & 1);
                                if (chek == 0)
                                {
                                    //output.SetPixel(i, j, Color.FromName("Black"));
                                    rgbNewPixel[c - 1] = 0;
                                }
                                else
                                {
                                    //output.SetPixel(i, j, Color.FromName("White"));
                                    rgbNewPixel[c - 1] = 255;
                                }
                            }
                        }
                        // ���������� ����� �������� ������� � ����������� �-� �����������
                        output.SetPixel(i, j, Color.FromArgb(rgbNewPixel[0], rgbNewPixel[1], rgbNewPixel[2]));
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("�� �� ����� ��� ����������� ��������� ��� �������������� �����������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}