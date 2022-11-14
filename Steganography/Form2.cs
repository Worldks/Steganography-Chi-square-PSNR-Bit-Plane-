using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Image img)
        {
            InitializeComponent();

            this.BackgroundImage = img;                        
            this.Size = new Size(img.Width, img.Height);
            this.BackgroundImageLayout = ImageLayout.Zoom;

            //f.BackColor = Color.Yellow;
        }
    }
}
