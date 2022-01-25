using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// duration = dauer
// fade out = ausblenden
// The game will end if JohnLemon escapes or if he's cought
public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;             // variable to fade out the screen
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;    // this will display if John Lemon has been caught

    bool m_IsPlayerAtExit;  
    bool m_IsPlayerCaught;  //This variable will check whether JohnLemon has been caught
    float m_Timer;

    public static bool gameIsPaused;
    public static Scene scene;
    public static int countScene;


    void OnTriggerEnter(Collider other)     //checks if the Collider that entered the Trigger belongs to the player’s character
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
    void Update()       // getting called every frame
    {
        if (m_IsPlayerAtExit)       // checking if player is at the exit
        {
            ENDLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (m_IsPlayerCaught)
        {
            //countScene = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene("QuestionScene");

            ENDLevel(caughtBackgroundImageCanvasGroup, true);
            gameIsPaused = !gameIsPaused;
            PauseGame();

        }
    }
    void ENDLevel(CanvasGroup ImageCanvasGroup, bool doRestart) //the script will change the alpha of whatever is passed in as a parameter
    {
        m_Timer += Time.deltaTime;      // set Timer
        ImageCanvasGroup.alpha = m_Timer / fadeDuration;  // Image will fade in when JohnLemon reaches the exit
        
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                //SceneManager.LoadScene(0);      // Load Scene again if player has been caught
                
                
                //SceneManager.LoadScene("QuestionScene");


            }
            else
            {
                Application.Quit();
            }
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        
        else
        {
            Time.timeScale = 1;
        }
    }

}
