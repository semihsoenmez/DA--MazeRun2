using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    public GameObject ball;
    public Text goals;


    bool tor = false;
    int goals1 = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tor)
        {
            if (goals1 < 6)
            {
                tor = false;
                goals.text = "Anzahl Tore: " + System.Convert.ToString(goals1);
            }
            else
            {
                goals.text = "Du Hast die Mission abgeschlossen";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            tor = true;
            goals1++;

            ball.transform.position = new Vector3(-15, 3, 75);
        }
    }
}