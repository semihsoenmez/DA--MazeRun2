using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameScene()
    {
        //SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene("SchoolSceneDayMazeRun");
    }
    
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SelectLoginRegisterScene()
    {
        SceneManager.LoadScene("SelectLoginRegisterScene");
    }

    public void LoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void RegisterScene()
    {
        SceneManager.LoadScene("RegisterScene");
    }

    public void QuestionScene()
    {
        SceneManager.LoadScene("QuestionScene");
    }

    public void ReloadMainScene()
    {
        SceneManager.LoadScene(GameEnding.countScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
