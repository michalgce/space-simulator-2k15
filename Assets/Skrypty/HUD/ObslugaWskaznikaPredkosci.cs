using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObslugaWskaznikaPredkosci : MonoBehaviour {


	public GameObject statek;
	public Text tekst;

	private RuchPostepowyStatku ruchPostepowyStatku;

	//private 

	// Use this for initialization
	void Start () {
		ruchPostepowyStatku = statek.GetComponent<RuchPostepowyStatku> ();
	}
	
	// Update is called once per frame
	void Update () {
		float szybkosc = - 270.0f * ruchPostepowyStatku.predkoscStatku / ruchPostepowyStatku.predkoscStatkuMax - 8.0f;
		this.transform.eulerAngles = new Vector3(0.0f, 0.0f, szybkosc);
		tekst.text = ruchPostepowyStatku.predkoscStatku.ToString("f");
}
}
