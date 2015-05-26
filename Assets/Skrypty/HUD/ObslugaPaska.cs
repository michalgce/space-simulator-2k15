using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObslugaPaska : MonoBehaviour {

	public RectTransform pasekPrzewijalny;
	public Text obiektTekstu;

	public float mnoznikZmian = 1.0f;
	public float autouzupelnianie = 0.0f;

	private float pozycjaY;

	private float pozycjaStartowaX;
	private float szerokoscPaska;
	private float stanPaska;

	private string tekst;

	// Use this for initialization
	void Start () {
		pozycjaY = pasekPrzewijalny.position.y;
		szerokoscPaska = pasekPrzewijalny.rect.width;
		pozycjaStartowaX = pasekPrzewijalny.position.x;
		stanPaska = 1.0f;
		tekst = obiektTekstu.text;
		obiektTekstu.text = tekst + ":  100%";
	}
	
	// Update is called once per frame
	void Update () {

		if (autouzupelnianie > 0.0f)
			ZmienStanPaska (-autouzupelnianie * Time.deltaTime);
	}

	public bool ZmienStanPaska(float ileOdjac)
	{
		stanPaska -= ileOdjac * mnoznikZmian;
		if (stanPaska < 0.0f)
			stanPaska = 0.0f;
		if (stanPaska > 1.0f)
			stanPaska = 1.0f;

		pasekPrzewijalny.position = new Vector3 (pozycjaStartowaX - (1.0f - stanPaska) * szerokoscPaska, pozycjaY, 0.0f);
		int procent = (int)(Mathf.Round(stanPaska * 100.0f));
		obiektTekstu.text = tekst + ": " + procent + "%";

		if (stanPaska <= 0.0f)
			return true;
		else
			return false;
	}

	public float JakiStanPaska() {
		return stanPaska;
	}
}
