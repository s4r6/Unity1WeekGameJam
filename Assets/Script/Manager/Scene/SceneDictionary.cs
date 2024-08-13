
using System.Collections.Generic;

public static class SceneDictionary
{
    public static Dictionary<SceneType, string> TypeOfName = new()
    {
        [SceneType.Unknown] = "",
        [SceneType.Title] = "‘å¼_Title",
        [SceneType.HowToPlay] = "‘å¼_Describe",
        [SceneType.Credit] = "‘å¼_Credit",
        [SceneType.InGame] = "‘å¼Test",
        [SceneType.Result] = "‘å¼_ƒV[ƒ“‘JˆÚTest"
    };
}

