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

    public void OnClickedHowToPlayButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.HowToPlay]
            );
    }

    public void OnClickedCreditButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.Credit]
            );
    }
}
