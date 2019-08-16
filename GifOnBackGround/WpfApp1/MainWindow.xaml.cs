using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace GifOnBackGround
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool stateMaximize = false;
        bool picture = false;
        public MainWindow()
        {
            InitializeComponent();
            ChangeSizeImageBackground();
        }
        private void ChangeSizeImageBackground()
        {
            if (stateMaximize)
            {
                ImagBackGround.Width = SystemParameters.PrimaryScreenWidth;
                
                ImagBackGround.Height = SystemParameters.PrimaryScreenHeight;
            }
            else
            {
                ImagBackGround.Width = Width;
                ImagBackGround.Height = Height;
            }
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeSizeImageBackground();
        }

        private void Click_ChangeImage(object sender, RoutedEventArgs e)
        {
            
            var image = new BitmapImage();
            image.BeginInit();
            if(picture)
            {
                picture = false;
                image.UriSource = new Uri("pack://application:,,,/Resources/giphy.gif");
            }
            else
            {
                picture = true;
                image.UriSource = new Uri("pack://application:,,,/Resources/images.jpg");
            }
            
            image.EndInit();
            ImageBehavior.SetAnimatedSource(ImagBackGround, image);
            ChangeSizeImageBackground();
        }

        private void stateCange(object sender, EventArgs e)
        {
            if(!stateMaximize)
            {
                stateMaximize = true;
            }
            else
            {
                stateMaximize = false;
            }
            ChangeSizeImageBackground();
        }
    }
}
