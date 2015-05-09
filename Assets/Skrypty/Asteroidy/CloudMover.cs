using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour
{
	private Vector3 kierunek;

	public void setKierunek(Vector3 v){
		kierunek = v;
	}

	void Start () {
	}

	void FixedUpdate() {
		GetComponent<Rigidbody>().AddForce(kierunek);
	}
}