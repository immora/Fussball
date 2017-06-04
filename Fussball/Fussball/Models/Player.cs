using Fussball.Utils.ExtensionMethods;
//using SQLite;

namespace Fussball.Models
{
  public class Player
  {
    //[PrimaryKey, AutoIncrement] //for sqllite
    public int Id { get; set; }

    public string DisplayName { get; set; }

    public string AvatarPath
    {
      get => DisplayName.ToLower().ReplacePolishSigns() + ".jpg";
    }

    public string ImagePath { get; set; } //forsqllite

    public override string ToString()
    {
      return DisplayName;
    }
  }
}
