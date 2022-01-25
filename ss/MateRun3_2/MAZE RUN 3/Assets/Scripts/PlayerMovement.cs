using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rotation
    public float turnSpeed = 20f;  //public appear in the inpector window

    Animator m_Animator;
    Vector3 m_Movement;
    // apply Movement and Rotation
    Rigidbody m_Rigidbody;


    //storing Rotations
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        // <What type of Component>
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called before the physics system
    void FixedUpdate()
    {
        // gettin input from keyboard and save as float
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // set movement with function .Set
        m_Movement.Set(horizontal, 0f, vertical);
        // normalize the size of the vector
        m_Movement.Normalize();
        // hasHorizontalInput is true if the 2 parameters are equal and false otherwise
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // logical or operator-->
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        // SetBool Method (name of teh Animator, value)
        m_Animator.SetBool("IsWalking", isWalking);

        // for Rotation
        // RotateTowards is a static method from teh Vector3 class
        // 4 parameters =  transform.forward is a shortcut to access the Transform component and get its forward vector
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    // apply root motion
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
