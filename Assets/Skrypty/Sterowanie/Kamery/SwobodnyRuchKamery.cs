using UnityEngine;
using System.Collections;


// RUCH KAMERY (MYSZ + WSAD) - do poruszania kamera przytrzymac LPM, LSHIFT do przyspieszenia

public class SwobodnyRuchKamery : MonoBehaviour {


	public float podstawowaPredkoscPrzesuniecia = 10.0f;
	public int mnoznikPredkosciPrzesuniecia   = 5;
	
	public float czuloscMyszyX = 5.0f;
	public float czuloscMyszyY = 5.0f;
	
	private float rotacjaY = 0.0f;

	private Vector3 pozycjaStartowa;
	private Vector3 rotacjaStartowa;

	void Start() {
		rotacjaY = -transform.localEulerAngles.x;
		pozycjaStartowa = transform.localPosition;
		rotacjaStartowa = transform.localEulerAngles;
	}

	void Update () {

		if ((gameObject.GetComponent<Camera> ().enabled) && (SterowanieOgolne.sterowanieKameraAktywne)) {

			// obrot
			if (SterowanieOgolne.myszkaAktywna)
			{
				float rotacjaX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * czuloscMyszyX;
				rotacjaY += Input.GetAxis ("Mouse Y") * czuloscMyszyY;
				rotacjaY = Mathf.Clamp (rotacjaY, -89.5f, 89.5f);
				transform.localEulerAngles = new Vector3 (-rotacjaY, rotacjaX, 0.0f);
			}
		

			// przod/tyl , lewo/prawo, gora/dol
			if ((Input.GetAxis ("Vertical") != 0.0f) || (Input.GetAxis ("Horizontal") != 0.0f) || (Input.mouseScrollDelta.y != 0.0f)) {
				float predkosc = (Input.GetKey (KeyCode.LeftShift) ? podstawowaPredkoscPrzesuniecia * mnoznikPredkosciPrzesuniecia : podstawowaPredkoscPrzesuniecia) * Time.deltaTime;
				Vector3 przesuniecie = new Vector3 (Input.GetAxis ("Horizontal"), Input.mouseScrollDelta.y, Input.GetAxis ("Vertical")) * predkosc;
				gameObject.transform.localPosition += gameObject.transform.localRotation * przesuniecie;
			}

			// reset
			if (Input.GetKey (KeyCode.R)) {
				transform.localPosition = pozycjaStartowa;
				transform.localEulerAngles = rotacjaStartowa;
				rotacjaY = -transform.localEulerAngles.x;
			}
		}
	}
}
