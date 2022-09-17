using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement01 : MonoBehaviour
{
    public float sensitivity = 5;

    public float movementSpeed = 6.0F;

    public float jumpSpeed = 8.0F;

    public float gravity = 20.0F;

    private float looker;

    private Vector3 moveDirection = Vector3.zero;

    private float turner;

    //public object controller;
    // Use this for initialization
    void Start()
    {
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, zAxis);

        Move (direction);

        turner = Input.GetAxis("Mouse X") * sensitivity;
        //looker = -Input.GetAxis("Mouse Y") * sensitivity;
        if (turner != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;

        //Making the character move
        Move(moveDirection * Time.deltaTime);
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
