using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class User_and_Score : MonoBehaviour
{
    public Button score_btn; 
    public TextMeshProUGUI user;
    public TextMeshProUGUI points;
    private int points_count = 0;

    // Start is called before the first frame update
    public void Start()
    {
        //user.text = "User: ";
        points.text = "Points: ";
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            points_count++;
        }
        points.text = "Points: " + points_count;
    }
}
