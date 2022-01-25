using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class GetUsername : MonoBehaviour
{

    private string username;
    private bool login;
    private bool register;
    public TextMeshProUGUI usernameTextField;
    // Start is called before the first frame update
    public void GetName()
    {
        //usernameTextField = GetComponent<TextMeshProUGUI>();
        login = GetComponent<LoginUsers>().login;
        register = GetComponent<RegisterUsers>().register;
        if (login == true)
        {
            Debug.Log("login is true");
            //username = GetComponent<LoginUsers>().nameField.text;
            usernameTextField.text = GetComponent<LoginUsers>().username;
        }
        if (register == true)
        {
            username = GetComponent<RegisterUsers>().nameField.text;
            usernameTextField.text = username;
        }

    }

    
}
