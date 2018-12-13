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
    public partial class resizeForm : Form
    {
        public resizeForm()
        {
            InitializeComponent();
        }        

        private void resizeForm_Load(object sender, EventArgs e)
        {
            Steganography steForm = new Steganography();
            widthValue.Text = steForm.pictureBox1.Width.ToString();
            heightValue.Text = steForm.pictureBox1.Height.ToString();
        }
    }
}
