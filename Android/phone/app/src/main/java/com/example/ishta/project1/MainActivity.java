package com.example.ishta.project1;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.content.Intent;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    // public final static String EXTRA_MESSAGE = "com.mycompany.myfirstapp.MESSAGE";
    public static String phoneNumber;
    public String message;
    public boolean resuming;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });
        resuming =false;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }
    @Override
    public void onResume()
    {
        super.onResume();
        if(resuming == true) {
            EditText editText = (EditText) findViewById(R.id.edit_message);
            editText.setText("Returning from Compose Message...", TextView.BufferType.NORMAL);
        }

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

    /**
     * Called when the user clicks the Send button
     */
    public void sendMessage(View view)
    {
        Intent intent = new Intent(MainActivity.this, DisplayMessageActivity.class);
        EditText editText = (EditText) findViewById(R.id.edit_message);
        message = editText.getText().toString();
        String allClear ="";
       // Log.i("help", allClear);
        if(message.length() > 12)
        {
            allClear = parseNumber(message);
            Log.i("asd", allClear);
        }
         if((allClear != null) || (!allClear.equals("")))
            {

                intent.putExtra("phoneNumber", allClear);
                startActivity(intent);
                resuming = true;
            }
            else
            {
                Toast.makeText(this, "Not a number", Toast.LENGTH_SHORT).show();
            }
    }



    public String parseNumber(String m)
    {
        String phNum ="";
            for (int i = 0; i < m.length()-12; i++)
            {
                if (m.charAt(i) =='(')
                {
                    if (Character.isDigit(m.charAt(i + 1))) //1 digit
                    {
                        if (Character.isDigit(m.charAt(i + 2)))//2 digit
                        {
                            if (Character.isDigit(m.charAt(i + 3)))//3 digit
                            {
                                if (m.charAt(i + 4) == ')')
                                {
                                    if (Character.isDigit(m.charAt(i + 5)))//4 digit
                                    {
                                        if (Character.isDigit(m.charAt(i + 6)))//5 digit
                                        {
                                            if (Character.isDigit(m.charAt(i + 7)))//6 digit
                                            {
                                                if (m.charAt(i + 8) == '-') {
                                                    if (Character.isDigit(m.charAt(i + 9)))//7 digit
                                                    {
                                                        if (Character.isDigit(m.charAt(i + 10)))//8 digit
                                                        {
                                                            if (Character.isDigit(m.charAt(i + 11)))//9 digit
                                                            {
                                                                if (Character.isDigit(m.charAt(i + 12)))//10 digit
                                                                {
                                                                    phNum = m.substring(i, i + 13);
                                                                }
                                                                else
                                                                    phNum="";
                                                            }
                                                            else
                                                                phNum="";
                                                        }
                                                        else
                                                            phNum="";
                                                    }
                                                    else
                                                        phNum="";
                                                }
                                                else
                                                    phNum="";
                                            }
                                            else
                                                phNum="";
                                        }
                                        else phNum="";
                                    }
                                    else
                                        phNum="";
                                }
                                else
                                    phNum="";
                            }
                            else
                                phNum="";
                        }
                        else
                            phNum="";
                    }
                    else
                        phNum="";
                }
                else
                    phNum = "";
            }
            //for the phone number with a space
            for (int i = 0; i < m.length()-13; i++)
            {
                if (m.charAt(i) == '(')
                {
                    if (Character.isDigit(m.charAt(i + 1))) //1 digit
                    {
                        if (Character.isDigit(m.charAt(i + 2)))//2 digit
                        {
                            if (Character.isDigit(m.charAt(i + 3)))//3 digit
                            {
                                if (m.charAt(i + 4) == ')')
                                {
                                    if (m.charAt(i + 5) == ' ')
                                    {
                                        if (Character.isDigit(m.charAt(i + 6)))//4 digit
                                        {
                                            if (Character.isDigit(m.charAt(i + 7)))//5 digit
                                            {
                                                if (Character.isDigit(m.charAt(i + 8)))//6 digit
                                                {
                                                    if (m.charAt(i + 9) == '-') {
                                                        if (Character.isDigit(m.charAt(i + 10)))//7 digit
                                                        {
                                                            if (Character.isDigit(m.charAt(i + 11)))//8 digit
                                                            {
                                                                if (Character.isDigit(m.charAt(i + 12)))//9 digit
                                                                {
                                                                    if (Character.isDigit(m.charAt(i + 13)))//10 digit
                                                                    {
                                                                        phNum = m.substring(i, i + 14);
                                                                    }
                                                                    else
                                                                        phNum = "";
                                                                }
                                                                else
                                                                    phNum = "";
                                                            }
                                                            else
                                                                phNum = "";
                                                        }
                                                        else
                                                            phNum = "";
                                                    }
                                                    else
                                                        phNum = "";
                                                }
                                                else
                                                    phNum = "";
                                            }
                                            else
                                                phNum = "";
                                        }
                                        else
                                            phNum = "";

                                    }
                                    else
                                        phNum = "";
                                }
                                else
                                    phNum = "";
                            }
                            else
                                phNum = "";
                        }
                        else
                            phNum = "";
                    }
                    else
                        phNum="";
                }
                else
                    phNum = "";
            }

        //do something
        return phNum;

    }

}
