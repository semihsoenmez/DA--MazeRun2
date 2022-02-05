using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    public Transform player;    // check player character's form
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;   // we need a reference to end the game
    private BasicRigidBodyPush basicRigidBodyPush;
    private StarterAssets.ThirdPersonController thirdPersonController;

    public int damage;


    private void Start()
    {
        basicRigidBodyPush = GameObject.FindObjectOfType<BasicRigidBodyPush>();
        thirdPersonController = GameObject.FindObjectOfType<StarterAssets.ThirdPersonController>();

        if (damage == 0)
        {
            damage = 100;
        }
    }

    void OnTriggerEnter(Collider other)     // When a GameObject collides with another GameObject
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }
    
    void OnTriggerExit(Collider other)      // When a GameObject exits the zone
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;  //JohnLemon’s position minus the PointOfView GameObject’s position | Vector3.up is a shortcut for (0, 1, 0)
            Ray ray = new Ray(transform.position, direction);


            RaycastHit raycastHit;      //Raycast method sets its data to information about whatever the Raycast hit
            if (Physics.Raycast(ray, out raycastHit))        // if statement will only be executed if the Raycast has hit something // out parameter to return information
            {
                if (raycastHit.collider.transform == player)
                {
                    //gameEnding.CaughtPlayer();      // CaughtPlayer method is public
                    //basicRigidBodyPush.TakeDamage(100);
                    thirdPersonController.TakeDamage(damage);
                }
            }
        }
    }
}
