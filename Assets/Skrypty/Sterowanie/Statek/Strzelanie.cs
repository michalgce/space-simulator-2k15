using UnityEngine;
using System.Collections;

public class Strzelanie : MonoBehaviour {

	public GameObject strzal;
	public Transform spawnPocisku;
	public float fireRate;
	public int destroyAfterSec;

	private float nextFire;

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject objekt = Instantiate(strzal, spawnPocisku.position, spawnPocisku.rotation) as GameObject;
			Destroy(objekt, destroyAfterSec);
		}
	}
}
