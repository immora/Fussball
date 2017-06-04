using Xamarin.Forms;

namespace Fussball.Controls
{
  public class FloatingActionButtonView : View
  {
    public static readonly BindableProperty ImageNameProperty = BindableProperty.Create<FloatingActionButtonView, string>(p => p.ImageName, string.Empty);
    public string ImageName
    {
      get { return (string)GetValue(ImageNameProperty); }
      set { SetValue(ImageNameProperty, value); }
    }

    public static readonly BindableProperty ColorNormalProperty = BindableProperty.Create<FloatingActionButtonView, Color>(p => p.ColorNormal, Color.White);
    public Color ColorNormal
    {
      get { return (Color)GetValue(ColorNormalProperty); }
      set { SetValue(ColorNormalProperty, value); }
    }

    public static readonly BindableProperty ColorPressedProperty = BindableProperty.Create<FloatingActionButtonView, Color>(p => p.ColorPressed, Color.White);
    public Color ColorPressed
    {
      get { return (Color)GetValue(ColorPressedProperty); }
      set { SetValue(ColorPressedProperty, value); }
    }

    public static readonly BindableProperty ColorRippleProperty = BindableProperty.Create<FloatingActionButtonView, Color>(p => p.ColorRipple, Color.White);
    public Color ColorRipple
    {
      get { return (Color)GetValue(ColorRippleProperty); }
      set { SetValue(ColorRippleProperty, value); }
    }
  }
}