using UnityEngine;
using System.Collections;

public class DiskMover : MonoBehaviour
{
	private int counter = 0;
	private float szybkosc = 1; 
	private Vector3 center;
	private Vector3 v;

	void Start () {
		v = (transform.position - center);
		//Debug.Log (v);
	}

	void Update () {
		counter++;
		float degreesPerSecond = Mathf.Pow(Mathf.Sin(counter),2)*100*szybkosc;
		v = Quaternion.AngleAxis (degreesPerSecond * Time.deltaTime, Vector3.up) * v;
		//Debug.Log (center + " " + v);
		transform.position = center + v;
	}

	public void setCenter(Vector3 c){
		this.center = c;
	}

	public void setSzybkosc(float s){
		this.szybkosc = s;
	}
}