using UnityEngine;
using System.Collections;

// Naped obracajacy statkiem wzdloz osi X, Y i Z (odpowiedniki wolantu i pedalow)

public class RuchObrotowyStatku : MonoBehaviour {

	public float czuloscMyszyX = 5.0f;
	public float czuloscMyszyY = 5.0f;
	
	float rotacjaY = 0.0f;

	void Start () {
	
	}

	void Update () {
		
		if (Input.GetMouseButton(1)) {

			float rotacjaX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * czuloscMyszyX;
			rotacjaY += Input.GetAxis ("Mouse Y") * czuloscMyszyY;
			rotacjaY = Mathf.Clamp (rotacjaY, -89.5f, 89.5f);
			transform.localEulerAngles = new Vector3 (-rotacjaY, rotacjaX, 0.0f);

		}
	}
}
