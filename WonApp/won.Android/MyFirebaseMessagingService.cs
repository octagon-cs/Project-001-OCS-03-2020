using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace won.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";

      /*  public override void OnCreate()
        {
            base.OnCreate();
            if (MainActivity.IsBacground)
            {
                var powerManager = (PowerManager)GetSystemService(PowerService);
                var wakeLock = powerManager.NewWakeLock(WakeLockFlags.ScreenDim | WakeLockFlags.AcquireCausesWakeup, "Info Tsunami");
                wakeLock.Acquire();
                AlarmManager manager = (AlarmManager)GetSystemService(Context.AlarmService);
                Intent myIntent = new Intent(this, typeof(NotifyBroadcastReceived));
                PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, myIntent, PendingIntentFlags.OneShot);
                myIntent.SetFlags(ActivityFlags.ClearTop);
                manager.Set(AlarmType.RtcWakeup, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), pendingIntent);
            }
        }*/

        public override void OnMessageReceived(RemoteMessage message)
        {
            if(message.From== "/topics/all")
            {
                AlarmManager manager = (AlarmManager)GetSystemService(Context.AlarmService);
                Intent myIntent = new Intent(this, typeof(NotifyBroadcastReceived));
                myIntent.PutExtra("message", message.Data.Where(x => x.Key == "message").FirstOrDefault().Value);
                myIntent.PutExtra("role", message.Data.Where(x => x.Key == "role").FirstOrDefault().Value);

                PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, myIntent, PendingIntentFlags.OneShot);
                myIntent.SetFlags(ActivityFlags.ClearTop);
                manager.Set(AlarmType.RtcWakeup, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), pendingIntent);
            }
            else
            {
                SendNotification(message.GetNotification().Title, message.GetNotification().Body, message.Data);
            }
           
            base.OnMessageReceived(message);
        }

        void SendNotification(string title, string messageBody, IDictionary<string, string> data)
        {
            var bigStyle = new NotificationCompat.BigTextStyle().BigText(messageBody);
            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            var context = MainActivity.Instance;
            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context, MainActivity.CHANNEL_ID)
                //  .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetStyle(bigStyle)
                .SetPriority(NotificationCompat.PriorityMax)
                .SetSmallIcon(Resource.Drawable.xamarin_logo);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                builder.SetVisibility(NotificationCompat.VisibilityPublic);
            }

            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://inatews.bmkg.go.id/terkini.php"));
            PendingIntent pendingIntent = PendingIntent.GetActivity(context, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.UpdateCurrent);



            builder.AddAction(Resource.Drawable.abc_ic_menu_overflow_material, "VIEW", pendingIntent);

            
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, builder.Build());
        }

        public override void OnNewToken(string p0)
        {
            base.OnNewToken(p0);
        }
    }
}