package com.example.ishta.appone;

import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    //MyReceiver myReceiver;
    IntentFilter intentFilterChi;
    IntentFilter intentFilterInd;
    Button btnSendBroadcast;
    Button indianaBroad;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        btnSendBroadcast = (Button) findViewById(R.id.ChiButton);
        indianaBroad = (Button) findViewById(R.id.IndButton);


        // myReceiver = new MyReceiver();
        //intentFilterChi = new IntentFilter("com.example.ishta.project3.CHI_ACTION");
        //intentFilterInd = new IntentFilter("com.example.ishta.project3.IND_ACTION");
        //registerReceiver(myReceiver, intentFilterChi);
        //registerReceiver(myReceiver,intentFilterInd);
    }

    public void sendChiIntent(View view) {
        Intent intnet = new Intent("com.example.ishta.project3.CHI_ACTION");
        intnet.putExtra("Type", "Chicago");
        Toast.makeText(this, "Requested: Chicago", Toast.LENGTH_SHORT).show();
        sendBroadcast(intnet);
    }

    public void sendIndIntent(View view) {
        Intent intnet = new Intent("com.example.ishta.project3.IND_ACTION");
        intnet.putExtra("Type", "Indianapolis");
        Toast.makeText(this, "Requested: Indianapolis", Toast.LENGTH_SHORT).show();
        sendBroadcast(intnet);
    }

    @Override
    protected void onResume() {
        super.onResume();

    }

    @Override
    protected void onPause() {
        super.onPause();
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

