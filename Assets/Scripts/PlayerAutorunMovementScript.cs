using System.Collections;
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

    float targetXLocation;
    float currentXLocation;

    //Called when the game starts
    void Start ()
    {
        //Gets our players CharacterController and stores it to a variable. By this way we don't have to get the controller every frame below
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	//Update is called every frame
	void Update ()
    {
        //Checks if the player is on ground
        if (controller.isGrounded)
        {
            isFalling = false;
            //If player jumps, we set the direction y value to 8. This value determines, how high the player will jump
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = 10;
            }
        }
        else 
        {
            //if character is not on ground and has no upward power left from jumping, it's is falling
            if (isFalling==false&&moveDirection.y<=0)
            {
                isFalling = true;
                moveDirection.y = 0;
            }
            //direction y is the gravity of the player. Changing the value below determines, how much gravity the player has
            moveDirection.y = moveDirection.y - 20 * Time.deltaTime;
        }

        //Changes the direction x value (left/right). The value 2 determines, how fast the player can move sideways
        moveDirection.x = Input.GetAxis("Horizontal") * 200 * Time.deltaTime;

        //direction z determines, how fast the player will move forward
        moveDirection.z = gameObject.transform.forward.z * 6;

        //Finally the controller.Move() will update our players location
        controller.Move(moveDirection * Time.deltaTime);
    }
}
