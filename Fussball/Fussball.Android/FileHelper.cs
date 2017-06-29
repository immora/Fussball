using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fussball.Data;

namespace Fussball.Droid
{
  public class FileHelper : IFileHelper
  {
    public string GetLocalFilePath(string filename)
    {
      string path = Environment.GetFolderPath(Android.OS.Environment.SpecialFolder.Personal);
      return Path.Combine(path, filename);
    }
  }
}