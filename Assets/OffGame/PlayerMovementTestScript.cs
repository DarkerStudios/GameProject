using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTestScript : MonoBehaviour {

    private float playerForwardSpeed = 6.0f;
    private float playerSidewaysSpeed = 4.0f;
    private float playerDownSpeed = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(Input.GetAxis("Horizontal") * playerSidewaysSpeed * Time.deltaTime, playerDownSpeed*Time.deltaTime, playerForwardSpeed * Time.deltaTime);
        if(Physics.Raycast(gameObject.transform.position,-gameObject.transform.up,1))
        {
            playerDownSpeed = 0;
        }
        else
        {
            playerDownSpeed = playerDownSpeed-0.5f;
        }
        if(Input.GetKeyDown("space"))
        {
            Jump();
        }
	}
    void Jump()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(1, 4, 0);
    }
}
