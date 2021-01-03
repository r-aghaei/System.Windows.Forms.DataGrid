namespace System.Windows.Forms
{
    using System.Runtime.Serialization.Formatters;
    using System.Runtime.Remoting;
    using System.Runtime.InteropServices;
    using System;
    using System.IO;
    using System.ComponentModel;
    using Microsoft.Win32;
    using System.Globalization;

    /// <summary>
    ///    <para>[To be supplied.]</para>
    /// </summary>
    public class DataGridPreferredColumnWidthTypeConverter : TypeConverter
    {
        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string) || sourceType == typeof(int))
                return true;
            else
                return false;
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value.GetType() == typeof(int))
                {
                    int pulica = (int)value;
                    if (pulica == -1)
                        return "AutoColumnResize (-1)";
                    else
                        return pulica.ToString(CultureInfo.CurrentCulture);
                }
                else
                {
                    return base.ConvertTo(context, culture, value, destinationType);
                }
            }
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        ///    <para>[To be supplied.]</para>
        /// </summary>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                string text = value.ToString();
                if (text.Equals("AutoColumnResize (-1)"))
                    return -1;
                else
                    return Int32.Parse(text, CultureInfo.CurrentCulture);
            }
            else if (value.GetType() == typeof(int))
            {
                return (int)value;
            }
            else
            {
                throw GetConvertFromException(value);
            }
        }
    }
}
