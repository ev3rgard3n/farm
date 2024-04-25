using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagare : MonoBehaviour
{
   public void ChangeScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void LoadNewGame(int numberGame)
    {
        SaveManager.ClearAllData();
        SceneManager.LoadScene(numberGame);
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
