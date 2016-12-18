package com.example.ishta.project2;

/**
 * Created by Ishta on 2/17/2016.
 */
import android.app.Activity;
import android.content.Context;
import android.content.res.AssetManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.io.InputStream;

public class CustomAdapter extends ArrayAdapter<String> {

    private final Activity context;
    private final String[] name;
    private final String[] imgindex;

    public CustomAdapter(Activity context, String[] name, String[] imgindex) {
        super(context, R.layout.listadapter, name);
        // TODO Auto-generated constructor stub

        this.context=context;
        this.name=name;
        this.imgindex=imgindex;
    }

    public View getView(int position,View view,ViewGroup parent) {
        LayoutInflater inflater=context.getLayoutInflater();
        View rowView=inflater.inflate(R.layout.listadapter, null,true);

        TextView txtTitle = (TextView) rowView.findViewById(R.id.item);
        ImageView imageView = (ImageView) rowView.findViewById(R.id.icon);
        TextView extratxt = (TextView) rowView.findViewById(R.id.textView1);

        txtTitle.setText(name[position]);
        try{
            imageView.setImageDrawable(getAssetImage(context, position));
        }catch(Exception e){

        }

        //imageView.setImageResource(imgindex[position]);
        parseDescribe(extratxt, position);
        return rowView;

    }
    public void parseDescribe(TextView extratxt, int position)
    {
        String a = name[position];
        if(a.compareTo("Clocks") == 0)
        {
            extratxt.setText("Coldplay");
        }
        else if(a.compareTo("Irrestible") == 0)
        {
            extratxt.setText("Fall Out Boy");
        }
        else if(a.compareTo("Demons") == 0)
        {
            extratxt.setText("Imagine Dragons");
        }
        else if(a.compareTo("Mama knows best") == 0)
        {
            extratxt.setText("Jessie J");
        }
        else if(a.compareTo("Born to die") == 0)
        {
            extratxt.setText("Lana Del rey");
        }
        else if(a.compareTo("Royals") == 0)
        {
            extratxt.setText("Lorde");
        }
        else if(a.compareTo("Secrets") == 0)
        {
            extratxt.setText("One Republic");
        }
        else if(a.compareTo("Miss Jackson") == 0)
        {
            extratxt.setText("Panic at the Disco");
        }
    }
    public Drawable getAssetImage(Context context, int position) throws IOException {
        AssetManager assets = context.getResources().getAssets();
        InputStream buffer = new BufferedInputStream((assets.open(imgindex[position] + ".png")));
        Bitmap bitmap = BitmapFactory.decodeStream(buffer);
        return new BitmapDrawable(context.getResources(), bitmap);
    }
}
