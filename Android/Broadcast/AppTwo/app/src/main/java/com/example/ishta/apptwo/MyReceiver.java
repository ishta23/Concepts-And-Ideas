package com.example.ishta.apptwo;

/**
 * Created by Ishta on 3/19/2016.
 */
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.widget.Toast;

import com.example.ishta.apptwo.MainActivity;

public class MyReceiver extends BroadcastReceiver {
    public MyReceiver() {
    }

    @Override
    public void onReceive(Context context, Intent intent) {
        Toast.makeText(context, "Received:" + intent.getStringExtra("Type"), Toast.LENGTH_SHORT).show();
        Intent goToApp = new Intent(context, MainActivity.class);
        if(intent.getStringExtra("Type").equals("Chicago"))
        {
            goToApp.putExtra("City", "Chicago");
        }
        else
        {
            goToApp.putExtra("City", "Indianapolis");
        }
        goToApp.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        context.startActivity(goToApp);
    }
}

