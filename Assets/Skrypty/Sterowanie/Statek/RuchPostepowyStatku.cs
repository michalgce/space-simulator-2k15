using UnityEngine;
using System.Collections;

// NAPED POSTEPOWY PRZEDNI I TYLNI (USTAWIANY ZA POMOCA KLAWISZY 1-5) 
// ORAZ LEWO PRAWO GORA DOL (KLAWISZE WSAD)
// R - RESET PPOZYCJI
// T - RESET SIL POSTEPOWYCH

public class RuchPostepowyStatku : MonoBehaviour {

	public float predkoscStatku = 0.0f;
	public float predkoscStatkuMax = 1.0f;
	public float mocSilnikaGlownego = 0.0f;

	public float mnoznikSilnikaGlownego = 1.0f;
	public float mnoznikMocyBocznych = 5.0f;

	public ParticleSystem plomienSilnikaGlownego;
	public ParticleSystem spalinySilnikaGlownego;

	public GameObject pasekPaliwa;
	private ObslugaPaska obslugaPaska;

	private Vector3 pozycjaStartowa;

	private Rigidbody statekRigidbody;

	void Start () {
		pozycjaStartowa = transform.localPosition;
		statekRigidbody = this.gameObject.GetComponent<Rigidbody> ();
		obslugaPaska = pasekPaliwa.GetComponent<ObslugaPaska> ();
	}
	
	void Update () {


		SprawdzenieZmianyMocySilnikaGlownego();


		// dodanie sil
		Vector3 nowaSila;
		if (SterowanieOgolne.sterowanieStatkiemAktywne)
			nowaSila = new Vector3(Input.GetAxis ("Horizontal") * mnoznikMocyBocznych, Input.GetAxis ("Vertical") * mnoznikMocyBocznych, mocSilnikaGlownego * mnoznikSilnikaGlownego);
		else
			nowaSila = new Vector3(0.0f, 0.0f, mocSilnikaGlownego * mnoznikSilnikaGlownego);

		nowaSila *= Time.deltaTime;
		if (obslugaPaska.ZmienStanPaska (nowaSila.magnitude) == false)
			statekRigidbody.AddRelativeForce (nowaSila);
		else {
			mocSilnikaGlownego = 0.0f;
			ObsluzSpaliny();
		}

		// spowalnianie statku
		float nowaPredkoscStatku = statekRigidbody.velocity.magnitude;
		float przyspieszenieStatku = nowaPredkoscStatku - predkoscStatku;
		przyspieszenieStatku = (przyspieszenieStatku > 0.0f ? przyspieszenieStatku : 0.0f);
		float wspolczynnikSpowolnienia = nowaPredkoscStatku / predkoscStatkuMax;
		statekRigidbody.velocity = statekRigidbody.velocity.normalized * (statekRigidbody.velocity.magnitude - przyspieszenieStatku * wspolczynnikSpowolnienia);

		predkoscStatku = statekRigidbody.velocity.magnitude;

		/*
		if (predkoscStatku > predkoscSwiatla) {
			statekRigidbody.velocity = statekRigidbody.velocity.normalized * predkoscSwiatla;
			//statekRigidbody.velocity *= predkoscStatkuMax;
			predkoscStatku = statekRigidbody.velocity.magnitude;
		}
*/

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

	void SprawdzenieZmianyMocySilnikaGlownego() {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.Alpha9))
				mocSilnikaGlownego = -0.5f;
			if (Input.GetKeyDown (KeyCode.Alpha0))
				mocSilnikaGlownego = 0.0f;
			if (Input.GetKeyDown (KeyCode.Alpha1))
				mocSilnikaGlownego = 0.2f;
			if (Input.GetKeyDown (KeyCode.Alpha2))
				mocSilnikaGlownego = 0.4f;
			if (Input.GetKeyDown (KeyCode.Alpha3))
				mocSilnikaGlownego = 0.6f;
			if (Input.GetKeyDown (KeyCode.Alpha4))
				mocSilnikaGlownego = 0.8f;
			if (Input.GetKeyDown (KeyCode.Alpha5))
				mocSilnikaGlownego = 1.0f;
			
			ObsluzSpaliny();
		}
		
		
		if (SterowanieOgolne.sterowanieStatkiemAktywne && Input.mouseScrollDelta.y != 0.0f) {
			
			// USTAWIENIE SILY WZDLOZ OSI Z
			
			// 0.1f - graniczna pozycja mocy silnika - wlacz lub wylacz silnik
			if ((mocSilnikaGlownego) < 0.01f && (Input.mouseScrollDelta.y > 0.0f))
				mocSilnikaGlownego = 0.1f;
			else 
				mocSilnikaGlownego += 0.02f * Input.mouseScrollDelta.y;
			
			mocSilnikaGlownego = (mocSilnikaGlownego > 1.0f ? 1.0f : mocSilnikaGlownego);
			mocSilnikaGlownego = (mocSilnikaGlownego < 0.099f ? 0.0f : mocSilnikaGlownego);
			
			ObsluzSpaliny();
		}
	}

	void ObsluzSpaliny() {


		if (mocSilnikaGlownego > 0.01f) 
		{

			plomienSilnikaGlownego.transform.localPosition = new Vector3 (plomienSilnikaGlownego.transform.localPosition.x, plomienSilnikaGlownego.transform.localPosition.y, -(mocSilnikaGlownego * 0.4f + 6.1f));
			plomienSilnikaGlownego.startSpeed = mocSilnikaGlownego * 5 - 1;
			plomienSilnikaGlownego.startSize = mocSilnikaGlownego * 0.5f + 0.1f;
			plomienSilnikaGlownego.emissionRate = 100.0f;

			spalinySilnikaGlownego.transform.localPosition = new Vector3 (spalinySilnikaGlownego.transform.localPosition.x, spalinySilnikaGlownego.transform.localPosition.y, -(mocSilnikaGlownego * 7.5f + 6.5f));
			spalinySilnikaGlownego.startSpeed = mocSilnikaGlownego * 2;
			spalinySilnikaGlownego.startSize = mocSilnikaGlownego * 0.15f + 0.1f;
			spalinySilnikaGlownego.emissionRate = mocSilnikaGlownego * 110.0f - 10.0f;
		} 
		else 
		{
			plomienSilnikaGlownego.emissionRate = 0.0f;
			spalinySilnikaGlownego.emissionRate = 0.0f;
		}
	}
	
}
