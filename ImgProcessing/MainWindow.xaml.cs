using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ImgProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int mode = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void switchModeClick(object sender, RoutedEventArgs e)
        {
            if(mode == 0)
            {
                BasicModePanel.Visibility = Visibility.Collapsed;
                SubtractModePanel.Visibility = Visibility.Visible;
                mode = 1;
            } 
            else if(mode == 1)
            {
                BasicModePanel.Visibility = Visibility.Visible;
                SubtractModePanel.Visibility = Visibility.Collapsed;
                mode = 0;
            }
            else
            {
                MessageBox.Show("Unknown mode", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void loadImageClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                LeftImage.Source = bitmap;
            }
        }

        private void saveImageClick(object sender, RoutedEventArgs e)
        {
            if (RightImage.Source == null)
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg",
                Title = "Save Processed Image",
                DefaultExt = "jpg"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var bitmapSource = RightImage.Source as BitmapSource;
                if (bitmapSource == null)
                {
                    MessageBox.Show("Unsupported image format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                using (var stream = System.IO.File.Create(saveFileDialog.FileName))
                {
                    encoder.Save(stream);
                }
            }
        }

        private void basicCopyClick(object sender, RoutedEventArgs e)
        {
            if (LeftImage.Source == null)
            {
                MessageBox.Show("Select image first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            RightImage.Source = LeftImage.Source;
        }

        private void greyScaleClick(object sender, RoutedEventArgs e)
        {
            if (LeftImage.Source == null)
            {
                MessageBox.Show("Select image first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bitmapSource = LeftImage.Source as BitmapSource;
            var grayBitmap = convertGreyScale(bitmapSource);
            RightImage.Source = grayBitmap;
        }

        private void colorInversionClick(object sender, RoutedEventArgs e)
        {
            if (LeftImage.Source == null)
            {
                MessageBox.Show("Select image first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bitmapSource = LeftImage.Source as BitmapSource;
            var inverted = convertColorInversion(bitmapSource);
            RightImage.Source = inverted;
        }

        private void histogramClick(object sender, RoutedEventArgs e)
        {
            if (LeftImage.Source == null)
            {
                MessageBox.Show("Select image first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bitmapSource = LeftImage.Source as BitmapSource;
            var histogram = convertHistogram(bitmapSource);
            RightImage.Source = histogram;
        }

        private void sepiaClick(object sender, RoutedEventArgs e)
        {
            if (LeftImage.Source == null)
            {
                MessageBox.Show("Select image first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bitmapSource = LeftImage.Source as BitmapSource;
            var sepia = convertSepia(bitmapSource);
            RightImage.Source = sepia;
        }

        private BitmapSource convertGreyScale(BitmapSource source)
        {
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;
            byte[] pixelData = new byte[height * stride];
            source.CopyPixels(pixelData, stride, 0);

            for (int i = 0; i < pixelData.Length; i += 4)
            {
                byte b = pixelData[i];
                byte g = pixelData[i + 1];
                byte r = pixelData[i + 2];
                byte gray = (byte)((r + g + b) / 3);
                pixelData[i] = gray;      
                pixelData[i + 1] = gray;  
                pixelData[i + 2] = gray; 
               
            }

            return BitmapSource.Create(width, height, source.DpiX, source.DpiY, PixelFormats.Bgra32, null, pixelData, stride);
        }

        private BitmapSource convertColorInversion(BitmapSource source)
        {
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;
            byte[] pixelData = new byte[height * stride];
            source.CopyPixels(pixelData, stride, 0);

            for (int i = 0; i < pixelData.Length; i += 4)
            {
                pixelData[i]     = (byte)(255 - pixelData[i]);     
                pixelData[i + 1] = (byte)(255 - pixelData[i + 1]); 
                pixelData[i + 2] = (byte)(255 - pixelData[i + 2]); 
               
            }

            return BitmapSource.Create(width, height, source.DpiX, source.DpiY, PixelFormats.Bgra32, null, pixelData, stride);
        }
        private BitmapSource convertHistogram(BitmapSource source, int width = 200, int height = 200)
        {
            int imgWidth = source.PixelWidth;
            int imgHeight = source.PixelHeight;
            int stride = imgWidth * 4;
            byte[] pixelData = new byte[imgHeight * stride];
            source.CopyPixels(pixelData, stride, 0);

   
            int[] histogram = new int[256];
            for (int i = 0; i < pixelData.Length; i += 4)
            {
                byte b = pixelData[i];
                byte g = pixelData[i + 1];
                byte r = pixelData[i + 2];

                byte gray = (byte)((r + g + b) / 3);
                histogram[gray]++;
            }

         
            WriteableBitmap bmp = new WriteableBitmap(width, height, 96, 96, PixelFormats.Gray8, null);
            byte[] pixels = new byte[width * height];
            int max = histogram.Max();

            for (int x = 0; x < 256 && x < width; x++)
            {
                int value = (int)((histogram[x] / (double)max) * height);
                for (int y = height - 1; y >= height - value; y--)
                {
                    pixels[y * width + x] = 255;
                }
            }

            bmp.WritePixels(new Int32Rect(0, 0, width, height), pixels, width, 0);
            return bmp;
        }
        private BitmapSource convertSepia(BitmapSource source)
        {
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;
            byte[] pixelData = new byte[height * stride];
            source.CopyPixels(pixelData, stride, 0);

            for (int i = 0; i < pixelData.Length; i += 4)
            {
                byte b = pixelData[i];
                byte g = pixelData[i + 1];
                byte r = pixelData[i + 2];

                
                double tr = (0.393 * r + 0.769 * g + 0.189 * b);
                double tg = (0.349 * r + 0.686 * g + 0.168 * b);
                double tb = (0.272 * r + 0.534 * g + 0.131 * b);

                pixelData[i + 2] = (byte)(tr > 255 ? 255 : tr); 
                pixelData[i + 1] = (byte)(tg > 255 ? 255 : tg); 
                pixelData[i] = (byte)(tb > 255 ? 255 : tb); 
                                                            
            }

            return BitmapSource.Create(width, height, source.DpiX, source.DpiY, PixelFormats.Bgra32, null, pixelData, stride);
        }


        private void loadBackgroundClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                backgroundImage.Source = bitmap;
            }
        }
        private void loadForegroundClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                foregroundImage.Source = bitmap;
            }
        }
        private void saveResultClick(object sender, RoutedEventArgs e)
        {
            if (resultImage.Source == null)
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg",
                Title = "Save Processed Image",
                DefaultExt = "jpg"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var bitmapSource = resultImage.Source as BitmapSource;
                if (bitmapSource == null)
                {
                    MessageBox.Show("Unsupported image format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                using (var stream = System.IO.File.Create(saveFileDialog.FileName))
                {
                    encoder.Save(stream);
                }
            }
        }


        private void clearImagesClick(object sender, RoutedEventArgs e)
        {
            backgroundImage.Source = null;
            foregroundImage.Source = null;
            resultImage.Source = null;
        }


        //im not using windows form sir so i cant use bitmap class. I used an alternative for WPF since it does not use Bitmap class
        private void subtractClick(object sender, RoutedEventArgs e)
        {
            var imageA = backgroundImage.Source as BitmapSource; 
            var imageB = foregroundImage.Source as BitmapSource; 

            if (imageA == null || imageB == null)
            {
                MessageBox.Show("Both images must be loaded first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int width = Math.Min(imageA.PixelWidth, imageB.PixelWidth);
            int height = Math.Min(imageA.PixelHeight, imageB.PixelHeight);

            int strideA = imageA.PixelWidth * 4;
            int strideB = imageB.PixelWidth * 4;

            byte[] pixelsA = new byte[imageA.PixelHeight * strideA];
            byte[] pixelsB = new byte[imageB.PixelHeight * strideB];
            byte[] resultPixels = new byte[height * width * 4];

            imageA.CopyPixels(pixelsA, strideA, 0);
            imageB.CopyPixels(pixelsB, strideB, 0);

            Color green = Color.FromRgb(0, 255, 0);
            int greyGreen = (green.R + green.G + green.B) / 3;
            int threshold = 5; 
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * strideB + x * 4;

                    byte b = pixelsB[index];
                    byte g = pixelsB[index + 1];
                    byte r = pixelsB[index + 2];

                    int grey = (r + g + b) / 3;
                    int diff = Math.Abs(grey - greyGreen);

                    if (diff < threshold)
                    {
                        
                        resultPixels[index] = pixelsA[index];       
                        resultPixels[index + 1] = pixelsA[index + 1]; 
                        resultPixels[index + 2] = pixelsA[index + 2];
                        resultPixels[index + 3] = 255;             
                    }
                    else
                    {
                        resultPixels[index] = b;
                        resultPixels[index + 1] = g;
                        resultPixels[index + 2] = r;
                        resultPixels[index + 3] = 255;
                    }
                }
            }

            var result = BitmapSource.Create(width, height, imageB.DpiX, imageB.DpiY, PixelFormats.Bgra32, null, resultPixels, width * 4);
            resultImage.Source = result;
        }


    }

}