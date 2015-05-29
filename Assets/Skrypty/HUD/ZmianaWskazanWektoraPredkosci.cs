using UnityEngine;
using System.Collections;

public class ZmianaWskazanWektoraPredkosci : MonoBehaviour {

	public GameObject statek;
	public GameObject MenagerKamer;
	public bool czyOsieZY;

	private float predkoscStatkuMax;
	private Vector3 velocity;
	private Rigidbody rigidbodyStatku;
	private PrzelaczanieKamer pk ;

	// Use this for initialization
	void Start () {
		predkoscStatkuMax = statek.GetComponent<RuchPostepowyStatku> ().predkoscStatkuMax;
		rigidbodyStatku = statek.GetComponent<Rigidbody>();
		pk = MenagerKamer.GetComponent<PrzelaczanieKamer>();
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 velocity = rigidbodyStatku.velocity;
		//velocity = pk.PobierzKamereBiezaca().transform.rotation * velocity;
		velocity = statek.transform.localRotation * velocity;

		float katGlowny;

		if (czyOsieZY) {

			if (Mathf.Abs (velocity.x) > 0.0f) {

				katGlowny = Mathf.Atan (velocity.z / velocity.x) * Mathf.Rad2Deg + 90.0f;

				if ((velocity.z < 0.0f && velocity.x > 0.0f) || (velocity.z > 0.0f && velocity.x > 0.0f))
					katGlowny += 180;
				katGlowny = -katGlowny;

			} else {
				if (velocity.z >= 0.0f)
					katGlowny = 0.0f;
				else
					katGlowny = 180.0f;
			}

		} else {
			if (Mathf.Abs (velocity.x) > 0.0f) {
				
				katGlowny = Mathf.Atan (velocity.y / velocity.x) * Mathf.Rad2Deg + 90.0f;
				
				if ((velocity.y < 0.0f && velocity.x > 0.0f) || (velocity.y > 0.0f && velocity.x > 0.0f))
					katGlowny += 180;
				
				
			} else {
				if (velocity.y >= 0.0f)
					katGlowny = 0.0f;
				else
					katGlowny = 180.0f;
			}
		}
			
		float katDrugorzedny;
		//katDrugorzedny = velocity.normalized.y * 90.0f;
		katDrugorzedny = 0.0f;


		transform.eulerAngles = new Vector3 (katDrugorzedny, 0.0f, katGlowny);

		float scale;

		if (velocity.magnitude < 0.005f)
			scale = 0.0f;
		else 
			scale = velocity.magnitude / predkoscStatkuMax + 0.3f;

		if (scale > 1.0f)
			scale = 1.0f;

		transform.localScale = new Vector3(scale, scale, scale);




	}
}
