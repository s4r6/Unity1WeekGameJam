using UnityEngine;
using UnityEngine.SceneManagement;

public class DescribeSceneTransitonManager : MonoBehaviour
{
    public void OnClickedStartButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.InGame]
            );
    }

    public void OnClickedBackButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.Title]
            );
    }
}
