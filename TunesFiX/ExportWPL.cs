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
using System.Text;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Forms;

namespace TunesFiX
{
  class ExportWPL
  {
    private FormMain f1 = null;

    public ExportWPL(FormMain f)
    {
      f1 = f;
    }

    #region Export HTML-Style Playlist (WMP Compatible)

    public int Export(List<string> sl, string fileName)
    {
      return (WriteHTML(sl, fileName, 0)); // write full path
    }
    //---------------------------------------------------------------------------
    private int WriteHTML(List<string> slIn, string fileName, int mode)
    // mode=> 0 = full, 1 = relative, 2 = name only
    {
      if (slIn == null || slIn.Count == 0) return 0;

      int Count = 0;

      try
      {
        List<string> slOut = new List<string>();

        int len = slIn.Count;

        f1.progressBar.Value = 0;

        slOut.Add("<?wpl version=\"1.0\"?>");
        slOut.Add("<smil>");
        slOut.Add("    <head>");
        slOut.Add("        <meta name=\"Generator\" content=\"Microsoft Windows Media Player -- 11.0.5721.5280\"/>");
        slOut.Add("        <title>" +
                Path.GetFileNameWithoutExtension(fileName) + "</title>");
        slOut.Add("    </head>");
        slOut.Add("    <body>");
        slOut.Add("        <seq>");

        for (int ii = 0; ii < len; ii++)
        {
          Application.DoEvents();

          string fName = slIn[ii];
          if (!System.IO.File.Exists(fName)) continue;

          try
          {
            fName = fName.Replace("&", "&amp;");
            fName = fName.Replace("'", "&apos;");

            slOut.Add("            <media src=\"" + fName + "\"/>");
            Count++;
          } catch { }

          f1.progressBar.Value = (100 * ii)/len;
        }

        slOut.Add("        </seq>");
        slOut.Add("    </body>");
        slOut.Add("</smil>");

        //Write to file
        if (!WriteFile(slOut, fileName, Encoding.UTF8))
          MessageBox.Show("List was empty, no file created!");

        f1.progressBar.Value = 0; // Reset
      }
      catch 
      {
        MessageBox.Show("Unable to Export list!");
      }

      return Count;
    }
    //---------------------------------------------------------------------------
    public bool WriteFile(List<string> sl, string fileName, Encoding encoding)
    {
      //Write to file
      if (sl.Count != 0)
      {
        try
        {
          StreamWriter sw = new StreamWriter(fileName, false, encoding);
          foreach (string item in sl) sw.WriteLine(item);
          sw.Close();
        } catch { return false; }
        return true;
      }
      else
        return false;
    }
    //---------------------------------------------------------------------------
    #endregion
  }
}
