using UnityEngine;
using System.Collections;

public class GrawitacjaPlanet : MonoBehaviour {

	public GameObject statek;
	public float mnoznikSilyGrawitacji;

	private GameObject[] planety;

	// Use this for initialization
	void Start () {
		planety = GameObject.FindGameObjectsWithTag ("Planeta");
	}
	
	// Update is called once per frame
	void Update () {

		string text = "Grawitacje:  ";

		foreach (GameObject planeta in planety) {
			Vector3 wektor = planeta.transform.position - statek.transform.position;
			float silaPrzyciagania = planeta.transform.localScale.x * mnoznikSilyGrawitacji / wektor.magnitude / wektor.magnitude;
			if (silaPrzyciagania > statek.GetComponent<RuchPostepowyStatku>().predkoscStatkuMax)
				silaPrzyciagania = statek.GetComponent<RuchPostepowyStatku>().predkoscStatkuMax;
			statek.GetComponent<Rigidbody>().AddForce(wektor.normalized * silaPrzyciagania);
			text += ">" + planeta.name + ": " + silaPrzyciagania + ";  ";
		}
		//Debug.Log (text);
	}
}
