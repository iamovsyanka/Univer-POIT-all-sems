using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab10
{
    public partial class ColorPicker : UserControl
    {
        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;
        public static readonly RoutedEvent ColorChangedEvent;

        public ColorPicker() => InitializeComponent();

        static ColorPicker()
        {
            var metadata1 = new FrameworkPropertyMetadata();
            metadata1.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            metadata1.PropertyChangedCallback = new PropertyChangedCallback(OnColorRGBChanged);

            var metadata2 = new FrameworkPropertyMetadata();
            metadata2.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            metadata2.PropertyChangedCallback = new PropertyChangedCallback(OnColorRGBChanged);

            var metadata3 = new FrameworkPropertyMetadata();
            metadata3.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            metadata3.PropertyChangedCallback = new PropertyChangedCallback(OnColorRGBChanged);

            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker), metadata1, new ValidateValueCallback(ValidateValue));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker), metadata2, new ValidateValueCallback(ValidateValue));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker), metadata3, new ValidateValueCallback(ValidateValue));

            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Tunnel,
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            else if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            else if (e.Property == BlueProperty)
            { 
                color.B = (byte)e.NewValue; 
            }

            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var newColor = (Color)e.NewValue;
            var colorpicker = (ColorPicker)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;

            colorpicker.txb.Text = newColor.ToString();

            colorpicker.RaiseEvent(new RoutedPropertyChangedEventArgs<Color>((Color)e.OldValue, newColor, ColorPicker.ColorChangedEvent));
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorPicker.ColorChangedEvent, value); }
            remove { RemoveHandler(ColorPicker.ColorChangedEvent, value); }
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            var currentValue = (byte)baseValue;
            if (currentValue > 255)  
                return 255;
            return currentValue;
        }

        private static bool ValidateValue(object value)
        {
            var currentValue = (byte)value;
            if (currentValue >= 0) 
                return true;
            return false;
        }
    }
}
