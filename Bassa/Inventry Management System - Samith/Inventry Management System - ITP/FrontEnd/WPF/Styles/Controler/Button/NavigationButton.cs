using System;
using System.Windows;
using System.Windows.Media;
using DefaultControls = System.Windows.Controls;

namespace Styles.Controler
{
    public class NavigationButton : DefaultControls.Button
    {
        static NavigationButton() { }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(NavigationButton), new PropertyMetadata(null));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(Boolean), typeof(NavigationButton), new PropertyMetadata(false));

        public Boolean IsActive
        {
            get { return (Boolean)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, (Boolean)value); }
        }
    }
}
