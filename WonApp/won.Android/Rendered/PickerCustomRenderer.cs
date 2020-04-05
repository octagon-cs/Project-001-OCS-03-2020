using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using won.Droid.Rendered;
using won.Rendered;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;



[assembly: ExportRenderer(typeof(PickerCustom), typeof(PickerCustomRenderer))]
namespace won.Droid.Rendered
{
    public class PickerCustomRenderer : PickerRenderer
    {
        public PickerCustomRenderer(Context context) : base(context)
        {
        }

        public PickerCustom ElementV2 => Element as PickerCustom;


        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Color.FromHex("#7a9efb").ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            Control.SetBackground(gd);
            Control.SetPadding((int)Context.ToPixels(ElementV2.Padding.Left), (int)Context.ToPixels(ElementV2.Padding.Top),
                (int)Context.ToPixels(ElementV2.Padding.Right), (int)Context.ToPixels(ElementV2.Padding.Bottom));
        }

    }
}