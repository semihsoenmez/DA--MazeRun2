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

//public void TakeDamage(int damage)
//{
//    curHealth -= damage;
//    //curHealth2 = curHealth* 0.1;
//    healthbar.UpdateHealthbar((float)curHealth / (float)maxHealth);

//}
