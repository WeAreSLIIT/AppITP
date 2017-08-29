using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceHandlingApplicationStyles.Model.Converter
{
    public sealed class ConvertBtnClassToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string btnClass = "default";

            if (!(parameter == null || String.IsNullOrEmpty((string)parameter)))
                btnClass = (string)parameter;

            btnClass = btnClass.ToLower();

            switch (btnClass)
            {
                case "primary":
                    return "Primary-Button";
                case "success":
                    return "Success-Button";
                case "warning":
                    return "Warning-Button";
                case "danger":
                    return "Danger-Button";
            }

            return "Default-Button";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
