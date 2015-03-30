using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;

	private Vector3[] vectors = new Vector3[]{new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(1, 1, 1), 
		new Vector3(1, 0, 1), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};

	void Start ()
	{
		int rand = (int) Random.Range (0, 6);
		GetComponent<Rigidbody>().velocity = vectors[rand] * speed;
	}
}
