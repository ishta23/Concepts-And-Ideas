package course.examples.Services.KeyService;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;

/**
 * Created by Ishta on 4/7/2016.
 */
public class DBHelper extends SQLiteOpenHelper {

    public static final String DATABASE_NAME = "MyDBName.db";
    public static final String TABLE_NAME = "records";
    public static final String _ID= "_id";
    public static final String DATE_TIME = "Date & Time";
    public static final String CURR_STATE = "Current State";
    public static final String KIND_REQ = "Kind of Request";
    public static final String CLIP_NUM = "Clip Number";
    final private Context mContext;
    private ArrayList<String> array_list;
    public boolean firstTime;
    //private HashMap hp;

    public DBHelper(Context context)
    {
        super(context, DATABASE_NAME, null, 1);
        this.mContext = context;
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        // TODO Auto-generated method stub
        db.execSQL(
                "CREATE TABLE " + TABLE_NAME + "(" + _ID +
                        " INTEGER PRIMARY KEY AUTOINCREMENT, date text,state text,kind text,clip_num text);"
        );
        array_list = new ArrayList<String>();
    }
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // TODO Auto-generated method stub
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(db);
    }

    public boolean insertRecord  (String date, String state, String kind, String clip_num)
    {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put("date", date);
        contentValues.put("state", state);
        contentValues.put("kind", kind);
        contentValues.put("clip_num", clip_num);
        db.insert("records", null, contentValues);
        return true;
    }
    public ArrayList<String> getAllRecords()
    {
        array_list = new ArrayList<String>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor res =  db.rawQuery( "select * from " + TABLE_NAME, null );
        res.moveToFirst();
        array_list.add("Date & Time, Current State, Kind of Request, Clip Number");
        String a ="blah  blah";
        while(!res.isAfterLast()){
            a = res.getString(1) + " , " + res.getString(2) + " , " + res.getString(3) + " , " + res.getString(4);
            array_list.add(a);
            res.moveToNext();
        }
        res.close();
        return array_list;
    }
    //public void deleteDatabase() {
       // mContext.deleteDatabase(DATABASE_NAME);
    //}

}