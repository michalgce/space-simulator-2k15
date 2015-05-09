using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsDiskManager : MonoBehaviour
{
	public DiskProperties[] dyski;
	public float maxDistance = 100;
	private GameObject[] prefabs = new GameObject[1];
	private List<GameObject> asteroids = new List<GameObject>();
	private float kasujCo = 3; //sekundy
	private GameObject statek;
	private Vector3 statekLoc;
	private List<Vector3> asteroidsVecs;
	
	void Start ()
	{
		statek = GameObject.FindGameObjectWithTag ("Statek");
		statekLoc = statek.transform.position;
		prefabs [0] = (GameObject) Resources.Load("Asteroidy/AsteroidaC");
		for (int i = 0; i<dyski.Length; i++) {
			if(dyski [i] != null)	{
				GenerujDysk (dyski [i]);
			}		
		}
		StartCoroutine (DestroyAsteroids ());
	}
	
	void Update ()
	{
	}
	
	void GenerujDysk (DiskProperties dysk)
	{
		int licznik = 0;
		asteroidsVecs = new List<Vector3>();
		Quaternion spawnRotation = Quaternion.identity;
		for (int i = 0; i<dysk.ilosc; i++) {
			GameObject asteroid = prefabs [Random.Range (0, prefabs.Length)];
			Vector3 spawnPosition = calculateSpawnPosition(dysk);
			if(spawnPosition == Vector3.zero){
				i--;
				continue;
			}
			GameObject asteroidInstantiated = (GameObject) Instantiate (asteroid, spawnPosition, spawnRotation);
			DiskMover mf = asteroidInstantiated.AddComponent<DiskMover>();
			mf.setCenter(dysk.srodek);
			mf.setSzybkosc(dysk.szybkosc);
			asteroids.Add(asteroidInstantiated);
			if(licznik++ > dysk.ilosc * 2){
				break;
			}
		}
	}

	IEnumerator DestroyAsteroids ()
	{
		List<GameObject> asteroidsToDestroy = new List<GameObject>();
		foreach (GameObject go in asteroids) 
		{
			float distance = Vector3.Distance(statekLoc, go.transform.position);
			if(distance > maxDistance){
				asteroidsToDestroy.Add(go);
			}
		}
		foreach (GameObject go in asteroidsToDestroy) 
		{
			asteroids.Remove(go);
			Destroy(go);
		}
		yield return new WaitForSeconds (kasujCo);
	}

	private Vector3 calculateSpawnPosition(DiskProperties dysk)
	{
		float r = dysk.promienZewnetrzny - dysk.promienWewnetrzny;
		float x0 = dysk.srodek.x;
		float z0 = dysk.srodek.z;
		float x = Random.Range (x0 - r, x0 + r);
		float z = Mathf.Sqrt (Mathf.Pow (r, 2) - Mathf.Pow (x - x0, 2) ) + z0;
		if (x < x0) {
			x = x - (dysk.promienWewnetrzny + Random.Range(0,r));
		} else {
			x = x + dysk.promienWewnetrzny + Random.Range(0,r);
		}
		float rand = Random.Range (-1, 1);
		if (rand < 0) {
			float rozn = z - z0;
			z = z - 2*rozn;
		}
		if (z < 0) {
			z = z - (dysk.promienWewnetrzny + Random.Range(0,r));
		} else {
			z = z +  dysk.promienWewnetrzny + Random.Range(0,r);
		}
		Vector3 v = new Vector3 (x, dysk.srodek.y, z);
		if (checkIfSimilarExists (v))
			return Vector3.zero;
		else {
			asteroidsVecs.Add (v);
			return v;
		}
	}

	
	private bool checkIfSimilarExists(Vector3 v){
		foreach(Vector3 ve in asteroidsVecs){
			if(checkIfClose(v, ve))
				return true;
		}
		return false;
	}
	
	private bool checkIfClose(Vector3 v1, Vector3 v2){
		if (Mathf.Pow (v1.x - v2.x, 2) < 2 && Mathf.Pow (v1.y - v2.y, 2) < 2 && Mathf.Pow (v1.z - v2.z, 2) < 2) {
			return true;
		}
		return false;
	}
	
}

