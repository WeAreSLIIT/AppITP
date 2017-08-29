using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InvoiceHandlingApplicationStyles.Model.Controls
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
