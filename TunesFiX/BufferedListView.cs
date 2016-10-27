//---------------------------------------------------------------------------
// TunesFiX - Reorganize music directory-tree structure by album-artist
// instead of by artist. Reassembles various-artist albums scattered over
// multiple folders. Powerful tag-editor.
//
// Author: Scott Swift
//
// Released to GitHub under GPL v3 October, 2016
//
//---------------------------------------------------------------------------
using System;
using System.Windows.Forms;

// S.S.
// Try this instead of new class for listView to get double-buffering!
// using System.Reflection;
//public static void SetDoubleBuffered(Control control)
//{
//  //Set instance non-public property with name "DoubleBuffered"
//  //to true.
//  typeof(Control).InvokeMember("DoubleBuffered",BindingFlags.SetProperty |
//    BindingFlags.Instance | BindingFlags.NonPublic,null, control, new object[] { true });
//}
namespace TunesFiX
{
  class BufferedListView : ListView
  {
    public BufferedListView()
    {
      //Activate double buffering
      //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

      //Enable the OnNotifyMessage event so we get a chance to filter out 
      // Windows messages before they get to the form's WndProc
      //this.SetStyle(ControlStyles.EnableNotifyMessage, true);

      // Works great but don't need it now...
      this.DoubleBuffered = true;
      //this.ResizeRedraw = true; // Stops colored items from being drawn improperly

    }

    // Prevent doubleclick from toggling the checkbox
    protected override void WndProc(ref Message m)
    {
      // Filter WM_LBUTTONDBLCLK
      if (m.Msg != 0x203) base.WndProc(ref m);
      else GlobalNotifier.OnItemDoubleClicked(0); // Fire our custom event
    }
  }
}
