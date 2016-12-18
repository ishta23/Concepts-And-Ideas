package com.example.ishta.apptwo;

import android.app.FragmentManager;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.webkit.WebViewFragment;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.Toast;
import android.content.res.Configuration;
import com.example.ishta.apptwo.Points.ListSelectionListener;

public class MainActivity extends AppCompatActivity implements ListSelectionListener {
    public static String[] mLocArray;
    public static String[] mLinkArray;
    public boolean homeTown;

    private Link_Fragment LinkFragment = new Link_Fragment();
    private FragmentManager mFragmentManager;
    private FrameLayout PointsFragment, LinksFragment;

    private static final int MATCH_PARENT = LinearLayout.LayoutParams.MATCH_PARENT;
    private static final String TAG = "AppTwoActivity";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);


        //Receive intent of whether it is Chicago or Indianapolis

        Intent intent = getIntent();
        String message = intent.getStringExtra("City");
        Toast.makeText(getApplicationContext(), "Where: " + message, Toast.LENGTH_SHORT).show();
        //choosing which city
        if(message.equals("Chicago")) {
            homeTown = true;
        } else {
            homeTown = false;
        }
        if (homeTown) {
            mLocArray = getResources().getStringArray(R.array.ChiLoc);
            mLinkArray = getResources().getStringArray(R.array.ChiLink);
        } else {
            mLocArray = getResources().getStringArray(R.array.IndLoc);
            mLinkArray = getResources().getStringArray(R.array.IndLink);
        }

        // Get references to the Point Fragment and to the QuotesFragment
        PointsFragment = (FrameLayout) findViewById(R.id.points_fragment_container);
        LinksFragment = (FrameLayout) findViewById(R.id.linksContainer);

        // Get a reference to the FragmentManager
        mFragmentManager = getFragmentManager();

        // Start a new FragmentTransaction
        FragmentTransaction fragmentTransaction = mFragmentManager
                .beginTransaction();

        // Add the Point Fragment to the layout
        fragmentTransaction.replace(R.id.points_fragment_container,
                new Points());

        // Commit the FragmentTransaction
        fragmentTransaction.commit();
        // Add a OnBackStackChangedListener to reset the layout when the back stack changes
        mFragmentManager
                .addOnBackStackChangedListener(new FragmentManager.OnBackStackChangedListener() {
                    public void onBackStackChanged() {
                        setLayout();
                    }
                });
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

        if (id == R.id.ChiAction)
        {
            Intent goToApp = new Intent(this, MainActivity.class);
            goToApp.putExtra("City", "Chicago");
            //goToApp.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            startActivity(goToApp);
        }
        else if (id == R.id.IndAction)
        {
            Intent goToApp = new Intent(this, MainActivity.class);
            goToApp.putExtra("City", "Indianapolis");
            startActivity(goToApp);
        }

        return super.onOptionsItemSelected(item);
    }

    private void setLayout() {
        if(getResources().getConfiguration().orientation == 2) {
            // Determine whether the Link_Fragment has been added
            if (!LinkFragment.isAdded()) {

                // Make the Point Fragment occupy the entire layout
                PointsFragment.setLayoutParams(new LinearLayout.LayoutParams(
                        MATCH_PARENT, MATCH_PARENT));
                LinksFragment.setLayoutParams(new LinearLayout.LayoutParams(0,
                        MATCH_PARENT));

            } else {

                // Make the TitleLayout take 1/3 of the layout's width
                PointsFragment.setLayoutParams(new LinearLayout.LayoutParams(0,
                        MATCH_PARENT, 1f));

                // Make the QuoteLayout take 2/3's of the layout's width
                LinksFragment.setLayoutParams(new LinearLayout.LayoutParams(0,
                        MATCH_PARENT, 2f));
            }
        }
        else
        {
            if (!LinkFragment.isAdded()) {

                // Make the Point Fragment occupy the entire layout
                PointsFragment.setLayoutParams(new LinearLayout.LayoutParams(
                        MATCH_PARENT, MATCH_PARENT));
                LinksFragment.setLayoutParams(new LinearLayout.LayoutParams(0,
                        MATCH_PARENT));
            } else {


                PointsFragment.setLayoutParams(new LinearLayout.LayoutParams(0,
                        MATCH_PARENT, 0f));

                LinksFragment.setLayoutParams(new LinearLayout.LayoutParams(0,
                        MATCH_PARENT, 1f));
            }
        }

    }

    // Called when the user selects an item in the TitlesFragment
    //@Override
    public void onListSelection(int index) {
        // Start a new FragmentTransaction
        FragmentTransaction fragmentTransaction =
                mFragmentManager.beginTransaction();

        // If the Link_Fragment has not been added, add it now
        if (!LinkFragment.isAdded()) {

            // Add the Link_Fragment to the layout
            fragmentTransaction.add(R.id.linksContainer,LinkFragment);

            // Add this FragmentTransaction to the backstack
            fragmentTransaction.addToBackStack(null);

            // Commit the FragmentTransaction
            fragmentTransaction.commit();

            // Force Android to execute the committed FragmentTransaction
            mFragmentManager.executePendingTransactions();
        }
        if (LinkFragment.getShownIndex() != index) {

            // Tell the Link_Fragment to show the quote string at position index
            //mFragmentManager.addToBackStack("webview");
            LinkFragment.getLinkAtIndex(index);

        }
    }
    public void onConfigurationChanged(Configuration newConfig)
    {
        super.onConfigurationChanged(newConfig);
        setLayout();
    }

    @Override
    public void onBackPressed(){
        FragmentManager fm = getFragmentManager();
        if (fm.getBackStackEntryCount() > 0) {
            Log.i("MainActivity", "popping backstack");
            fm.popBackStack();
        } else {
            Log.i("MainActivity", "nothing on backstack, calling super");
            super.onBackPressed();
        }
    }
}
