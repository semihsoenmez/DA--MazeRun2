using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthbar;

    public void UpdateHealthbar(float fraction)
    {
        healthbar.fillAmount = fraction;
    }
}
