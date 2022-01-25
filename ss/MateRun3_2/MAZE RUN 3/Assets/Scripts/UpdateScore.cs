using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{

  //public InputField nameField;
    //public InputField passwordField;
    public TMP_Text score;

    //public Button submitButton;

    //nameField = GetComponent<TextMeshPro()>;
    public void CallLogin() //Connect to PHP-File
    {
        StartCoroutine(Login());
        Debug.Log("Routine Started");
    }

    IEnumerator Login() //PHP-File location
    {
        WWWForm form = new WWWForm(); //information that need to passed
        form.AddField("score", score.text);
        //form.AddField("password", passwordField.text);
        Debug.Log("Routine Started 2");
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Diplomarbeit/MazeRun_Login/login.php?", form);

        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        if (www.downloadHandler.text == "Password is correct") //PHP says no error
        {
            Debug.Log("Logged in successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Login failed. Error: \n" + www.downloadHandler.text);
        }
        //Debug.Log(www.downloadHandler.text);

    }

    public void VerifyInputs() //input requirements
    {
        //submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8); //name and password should be atleast 8 characters long
    }
}
