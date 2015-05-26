using UnityEngine;
using System.Collections;

public class Strzelanie : MonoBehaviour {

	public GameObject strzal;
	public Transform spawnPocisku;
	public float fireRate;
	public int destroyAfterSec;
	public GameObject pasekAmunicji;

	private float nextFire;

	private ObslugaPaska obslugaPaskaAmunicji;
	private float strataEnergiiNaPocisk = (0.1f);  // 0.0 - nic, 1.0 - cala energia
	

	void Start () {
		obslugaPaskaAmunicji = pasekAmunicji.GetComponent<ObslugaPaska> ();
	}

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire && obslugaPaskaAmunicji.JakiStanPaska() >= strataEnergiiNaPocisk) {
			nextFire = Time.time + fireRate;
			GameObject objekt = Instantiate(strzal, spawnPocisku.position, spawnPocisku.rotation) as GameObject;
			Destroy(objekt, destroyAfterSec);
			obslugaPaskaAmunicji.ZmienStanPaska(strataEnergiiNaPocisk);
		}
	}
}
