using UnityEngine;
using System.Collections;

public class DiskProperties : MonoBehaviour 
{
	public Vector3 srodek;
	public float promienWewnetrzny;
	public float promienZewnetrzny;
	public int ilosc;
	public float szybkosc; 

	public DiskProperties(Vector3 s, float rw, float rz, int il, float sz){
		this.srodek = s;
		this.promienWewnetrzny = rw;
		this.promienZewnetrzny = rz;
		this.ilosc = il;
		this.szybkosc = sz;
	}

}