using UnityEngine;
using System.Collections;


// RUCH KAMERY (MYSZ + WSAD)

public class SwobodnyRuchKamery : MonoBehaviour {


	public float normalnaPredkosc = 10.0f;
	public float zwiekszonaPredkosc   = 50.0f;
	
	public float czuloscMyszyX = 5.0f;
	public float czuloscMyszyY = 5.0f;
	
	float rotacjaY = 0.0f;

	
	void Start () {
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

		// obrot     
		if (Input.GetMouseButton(0)) 
		{
			float rotacjaX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * czuloscMyszyX;
			rotacjaY += Input.GetAxis("Mouse Y") * czuloscMyszyY;
			rotacjaY = Mathf.Clamp(rotacjaY, -89.5f, 89.5f);
			transform.localEulerAngles = new Vector3(-rotacjaY, rotacjaX, 0.0f);
		}

		// przod / tyl
		if (Input.GetAxis("Vertical") != 0.0f)  
		{
			float predkosc = Input.GetKey(KeyCode.LeftShift) ? zwiekszonaPredkosc : normalnaPredkosc;
			Vector3 przesuniecie = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical") * predkosc * Time.deltaTime);
			gameObject.transform.localPosition += gameObject.transform.localRotation * przesuniecie;
		}
		
		// lewo / prawo
		if (Input.GetAxis("Horizontal") != 0.0f) 
		{
			float predkosc = Input.GetKey(KeyCode.LeftShift) ? zwiekszonaPredkosc : normalnaPredkosc;
			Vector3 przesuniecie = new Vector3(Input.GetAxis("Horizontal") * predkosc * Time.deltaTime, 0.0f, 0.0f);
			gameObject.transform.localPosition += gameObject.transform.localRotation * przesuniecie;
		}

		// reset
		if (Input.GetKey(KeyCode.R))
		{
			gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
		}
	}
}
