using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class RegisterUsers : MonoBehaviour
{

    public InputField nameField;
    public InputField passwordField;
    public bool register = false;
    public Button submitButton;

    //nameField = GetComponent<TextMeshPro()>;
    public void CallRegister() //Connect to PHP-File
    {
        StartCoroutine(Register());
        Debug.Log("Routine Started");
    }

    IEnumerator Register() //PHP-File location
    {
        WWWForm form = new WWWForm(); //information that need to passed
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        Debug.Log("Routine Started 2");
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Diplomarbeit/MazeRun_Login/register.php?", form);
          
                yield return www.SendWebRequest();
                if (www.downloadHandler.text == "0") //PHP says no error
                {
                    Debug.Log("User created successfully.");
                    //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    register = true;
                }
                else
                {
                    Debug.Log("User creation failed. Error #" + www.downloadHandler.text);
                }
        Debug.Log(www.downloadHandler.text);

    }

        public void VerifyInputs() //input requirements
        {
            submitButton.interactable = (nameField.text.Length >= 1 && passwordField.text.Length >= 1); //name and password should be atleast 8 characters long
        }
    } 
