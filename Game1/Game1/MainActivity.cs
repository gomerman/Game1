using System;
using Android.App;
using Android.Content.PM;
using Android.OS;

using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Game1
{
    [Activity(Label = "MainActivity"
        , LaunchMode = LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Microsoft.Xna.Framework.AndroidGameActivity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            var game = new Game1();
            SetContentView((View)game.Services.GetService(typeof(View)));
            game.Run();
        }
    }
}