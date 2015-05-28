using UnityEngine;
using System.Collections;

public class ObslugaPaskaMocySilnika : MonoBehaviour {

	public RectTransform pasekPrzewijalny;
	public GameObject statek;

	private RuchPostepowyStatku ruchPostepowyStatku;

	private float pozycjaX;
	
	private float pozycjaStartowaY;
	private float dlugoscPaska;

	// Use this for initialization
	void Start () {
		pozycjaX = pasekPrzewijalny.position.x;
		pozycjaStartowaY = pasekPrzewijalny.position.y;
		dlugoscPaska = pasekPrzewijalny.rect.height;
		ruchPostepowyStatku = statek.GetComponent<RuchPostepowyStatku>();
	}
	
	// Update is called once per frame
	void Update () {
		if (ruchPostepowyStatku.mocSilnikaGlownego <= 0.0f)
			pasekPrzewijalny.position = new Vector3 (pozycjaX, pozycjaStartowaY, 0.0f);
		else
			pasekPrzewijalny.position = new Vector3 (pozycjaX, pozycjaStartowaY + (ruchPostepowyStatku.mocSilnikaGlownego) * dlugoscPaska, 0.0f);

	}
}
