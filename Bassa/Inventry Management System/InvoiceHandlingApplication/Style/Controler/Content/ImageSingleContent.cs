using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InvoiceHandlingApplication.Style.Controler
{
    public class ImageSingleContent : ContentControl
    {
        static ImageSingleContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageSingleContent), new FrameworkPropertyMetadata(typeof(ImageSingleContent)));
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageSingleContent), new PropertyMetadata(null));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
}
