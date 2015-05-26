using UnityEngine;
using System.Collections;

public class ZmianaWskazanWektoraPredkosci : MonoBehaviour {

	public GameObject statek;
	public float kat;
	public GameObject MenagerKamer;

	private float predkoscStatkuMax;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		predkoscStatkuMax = statek.GetComponent<RuchPostepowyStatku> ().predkoscStatkuMax;

	}
	
	// Update is called once per frame
	void Update () {
		//PrzelaczanieKamer pk = MenagerKamer.GetComponent<PrzelaczanieKamer> ();
		//Camera kamera = pk.PobierzKamereBiezaca();


		if (Mathf.Abs (velocity.x) > 0.0f) {

			kat = Mathf.Atan (velocity.y / velocity.x) * Mathf.Rad2Deg + 90.0f;

			if ((velocity.y < 0.0f && velocity.x > 0.0f) || (velocity.y > 0.0f && velocity.x > 0.0f))
				kat += 180;


		} else {
			if (velocity.y >= 0.0f)
				kat = 0.0f;
			else kat = 180.0f;
		}
			
		transform.localEulerAngles = new Vector3 (0.0f, 0.0f, kat);

		float scale = velocity.magnitude / predkoscStatkuMax + 0.3f;

		if (scale > 1.0f)
			scale = 1.0f;

		transform.localScale = new Vector3(scale, scale, scale);




	}
}
