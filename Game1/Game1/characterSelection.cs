using System;

using Android.Content.PM;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
namespace Game1
{
    [Activity(Label = "characterSelection", 
         LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class CharacterSelection : Microsoft.Xna.Framework.AndroidGameActivity
    {
        ImageButton garryButton, wizardButton, cyborgButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.charactersLayout);
            garryButton  = FindViewById <ImageButton> (Resource.Id.garry_button);
            wizardButton = FindViewById <ImageButton> (Resource.Id.wizard_button);
            cyborgButton = FindViewById <ImageButton> (Resource.Id.cyborg_button);

            garryButton.Click  += GarryButton_Click;
            wizardButton.Click += WizardButton_Click;
            cyborgButton.Click += CyborgButton_Click;
        
            
        }

        private void CyborgButton_Click(object sender, EventArgs e)
        {
           // Game1.characterType = 1;
            StartActivity(typeof(MainActivity));
        }

        private void WizardButton_Click(object sender, EventArgs e)
        {
           // Game1.characterType = 2;
            StartActivity(typeof(MainActivity));
        }

        private void GarryButton_Click(object sender, EventArgs e)
        {
           // Game1.characterType = 3;
            StartActivity(typeof(MainActivity));
        }
    }
}