using UnityEngine;
using System.Collections;

public class SterowanieOgolne : MonoBehaviour {

	public static bool sterowanieKameraAktywne;
	public static bool sterowanieStatkiemAktywne;
	public static bool myszkaAktywna;
	
	void Start () {
		sterowanieKameraAktywne = true;
		sterowanieStatkiemAktywne = false;
		myszkaAktywna = false;
	}

	void Update () {

		// PRZELACZENIE STEROWANIA KAMERA - STATEK
		if (Input.GetKeyDown (KeyCode.K) || Input.GetMouseButtonDown(2)) {
			sterowanieKameraAktywne = !sterowanieKameraAktywne;
			sterowanieStatkiemAktywne = !sterowanieStatkiemAktywne;
		}

		// PRZELACZENIE AKTYWNOSCI MYSZKI
		if (Input.GetKeyDown (KeyCode.M) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
			myszkaAktywna = !myszkaAktywna;
			//Cursor.visible = !Cursor.visible;
		}

	}
}
