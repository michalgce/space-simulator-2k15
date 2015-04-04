using UnityEngine;
using System.Collections;

public class Strzal : MonoBehaviour {

	public float speed;

	void Start () {
		GameObject statek = GameObject.FindGameObjectWithTag ("Statek");
		GetComponent<Rigidbody>().velocity = statek.transform.forward * speed;
	}
}
