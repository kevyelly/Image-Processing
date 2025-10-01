using AForge.Video;
using AForge.Video.DirectShow;
using ImageProcessingApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImgProcessing
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            backgroundBox.SizeMode = PictureBoxSizeMode.Zoom;
            foregroundBox.SizeMode = PictureBoxSizeMode.Zoom;   
            subtractedBox.SizeMode = PictureBoxSizeMode.Zoom;
            convulationPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            convulationResultPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            LoadCameras();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void LoadCameras()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                comboBox1.Items.Add(device.Name);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }


        private void basicCopyClick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to copy!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                pictureBox2.Image = (Image)pictureBox1.Image.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to copy image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void greyScaleClick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap original = new Bitmap(pictureBox1.Image);
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    Color newColor = Color.FromArgb(gray, gray, gray);
                    grayscale.SetPixel(x, y, newColor);
                }
            }

            pictureBox2.Image = grayscale;
        }

        private void inversionClick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap original = new Bitmap(pictureBox1.Image);
            Bitmap inverted = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;

                    Color newColor = Color.FromArgb(r, g, b);
                    inverted.SetPixel(x, y, newColor);
                }
            }

            pictureBox2.Image = inverted;
        }
         
        private void histogramClicked(object sender, EventArgs e)
        {
            Bitmap processedImage = pictureBox1.Image as Bitmap;
            if (processedImage == null) return;

            int[] histogram = new int[256];
            for (int y = 0; y < processedImage.Height; y++)
            {
                for (int x = 0; x < processedImage.Width; x++)
                {
                    Color c = processedImage.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    histogram[gray]++;
                }
            }

            int max = 0;
            foreach (int val in histogram)
                if (val > max) max = val;

            int width = pictureBox2.ClientSize.Width;
            int height = pictureBox2.ClientSize.Height;
            Bitmap histBmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(histBmp))
            {
                g.Clear(pictureBox2.BackColor);

                float barWidth = (float)width / 256f;

                for (int i = 0; i < 256; i++)
                {
                    float barHeight = (histogram[i] / (float)max) * (height - 1);

                    g.FillRectangle(Brushes.Black,
                        i * barWidth,
                        height - barHeight,
                        barWidth,
                        barHeight);
                }
            }

            pictureBox2.Image = histBmp;
        }

        private void sepiaClick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap original = new Bitmap(pictureBox1.Image);
            Bitmap sepia = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);

                    int tr = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    int tg = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    int tb = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);
                    tr = Math.Min(255, tr);
                    tg = Math.Min(255, tg);
                    tb = Math.Min(255, tb);

                    sepia.SetPixel(x, y, Color.FromArgb(tr, tg, tb));
                }
            }

            pictureBox2.Image = sepia;
        }

        private void loadImageClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);

            }
        }

        private void saveImageClick(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No image to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save Image As";
                saveFileDialog.FileName = "image.jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox2.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loadForeground(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foregroundBox.Image = new Bitmap(openFileDialog.FileName);

            }
        }

        private void loadBackground(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundBox.Image = new Bitmap(openFileDialog.FileName);

            }
        }

        private void saveSubtracted(object sender, EventArgs e)
        {
            if (subtractedBox.Image == null)
            {
                MessageBox.Show("No image to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save Image As";
                saveFileDialog.FileName = "image.jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        subtractedBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void subtractClicked(object sender, EventArgs e)
        {
            Color mygreen = Color.FromArgb(0, 0, 255);  
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 5;

            Bitmap foreground = foregroundBox.Image as Bitmap;
            Bitmap background = backgroundBox.Image as Bitmap;
            Bitmap subtracted = new Bitmap(foreground.Width, foreground.Height);

            for (int x = 0; x  < foreground.Width; x++)
            {
                for (int y = 0; y  < foreground.Height; y++)
                {
                    Color pixel = foreground.GetPixel(x, y);
                    Color backpixel = background.GetPixel(x, y);
                    int grey  = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);
                    if(subtractvalue > threshold)
                    {
                        subtracted.SetPixel(x, y, pixel);
                    }
                    else
                    {
                        subtracted.SetPixel(x, y, backpixel);
                    }

                }
            }
            subtractedBox.Image = subtracted;
        }

        private void clearClicked(object sender, EventArgs e)
        {
            foregroundBox.Image = null;
            backgroundBox.Image = null; 
            subtractedBox.Image = null;
        }

        private void loadConvulationPic(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                convulationPictureBox.Image = new Bitmap(openFileDialog.FileName);

            }
        }

        private void saveConvulationPic(object sender, EventArgs e)
        {
            if (convulationResultPictureBox.Image == null)
            {
                MessageBox.Show("No image to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save Image As";
                saveFileDialog.FileName = "image.jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        convulationResultPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void smoothClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.Smooth(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void gaussianClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.GaussianBlur(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void sharpenClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.Sharpen(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void meanRemovalClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.MeanRemoval(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void LaplascianClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.Emboss(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void horizontalVerticalClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.EmbossHorizontalVertical(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void allDirectionClick(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.EmbossAllDirections(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void lossyClicked(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.EmbossLossy(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void horizontalOnlyClicked(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.EmbossHorizontalOnly(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void verticalOnlyClicked(object sender, EventArgs e)
        {
            Bitmap processedImage = convulationPictureBox.Image as Bitmap;
            if (processedImage == null) return;
            BitmapFilter.EmbossVerticalOnly(processedImage);
            convulationResultPictureBox.Image = processedImage;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
       
                if (comboBox1.SelectedIndex >= 0)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                    videoSource.NewFrame += VideoSource_NewFrame;
                    videoSource.Start();
                }
            }
            else
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.NewFrame -= VideoSource_NewFrame;
                    webCamPictureBox.Image = null;
                }
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            webCamPictureBox.Image = bitmap;
        }


        private void redBG()
        {
            webCamPictureBox.BackColor = Color.Red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
