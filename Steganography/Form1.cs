namespace Steganography
{
    public partial class Form1 : Form
    {

        //  Необходимо содать статические переменные этой формы. Это Канал изображения и его битовая плоскасть.
        private string channel;
        private byte bitPlane;
        private byte channelNumber;
        private byte lastPressOption;

        public Form1()
        {
            InitializeComponent();            
        }

        //Открывает проводник для выбора файла с заданным расширением       ВЫВОД ИНФОРМАЦИЮ О ФАЙЛЕ(КОНТЕЙНЕРЕ)
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // диалог для выбора файла
            OpenFileDialog ofd = new OpenFileDialog();
            // фильтр форматов файлов
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // загружаем изображение
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    
                    FileInfo file = new FileInfo($"{ofd.FileName}");                    
                    imageInformationLabel.Text = file.Name;

                    //file.LastWriteTime
                    imageInformationLabel.Text += "  |   " + file.Length / 1024 + "KB    |  " + file.CreationTime + "    Data created   |   " + file.Extension + "  Extension   |   " + file.LastWriteTime + "   LastWriteTime " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height;

                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Открывает проводник для сохранения преобразованного файла из Picturebox2 с заданным расширением
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) // если изображение в pictureBox2 имеется
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true; // показывать ли "Перезаписать файл" если пользователь указывает имя файла, который уже существует
                sfd.CheckPathExists = true; // отображает ли диалоговое окно предупреждение, если пользователь указывает путь, который не существует
                                            // фильтр форматов файлов
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                sfd.ShowHelp = true; // отображается ли кнопка Справка в диалоговом окне
                                     // если в диалоге была нажата кнопка ОК
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // сохраняем изображение
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch // в случае ошибки выводим MessageBox
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Установка значения канал изображения
        private void comBoxOfChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            channel = comBoxOfChannels.Text;
            //MessageBox.Show($"{channel}", "Ошибка",
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Устанавливаем значение каннала в тип byte
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

        // Установка значения битовой плоскости изображения
        private void comBoxOfBitPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bitPlane = byte.Parse(comBoxOfBitPlanes.Text);
            //MessageBox.Show($"{bitPlane}", "Ошибка",
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

        //Увеличение изображения в Picturebox2 при нажатии на неё
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Image != null)
            {
                Form2 imageForm = new Form2(pictureBox2.Image);
                imageForm.Show();
            }
        }

        //Увеличение изображения в Picturebox1 при нажатии на неё
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {                
                Form2 imageForm = new Form2(pictureBox1.Image);
                imageForm.Show();
            }
           
        }

        //Нажатие кнопки конвертации изображения по ОТДЕЛЬНЫМ КАНАЛАМ (кнопка по середине)
        private void convertImage_Click(object sender, EventArgs e)
        {
            if (channel != null && bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //Мы нажали последним НЕКОТОРЫЙ КАНАЛ
                lastPressOption = 2;

                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем цвет (i, j) пикселя исходного изображения
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                        // Проверяем битовую плоскость необходимого канала
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
                MessageBox.Show("Вы не ввели все необходимые параметры для преобразования изображения", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Нажатие кнопки конвертации изображения по ВСЕМ КАНАЛАМ (кнопка в самом верху)
        private void allChannelsButton_Click(object sender, EventArgs e)
        {
            if (bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //Мы нажали последним ВСЕ КАНАЛЫ
                lastPressOption = 1;

                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем цвет (i, j) пикселя исходного изображения
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };
                        int[] rgbNewPixel = new int[3] { 0, 0, 0 };

                        // Проверяем битовую плоскость необходимого канала
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
                        // Установить новое значение пикселя с измененными з-и компонентов
                        output.SetPixel(i, j, Color.FromArgb(rgbNewPixel[0], rgbNewPixel[1], rgbNewPixel[2]));
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("Вы не ввели все необходимые параметры для преобразования изображения", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Вызов метода конвертации изображения (по ВСЕМ каналам) через обработу события выбора з-я comBoxOfBitPlanes_SelectedIndexChanged ЧТОБЫ ПОСТОЯННО НЕ ТЫКАТЬ КНОПКУ ИЛИ СОЧЕТАНИЕ КЛАВИШ
        private void checkBoxAllChannelsPressMoreThenOnes()
        {
            if (bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //Мы нажали последним ВСЕ КАНАЛЫ
                lastPressOption = 1;

                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем цвет (i, j) пикселя исходного изображения
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };
                        int[] rgbNewPixel = new int[3] { 0, 0, 0 };

                        // Проверяем битовую плоскость необходимого канала
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
                        // Установить новое значение пикселя с измененными з-и компонентов
                        output.SetPixel(i, j, Color.FromArgb(rgbNewPixel[0], rgbNewPixel[1], rgbNewPixel[2]));
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("Вы не ввели все необходимые параметры для преобразования изображения", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Вызов метода конвертации изображения (по ОТДЕЛЬНЫМ каналам) через обработу события выбора з-я comBoxOfBitPlanes_SelectedIndexChanged ЧТОБЫ ПОСТОЯННО НЕ ТЫКАТЬ КНОПКУ ИЛИ СОЧЕТАНИЕ КЛАВИШ
        private void SomeChannelPressMoreThenOnes()
        {
            if (channel != null && bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //Мы нажали последним НЕКОТОРЫЙ КАНАЛ
                lastPressOption = 2;

                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем цвет (i, j) пикселя исходного изображения
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                        // Проверяем битовую плоскость необходимого канала
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
                MessageBox.Show("Вы не ввели все необходимые параметры для преобразования изображения", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Вызов метода конвертации изображения (по ОТДЕЛЬНЫМ каналам) через обработу события выбора з-я поля меню(используя сочетание клавиш - костыль) 
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (channel != null && bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //Мы нажали последним НЕКОТОРЫЙ КАНАЛ
                lastPressOption = 2;

                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем цвет (i, j) пикселя исходного изображения
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };

                        // Проверяем битовую плоскость необходимого канала
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
                MessageBox.Show("Вы не ввели все необходимые параметры для преобразования изображения", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ////Вызов метода конвертации изображения (по ВСЕМ каналам) через обработу события выбора з-я поля меню(используя сочетание клавиш - костыль) 
        private void allChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitPlane <= 8 && bitPlane >= 1 && pictureBox1.Image != null)
            {
                //Мы нажали последним ВСЕ КАНАЛЫ
                lastPressOption = 1;

                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем цвет (i, j) пикселя исходного изображения
                        Color pixel = input.GetPixel(i, j);

                        byte[] argbOfPexel = new byte[4] { pixel.A, pixel.R, pixel.G, pixel.B };
                        int[] rgbNewPixel = new int[3] { 0, 0, 0 };

                        // Проверяем битовую плоскость необходимого канала
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
                        // Установить новое значение пикселя с измененными з-и компонентов
                        output.SetPixel(i, j, Color.FromArgb(rgbNewPixel[0], rgbNewPixel[1], rgbNewPixel[2]));
                    }
                pictureBox2.Image = output;
            }
            else
            {
                MessageBox.Show("Вы не ввели все необходимые параметры для преобразования изображения", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}