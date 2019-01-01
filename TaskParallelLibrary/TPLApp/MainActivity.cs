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
	    private Button _taskButton;
	    private Button _asyncButton;
	    private Button _syncContextButton;
	    private TextView _textView;

	    private SynchronizationContext _uiSyncContext;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);
            _uiSyncContext = SynchronizationContext.Current;

		    _taskButton = FindViewById<Button>(Resource.Id.TaskButton);
		    _asyncButton = FindViewById<Button>(Resource.Id.AsyncButton);
		    _syncContextButton = FindViewById<Button>(Resource.Id.SyncContextButton);
		    _textView = FindViewById<TextView>(Resource.Id.TextView);
		    _syncContextButton.Click += OnClickSyncContextButton;
		    _taskButton.Click += OnClickTaskButton;
		}

	    private void OnClickSyncContextButton(object sender, EventArgs e)
	    {
	        Task.Run(async () =>
	        {
	            await Task.Delay(5000);
	            _uiSyncContext.Post(_ => _textView.Text = "UI context captured", null);
	        });
	    }

	    private void OnClickTaskButton(object sender, EventArgs e)
	    {
	        var task = Task.Run(() => PrimeNumber());
	        var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                var result = awaiter.GetResult();
                _textView.Text = $"There is {result} of prime numbers in range from 2 to 300000";
            });
	    }

	    private int PrimeNumber()
	    {
	        return Enumerable.Range(2, 300000).Count(number =>
	            Enumerable.Range(2, (int) Math.Sqrt(number) - 1).All(i => number % i > 0));
	    }
	}
}

