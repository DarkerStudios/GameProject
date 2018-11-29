using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < 10)
        {
            Instantiate(gameObject, new Vector3(0, 20, 0), Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
