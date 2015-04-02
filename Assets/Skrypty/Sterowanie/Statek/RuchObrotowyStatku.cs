using UnityEngine;
using System.Collections;

// Naped obracajacy statkiem wzdloz osi X, Y i Z (odpowiedniki wolantu i pedalow)

public class RuchObrotowyStatku : MonoBehaviour {

	public float czuloscMyszyX = 5.0f;
	public float czuloscMyszyY = 5.0f;
	public float czuloscMyszyZ = 2.0f;

	void Update () {
		
		if (!SterowanieOgolne.kameraAktywna) {

			float axisZ = 0.0f;
			if (Input.GetKey(KeyCode.Q))
				axisZ += 1.0f;
			if (Input.GetKey(KeyCode.E))
				axisZ -= 1.0f;


			if (SterowanieOgolne.myszkaAktywna)
				this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(- Input.GetAxis("Mouse Y") * czuloscMyszyY, Input.GetAxis("Mouse X") * czuloscMyszyX, axisZ * czuloscMyszyZ));
			else
				this.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0.0f, 0.0f, axisZ * czuloscMyszyZ));


		}
	}
}
