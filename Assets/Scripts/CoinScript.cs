using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CapsuleCollider))]

public class CoinScript : MonoBehaviour {

	void Update () {
        transform.Rotate(0, 150 * Time.deltaTime, 0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("StatsManager").GetComponent<StatsManagerScript>().AddCoins(1);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled=false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(WaitForDestroy());
        }
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
