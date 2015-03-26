using UnityEngine;
using System.Collections;

public class PrzelaczanieKamer : MonoBehaviour {

	public Camera kameraStartowa;
	public Camera kamera1;
	public Camera kamera2;
	public Camera kamera3;
	public Camera kamera4;
	public Camera kamera5;
	public Camera kamera6;

	private Camera kameraBiezaca;
	
	void Start () {

		if (kamera1 != null)
			kamera1.enabled = false;
		if (kamera2 != null)
			kamera2.enabled = false;
		if (kamera3 != null)
			kamera3.enabled = false;
		if (kamera4 != null)
			kamera4.enabled = false;
		if (kamera5 != null)
			kamera5.enabled = false;
		if (kamera6 != null)
			kamera6.enabled = false;


		kameraBiezaca = kameraStartowa;
		kameraBiezaca.enabled = true;
	}

	void Update () {
		if (Input.anyKeyDown) {
			if ((Input.GetKeyDown(KeyCode.F1)) && (kamera1 != null)){
				kameraBiezaca.enabled = false;
				kameraBiezaca = kamera1;
				kameraBiezaca.enabled = true;
			}
			if ((Input.GetKeyDown(KeyCode.F2)) && (kamera2 != null)){
				kameraBiezaca.enabled = false;
				kameraBiezaca = kamera2;
				kameraBiezaca.enabled = true;
			}
			if ((Input.GetKeyDown(KeyCode.F3)) && (kamera3 != null)){
				kameraBiezaca.enabled = false;
				kameraBiezaca = kamera3;
				kameraBiezaca.enabled = true;
			}
			if ((Input.GetKeyDown(KeyCode.F4)) && (kamera4 != null)){
				kameraBiezaca.enabled = false;
				kameraBiezaca = kamera4;
				kameraBiezaca.enabled = true;
			}
			if ((Input.GetKeyDown(KeyCode.F5)) && (kamera5 != null)){
				kameraBiezaca.enabled = false;
				kameraBiezaca = kamera5;
				kameraBiezaca.enabled = true;
			}
			if ((Input.GetKeyDown(KeyCode.F6)) && (kamera6 != null)){
				kameraBiezaca.enabled = false;
				kameraBiezaca = kamera6;
				kameraBiezaca.enabled = true;
			}

		}
	}
}
