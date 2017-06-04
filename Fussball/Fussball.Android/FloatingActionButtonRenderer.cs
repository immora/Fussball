//using Android.Widget;
//using com.refractored.fab;
//using Fussball.Controls;
//using System;
//using System.IO;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//namespace Fussball.Droid
//{
//  public class FloatingActionButtonRenderer : ViewRenderer<FloatingActionButtonView, FrameLayout>
//  {
//    private readonly Android.Content.Context context;
//    private readonly FloatingActionButton fab;

//    public FloatingActionButtonRenderer()
//    {
//      context = Xamarin.Forms.Forms.Context;
//      fab = new FloatingActionButton(context);
//    }

//    protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButtonView> e)
//    {
//      base.OnElementChanged(e);

//      if (e.OldElement != null || this.Element == null)
//        return;

//      if (e.OldElement != null)
//        e.OldElement.PropertyChanged -= HandlePropertyChanged;

//      if (this.Element != null)
//      {
//        //UpdateContent ();
//        this.Element.PropertyChanged += HandlePropertyChanged;
//      }

//      Element.Show = Show;
//      Element.Hide = Hide;

//      SetFabImage(Element.ImageName);

//      fab.ColorNormal = Element.ColorNormal.ToAndroid();
//      fab.ColorPressed = Element.ColorPressed.ToAndroid();
//      fab.ColorRipple = Element.ColorRipple.ToAndroid();

//      var frame = new FrameLayout(Forms.Context);
//      frame.RemoveAllViews();
//      frame.AddView(fab);

//      SetNativeControl(frame);
//    }

//    public void Show(bool animate = true)
//    {
//      fab.Show(animate);
//    }

//    public void Hide(bool animate = true)
//    {
//      fab.Hide(animate);
//    }

//    void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
//    {
//      if (e.PropertyName == "Content")
//      {
//        Tracker.UpdateLayout();
//      }
//      else if (e.PropertyName == FloatingActionButtonView.ColorNormalProperty.PropertyName)
//      {
//        fab.ColorNormal = Element.ColorNormal.ToAndroid();
//      }
//      else if (e.PropertyName == FloatingActionButtonView.ColorPressedProperty.PropertyName)
//      {
//        fab.ColorPressed = Element.ColorPressed.ToAndroid();
//      }
//      else if (e.PropertyName == FloatingActionButtonView.ColorRippleProperty.PropertyName)
//      {
//        fab.ColorRipple = Element.ColorRipple.ToAndroid();
//      }
//    }

//    void SetFabImage(string imageName)
//    {
//      if (!string.IsNullOrWhiteSpace(imageName))
//      {
//        try
//        {
//          var drawableNameWithoutExtension = Path.GetFileNameWithoutExtension(imageName);
//          var resources = context.Resources;
//          var imageResourceName = resources.GetIdentifier(drawableNameWithoutExtension, "drawable", context.PackageName);
//          fab.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeResource(context.Resources, imageResourceName));
//        }
//        catch (Exception ex)
//        {
//          throw new FileNotFoundException("There was no Android Drawable by that name.", ex);
//        }
//      }
//    }
//  }
//}
