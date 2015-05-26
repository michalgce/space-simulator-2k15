using UnityEngine;
using System.Collections;

// Naped obracajacy statkiem wzdloz osi X, Y i Z (odpowiedniki wolantu i pedalow)
// R - RESET ROTACJI
// T - RESET MOMENTOW OBROTOWYCH

public class RuchObrotowyStatku : MonoBehaviour {

	public float czuloscMyszyX = 1.0f;
	public float czuloscMyszyY = 1.0f;
	public float czuloscMyszyZ = 1.0f;

	private Vector3 rotacjaStartowa;

	void Start() {
		rotacjaStartowa = transform.localEulerAngles;
	}

	void Update () {
		
		if (SterowanieOgolne.sterowanieStatkiemAktywne) {

			float rotacjaZ = 0.0f;
			if (Input.GetKey(KeyCode.Q))
				rotacjaZ += czuloscMyszyZ;
			if (Input.GetKey(KeyCode.E))
				rotacjaZ -= czuloscMyszyZ;


			if (SterowanieOgolne.myszkaAktywna)
				this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(- Input.GetAxis("Mouse Y") * czuloscMyszyY, Input.GetAxis("Mouse X") * czuloscMyszyX, rotacjaZ));
			else
				this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0.0f, 0.0f, rotacjaZ));

			//this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(), 


			// RESET ROTACJI
			if (Input.GetKeyDown(KeyCode.R)) 
				transform.localEulerAngles = rotacjaStartowa;

			// RESET MOMENTOW
			if (Input.GetKeyDown(KeyCode.T)) 
				this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3();
		}
	}
}
