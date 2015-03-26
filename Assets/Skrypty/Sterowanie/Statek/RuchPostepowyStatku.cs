using UnityEngine;
using System.Collections;

// Naped postepowy, przede wszystkim naped przedni i wsteczny. 
// Dla statku kosmicznego przydalby sie jeszcze ciag gora dol i na boki

public class RuchPostepowyStatku : MonoBehaviour {


	private int mocSilnika = 0;

	private int mnoznikMocySilnika = 1;

	public ParticleSystem spalinySilnikaGlownego;

	public float x;

	public float y;

	public float z;

	public float q;


	void Start () {
	
	}
	
	void Update () {

		// przod/tyl

		this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, mocSilnika * Time.deltaTime));
		//this.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.rotation.eulerAngles.normalized * mocSilnika * Time.deltaTime);



		// DO PORPAWKI

		if (Input.anyKeyDown) {

			if (Input.GetKeyDown (KeyCode.Alpha0))
				mocSilnika = 0;
			if (Input.GetKeyDown (KeyCode.Alpha1))
				mocSilnika = 1 * mnoznikMocySilnika;
			if (Input.GetKeyDown (KeyCode.Alpha2))
				mocSilnika = 2 * mnoznikMocySilnika;
			if (Input.GetKeyDown (KeyCode.Alpha3))
				mocSilnika = 3 * mnoznikMocySilnika;
			if (Input.GetKeyDown (KeyCode.Alpha4))
				mocSilnika = 4 * mnoznikMocySilnika;
			if (Input.GetKeyDown (KeyCode.Alpha5))
				mocSilnika = 5 * mnoznikMocySilnika;


			spalinySilnikaGlownego.startSpeed = 0.2f + mocSilnika / 2.0f;
			spalinySilnikaGlownego.startSize = 0.5f + mocSilnika / 10.0f;
			spalinySilnikaGlownego.emissionRate = 2 + mocSilnika * 5;
		}

		if (!Input.GetMouseButton (0)) {
			// RUCHY WSAD
		}
		

		// reset
		if (Input.GetKey (KeyCode.R)) {
			gameObject.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
			gameObject.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
		}


	}
}
