using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrapScript : MonoBehaviour {

    public GameObject holder1;
    public GameObject holder2;

    private float currentRotation = 0;
    private readonly float rotationMultiplier = 400;
    private readonly float maxRotation = 90;
    private bool hasActivatedTrap = false;

	
	void Update ()
    {
        if (hasActivatedTrap == true && currentRotation < maxRotation)
        {
            currentRotation = currentRotation + rotationMultiplier * Time.deltaTime;
            holder1.transform.localRotation = Quaternion.Euler(currentRotation, 0, 0);
            holder2.transform.localRotation = Quaternion.Euler(-currentRotation, 0, 0);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            hasActivatedTrap = true;
        }
    }
}
