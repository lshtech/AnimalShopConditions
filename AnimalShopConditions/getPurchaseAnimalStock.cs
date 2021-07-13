using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI;
using StardewValley;

namespace AnimalShopConditions
{
  // ReSharper disable once InconsistentNaming
  internal class getPurchaseAnimalStock
  {
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    public static void Postfix(ref List<Object> __result)
    {
      foreach (var condition in ModEntry.Config.AnimalConditions)
      {
        if (ModEntry.ConditionsChecker.CheckConditions(condition.ConditionString())) continue;
        foreach (var animal in __result.Where(animal => animal.Name == condition.AnimalName))
        {
          __result.Remove(animal);
          break;
        }
      }
    }
  }
}