using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace won.Droid
{
    [BroadcastReceiver]
    public class NotifyBroadcastReceived : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            var message = intent.GetStringExtra("message");
            var role = intent.GetStringExtra("role");

            var bigStyle = new NotificationCompat.BigTextStyle().BigText("Telah Terjadi Tsunami");
            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context, MainActivity.CHANNEL_ID)
                //  .SetContentIntent(pendingIntent)
                .SetContentTitle(role +" waena-desa.id")
                .SetContentText(message)
                .SetAutoCancel(true)
                .SetStyle(bigStyle)
                .SetPriority(NotificationCompat.PriorityMax)
                .SetSmallIcon(Resource.Drawable.xamarin_logo);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                builder.SetVisibility(NotificationCompat.VisibilityPublic);
            }

            Intent intents = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://inatews.bmkg.go.id/terkini.php"));
            PendingIntent pendingIntent = PendingIntent.GetActivity(context, MainActivity.NOTIFICATION_ID, intents, PendingIntentFlags.UpdateCurrent);


            builder.AddAction(Resource.Drawable.abc_ic_menu_overflow_material, "VIEW", pendingIntent);

            
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, builder.Build());
        }


    }
}