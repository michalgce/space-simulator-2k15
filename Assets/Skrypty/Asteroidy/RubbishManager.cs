using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RubbishManager : MonoBehaviour
{
	public bool czyGenerowac = false;
	public float maxDistance = 100;
	private GameObject[] prefabs = new GameObject[7];
	private GameObject statek;
	private List<GameObject> rubbishList = new List<GameObject>();
	private Vector3 statekLoc;
	private float generujCo = 3; //sekundy
	private float kasujCo = 3; //sekundy

	void Start ()
	{
		statek = GameObject.FindGameObjectWithTag ("Statek");
		statekLoc = statek.transform.position;
		prefabs [0] = (GameObject) Resources.Load("Smieci/Barrel");
		prefabs [1] = (GameObject) Resources.Load("Smieci/bucket_a_pref");
		prefabs [2] = (GameObject) Resources.Load("Smieci/bucket_b_pref");
		prefabs [3] = (GameObject) Resources.Load("Smieci/book_0001a");
		prefabs [4] = (GameObject) Resources.Load("Smieci/book_0001b");
		prefabs [5] = (GameObject) Resources.Load("Smieci/MagicLamp_LOD0");
		prefabs [6] = (GameObject) Resources.Load("Smieci/OldExtinguisher");
		StartCoroutine (SpawnRubbish ());
		StartCoroutine (DestroyRubbish ());
	}
	
	void Update ()
	{
		statekLoc = statek.transform.position;
	}
	
	IEnumerator SpawnRubbish ()
	{
		while (czyGenerowac)
		{
			GameObject rubbish = prefabs [Random.Range (0, prefabs.Length)];
			Vector3 spawnPosition = calculateSpawnPosition();
			Quaternion spawnRotation = Quaternion.identity;
			GameObject rubbishInstantiated = (GameObject) Instantiate (rubbish, spawnPosition, spawnRotation);
			rubbishList.Add(rubbishInstantiated);
			yield return new WaitForSeconds (generujCo);
		}
	}

	IEnumerator DestroyRubbish ()
	{
		while (czyGenerowac)
		{
			List<GameObject> rubbishToDestroy = new List<GameObject>();
			foreach (GameObject go in rubbishList) 
			{
				float distance = Vector3.Distance(statekLoc, go.transform.position);
				if(distance > maxDistance){
					rubbishToDestroy.Add(go);
				}
			}
			foreach (GameObject go in rubbishToDestroy) 
			{
				rubbishList.Remove(go);
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

