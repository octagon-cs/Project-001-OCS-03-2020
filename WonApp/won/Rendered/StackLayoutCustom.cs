using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace won.Rendered
{
    public class StackLayoutCustom : StackLayout,INotifyPropertyChanged
    {

        public static readonly BindableProperty FirstColorProperty = BindableProperty.Create("FirstColor", typeof(Color), typeof(StackLayoutCustom), Color.White);
        public static readonly BindableProperty SecoundColorProperty = BindableProperty.Create("SecoundColor", typeof(Color), typeof(StackLayoutCustom), Color.White);
        public static readonly BindableProperty ThirdColorProperty = BindableProperty.Create("ThirdColor", typeof(Color), typeof(StackLayoutCustom), Color.Gray);
        public Color FirstColor
        {
            get { return (Color)GetValue(FirstColorProperty); }
            set { SetValue(FirstColorProperty, value); }
        }

        public Color SecoundColor
        {
            get { return (Color)GetValue(SecoundColorProperty); }
            set { SetValue(SecoundColorProperty, value); }
        }

        public Color ThirdColor
        {
            get { return (Color)GetValue(ThirdColorProperty); }
            set { SetValue(ThirdColorProperty, value); }
        }

        public GradientColorStackMode Mode { get; set; } = GradientColorStackMode.ToBottom;

    }


    public enum GradientColorStackMode
    {
        ToRight,
        ToLeft,
        ToTop,
        ToBottom,
        ToTopLeft,
        ToTopRight,
        ToBottomLeft,
        ToBottomRight
    }
}
