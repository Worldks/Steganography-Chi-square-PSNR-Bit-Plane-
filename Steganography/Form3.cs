using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form3 : Form
    {
        //public Form3()
        //{
        //    InitializeComponent();
        //}

        private string channel;
        private byte bitPlane;
        private byte channelNumber;
        private byte lastPressOption;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

                    //  FileInfo file = new FileInfo($"{ofd.FileName}");
                    //imageInformationLabel.Text = file.Name;

                    //file.LastWriteTime
                    //  imageInformationLabel.Text += "  |   " + file.Length / 1024 + "KB    |  " + file.CreationTime + "    Data created   |   " + file.Extension + "  Extension   |   " + file.LastWriteTime + "   LastWriteTime " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height;

                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                    pictureBox2.Image = new Bitmap(ofd.FileName);

                    // FileInfo file = new FileInfo($"{ofd.FileName}");
                    // imageInformationLabel.Text = file.Name;

                    //file.LastWriteTime
                    // imageInformationLabel.Text += "  |   " + file.Length / 1024 + "KB    |  " + file.CreationTime + "    Data created   |   " + file.Extension + "  Extension   |   " + file.LastWriteTime + "   LastWriteTime " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height;

                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Значение PSNR : ";

            Bitmap input = new Bitmap(pictureBox1.Image);
            Bitmap input2 = new Bitmap(pictureBox2.Image);
            double mse = 0;
            double mse_R = 0;
            // double mse_G = 0;
            //double mse_B = 0;
            for (int color = 0; color < 3; color++)
            {
                for (int i = 0; i < input.Width; i++)
                {
                    for (int j = 0; j < input.Height; j++)
                    {
                        Color pixel = input.GetPixel(i, j);
                        Color pixel2 = input2.GetPixel(i, j);
                        if (color == 0)
                        {
                            mse_R += Math.Pow(pixel.R - pixel2.R, 2);
                        }
                        if (color == 1)
                        {
                            mse_R += Math.Pow(pixel.G - pixel2.G, 2);
                        }
                        if (color == 2)
                        {
                            mse_R += Math.Pow(pixel.B - pixel2.B, 2);
                        }
                    }
                }
                mse += mse_R / (input.Width * input.Height);
                mse_R = 0;
            }
            mse = mse / 3;
            // double psnr = 20 * Math.Log10(16777215 / Math.Sqrt(mse));
            double psnr = 10 * Math.Log10(Math.Pow(255, 2) / mse);
            label1.Text = label1.Text + " " + psnr.ToString();
        }

    }
}
