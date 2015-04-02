using UnityEngine;
using System.Collections;

// NAPED POSTEPOWY PRZEDNI I TYLNI (USTAWIANY ZA POMOCA KLAWISZY 1-5) 
// ORAZ LEWO PRAWO GORA DOL (KLAWISZE WSAD)

public class RuchPostepowyStatku : MonoBehaviour {


	private int mocSilnika = 0;

	private int mnoznikMocySilnika = 1;

	public ParticleSystem spalinySilnikaGlownego;


	void Start () {
	
	}
	
	void Update () {

		if (Input.anyKeyDown) {

			// USTAWIENIE SILY WZDLOZ OSI Z
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




			// RESET POZYCJI I ROTACJI
			if (Input.GetKey (KeyCode.R)) {
				gameObject.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
				gameObject.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
			}

		}

//		// USTAWIENIE SIL WZDLOZ OSI X I Y
//		if (Input.GetMouseButton (1)) {
//			if (Input.GetKey(KeyCode.A))
//				translationX += 1.0f;
//			if (Input.GetKey(KeyCode.D))
//				translationX -= 1.0f;
//			if (Input.GetKey(KeyCode.W))
//				translationY += 1.0f;
//			if (Input.GetKey(KeyCode.S))
//				translationY -= 1.0f;
//		}



		// dodanie sil
		if (!SterowanieOgolne.kameraAktywna)
			this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), mocSilnika) * Time.deltaTime);
		else
			this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, 0.0f, mocSilnika) * Time.deltaTime);


	}
}
