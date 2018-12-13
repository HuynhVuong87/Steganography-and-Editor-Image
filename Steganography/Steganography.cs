
    //-----------------KHAI BÁO THƯ VIỆN--------------------//
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace Steganography
{
    public partial class Steganography : Form
    {
        private Bitmap bmp = null;  // khai báo biến Bitmap
        Image file = null;  // khai báo biến file để mở ảnh
        Boolean bHaveMouse; // khai báo biến kiểm tra đã vẽ hình chưa cho việc crop hình
        Point ptOriginal = new Point(); // khai báo điểm chuột khởi tạo
        Point ptLast = new Point(); // khai báo điểm chuột cuối
        Rectangle rectCropArea; // khai báo hình chữ nhật giả lập để crop hình
        Boolean opened = false; // khai báo biến kiểm tra xem đã mở ảnh chưa
        Boolean openedStego = false; // khai báo biến kiểm tra xem đã mở ảnh để đọc giấu tin chưa
        private string extractedText = string.Empty;    // biến chứa đoạn tin cần giấu
        int i = 1; // biến kiểm tra hình xoay ngang hay dọc
        public Steganography()
        {
            InitializeComponent();
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
            bHaveMouse = false;
        }

     //---------------------------------------FUNCTION---------------------------------------//

        //--Hàm mở hình ảnh từ file local--//
        void openImage(PictureBox pictureBox) 
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // file = Image.FromFile(openFileDialog1.FileName);
                Bitmap bit = new Bitmap(openFileDialog1.FileName);
                pictureBox.Image = bit;
                opened = true;
            }
        }

        //--Hàm lưu hình ảnh từ pictureBox--//
        void saveImage(PictureBox pictureBox)
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog(); // create a new save file dialog object
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;// you want to store it in by default format
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox.Image.Save(sfd.FileName, format);
                }



            }
            else { MessageBox.Show("No image loaded, first upload image "); }

        }

        //--Hàm load lại ảnh gốc sau khi chỉnh sửa--//
        void reload()
        {
            if (!opened)
            {
                // MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                if (opened)
                {
                    Size origin = new Size(864, 528);
                    pictureBox1.Size = origin;
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }

        //--Hàm chỉnh màu RBG--//
        void hue()
        {
            float changered = redbar.Value * 0.1f; //giá trị thay đổi màu đỏ
            float changegreen = greenbar.Value * 0.1f; //giá trị thay đổi màu xanh lục
            float changeblue = bluebar.Value * 0.1f; //giá trị thay đổi màu xanh lam

            redvalue.Text = changered.ToString();
            greenvalue.Text = changeblue.ToString();
            bluevalue.Text = changegreen.ToString();

            reload(); // load lại ảnh gốc

            if (!opened) { //kiểm tra xem đã có ảnh trong pictureBox chưa?
                MessageBox.Show("Vui Lòng Mở Một Hình Ảnh Để Chỉnh Sửa", "Warning");
            } 
            else //nếu có rồi
            {
                Image img = pictureBox1.Image;                             // Lưu ảnh trong pictureBox1 sang kiểu dữ liệu Image
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   // Tạo bitmap với chiều dài = pictureBox1.width và chiều rộng = pictureBox1.height

                ImageAttributes ia = new ImageAttributes();                 //tạo đối tượng imageAttribute để thay đổi thuộc tính của ảnh
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       // tạo ma trận để thay đổi hiệu ứng trên ảnh
                {
                    new float[]{1+changered, 0, 0, 0, 0},
                    new float[]{0, 1+changegreen, 0, 0, 0},
                    new float[]{0, 0, 1+changeblue, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);   //chuyển ma trận màu sang thuộc tính của ảnh
                Graphics g = Graphics.FromImage(bmpInverted);  /*Tạo biến graphic để thay đổi lên ảnh.
                                                            Graphics newGraphics = Graphics.FromImage(imageFile); để định dạng ảnh sang graphic để thay đổi hiệu ứng*/

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                /* vẽ hình với graphics kèm sự thay đổi các thuộc tính */

                g.Dispose();                            
                pictureBox1.Image = bmpInverted; // gán graphic được thay đổi ở trên vào ảnh trong pictureBox1

            }
        }

        void redscale()
        {
            if (!opened)
            {
                MessageBox.Show("Vui Lòng Mở Một Hình Ảnh Để Chỉnh Sửa", "Warning");
            }
            else
            {

                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);                                                                        

                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f, .349f, .272f, 0, 0},
                    new float[]{.769f, .686f, .534f, 0, 0},
                    new float[]{.189f, .168f, .131f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);   
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }
        }

        void grayscale()
        {
            if (!opened)
            {
                MessageBox.Show("Vui Lòng Mở Một Hình Ảnh Để Chỉnh Sửa", "Warning");
            }
            else
            {
                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{0.299f, 0.299f, 0.299f, 0, 0},
                    new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                    new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 0}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);                                                            

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();         
                pictureBox1.Image = bmpInverted;
            }
        }

        void winter()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1,0,0,0,0},
                    new float[]{0,1,0,0,0},
                    new float[]{0,0,1,0,0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 1, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);   
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }
        }

        void filter3()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f+0.3f, .349f, .272f, 0, 0},
                    new float[]{.769f, .686f+0.2f, .534f, 0, 0},
                    new float[]{.189f, .168f, .131f+0.9f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);   
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();                           
                pictureBox1.Image = bmpInverted;

            }
        }

        //--Sự kiện con trỏ chuột di chuyển xuống dưới ở pictureBox1--//
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (opened)
            {
                bHaveMouse = false; 

                ptLast.X = -1;
                ptLast.Y = -1;
                ptOriginal.X = -1;
                ptOriginal.Y = -1;
            }
        }
                
        //--Sự kiện con trỏ chuột di chuyển xuống dưới ở pictureBox1--//
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (opened)
            {
                bHaveMouse = true;
                ptOriginal.X = e.X;
                ptOriginal.Y = e.Y;

                ptLast.X = -1;
                ptLast.Y = -1;

                // khởi tạo kích thước hình chữ nhật khi di chuyển chuột
                rectCropArea = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }

        //--Sự kiện con trỏ chuột di chuyển ở pictureBox1--//
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);

            if (bHaveMouse && opened)
            {
                ptLast = ptCurrent;

                // set kích thước cho hình chữ nhật
                if (e.X > ptOriginal.X && e.Y > ptOriginal.Y)
                {
                    rectCropArea.Width = e.X - ptOriginal.X;
                    rectCropArea.Height = e.Y - ptOriginal.Y;
                }
                else if (e.X < ptOriginal.X && e.Y > ptOriginal.Y)
                {
                    rectCropArea.Width = ptOriginal.X - e.X;
                    rectCropArea.Height = e.Y - ptOriginal.Y;

                    rectCropArea.X = e.X;
                    rectCropArea.Y = ptOriginal.Y;
                }
                else if (e.X > ptOriginal.X && e.Y < ptOriginal.Y)
                {
                    rectCropArea.Width = e.X - ptOriginal.X;
                    rectCropArea.Height = ptOriginal.Y - e.Y;

                    rectCropArea.X = ptOriginal.X;
                    rectCropArea.Y = e.Y;
                }
                else
                {
                    rectCropArea.Width = ptOriginal.X - e.X;
                    rectCropArea.Height = ptOriginal.Y - e.Y;

                    rectCropArea.X = e.X;
                    rectCropArea.Y = e.Y;
                }
                pictureBox1.Refresh();
            }
        }

        //-- Vẽ hình chữ nhật trên pictureBox1 bằng con trỏ chuột--//
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (opened)
            {
                Pen drawLine = new Pen(Color.White, 2); // tạo đường màu trắng size = 2
                drawLine.DashStyle = DashStyle.Dash; // kiểu dash (--------)
                e.Graphics.DrawRectangle(drawLine, rectCropArea); //vẽ hình chữ nhật được tạo ở trên lên pictureBox1
            }
            
        }

        //--function kiểm tra số chẵn lẻ--//
        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

     // ---------------------------------------ACTION----------------------------------------//

        //--Sự kiện click nút DẤU TIN--//
        private void hideButton_Click(object sender, EventArgs e)
        {
            if (openedStego)
            {
                bmp = (Bitmap)imagePictureBox.Image;

                string text = dataTextBox.Text;

                if (text.Equals("")) // kiểm tra ô tin trống?
                {
                    MessageBox.Show("Vui lòng nhập đoạn tin bạn muốn giấu", "Warning");
                    return; //break hàm khi text trống
                }

                bmp = SteganographyHelper.embedText(text, bmp); // Hàm embedText trong class SteganographyHelper
                MessageBox.Show("ĐÃ GIẤU THÀNH CÔNG ĐOẠN TIN VÀO ẢNH CỦA BẠN !", "Done");
                notesLabel.Text = "Notes: ĐỪNG QUÊN LƯU NÓ LẠI VÀ GỬI CHO NGƯỜI BẠN MUỐN GỬI =))";
                notesLabel.ForeColor = Color.OrangeRed;
            }
            
        }

        //--Sự kiện click nút ĐỌC TIN--//
        private void extractButton_Click(object sender, EventArgs e)
        {
            if (openedStego)
            {
                bmp = (Bitmap)imagePictureBox.Image;

                string extractedText = SteganographyHelper.extractText(bmp);    // Hàm extractText trong class SteganographyHelper            

                dataTextBox.Text = extractedText;
            }                            
        }

        //--hàm mở ảnh để giấu / đọc tin--//
        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openImage(imagePictureBox);
        }

        //--hàm lưu ảnh vừa giấu tin--//
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(imagePictureBox);
        }        

        //------CÁC HÀM EDITOR--------//
        private void reloadBtn_Click(object sender, EventArgs e)
        {
            reload();
            this.redbar.Value = 0;
            this.greenbar.Value = 0;
            this.bluebar.Value = 0;
            this.bluevalue.Text = "0.0";
            this.redvalue.Text = "0.0";
            this.greenvalue.Text = "0.0";
        }

        private void cropBtn_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                Image img = pictureBox1.Image;

                // Khai báo bitmap để vẽ lại với các thay đổi 
                Bitmap sourceBitmap = new Bitmap(img, pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(sourceBitmap);

                //vẽ hình với graphics với các kích thước
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                    rectCropArea, GraphicsUnit.Pixel);
                g.Dispose();

                Size cropSize = new Size(rectCropArea.Width, rectCropArea.Height);
                pictureBox1.Size = cropSize;
                pictureBox1.Image = sourceBitmap; // gắn hình vừa crop vào pictureBox1

            }            
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                i++;

                // set lại pictureBox1 với kích thước gốc
                Size origin = new Size(864, 528);
                pictureBox1.Size = origin;

                if (IsEven(i)) // kiểm tra hình xoay ngang hay dọc để thay đổi kích thước pictureBox1 cho phù hợp
                {
                    int newWidth = (528 * 528) / 864; // tạo chiều dài mới với đúng tỉ lệ khi xoay dọc hình
                    Size newSize = new Size(newWidth, 528);
                    pictureBox1.Size = newSize;
                }
                
                Console.WriteLine($"{pictureBox1.Width} {';'} {pictureBox1.Height}");

                Image img = pictureBox1.Image;
                Bitmap sourceBitmap = new Bitmap(img, pictureBox1.Height, pictureBox1.Width);
                sourceBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone); //Xoay bitmap của hình đi 90 độ
                pictureBox1.Image = sourceBitmap;
            }
        }

        //------SỰ KIỆN CLICK CỦA CÁC NÚT FILTER--------//
        private void sepiaFilterBtn_Click(object sender, EventArgs e)
        {
            reload();
            redscale();
        }

        private void artisticFilterBtn_Click(object sender, EventArgs e)
        {
            reload();
            winter();
        }

        private void grayFilterBtn_Click(object sender, EventArgs e)
        {
            reload();
            grayscale();
        }

        private void dramaticFilterBtn_Click(object sender, EventArgs e)
        {
            reload();
            filter3();
        }

        //-------SỰ KIỆN THAY ĐỔI TRACKBAR RBG----------//
        private void redbar_Scroll(object sender, EventArgs e)
        {
            hue();
        }

        private void greenbar_Scroll(object sender, EventArgs e)
        {
            hue();
        }

        private void bluebar_Scroll(object sender, EventArgs e)
        {
            hue();
        }

        //------- CÁC NÚT MỞ ẢNH VÀ LƯU ẢNH ĐỂ CHỈNH SỬA--------//
        private void openImageBtn_Click(object sender, EventArgs e)
        {
            openImage(pictureBox1);
        }

        private void saveImageBtn_Click(object sender, EventArgs e)
        {
            saveImage(pictureBox1);
        }

        //--remove placeholder khi click--//
        private void dataTextBox_Click(object sender, EventArgs e)
        {
            if(dataTextBox.Text == "Nhập đoạn tin bạn muốn giấu tại đây...")
            {
                dataTextBox.Text = "";
            }
            
        }

        private void openStegoImage_Click(object sender, EventArgs e)
        {
            openImage(imagePictureBox);
            openedStego = true;
        }

        private void saveStegoImage_Click(object sender, EventArgs e)
        {
            saveImage(imagePictureBox);
        }

        private void resizeBtn_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                resizeForm rsForm = new resizeForm();
                rsForm.ShowDialog();
                if (rsForm.DialogResult == DialogResult.OK)
                {
                    // Display a message box indicating that the OK button was clicked.
                    Size resize = new Size(Int32.Parse(rsForm.widthValue.Text), Int32.Parse(rsForm.heightValue.Text));
                    pictureBox1.Size = resize;
                    // Optional: Call the Dispose method when you are finished with the dialog box.
                    rsForm.Dispose();
                }
                else
                {
                    // Display a message box indicating that the Cancel button was clicked.
                    // MessageBox.Show("The Cancel button on the form was clicked.");
                    // Optional: Call the Dispose method when you are finished with the dialog box.
                    rsForm.Dispose();
                }
            }
            
        }
    }
}