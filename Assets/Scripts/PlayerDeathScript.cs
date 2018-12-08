using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour {
    public float deathHeight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < deathHeight)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 20, 0);
            Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutorunMovementScript>());
            GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerAutorunMovementScript>();
            //Instantiate(gameObject, new Vector3(0, 20, 0), Quaternion.identity);
            //Destroy(gameObject);
        }
	}
}
