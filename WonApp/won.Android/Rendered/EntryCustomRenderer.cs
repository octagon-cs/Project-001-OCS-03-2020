using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using won.Droid.Rendered;
using won.Rendered;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;



[assembly: ExportRenderer(typeof(EntryCustom), typeof(EntryCustomRenderer))]
namespace won.Droid.Rendered
{
    public class EntryCustomRenderer : EntryRenderer
    {
        public EntryCustomRenderer(Context context) : base(context)
        {
        }

        public EntryCustom ElementV2 => Element as EntryCustom;

        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();
            Update(control);
            return control;
        }

        private void Update(FormsEditText control)
        {
            if (control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Color.FromHex("#7a9efb").ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            control.SetBackground(gd);
            control.SetPadding((int)Context.ToPixels(ElementV2.Padding.Left), (int)Context.ToPixels(ElementV2.Padding.Top),
                (int)Context.ToPixels(ElementV2.Padding.Right), (int)Context.ToPixels(ElementV2.Padding.Bottom));
        }

    }
}