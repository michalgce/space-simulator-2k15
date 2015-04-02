using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsManager : MonoBehaviour
{
	public bool czyGenerowac = false;
	public float maxDistance = 100;
	private GameObject[] prefabs = new GameObject[3];
	private GameObject statek;
	private List<GameObject> asteroids = new List<GameObject>();
	private Vector3 statekLoc;
	private float generujCo = 1; //sekundy
	private float kasujCo = 3; //sekundy

	void Start ()
	{
		statek = GameObject.FindGameObjectWithTag ("Statek");
		statekLoc = statek.transform.position;
		prefabs [0] = (GameObject) Resources.Load("Asteroidy/AsteroidaA");
		prefabs [1] = (GameObject) Resources.Load("Asteroidy/AsteroidaB");
		prefabs [2] = (GameObject) Resources.Load("Asteroidy/AsteroidaC");
		StartCoroutine (SpawnAsteroids ());
		StartCoroutine (DestroyAsteroids ());
	}
	
	void Update ()
	{
		statekLoc = statek.transform.position;
	}
	
	IEnumerator SpawnAsteroids ()
	{
		while (czyGenerowac)
		{
			GameObject asteroid = prefabs [Random.Range (0, prefabs.Length)];
			Vector3 spawnPosition = calculateSpawnPosition();
			Quaternion spawnRotation = Quaternion.identity;
			GameObject asteroidInstantiated = (GameObject) Instantiate (asteroid, spawnPosition, spawnRotation);
			asteroids.Add(asteroidInstantiated);
			yield return new WaitForSeconds (generujCo);
		}
	}

	IEnumerator DestroyAsteroids ()
	{
		while (czyGenerowac)
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

}

