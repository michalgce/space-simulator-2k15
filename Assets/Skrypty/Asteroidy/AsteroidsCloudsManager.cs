using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsCloudsManager : MonoBehaviour
{
	public CloudProperties[] chmury;
	public bool czyGenerowacAutomatycznie = false;
	public float maxDistance = 100;
	private float generujCo = 20; //sekundy
	private GameObject[] prefabs = new GameObject[1];
	private List<GameObject> asteroids = new List<GameObject>();
	private float kasujCo = 3; //sekundy
	private GameObject statek;
	private Vector3 statekLoc;
	private List<Vector3> asteroidsVecs;
	private Vector3[] vectors = new Vector3[]{new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(1, 1, 1), 
		new Vector3(1, 0, 1), new Vector3(1, 1, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0)};

	void Start ()
	{
		statek = GameObject.FindGameObjectWithTag ("Statek");
		statekLoc = statek.transform.position;
		prefabs [0] = (GameObject) Resources.Load("Asteroidy/AsteroidaC");
		for (int i = 0; i<chmury.Length; i++) {
			if(chmury [i] != null)	{
				GenerujChmure (chmury [i]);
			}
				
		}
		StartCoroutine (DestroyAsteroids ());
		StartCoroutine (SpawnCloud ());
	}

	IEnumerator SpawnCloud ()
	{
		while (czyGenerowacAutomatycznie)
		{
			CloudProperties chmura = gameObject.AddComponent<CloudProperties> ();
			chmura.srodek = calculateSpawnPosition();
			chmura.promien = Random.Range(5,10);
			chmura.ilosc = Random.Range(10, 20);
			chmura.kierunek = vectors[(int)  Random.Range (0, 6)];
			GenerujChmure(chmura);
			yield return new WaitForSeconds (generujCo);
		}
	}


	void Update ()
	{
	}
	
	void GenerujChmure (CloudProperties chmura)
	{
		int licznik = 0;
		asteroidsVecs = new List<Vector3>();
		Quaternion spawnRotation = Quaternion.identity;
		for (int i = 0; i<chmura.ilosc; i++) {
			GameObject asteroid = prefabs [Random.Range (0, prefabs.Length)];
			Vector3 spawnPosition = calculateSpawnPosition(chmura);
			if(spawnPosition == Vector3.zero){
				i--;
				continue;
			}
			GameObject asteroidInstantiated = (GameObject) Instantiate (asteroid, spawnPosition, spawnRotation);
			CloudMover mf = asteroidInstantiated.AddComponent<CloudMover>();
			mf.setKierunek(chmura.kierunek);
			asteroids.Add(asteroidInstantiated);
			if(licznik++ > chmura.ilosc * 2){
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

	private Vector3 calculateSpawnPosition(CloudProperties chmura)
	{
		float r = chmura.promien;
		float x0 = chmura.srodek.x;
		float y0 = chmura.srodek.y;
		float z0 = chmura.srodek.z;
		float x = Random.Range (x0 - r/1.5f, x0 + r/1.5f);
		float y = Random.Range (y0 - r/1.5f, y0 + r/1.5f);
		float z = Mathf.Sqrt (Mathf.Pow (r, 2) - Mathf.Pow (x - x0, 2) - Mathf.Pow (y - y0, 2)) + z0;
		Vector3 v = new Vector3 (x, y, z);
		if (checkIfSimilarExists (v))
			return Vector3.zero;
		else {
			asteroidsVecs.Add (v);
			return v;
		}
	}

	private Vector3 calculateSpawnPosition()
	{
		float r = 70;
		float x0 = statekLoc.x;
		float y0 = statekLoc.y;
		float z0 = statekLoc.z;
		float x = Random.Range (x0 - 40, x0 + 40);
		float y = Random.Range (y0 - 40, y0 + 40);
		float z = Mathf.Sqrt (Mathf.Pow (r, 2) - Mathf.Pow (x - x0, 2) - Mathf.Pow (y - y0, 2)) + z0;
		return new Vector3(x, y, z);
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

