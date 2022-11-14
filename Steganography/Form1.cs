namespace Steganography
{
    public partial class Form1 : Form
    {

        //  ���������� ������ ����������� ���������� ���� �����. ��� ����� ����������� � ��� ������� ���������.
        private string channel;
        private byte bitPlane;
        private byte channelNumber;         //��������� ������  A = 0 R = 1 G = 2 B = 3
        private byte lastPressOption;
        string defaultStroka = "������ � ��������� ��������� ���������� �� ������ ��-�������";
        Bitmap originImage;     // �������� ������������ ��� ���������� �� �� ����� ��-�������

        public Form1()
        {
            InitializeComponent();            
        }

        //��������� ��������� ��� ������ ����� � �������� �����������       ����� ���������� � �����(����������)
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxEmbeddedMessage.Text = "������ � ��������� ��������� ���������� �� ������ ��-�������";


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

        //Chi-square ����� ��-�������
        private void chisquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // ���� ����������� � pictureBox1 �������
            {
                textBoxEmbeddedMessage.Text = "�������� �������� �� ��������� ������ : ";

                Bitmap input = new Bitmap(pictureBox1.Image);

                originImage = input;
                //bool res = isImgeHasEmbeddedMessageVStrokach2(414);
                bool[] isMessageInImageStroky = isImgeHasEmbeddedMessageVStrokach();

                for (int i = 0; i < originImage.Height; i++)
                {
                    if (isMessageInImageStroky[i])
                    {
                        //Console.WriteLine("� ������ {i} ���� ������� ���������");
                        //MessageBox.Show($"{i}", "������",
                        //   MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBoxEmbeddedMessage.Text = textBoxEmbeddedMessage.Text + " " + i.ToString();
                    }
                    else
                    {
                        //MessageBox.Show("������� �������� � �������������� �� ����������", "������",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("�� �� ������� �����������", "������",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �������� ����� ��-�������
        public bool[] isImgeHasEmbeddedMessageVStrokach()
        {
            int[] PoVs = new int[256];     // ������ ��� �������� ���(�� 128, �� �������� 256)  ����������� PoVs
            double chiSquareFacticheskiy = 0;
            double chiSquareCritical = 0;
            int zeroCountPoVsTeoretic = 0;
            //int stepenSvobody = 128;
            //List<bool> strokaMessege = new List<bool>();
            bool[] strokaMessage = new bool[originImage.Height];            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1

            //�-� ��-������� ������������ ��� ���� = 0.05 � ������ �������� ������� �� 1 �� 128
            double[] chiSquareCriticalConstant = new double[127] { 3.841458821, 5.991464547, 7.814727903, 9.487729037, 11.07049769, 12.59158724, 14.06714045, 15.50731306,
                    16.9189776, 18.30703805, 19.67513757, 21.02606982, 22.36203249, 23.6847913, 24.99579014, 26.2962276, 27.58711164, 28.86929943, 30.14352721, 31.41043284,
                    32.67057334, 33.92443847, 35.17246163, 36.4150285, 37.65248413, 38.88513866, 40.11327207, 41.33713815, 42.5569678, 43.77297183, 44.98534328, 46.19425952,
                    47.39988392, 48.60236737, 49.80184957, 50.99846017, 52.19231973, 53.38354062, 54.57222776, 55.75847928, 56.94238715, 58.12403768, 59.30351203, 60.48088658,
                    61.65623338, 62.82962041, 64.00111197, 65.1707689, 66.33864886, 67.50480655, 68.66929391, 69.83216034, 70.99345283, 72.15321617, 73.31149303, 74.46832416, 75.62374847,
                    76.77780316, 77.93052381, 79.08194449, 80.23209785, 81.38101519, 82.52872654, 83.67526074, 84.8206455, 85.96490744, 87.1080722, 88.25016442, 89.39120787,
                    90.53122543, 91.67023918, 92.80827038, 93.9453396, 95.08146667, 96.21667075, 97.35097038, 98.48438346, 99.61692732, 100.7486187, 100.879474, 103.0095087,
                    104.1387382, 105.2671773, 106.3948402, 107.521741, 108.647893, 109.7733094, 110.8980028, 112.0219857, 113.1452701, 114.2678677, 115.3897897, 116.5110473,
                    117.6316511, 118.7516118, 119.8709393, 120.9896437, 122.1077346, 123.2252215, 124.3421134, 125.4584194, 126.5741482, 127.6893083, 128.8039079, 129.9179553,
                    131.0314583, 132.1444245, 133.2568617, 134.3687771, 135.4801779, 136.5910712, 137.7014639, 138.8113626, 139.9207739, 141.0297043, 142.13816, 143.2461473,
                    144.353672, 145.4607402, 146.5673576, 147.6735298, 148.7792623, 149.8845606, 150.98943, 152.0938757, 153.1979027, 154.3015162 };

            for (int j = 0; j < originImage.Height; j++)
            {
                for (int i = 0; i < originImage.Width; i++)     // ����������� �� ���� ������ �����������
                {
                    Color pixel = originImage.GetPixel(i, j);

                    byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                    byte valueOfImageChannel = argbOfPexel[channelNumber];         // �-� ��������������� ������ ��� ����� �����������

                    PoVs[valueOfImageChannel] += 1;
                }

                // ���������� ������������� PoVs
                int[] PoVs_Teoretic = new int[128];

                for (int i = 0; i < 128; i++)
                {
                    PoVs_Teoretic[i] = (PoVs[i * 2] + PoVs[i * 2 + 1]) / 2;     // ������ ������� ������� �����
                }

                // ������� ��-������� �����������
                for (int i = 0; i < 128; i++)
                {
                    if (PoVs_Teoretic[i] != 0)
                    {
                        chiSquareFacticheskiy += (PoVs[i * 2] - PoVs_Teoretic[i]) * (PoVs[i * 2] - PoVs_Teoretic[i]) / PoVs_Teoretic[i];
                    }
                    else
                    {
                        zeroCountPoVsTeoretic += 1;
                    }
                }

                if (zeroCountPoVsTeoretic == 127)  // ��������� ��� ��-�������� � ������ ������� ����������   ����� �������� ��� ����� ������� ���������� !!!!!!!!!!!!!!!!!!!!!!
                {
                    int temp = 0;

                    for (int i = 0; i < 127; i++)
                    {
                        if (PoVs_Teoretic[i] != 0)
                        {
                            temp = PoVs[i * 2] * 100 / PoVs_Teoretic[i];        //������� ��������� �������� ������������ �-� �� �������������� �����

                            if (temp <= 108 && temp >= 92)
                            {
                                strokaMessage[j] = true;    //(���� ���������)
                            }

                            strokaMessage[j] = false;   // ������ �� (false ��������� ���)
                        }
                    }
                }
                else
                {
                    // ��������� ����������� �������� �������� ��-�������
                    chiSquareCritical = chiSquareCriticalConstant[126 - zeroCountPoVsTeoretic];

                    if (chiSquareCritical < (double)chiSquareFacticheskiy)
                    {
                        strokaMessage[j] = false;   // ������ �� (false ��������� ���)
                    }
                    else
                    {
                        strokaMessage[j] = true;    //(���� ���������)
                    }
                }

                // �������� ����� �� ���������� ��������
                zeroCountPoVsTeoretic = 0;
                chiSquareFacticheskiy = 0;
                for (int k = 0; k < 256; k++)
                {
                    PoVs[k] = 0;
                }
            }

            return strokaMessage;
        }

        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 psnr = new Form3();
            psnr.Show();
        }
    }
}