using System;
using Harmony;
using StardewModdingAPI;
using StardewValley;

namespace AnimalShopConditions
{
  public class ModEntry : Mod
  {
    public static Config Config;
    public static IConditionsChecker ConditionsChecker;

    public override void Entry(IModHelper helper)
    {
      Config = helper.ReadConfig<Config>();
      try
      {
        var harmonyInstance = HarmonyInstance.Create("elbe.AnimalShopConditions");
        harmonyInstance.Patch(original: AccessTools.Method(typeof(Utility), "getPurchaseAnimalStock"),
          postfix: new HarmonyMethod(typeof(getPurchaseAnimalStock), "Postfix"));
      }
      catch (Exception ex)
      {
        Monitor.Log(ex.Message, LogLevel.Error);
      }
      
      helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;


    }

    private void GameLoop_GameLaunched(object sender, StardewModdingAPI.Events.GameLaunchedEventArgs e)
    {
      ConditionsChecker = Helper.ModRegistry.GetApi<IConditionsChecker>("Cherry.ExpandedPreconditionsUtility");
      var verboseMode = false;
      ConditionsChecker.Initialize(verboseMode, ModManifest.UniqueID);
    }
  }
}