/*
 * This file is auto-generated.  DO NOT MODIFY.
 * Original file: C:\\Users\\Ishta Bhagat\\Documents\\Spring'16\\CS478\\Project4\\ServiceWithIPCExampleService\\app\\src\\main\\aidl\\course\\examples\\Services\\KeyCommon\\KeyGenerator.aidl
 */
package course.examples.Services.KeyCommon;
public interface KeyGenerator extends android.os.IInterface
{
/** Local-side IPC implementation stub class. */
public static abstract class Stub extends android.os.Binder implements course.examples.Services.KeyCommon.KeyGenerator
{
private static final java.lang.String DESCRIPTOR = "course.examples.Services.KeyCommon.KeyGenerator";
/** Construct the stub at attach it to the interface. */
public Stub()
{
this.attachInterface(this, DESCRIPTOR);
}
/**
 * Cast an IBinder object into an course.examples.Services.KeyCommon.KeyGenerator interface,
 * generating a proxy if needed.
 */
public static course.examples.Services.KeyCommon.KeyGenerator asInterface(android.os.IBinder obj)
{
if ((obj==null)) {
return null;
}
android.os.IInterface iin = obj.queryLocalInterface(DESCRIPTOR);
if (((iin!=null)&&(iin instanceof course.examples.Services.KeyCommon.KeyGenerator))) {
return ((course.examples.Services.KeyCommon.KeyGenerator)iin);
}
return new course.examples.Services.KeyCommon.KeyGenerator.Stub.Proxy(obj);
}
@Override public android.os.IBinder asBinder()
{
return this;
}
@Override public boolean onTransact(int code, android.os.Parcel data, android.os.Parcel reply, int flags) throws android.os.RemoteException
{
switch (code)
{
case INTERFACE_TRANSACTION:
{
reply.writeString(DESCRIPTOR);
return true;
}
case TRANSACTION_playSong:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.playSong(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_actionChosen:
{
data.enforceInterface(DESCRIPTOR);
java.lang.String _arg0;
_arg0 = data.readString();
this.actionChosen(_arg0);
reply.writeNoException();
return true;
}
case TRANSACTION_getEachRow:
{
data.enforceInterface(DESCRIPTOR);
int _arg0;
_arg0 = data.readInt();
java.lang.String _result = this.getEachRow(_arg0);
reply.writeNoException();
reply.writeString(_result);
return true;
}
case TRANSACTION_getRecordSize:
{
data.enforceInterface(DESCRIPTOR);
int _result = this.getRecordSize();
reply.writeNoException();
reply.writeInt(_result);
return true;
}
}
return super.onTransact(code, data, reply, flags);
}
private static class Proxy implements course.examples.Services.KeyCommon.KeyGenerator
{
private android.os.IBinder mRemote;
Proxy(android.os.IBinder remote)
{
mRemote = remote;
}
@Override public android.os.IBinder asBinder()
{
return mRemote;
}
public java.lang.String getInterfaceDescriptor()
{
return DESCRIPTOR;
}
//String getKey();

@Override public void playSong(java.lang.String num) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(num);
mRemote.transact(Stub.TRANSACTION_playSong, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
@Override public void actionChosen(java.lang.String act) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeString(act);
mRemote.transact(Stub.TRANSACTION_actionChosen, _data, _reply, 0);
_reply.readException();
}
finally {
_reply.recycle();
_data.recycle();
}
}
//TODO: return the table of records

@Override public java.lang.String getEachRow(int index) throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
java.lang.String _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
_data.writeInt(index);
mRemote.transact(Stub.TRANSACTION_getEachRow, _data, _reply, 0);
_reply.readException();
_result = _reply.readString();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
@Override public int getRecordSize() throws android.os.RemoteException
{
android.os.Parcel _data = android.os.Parcel.obtain();
android.os.Parcel _reply = android.os.Parcel.obtain();
int _result;
try {
_data.writeInterfaceToken(DESCRIPTOR);
mRemote.transact(Stub.TRANSACTION_getRecordSize, _data, _reply, 0);
_reply.readException();
_result = _reply.readInt();
}
finally {
_reply.recycle();
_data.recycle();
}
return _result;
}
}
static final int TRANSACTION_playSong = (android.os.IBinder.FIRST_CALL_TRANSACTION + 0);
static final int TRANSACTION_actionChosen = (android.os.IBinder.FIRST_CALL_TRANSACTION + 1);
static final int TRANSACTION_getEachRow = (android.os.IBinder.FIRST_CALL_TRANSACTION + 2);
static final int TRANSACTION_getRecordSize = (android.os.IBinder.FIRST_CALL_TRANSACTION + 3);
}
//String getKey();

public void playSong(java.lang.String num) throws android.os.RemoteException;
public void actionChosen(java.lang.String act) throws android.os.RemoteException;
//TODO: return the table of records

public java.lang.String getEachRow(int index) throws android.os.RemoteException;
public int getRecordSize() throws android.os.RemoteException;
}
