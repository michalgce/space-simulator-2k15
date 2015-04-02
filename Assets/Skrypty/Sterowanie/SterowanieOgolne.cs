using UnityEngine;
using System.Collections;

public class SterowanieOgolne : MonoBehaviour {

	public static bool kameraAktywna;

	public static bool myszkaAktywna;

	// Use this for initialization
	void Start () {
		kameraAktywna = true;
		myszkaAktywna = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K))
			kameraAktywna = !kameraAktywna;

		if (Input.GetKeyDown (KeyCode.M) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
			myszkaAktywna = !myszkaAktywna;
			Cursor.visible = !Cursor.visible;
		}

	}
}
