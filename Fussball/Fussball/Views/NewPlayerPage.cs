using ImageCircle.Forms.Plugin.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fussball.Views
{
  public class NewPlayerPage : ContentPage
  {
    CircleImage uploadedImage;

    public NewPlayerPage()
    {
      Entry playerNameEntry = new Entry
      {
        Placeholder = "Imie gracza"
      };
      //playerNameEntry.SetBinding(Entry.TextProperty, new Binding("PlayerName", BindingMode.OneWay));

      Button choosePicFromGalleryButton = new Button
      {
        Text = "Wybierz istniejace zdjecie"
      };
      choosePicFromGalleryButton.Clicked += ChoosePicFromGalleryButton_Clicked;

      Button takeAPictureButton = new Button
      {
        Text = "Zrob zdjecie",
      };
      takeAPictureButton.Clicked += TakeAPictureButton_Clicked;

      uploadedImage = new CircleImage
      {
        WidthRequest = 200,
        HeightRequest = 200,
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Aspect = Aspect.AspectFill,
      };

      //uploadedImage.SetBinding(CircleImage.SourceProperty, new Binding("ImageSource"));

      Button addPlayerButton = new Button
      {
        Text = "Dodaj"
      };
      addPlayerButton.Clicked += AddPlayerButton_Clicked;

      Content = new StackLayout
      {
        Children =
        {
          playerNameEntry,
          choosePicFromGalleryButton,
          takeAPictureButton,
          uploadedImage,
          addPlayerButton
        }
      };
    }

    private void AddPlayerButton_Clicked(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private async void ChoosePicFromGalleryButton_Clicked(object sender, EventArgs e)
    {
      if (!CrossMedia.Current.IsPickPhotoSupported)
      {
        DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
        return;
      }

      var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
      {
        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
        CompressionQuality = 92
      });

      if (file == null)
        return;

      uploadedImage.Source = ImageSource.FromStream(() =>
      {
        var stream = file.GetStream();
        file.Dispose();
        return stream;
      });
    }

    private async void TakeAPictureButton_Clicked(object sender, EventArgs e)
    {
      if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
      {
        DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
        return;
      }

      var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
      {
        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
        Directory = "FussballPlayers",
        Name = "player.jpg", //coś trzeba z tym zrobić
        CompressionQuality = 92,
        SaveToAlbum = true,
        AllowCropping = true
      });

      if (file == null)
        return;

      DisplayAlert("File Location", file.Path, "OK");

      uploadedImage.Source = ImageSource.FromStream(() =>
      {
        var stream = file.GetStream();
        file.Dispose();
        return stream;
      });
    }
  }
}
