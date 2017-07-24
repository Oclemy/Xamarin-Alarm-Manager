using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using Java.Lang;

namespace Alarm_Manager
{
    /*
     * OUR MAINACTIVITY
     * -Extends Activity
     * -Initializes our views and widgets
     * -Starts Alarm
     */
    [Activity(Label = "Alarm_Manager", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //DECLARE WIDGETS
        private Button startBtn;
        private EditText timeTxt;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

             this.initializeViews();

        }
         /*
    INITIALIZE VIEWS
     */
    private void initializeViews()
    {
        timeTxt=  FindViewById<EditText>(Resource.Id.timeTxt);
        startBtn= FindViewById<Button>(Resource.Id.startBtn);

        startBtn.Click += startBtn_Click;

    }

    void startBtn_Click(object sender, EventArgs e)
    {
        go();
    }

    /*
    INITIALIZE AND START OUR ALARM
     */
    private void go()
    {
        //GET TIME IN SECONDS AND INITIALIZE INTENT
        int time=Convert.ToInt32(timeTxt.Text);
        Intent i=new Intent(this,typeof(MyReceiver));

        //PASS CONTEXT,YOUR PRIVATE REQUEST CODE,INTENT OBJECT AND FLAG
        PendingIntent pi = PendingIntent.GetBroadcast(this,0,i,0);

        //INITIALIZE ALARM MANAGER
        AlarmManager alarmManager= (AlarmManager) GetSystemService(AlarmService);

        //SET THE ALARM
        alarmManager.Set(AlarmType.RtcWakeup, JavaSystem.CurrentTimeMillis()+(time*1000),pi);
        Toast.MakeText(this, "Alarm set In: " + time + " seconds", ToastLength.Short).Show();
    }


    }
}

