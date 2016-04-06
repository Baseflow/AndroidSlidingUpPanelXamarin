using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Com.Sothree.Slidinguppanel;

namespace SlidingUpPanel.Sample
{
    [Activity (Label = "SlidingUpPanel.Sample", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        private SlidingUpPanelLayout mLayout;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            SetSupportActionBar(FindViewById<Toolbar>(Resource.Id.main_toolbar));


            mLayout = FindViewById<SlidingUpPanelLayout>(Resource.Id.sliding_layout);
        }
    }
}


