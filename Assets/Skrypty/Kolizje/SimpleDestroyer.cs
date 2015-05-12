using UnityEngine;
using System.Collections;

public class SimpleDestroyer : MonoBehaviour
{
	public GameObject explosion;

	void Start ()
	{
	}

	void OnTriggerEnter (Collider other)
	{
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		//Destroy (other.gameObject);
		Destroy (gameObject);
	}
}