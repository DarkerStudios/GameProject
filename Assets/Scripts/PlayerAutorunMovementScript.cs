using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutorunMovementScript : MonoBehaviour
{
    //CharacterController can move the character easily with SimpleMove() or Move() method. We are using Move()
    private CharacterController controller;
    //The direction player will be moving. Vector3 = (x, y, z). Each value can be changed, without touching other values
    private Vector3 moveDirection;

    //Animator controls what animation will be played and when
    private Animator movementAnimator;

    //Used for gravity setting + jump can be only done if player is not falling
    private bool isFalling = false;

    //Advanced moving
    float targetXLocation;
    float currentXLocation;
    bool isMoving = false;
    float distanceLeft;

    //Determines the forward moving speed. Other values should be changed aswell if this will be changed
    private float forwardSpeedMultiplier = 8.0f;
    //MoveToNextLevelScript sets this true in the end of the level. Player will slow down slightly when this is set true
    private bool isOnEndOfLevel = false;

    //Called when the game starts
    void Start()
    {
        //Gets the Animator from child
        movementAnimator = gameObject.GetComponentInChildren<Animator>();
        //Gets our players CharacterController and stores it to a variable. By this way we don't have to get the controller every frame below
        controller = gameObject.GetComponent<CharacterController>();
    }

    //Called every frame
    void Update()
    {
        //Checks the x location (left/right location)
        currentXLocation = gameObject.transform.position.x;
        if (isMoving == true)
        {
            //Checks the location for the target X location (used for determining speed for left/right movement)
            distanceLeft = Mathf.Abs(currentXLocation - targetXLocation);
            if (CloseEnough(currentXLocation, targetXLocation, 0.1f))
            {
                //Stops the player
                isMoving = false;
                moveDirection.x = 0;
                gameObject.transform.position = new Vector3(targetXLocation, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                //These determines how fast the player will move during going left/right
                if (currentXLocation > targetXLocation)
                {
                    moveDirection.x = -distanceLeft * 2 - 6;
                }
                else
                {
                    moveDirection.x = distanceLeft * 3 + 6;
                }
            }
        }

        //PC input only
        if (Input.GetButtonDown("GoLeft"))
        {
            GoLeftPressed();
        }
        //PC input only
        else if (Input.GetButtonDown("GoRight"))
        {
            GoRightPressed();
        }
        else if(isMoving == false)
        {
            movementAnimator.SetBool("Left", false);
            movementAnimator.SetBool("Right", false);
        }

        //Checks if the player is on ground
        if (controller.isGrounded)
        {
            movementAnimator.SetBool("Jump", false);
            movementAnimator.SetBool("Run", true);
            
            isFalling = false;
            if (Input.GetButtonDown("Jump"))
            {
                JumpPressed();
            }
        }
        else
        {
            movementAnimator.SetBool("Run", false);
            movementAnimator.SetBool("Jump", true);
            
            //if character is not on ground and has no upward power left from jumping, it's is falling
            if (isFalling == false && moveDirection.y <= 0)
            {
                isFalling = true;
                moveDirection.y = -2;
            }
            //direction y is the gravity of the player. Changing the value below determines, how much gravity the player has
            moveDirection.y = moveDirection.y - 20 * Time.deltaTime;
        }

        if(isOnEndOfLevel==false)
        {
            //direction z determines, how fast the player will move forward
            moveDirection.z = gameObject.transform.forward.z * forwardSpeedMultiplier;
        }
        else if(forwardSpeedMultiplier>0)
        {
            //slows down the player if it is in end of the level
            forwardSpeedMultiplier = forwardSpeedMultiplier - Time.deltaTime * 5;
            if(forwardSpeedMultiplier<0)
            {
                forwardSpeedMultiplier = 0;
            }
            moveDirection.z = gameObject.transform.forward.z * forwardSpeedMultiplier;
        }

        //Finally the controller.Move() will update our players location
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void GoLeftPressed()
    {
        movementAnimator.SetBool("Right", false);
        movementAnimator.SetBool("Left", true);
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
    public void GoRightPressed()
    {
        movementAnimator.SetBool("Left", false);
        movementAnimator.SetBool("Right", true);
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
    public void JumpPressed()
    {
        if (controller.isGrounded)
        {
            //If player jumps, we set the direction y value to 9. This value determines, how high the player will jump
            moveDirection.y = 9;
        }
    }
    public static bool CloseEnough(float firstNumber, float secondNumber, float threshold)
    {
        return ((firstNumber - secondNumber) < 0 ? ((firstNumber - secondNumber) * -1) : (firstNumber - secondNumber)) <= threshold;
    }

    //At the end of level
    public void SlowDown()
    {
        isOnEndOfLevel = true;
    }
}
