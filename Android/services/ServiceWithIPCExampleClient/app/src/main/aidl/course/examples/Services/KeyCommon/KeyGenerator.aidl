package course.examples.Services.KeyCommon;

interface KeyGenerator {
    //String getKey();
    void playSong(String num);
    void actionChosen(String act);
        //TODO: return the table of records
        String getEachRow(int index);
        int getRecordSize();

}