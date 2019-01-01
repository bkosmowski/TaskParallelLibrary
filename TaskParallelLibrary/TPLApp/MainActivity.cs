using System;
using System.Linq;
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
	    private Button _getAwaiterButton;
	    private Button _continueWithButton;
	    private Button _asyncButton;
	    private Button _syncContextButton;
	    private TextView _textView;

	    private SynchronizationContext _uiSyncContext;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);
            _uiSyncContext = SynchronizationContext.Current;

		    _getAwaiterButton = FindViewById<Button>(Resource.Id.GetAwaiterButton);
		    _continueWithButton = FindViewById<Button>(Resource.Id.ContinueWithButton);
		    _asyncButton = FindViewById<Button>(Resource.Id.AsyncButton);
		    _syncContextButton = FindViewById<Button>(Resource.Id.SyncContextButton);
		    _textView = FindViewById<TextView>(Resource.Id.TextView);

		    _syncContextButton.Click += OnClickSyncContextButton;
		    _getAwaiterButton.Click += OnClickGetAwaiterButton;
		    _continueWithButton.Click += OnClickContinueWithButton;
            _asyncButton.Click += OnClickAsyncButton;
		}

	    private void OnClickSyncContextButton(object sender, EventArgs e)
	    {
	        Task.Run(async () =>
	        {
	            await Task.Delay(5000);
	            _uiSyncContext.Post(_ => _textView.Text = "UI context captured", null);
	        });
	    }

	    private void OnClickGetAwaiterButton(object sender, EventArgs e)
	    {
	        var task = Task.Run(() => PrimeNumber());
	        var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                var result = awaiter.GetResult();
                _textView.Text = $"Result from GetAwaiter: \nThere is {result} of prime numbers \nin range from 2 to 300000";
            });
	    }

	    private void OnClickContinueWithButton(object sender, EventArgs e)
	    {
	        var task = Task.Run(() => PrimeNumber());
	        task.ContinueWith(
	            continuationTask => _textView.Text =
	                $"Result from ContinueWith: \nThere is {continuationTask.Result} of prime numbers \nin range from 2 to 300000",
	            TaskScheduler.FromCurrentSynchronizationContext());
	    }

	    private async void OnClickAsyncButton(object sender, EventArgs e)
	    {
	        var result = await Task.Run(() => PrimeNumber());
	        _textView.Text =
	            $"Result from async: \nThere is {result} of prime numbers \nin range from 2 to 300000";

	    }

	    private int PrimeNumber()
	    {
	        return Enumerable.Range(2, 300000).Count(number =>
	            Enumerable.Range(2, (int) Math.Sqrt(number) - 1).All(i => number % i > 0));
	    }
	}
}

