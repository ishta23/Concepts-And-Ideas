package course.examples.Services.KeyService;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashSet;
import java.util.Set;
import java.util.UUID;
import android.app.Service;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.IBinder;
import android.util.Log;


import course.examples.Services.KeyCommon.KeyGenerator;

public class KeyGeneratorImpl extends Service {

	private final static Set<UUID> mIDs = new HashSet<UUID>();
	private int songIndex; //what the clip number is
	private int action; //0-null, 1-play, 2-pause, 3-stop
	private MediaPlayer mPlayerOne;	//the music player
	private int prevSongIndex =0; //for the records- which was previous song before new request
	private int prevAction =0; //action for records before new request
	public ArrayList<String> result; //the records are saved here
	public DBHelper mydb; //access to the database
	public int[] songArr ={R.raw.bensound_epic, R.raw.bensound_jazzyfrenchy, R.raw.bensound_ofeliasdream};

	// Implement the Stub for this Object
	private final KeyGenerator.Stub mBinder = new KeyGenerator.Stub()
	{
		//read in the song clip number from client
		public void playSong(String num)
		{
			try
			{
				prevSongIndex = songIndex +1;
				songIndex = Integer.parseInt(num);
				songIndex =  songIndex -1;
			}
			catch (NumberFormatException e)
			{
				Log.i("tracker", "not a num");
			}
		}
		//what action (play, pause..etc) was requested
		public void actionChosen(String act)
		{
			try {
				//Log.i("action", "IN ACTIONCHOSEN OF SERVER");
				prevAction = action;
				String a = "play";
				String b = "pause";
				String c = "stop";
				if (act.equalsIgnoreCase(a)) {
					action = 1;
				} else if (act.equalsIgnoreCase(b)) {
					action = 2;
				} else if (act.equalsIgnoreCase(c)) {
					action = 3;
				}
				saveToRecord();
				doAction();
			}
			catch (NullPointerException e)
			{
				Log.i("action", "Null para");
			}
		}
		//get the size of the records
		public int getRecordSize()
		{
			//Log.i("asd", "in getRecord Size" + result.size());
			return result.size();
		}
		//return the records by row
		public String getEachRow(int index)
		{
			//Log.i("asd", "get Row" + index + "string " +  result.get(index));
			return result.get(index);
		}
	};

	// Return the Stub defined above
	@Override
	public IBinder onBind(Intent intent) {
		return mBinder;
	}

	public void onCreate() {
		super.onCreate();
		mPlayerOne = new MediaPlayer();
		mPlayerOne.setOnPreparedListener(new MediaPlayer.OnPreparedListener() {
			@Override
			public void onPrepared(MediaPlayer mp) {
				mPlayerOne.start();
			}
		});
		mPlayerOne.setLooping(false);
		// Stop Service when music has finished playing
		mPlayerOne.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {

			@Override
			public void onCompletion(MediaPlayer mp) {

				mPlayerOne.stop();

			}
		});
		mydb = new DBHelper(this);
		result = new ArrayList<String>();
		action = 0;


	}
	//performing the action request on player
	public void doAction()
	{

		//play is pressed
		if(action == 1)
		{
			mPlayerOne.stop();
			mPlayerOne = MediaPlayer.create(this, songArr[songIndex]);
			mPlayerOne.start();
			Log.i("asd", "Song " + (songIndex + 1) + "playing");

		}
		else if(action == 2 )
		{
			if(mPlayerOne.isPlaying())
				mPlayerOne.pause();
			Log.i("asd", "Song " + (songIndex + 1) + "paused");
		}
		else if(action == 3)
		{
			if(mPlayerOne.isPlaying())
			{
				mPlayerOne.stop();
				mPlayerOne.seekTo(0);
			}
			Log.i("asd", "Song " + (songIndex + 1) + "stopped");
		}
	}
	//Convert the action int to a string
	public String getActionString(int act)
	{
		if(act == 1)
		{
			return "play";
		}
		else if (act == 2)
		{
			return "pause";
		}
		else
		{
			return "stop";
		}
	}
	//converting the previous state into record
	public String getPrevState()
	{
		return ("" + getActionString(prevAction) + "ing clip number" + prevSongIndex);
	}
	//save and add to the database record
	public void saveToRecord()
	{

		//TODO: insert into table for each thing
		//Calendar-Time (seconds)and Date - Calendar.getInstance();
		Calendar calendar = Calendar.getInstance();
		// Get current day from calendar
		 int day = calendar.get(Calendar.DATE);
		// Get current month from calendar
		 int month = calendar.get(Calendar.MONTH);
		// Get current year from calendar
		 int year = calendar.get(Calendar.YEAR);
		//get current hour
		int hour = calendar.get(Calendar.HOUR_OF_DAY);
		int minute = calendar.get(Calendar.MINUTE);
		int seconds = calendar.get(Calendar.SECOND);
		String date = "" + month + "/" + day + "/" + year +" " + hour + ":" + minute +":" +seconds;
		//Log.i("asd", date);
		String state = getPrevState();
		//Log.i("asd", state);
		String actionString = getActionString(action);
		//insert into database table
		mydb.insertRecord(date, state, actionString, ("" + (songIndex + 1)));

		//update the arraylist<string> so can be returned to client to display

		result = mydb.getAllRecords();
		/*for(int i =0; i < result.length; i++) {
			Log.i("asdad", result[i] + "\n");
		}*/
	}

	@Override
	public void onDestroy()
	{
		if (null != mPlayerOne) {

			mPlayerOne.stop();
			mPlayerOne.reset();
			mPlayerOne.release();
			mPlayerOne =null;
		}
		//mydb.deleteDatabase();
		mydb.close();
		super.onDestroy();

	}

}
