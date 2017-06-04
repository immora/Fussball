using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Fussball.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string MatchCountKey = "matchCount_key";
    private static readonly int MatchCountDefault = 3;

    private const string MatchTimeKey = "matchTime_key";
    private static readonly int MatchTimeDefault = 5;

    private const string GoalLimitKey = "goalLimit_key";
    private static readonly int GoalLimitDefault = 0;

    #endregion

    public static int MatchCount
    {
      get => AppSettings.GetValueOrDefault<int>(MatchCountKey, MatchCountDefault);
      set => AppSettings.AddOrUpdateValue<int>(MatchCountKey, value);
    }

    public static int MatchTime
    {
      get => AppSettings.GetValueOrDefault<int>(MatchTimeKey, MatchTimeDefault);
      set => AppSettings.AddOrUpdateValue<int>(MatchTimeKey, value);
    }

    public static int GoalLimit
    {
      get => AppSettings.GetValueOrDefault<int>(GoalLimitKey, GoalLimitDefault);
      set => AppSettings.AddOrUpdateValue<int>(GoalLimitKey, value);
    }
  }
}