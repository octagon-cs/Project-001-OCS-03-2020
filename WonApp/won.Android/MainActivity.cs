
using Android.App;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Android.Support.V4.App;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using Plugin.CurrentActivity;
using Plugin.FilePicker;

namespace won.Droid
{
    [Activity(Label = "Won")]
    public class MainActivity : FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";
        internal static MainActivity Instance { get; private set; }
        public static bool IsBackground { get; private set; }
        public static readonly string CHANNEL_ID = "ChannelId1";
        public static readonly int NOTIFICATION_ID = 100;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.Window.RequestFeature(WindowFeatures.ActionBar);
         
            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
          
            Instance = this;

            Firebase.Messaging.FirebaseMessaging.Instance.SubscribeToTopic("all");
            CreateNotificationChannel();

            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();
            IsBackground = false;
        }


        protected override void OnPause()
        {
            base.OnPause();
            IsBackground = true;
         
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);
         
        }


        public bool IsPlayServicesAvailable()
        {
            string text = "";
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    text = "This device is not supported";
                    Finish();
                }
                Toast.MakeText(this, text, ToastLength.Long).Show();
                return false;
            }
            else
            {
                text = "Google Play Services is available.";
                Toast.MakeText(this, text,  ToastLength.Long).Show();
                return true;
            }
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var bigStyle = new NotificationCompat.BigTextStyle().BigText("Progress Permohonan");
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID.ToString())
                //  .SetContentIntent(pendingIntent)
                .SetContentTitle("Waena-desa.id")
                .SetContentText("Permohonan")
                .SetAutoCancel(true)
                .SetStyle(bigStyle)
                .SetPriority(NotificationCompat.PriorityMax)
                .SetSmallIcon(Resource.Drawable.xamarin_logo);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                builder.SetVisibility(NotificationCompat.VisibilityPublic);
            }

            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://inatews.bmkg.go.id/terkini.php"));
            PendingIntent pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.UpdateCurrent);

            builder.AddAction(Resource.Drawable.abc_ic_menu_overflow_material, "VIEW", pendingIntent);

            notificationManager.Notify(MainActivity.NOTIFICATION_ID, builder.Build());

        }
    }
}