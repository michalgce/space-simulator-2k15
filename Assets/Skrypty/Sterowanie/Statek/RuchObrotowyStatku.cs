using UnityEngine;
using System.Collections;

// Naped obracajacy statkiem wzdloz osi X, Y i Z (odpowiedniki wolantu i pedalow)

public class RuchObrotowyStatku : MonoBehaviour {

	public float czuloscMyszyX = 5.0f;
	public float czuloscMyszyY = 5.0f;
	public float czuloscMyszyZ = 2.0f;

	private Vector3 rotacjaStartowa;

	void Start() {
		rotacjaStartowa = transform.localEulerAngles;
	}

	void Update () {
		
		if (SterowanieOgolne.sterowanieStatkiemAktywne) {

			float rotacjaZ = 0.0f;
			if (Input.GetKey(KeyCode.Q))
				rotacjaZ += 1.0f;
			if (Input.GetKey(KeyCode.E))
				rotacjaZ -= 1.0f;


			if (SterowanieOgolne.myszkaAktywna)
				this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(- Input.GetAxis("Mouse Y") * czuloscMyszyY, Input.GetAxis("Mouse X") * czuloscMyszyX, rotacjaZ * czuloscMyszyZ));
			else
				this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0.0f, 0.0f, rotacjaZ * czuloscMyszyZ));


			// RESET ROTACJI
			if (Input.GetKeyDown(KeyCode.R)) 
				transform.localEulerAngles = rotacjaStartowa;

			// RESET MOMENTOW
			if (Input.GetKeyDown(KeyCode.T)) 
				this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3();
		}
	}
}
