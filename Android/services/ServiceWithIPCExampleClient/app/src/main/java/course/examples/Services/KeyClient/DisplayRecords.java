package course.examples.Services.KeyClient;

import android.app.Activity;

import android.os.Bundle;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;


public class DisplayRecords extends Activity /*implements Parcelable*/{

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_display_records);
        //grab bundle from intent
        Bundle b = this.getIntent().getExtras();
        String[] array = b.getStringArray("records");
        //display on listview
        ArrayAdapter adapter = new ArrayAdapter<String>(this, R.layout.activity_listview, array);
        ListView listView = (ListView) findViewById(R.id.recordsView);
        listView.setAdapter(adapter);
    }

}
