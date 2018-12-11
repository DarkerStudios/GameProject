using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRockScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 20, 0);
            Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutorunMovementScript>());
            GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerAutorunMovementScript>();
        }
    }
}
