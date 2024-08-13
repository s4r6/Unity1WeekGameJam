using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneTransitionManager : MonoBehaviour
{
    public void OnClickedBackButton()
    {
        SceneManager.LoadScene(
            SceneDictionary.TypeOfName[SceneType.Title]
            );
    }
}
