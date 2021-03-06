using System.Collections.Generic;
using System.Linq;

namespace AnimalShopConditions
{
  public class Config
  {
    public IEnumerable<AnimalCondition> AnimalConditions { get; set; }
  }

  public class AnimalCondition
  {
    public string AnimalName { get; set; }
    public IEnumerable<string> Conditions { get; set; }

    internal string ConditionString()
    {
      var conditionString = Conditions.Aggregate(
        string.Empty, (current, condition) => current + (condition + '/'));
      if (conditionString.Length > 0)
        conditionString = conditionString.TrimEnd('/');
      return conditionString;
    }
  }
}