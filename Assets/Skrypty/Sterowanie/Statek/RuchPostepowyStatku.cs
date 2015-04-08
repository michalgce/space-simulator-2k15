using UnityEngine;
using System.Collections;

// NAPED POSTEPOWY PRZEDNI I TYLNI (USTAWIANY ZA POMOCA KLAWISZY 1-5) 
// ORAZ LEWO PRAWO GORA DOL (KLAWISZE WSAD)
// R - RESET PPOZYCJI
// T - RESET SIL POSTEPOWYCH

public class RuchPostepowyStatku : MonoBehaviour {


	public float mocSilnika = 0.0f;

	public float mnoznikMocySilnika = 0.1f;

	public ParticleSystem spalinySilnikaGlownego1;
	public ParticleSystem spalinySilnikaGlownego2;

	private Vector3 pozycjaStartowa;

	void Start () {
		pozycjaStartowa = transform.localPosition;
	}
	
	void Update () {


		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.Alpha0))
				mocSilnika = 0.0f;
			if (Input.GetKeyDown (KeyCode.Alpha1))
				mocSilnika = 0.2f;
			if (Input.GetKeyDown (KeyCode.Alpha2))
				mocSilnika = 0.4f;
			if (Input.GetKeyDown (KeyCode.Alpha3))
				mocSilnika = 0.6f;
			if (Input.GetKeyDown (KeyCode.Alpha4))
				mocSilnika = 0.8f;
			if (Input.GetKeyDown (KeyCode.Alpha5))
				mocSilnika = 1.0f;

			obsluzSpaliny();
		}


		if (SterowanieOgolne.sterowanieStatkiemAktywne && Input.mouseScrollDelta.y != 0.0f) {

			// USTAWIENIE SILY WZDLOZ OSI Z

			// 0.1f - graniczna pozycja mocy silnika - wlacz lub wylacz silnik
			if ((mocSilnika) < 0.01f && (Input.mouseScrollDelta.y > 0.0f))
					mocSilnika = 0.1f;
			else 
				mocSilnika += 0.02f * Input.mouseScrollDelta.y;

			mocSilnika = (mocSilnika > 1.0f ? 1.0f : mocSilnika);
			mocSilnika = (mocSilnika < 0.099f ? 0.0f : mocSilnika);

			obsluzSpaliny();
		}


		// dodanie sil
		if (SterowanieOgolne.sterowanieStatkiemAktywne)
			this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Input.GetAxis ("Horizontal") * 5.0f, Input.GetAxis ("Vertical") * 5.0f, mocSilnika) * Time.deltaTime * mnoznikMocySilnika);
		else
			this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, 0.0f, mocSilnika) * Time.deltaTime * mnoznikMocySilnika);


		// RESETOWANIE
		if (SterowanieOgolne.sterowanieStatkiemAktywne) {

			// RESET POZYCJI
			if (Input.GetKey (KeyCode.R)) 
				transform.localPosition = pozycjaStartowa;

			// RESET SIL POSTEPOWYCH
			if (Input.GetKey (KeyCode.T)) 
				this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3();
		}

	}

	void obsluzSpaliny() {

		spalinySilnikaGlownego1.transform.localPosition = new Vector3(spalinySilnikaGlownego1.transform.localPosition.x, spalinySilnikaGlownego1.transform.localPosition.y, -(6.0f + mocSilnika * 0.5f));
		spalinySilnikaGlownego1.startSpeed =  mocSilnika * 2 - 0.2f;
		spalinySilnikaGlownego1.startSize = (mocSilnika > 0.05f ? mocSilnika * 0.5f + 0.1f : 0.0f);
		
		spalinySilnikaGlownego2.transform.localPosition = new Vector3(spalinySilnikaGlownego2.transform.localPosition.x, spalinySilnikaGlownego2.transform.localPosition.y, -(6.0f + mocSilnika * 0.5f));
		spalinySilnikaGlownego2.startSpeed =  mocSilnika * 2 - 0.2f;
		spalinySilnikaGlownego2.startSize = (mocSilnika > 0.05f ? mocSilnika * 0.5f + 0.1f : 0.0f);

	}
}
