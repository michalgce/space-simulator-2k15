using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsManager : MonoBehaviour
{
	public bool czyGenerowac = false;
	public float maxDistance = 10;
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
			Vector3 spawnPosition = new Vector3 (statekLoc.x+1, statekLoc.y+1, statekLoc.z+1); //TODO: do zrobienia generowanie dookoła? statku
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

}

