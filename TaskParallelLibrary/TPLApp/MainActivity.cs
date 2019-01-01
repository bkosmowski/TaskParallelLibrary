using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace TPLApp
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
	    private Button _syncButton;
	    private Button _asyncButton;
	    private Button _syncContextButton;
	    private TextView _textView;

	    private SynchronizationContext _uiSyncContext;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);
            _uiSyncContext = SynchronizationContext.Current;

		    _syncButton = FindViewById<Button>(Resource.Id.SyncButton);
		    _asyncButton = FindViewById<Button>(Resource.Id.AsyncButton);
		    _syncContextButton = FindViewById<Button>(Resource.Id.SyncContextButton);
		    _textView = FindViewById<TextView>(Resource.Id.TextView);
		    _syncContextButton.Click += OnClickSyncContextButton;
		}

	    private void OnClickSyncContextButton(object sender, EventArgs e)
	    {
	        Task.Run(() =>
	        {
	            Task.Delay(5000);
	            _uiSyncContext.Post(_ => _textView.Text = "UI context captured", null);
	        });
	    }
	}
}

