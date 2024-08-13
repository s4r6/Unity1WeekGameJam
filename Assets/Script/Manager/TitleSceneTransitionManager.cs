using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneTransitionManager : MonoBehaviour
{
    public void OnClickedStartButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.InGame]
            );
    }

    public void OnClickedDescribeButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.Describe]
            );
    }

    public void OnClickedCreditButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.Credit]
            );
    }
}
