package course.examples.Services.KeyClient;

import android.app.Activity ;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.content.pm.ResolveInfo;
import android.os.Bundle;
import android.os.IBinder;
import android.os.RemoteException;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import com.google.android.gms.common.api.GoogleApiClient;
import course.examples.Services.KeyCommon.KeyGenerator;

public class KeyServiceUser extends Activity {

	protected static final String TAG = "KeyServiceUser";
	private KeyGenerator mKeyGeneratorService;
	private boolean mIsBound = false;
	public String[] result;
	/**
	 * ATTENTION: This was auto-generated to implement the App Indexing API.
	 * See https://g.co/AppIndexing/AndroidStudio for more information.
	 */
	private GoogleApiClient client;

	@Override
	public void onCreate(Bundle icicle) {
		super.onCreate(icicle);

		setContentView(R.layout.main);

		//final TextView output = (TextView) findViewById(R.id.output);
		//Action for PLay Button
		final Button playButton = (Button) findViewById(R.id.playButton);
		playButton.setOnClickListener(new OnClickListener() {

			public void onClick(View v) {

				try {
					EditText editText = (EditText) findViewById(R.id.songInsert);
					String message = editText.getText().toString();

						mKeyGeneratorService.playSong(message);
						mKeyGeneratorService.actionChosen("play");

				} catch (RemoteException e) {

					Log.e(TAG, e.toString());

				}
			}
		});
		//Action for Pause Button
		final Button pauseButton = (Button) findViewById(R.id.pauseButton);
		pauseButton.setOnClickListener(new OnClickListener() {

			public void onClick(View v) {

				try {

					mKeyGeneratorService.actionChosen("pause");

				} catch (RemoteException e) {

					Log.e(TAG, e.toString());

				}
			}
		});
		//ACtion for Stop Button
		final Button stopButton = (Button) findViewById(R.id.stopButton);
		stopButton.setOnClickListener(new OnClickListener() {

			public void onClick(View v) {

				try {

					mKeyGeneratorService.actionChosen("stop");

				} catch (RemoteException e) {

					Log.e(TAG, e.toString());

				}
			}
		});
		//Action for View records which starts another activity
		// and grabs data from database in server app
		final Button viewButton = (Button) findViewById(R.id.viewDB);
		viewButton.setOnClickListener(new OnClickListener() {

			public void onClick(View v) {

				try {
					mKeyGeneratorService.actionChosen("view");
					//TODO- SQLite functions
					result = new String[mKeyGeneratorService.getRecordSize()];
					for(int i =0; i < mKeyGeneratorService.getRecordSize(); i++) {
						//Log.i("asd",mKeyGeneratorService.getEachRow(i));
						result[i] = mKeyGeneratorService.getEachRow(i);
					}
					Bundle b=new Bundle();
					b.putStringArray("records", result);
					Intent intent =new Intent(getApplicationContext(), DisplayRecords.class);
					intent.putExtras(b);
					Toast.makeText(getApplicationContext(), "View DB Button Clicked",Toast.LENGTH_SHORT).show();
					startActivity(intent);

				} catch (RemoteException e) {

					Log.e(TAG, e.toString());

				}
			}
		});

		// ATTENTION: This was auto-generated to implement the App Indexing API.
		// See https://g.co/AppIndexing/AndroidStudio for more information.
		//client = new GoogleApiClient.Builder(this).addApi(AppIndex.API).build();
	}

	// Bind to KeyGenerator Service
	@Override
	protected void onResume() {
		super.onResume();

		if (!mIsBound) {

			boolean b = false;
			Intent i = new Intent(KeyGenerator.class.getName());
			ResolveInfo info = getPackageManager().resolveService(i, Context.BIND_AUTO_CREATE);
			i.setComponent(new ComponentName(info.serviceInfo.packageName, info.serviceInfo.name));

			b = bindService(i, this.mConnection, Context.BIND_AUTO_CREATE);
			if (b) {
				Log.i(TAG, "Ugo says bindService() succeeded!");
			} else {
				Log.i(TAG, "Ugo says bindService() failed!");
			}

		}
	}

	// Unbind from KeyGenerator Service

	//Unbind the service
	@Override
	protected void onPause()
	{
		if (!mIsBound) {

			unbindService(this.mConnection);

		}
		super.onPause();
	}

	//Creating the connection, connecting and disconnecting
	private final ServiceConnection mConnection = new ServiceConnection() {

		public void onServiceConnected(ComponentName className, IBinder iservice) {

			mKeyGeneratorService = KeyGenerator.Stub.asInterface(iservice);
			Toast.makeText(getApplicationContext(), "Service Connected", Toast.LENGTH_SHORT).show();
			mIsBound = true;

		}

		public void onServiceDisconnected(ComponentName className) {

			mKeyGeneratorService = null;
			Toast.makeText(getApplicationContext(), "Service Connected", Toast.LENGTH_SHORT).show();
			mIsBound = false;

		}
	};


}
