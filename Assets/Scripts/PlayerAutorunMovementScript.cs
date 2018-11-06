﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutorunMovementScript : MonoBehaviour
{
    //CharacterController can move the character easily with SimpleMove() or Move() method. We are using Move()
    private CharacterController controller;
    //The direction player will be moving. Vector3 = (x, y, z). Each value can be changed, without touching other values
    private Vector3 moveDirection;

    //Used for gravity setting
    private bool isFalling = false;

    //Advanced moving
    float targetXLocation;
    float currentXLocation;
    bool isMoving = false;
    float distanceLeft;

    //Called when the game starts
    void Start()
    {
        Application.targetFrameRate = 60;
        //Gets our players CharacterController and stores it to a variable. By this way we don't have to get the controller every frame below
        controller = gameObject.GetComponent<CharacterController>();
    }

    //Update is called every frame
    void Update()
    {
        currentXLocation = gameObject.transform.position.x;
        if (isMoving == true)
        {
            Debug.Log("MOVING");
            distanceLeft = Mathf.Abs(currentXLocation - targetXLocation);
            if (CloseEnough(currentXLocation, targetXLocation, 0.1f))
            {
                isMoving = false;
                moveDirection.x = 0;
                gameObject.transform.position = new Vector3(targetXLocation, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                if (currentXLocation > targetXLocation)
                {
                    moveDirection.x = -distanceLeft * 2 - 6;
                    Debug.Log("1");
                }
                else
                {
                    moveDirection.x = distanceLeft * 3 + 6;
                    Debug.Log("2");
                }
            }
        }

        if (Input.GetButtonDown("GoLeft"))
        {
            GoLeftPressed();
        }
        else if (Input.GetButtonDown("GoRight"))
        {
            GoRightPressed();
        }

        //Checks if the player is on ground
        if (controller.isGrounded)
        {
            isFalling = false;
            //If player jumps, we set the direction y value to 8. This value determines, how high the player will jump
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = 8;
            }
        }
        else
        {
            //if character is not on ground and has no upward power left from jumping, it's is falling
            if (isFalling == false && moveDirection.y <= 0)
            {
                isFalling = true;
                moveDirection.y = -2;
            }
            //direction y is the gravity of the player. Changing the value below determines, how much gravity the player has
            moveDirection.y = moveDirection.y - 20 * Time.deltaTime;
        }

        //OLD CODE
        //Changes the direction x value (left/right). The value 2 determines, how fast the player can move sideways
        //moveDirection.x = Input.GetAxis("Horizontal") * 200 * Time.deltaTime;

        //direction z determines, how fast the player will move forward
        moveDirection.z = gameObject.transform.forward.z * 8;

        //Finally the controller.Move() will update our players location
        controller.Move(moveDirection * Time.deltaTime);
    }

    void GoLeftPressed()
    {

        if (currentXLocation >= 0 || CloseEnough(currentXLocation, 0, 1.0f))
        {
            if (currentXLocation == 0 || CloseEnough(currentXLocation,0,1.0f))
            {
                targetXLocation = -3;
            }
            else
            {
                targetXLocation = 0;
            }
            isMoving = true;
        }
    }
    void GoRightPressed()
    {
        if (currentXLocation <= 0 || CloseEnough(currentXLocation, 0, 1.0f))
        {
            if (currentXLocation == 0 || CloseEnough(currentXLocation, 0, 1.0f))
            {
                targetXLocation = 3;
            }
            else
            {
                targetXLocation = 0;
            }
            isMoving = true;
        }
    }
    public static bool CloseEnough(float firstNumber, float secondNumber, float threshold)
    {
        return ((firstNumber - secondNumber) < 0 ? ((firstNumber - secondNumber) * -1) : (firstNumber - secondNumber)) <= threshold;
    }
}
