using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Com.Sothree.Slidinguppanel;
using Android.Widget;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using static Com.Sothree.Slidinguppanel.SlidingUpPanelLayout;

namespace SlidingUpPanel.Sample
{
    [Activity(Label = "SlidingUpPanel.Sample", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, IPanelSlideListener, View.IOnClickListener
    {
        private SlidingUpPanelLayout mLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.main_toolbar));

            var lv = (ListView)FindViewById(Resource.Id.list);
            lv.ItemClick += delegate
            {
                Toast.MakeText(this, "onItemClick", ToastLength.Short).Show();
            };

            var your_array_list = new[] {
                    "This",
                    "Is",
                    "An",
                    "Example",
                    "ListView",
                    "That",
                    "You",
                    "Can",
                    "Scroll",
                    ".",
                    "It",
                    "Shows",
                    "How",
                    "Any",
                    "Scrollable",
                    "View",
                    "Can",
                    "Be",
                    "Included",
                    "As",
                    "A",
                    "Child",
                    "Of",
                    "SlidingUpPanelLayout"
            };

            // This is the array adapter, it takes the context of the activity as a
            // first parameter, the type of list view as a second parameter and your
            // array as a third parameter.
            var arrayAdapter = new ArrayAdapter<String>(
                    this,
                    Android.Resource.Layout.SimpleListItem1,
                    your_array_list);
            lv.Adapter = (arrayAdapter);

            mLayout = (SlidingUpPanelLayout)FindViewById(Resource.Id.sliding_layout);

            mLayout.AddPanelSlideListener(this);
            mLayout.SetFadeOnClickListener(this);

            var t = (TextView)FindViewById(Resource.Id.name);
            t.SetText(Html.FromHtml(GetString(Resource.String.hello)), TextView.BufferType.Spannable);
            var f = (Button)FindViewById(Resource.Id.follow);
            f.SetText(Html.FromHtml(GetString(Resource.String.follow)), TextView.BufferType.Spannable);
            f.MovementMethod = LinkMovementMethod.Instance;
            f.Click += delegate
            {
                Intent i = new Intent(Intent.ActionView);
                i.SetData(Android.Net.Uri.Parse("http://www.twitter.com/naxamco"));
                StartActivity(i);
            };
        }

        public void OnPanelClosed(View panel)
        {
        }

        public void OnPanelOpened(View panel)
        {
        }

        public void OnPanelSlide(View panel, float slideOffset)
        {
            Log.Info("SlidingPanel", "onPanelSlide, offset " + slideOffset);
        }

        public void OnPanelStateChanged(View p0, PanelState p1, PanelState p2)
        {
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);

            // Inflate the menu; this adds items to the action bar if it is present.
            MenuInflater.Inflate(Resource.Menu.demo, menu);

            var item = menu.FindItem(Resource.Id.action_toggle);
            if (mLayout != null)
            {
                if (mLayout.GetPanelState() == PanelState.Hidden)
                {
                    item.SetTitle(Resource.String.action_show);
                }
                else
                {
                    item.SetTitle(Resource.String.action_hide);
                }
            }
            return true;
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return base.OnOptionsItemSelected(item);

            switch (item.ItemId)
            {
                case Resource.Id.action_toggle:
                    {
                        if (mLayout != null)
                        {
                            if (mLayout.GetPanelState() != PanelState.Hidden)
                            {
                                mLayout.SetPanelState(PanelState.Hidden);
                                item.SetTitle(Resource.String.action_show);
                            }
                            else
                            {
                                mLayout.SetPanelState(PanelState.Collapsed);
                                item.SetTitle(Resource.String.action_hide);
                            }
                        }
                        return true;
                    }
                case Resource.Id.action_anchor:
                    {
                        if (mLayout != null)
                        {
                            if (mLayout.AnchorPoint == 1.0f)
                            {
                                mLayout.AnchorPoint = (0.7f);
                                mLayout.SetPanelState(PanelState.Anchored);
                                item.SetTitle(Resource.String.action_anchor_disable);
                            }
                            else
                            {
                                mLayout.AnchorPoint = (1.0f);
                                mLayout.SetPanelState(PanelState.Collapsed);
                                item.SetTitle(Resource.String.action_anchor_enable);
                            }
                        }
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (mLayout != null &&
                (mLayout.GetPanelState() == PanelState.Expanded || mLayout.GetPanelState() == PanelState.Anchored))
            {
                mLayout.SetPanelState(PanelState.Collapsed);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public void OnClick(View v)
        {
            if (v.Id != Resource.Id.sliding_layout) return;

            mLayout.SetPanelState(PanelState.Collapsed);
        }
    }
}


