package com.example.ishta.project2;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.ContextMenu;
import android.view.MenuInflater;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    ListView list;
    int index;
    String[] name ={
            "Clocks",
            "Irrestible",
            "Demons",
            "Mama knows best",
            "Born to die",
            "Royals",
            "Secrets",
            "Miss Jackson"
    };

    String[] imgindex={
            "coldplay",
            "falloutboy",
            "imaginedragons",
            "jessiej",
            "lanadelray",
            "lorde",
            "onerepublic",
            "panic",
    };

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        CustomAdapter adapter=new CustomAdapter(this, name, imgindex);
        list=(ListView)findViewById(R.id.list2);
        list.setAdapter(adapter);
        index =0;
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                // TODO Auto-generated method stub
                // String Slecteditem= name[+position];
                //Toast.makeText(getApplicationContext(), Slecteditem, Toast.LENGTH_SHORT).show();
                String url = parseURL(position);
                Intent browser = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
                startActivity(browser);

            }
        });

        list.setLongClickable(true);
        list.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {

            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view,
                                           int position, long id) {
                // TODO Auto-generated method stub
                // String Slecteditem= name[+position];
                //Toast.makeText(getApplicationContext(), "Yay", Toast.LENGTH_SHORT).show();
                //something
                index = position;
                registerForContextMenu(list);
                openContextMenu(parent);
                return true;

            }
        });
    }
    @Override
    public void onCreateContextMenu(ContextMenu menu, View v,
                                    ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        //.makeText(getApplicationContext(), "Yay", Toast.LENGTH_SHORT).show();
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_main, menu);
        menu.add(0, v.getId(), 0, "View Video");
        menu.add(0, v.getId(), 0, "View Wikipedia of Song");
        menu.add(0, v.getId(), 0, "View Wikipedia of Artist(s)");
    }
    @Override
    public boolean onContextItemSelected(MenuItem item) {
        if (item.getTitle() == "View Video") {
            String url = parseURL(index);
            Intent browserInt = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
            startActivity(browserInt);
        } else if (item.getTitle() == "View Wikipedia of Song") {
            String songWiki = parseSong(index);
            Intent bro = new Intent(Intent.ACTION_VIEW, Uri.parse(songWiki));
            startActivity(bro);
        } else if (item.getTitle() == "View Wikipedia of Artist(s)") {
            String artistWiki = parseArtist(index);
            Intent brot = new Intent(Intent.ACTION_VIEW, Uri.parse(artistWiki));
            startActivity(brot);
        } else {
            return false;
        }
        return true;
    }
    public String parseURL(int position)
    {
        String ret ="";
        String a = name[position];
        if(a.compareTo("Clocks") == 0)
        {
            ret = "https://www.youtube.com/watch?v=d020hcWA_Wg";
        }
        else if(a.compareTo("Irrestible") == 0)
        {
            ret = "https://www.youtube.com/watch?v=2Lb2BiUC898";
        }
        else if(a.compareTo("Demons") == 0)
        {
            ret = "https://www.youtube.com/watch?v=mWRsgZuwf_8";
        }
        else if(a.compareTo("Mama knows best") == 0)
        {
            ret = "https://www.youtube.com/watch?v=y29eTcRFEl8";
        }
        else if(a.compareTo("Born to die") == 0)
        {
            ret = "https://www.youtube.com/watch?v=Bag1gUxuU0g";
        }
        else if(a.compareTo("Royals") == 0)
        {
            ret = "https://www.youtube.com/watch?v=nlcIKh6sBtc";
        }
        else if(a.compareTo("Secrets") == 0)
        {
            ret = "https://www.youtube.com/watch?v=qHm9MG9xw1o";
        }
        else if(a.compareTo("Miss Jackson") == 0)
        {
            ret = "https://www.youtube.com/watch?v=LUc_jXBD9DU";
        }
        return ret;
    }
    public String parseSong(int position)
    {
        String ret ="";
        String a = name[position];
        if(a.compareTo("Clocks") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Clocks_(song)";
        }
        else if(a.compareTo("Irrestible") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Irresistible_(Fall_Out_Boy_song)";
        }
        else if(a.compareTo("Demons") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Demons_(Imagine_Dragons_song)";
        }
        else if(a.compareTo("Mama knows best") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Mamma_Knows_Best";
        }
        else if(a.compareTo("Born to die") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Born_to_Die_(song)";
        }
        else if(a.compareTo("Royals") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Royals_(song)";
        }
        else if(a.compareTo("Secrets") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Secrets_(OneRepublic_song)";
        }
        else if(a.compareTo("Miss Jackson") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Miss_Jackson";
        }
        return ret;
    }
    public String parseArtist(int position)
    {
        String ret ="";
        String a = name[position];
        if(a.compareTo("Clocks") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Coldplay";
        }
        else if(a.compareTo("Irrestible") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Fall_Out_Boy";
        }
        else if(a.compareTo("Demons") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Imagine_Dragons";
        }
        else if(a.compareTo("Mama knows best") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Jessie_J";
        }
        else if(a.compareTo("Born to die") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Lana_Del_Rey";
        }
        else if(a.compareTo("Royals") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Lorde";
        }
        else if(a.compareTo("Secrets") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/OneRepublic";
        }
        else if(a.compareTo("Miss Jackson") == 0)
        {
            ret = "https://en.wikipedia.org/wiki/Panic!_at_the_Disco";
        }
        return ret;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

}
