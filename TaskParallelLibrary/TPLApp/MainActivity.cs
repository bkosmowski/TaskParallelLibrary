using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace TPLApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private NumberPicker _hoursPicker;
        private NumberPicker _minutesPicker;
        private NumberPicker _secondsPicker;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            _hoursPicker = FindViewById<NumberPicker>(Resource.Id.hoursPicker);
            _hoursPicker.MinValue = 0;
            _hoursPicker.MaxValue = 12;

            _minutesPicker = FindViewById<NumberPicker>(Resource.Id.minutesPicker);
            _minutesPicker.MinValue = 0;
            _minutesPicker.MaxValue = 60;
            _secondsPicker = FindViewById<NumberPicker>(Resource.Id.secondsPicker);
            _secondsPicker.MinValue = 0;
            _secondsPicker.MaxValue = 60;
        }
    }
}