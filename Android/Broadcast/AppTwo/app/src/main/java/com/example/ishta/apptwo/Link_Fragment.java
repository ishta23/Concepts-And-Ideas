package com.example.ishta.apptwo;

import android.content.Context;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;

public class Link_Fragment extends Fragment {

    private WebView mWebView = null;
    private int mCurrIdx = -1;
    private int mWebArrLen;

    int getShownIndex() {
        return mCurrIdx;
    }

    // Show the Link string at position newIndex
    void getLinkAtIndex(int newIndex) {
        if (newIndex < 0 || newIndex >= (R.array.ChiLink))
            return;
        mCurrIdx = newIndex;
        mWebView.loadUrl(MainActivity.mLinkArray[mCurrIdx]);
    }

    public Link_Fragment() {
        // Required empty public constructor
    }
    //creating the fragment
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    //inflate the fragment to into the container
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_link, container, false);

    }
    public void onActivityCreated(Bundle savedInstanceState)
    {
        super.onActivityCreated(savedInstanceState);
        mWebView = (WebView) getActivity().findViewById(R.id.webViewID);
        mWebArrLen= MainActivity.mLinkArray.length;
        mWebView.getSettings().setJavaScriptEnabled(true);
        mWebView.getSettings().setDomStorageEnabled(true);
        setRetainInstance(true);
    }
    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
        //mListener = null;
    }
    public boolean canGoBack() {
        return mWebView.canGoBack();
    }

    public void goBack() {
        mWebView.goBack();
    }

}
