using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Game1
{
    [Activity(Label = "Game1"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class StartActity : Microsoft.Xna.Framework.AndroidGameActivity
    {
        Button startButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.startLayout);
            startButton = FindViewById<Button>(Resource.Id.startButton);
            startButton.Click += StartButton_Click;
            
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            
            SetVisible(false);
            StartActivity(typeof(CharacterSelection));
        }
    }
}

