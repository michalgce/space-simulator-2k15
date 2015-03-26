using UnityEngine;
using System.Collections;


// RUCH KAMERY (MYSZ + WSAD) - do poruszania kamera przytrzymac LPM, LSHIFT do przyspieszenia

public class SwobodnyRuchKamery : MonoBehaviour {


	public float normalnaPredkosc = 10.0f;
	public float zwiekszonaPredkosc   = 50.0f;
	
	public float czuloscMyszyX = 5.0f;
	public float czuloscMyszyY = 5.0f;
	
	float rotacjaY = 0.0f;

	void Update () {

		if ((gameObject.GetComponent<Camera> ().enabled) && (Input.GetMouseButton (0))) {

			// obrot
			float rotacjaX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * czuloscMyszyX;
			rotacjaY += Input.GetAxis ("Mouse Y") * czuloscMyszyY;
			rotacjaY = Mathf.Clamp (rotacjaY, -89.5f, 89.5f);
			transform.localEulerAngles = new Vector3 (-rotacjaY, rotacjaX, 0.0f);
		

			// przod/tyl i lewo/prawo
			if ((Input.GetAxis ("Vertical") != 0.0f) || (Input.GetAxis ("Horizontal") != 0.0f)) {
				float predkosc = (Input.GetKey (KeyCode.LeftShift) ? zwiekszonaPredkosc : normalnaPredkosc) * Time.deltaTime;
				Vector3 przesuniecie = new Vector3 (Input.GetAxis ("Horizontal") * predkosc, 0.0f, Input.GetAxis ("Vertical") * predkosc);
				gameObject.transform.localPosition += gameObject.transform.localRotation * przesuniecie;
			}

			// reset
			if (Input.GetKey (KeyCode.R)) {
				gameObject.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
				gameObject.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
			}
		}
	}
}
