using AForge.Video;
using AForge.Video.DirectShow;
using ImageProcessingApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        private enum WebcamProcessMode { None, Grayscale, Invert, Sepia, Subtract }
        private WebcamProcessMode _webcamMode = WebcamProcessMode.None;
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
            webCamPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
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

       


        private void redBG()
        {
            webCamPictureBox.BackColor = Color.Red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (videoSource != null)
            {
                try
                {
                    videoSource.NewFrame -= Video_NewFrame;

                    if (videoSource.IsRunning)
                    {
   
                        videoSource.SignalToStop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error stopping video: " + ex.Message);
                }
                finally
                {
                    videoSource = null;
                }
            }

            base.OnFormClosing(e);
        }


        private Bitmap ApplyEffect(Bitmap src)
        {
            Bitmap bmp = new Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);

            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dstData = bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(srcData.Stride) * src.Height;
            byte[] srcBuffer = new byte[bytes];
            byte[] dstBuffer = new byte[bytes];

            Marshal.Copy(srcData.Scan0, srcBuffer, 0, bytes);

            for (int i = 0; i < bytes; i += 3)
            {
                byte b = srcBuffer[i];
                byte g = srcBuffer[i + 1];
                byte r = srcBuffer[i + 2];

                switch (_webcamMode)
                {
                    case WebcamProcessMode.Grayscale:
                        byte gray = (byte)((r + g + b) / 3);
                        dstBuffer[i] = dstBuffer[i + 1] = dstBuffer[i + 2] = gray;
                        break;

                    case WebcamProcessMode.Invert:
                        dstBuffer[i] = (byte)(255 - b);
                        dstBuffer[i + 1] = (byte)(255 - g);
                        dstBuffer[i + 2] = (byte)(255 - r);
                        break;

                    case WebcamProcessMode.Sepia:
                        int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                        int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                        int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);
                        dstBuffer[i + 2] = (byte)Math.Min(255, tr);
                        dstBuffer[i + 1] = (byte)Math.Min(255, tg);
                        dstBuffer[i] = (byte)Math.Min(255, tb);
                        break;

                    case WebcamProcessMode.Subtract:
                        byte grayVal = (byte)((r + g + b) / 3);
                        byte greenGray = (byte)((0 + 255 + 0) / 3);
                        byte sub = (byte)Math.Abs(grayVal - greenGray);
                        if (sub > 5)
                        {
                            dstBuffer[i] = b;
                            dstBuffer[i + 1] = g;
                            dstBuffer[i + 2] = r;
                        }
                        else
                        {
                            dstBuffer[i] = dstBuffer[i + 1] = dstBuffer[i + 2] = 0;
                        }
                        break;

                    default:
                        dstBuffer[i] = b;
                        dstBuffer[i + 1] = g;
                        dstBuffer[i + 2] = r;
                        break;
                }
            }

            Marshal.Copy(dstBuffer, 0, dstData.Scan0, bytes);
            src.UnlockBits(srcData);
            bmp.UnlockBits(dstData);

            return bmp;
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            Bitmap processed = ApplyEffect(frame);
            frame.Dispose(); // free original frame

            webCamPictureBox.Invoke((Action)(() =>
            {
                webCamPictureBox.Image?.Dispose();
                webCamPictureBox.Image = processed;
            }));
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                
                if (videoDevices == null || videoDevices.Count == 0) return;

                int selectedIndex = comboBox1.SelectedIndex;
                if (selectedIndex < 0) return;

                videoSource = new VideoCaptureDevice(videoDevices[selectedIndex].MonikerString);
                videoSource.NewFrame += Video_NewFrame;
                videoSource.Start();
            }
            else
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                    videoSource.NewFrame -= Video_NewFrame;
                    videoSource = null;
                }
                webCamPictureBox.Image?.Dispose();
                webCamPictureBox.Image = null;
            }
        }

        private void greyscaleWebcamClicked(object sender, EventArgs e) // Grayscale button
        {
            _webcamMode = WebcamProcessMode.Grayscale;
        }

        private void invertWebcamClicked(object sender, EventArgs e) // Invert button
        {
            _webcamMode = WebcamProcessMode.Invert;
        }

        private void sepiaWebcamClicked(object sender, EventArgs e) // Sepia Button
        {
            _webcamMode = WebcamProcessMode.Sepia;
        }

        private void subtractWebcamClicked(object sender, EventArgs e) // subtract button
        {
            _webcamMode = WebcamProcessMode.Subtract;
        }

        private void clearWebCamClicked(object sender, EventArgs e) // clear effects button
        {
            _webcamMode = default;
        }

        private void saveWebcamClicked(object sender, EventArgs e)
        {
            if (webCamPictureBox.Image == null)
            {
                MessageBox.Show("No image to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save Image As";
                saveFileDialog.FileName = "webcam_image.jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        webCamPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
