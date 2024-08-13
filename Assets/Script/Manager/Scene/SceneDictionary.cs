
using System.Collections.Generic;

public static class SceneDictionary
{
    public static Dictionary<SceneType, string> TypeOfName = new()
    {
        [SceneType.Unknown] = "",
        [SceneType.Title] = "Title",
        [SceneType.Describe] = "Describe",
        [SceneType.Credit] = "Credit",
        [SceneType.InGame] = "Onishi_InGame",
        [SceneType.Result] = "Onishi_Result"
    };
}

