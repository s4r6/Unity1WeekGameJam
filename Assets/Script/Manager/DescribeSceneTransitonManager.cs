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
}
