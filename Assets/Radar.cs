﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour {


	public GameObject[] trackedObjects;
	public GameObject radarPrefab;
	List<GameObject> radarObjects;
	List<GameObject> borderObjects;
	public float switchDistance;
	public Transform helpTransform;

	// Use this for initialization
	void Start () {
		createRadarObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < radarObjects.Count; i++) {
			if(Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance) {
				helpTransform.LookAt(radarObjects[i].transform);
				borderObjects[i].transform.position = transform.position + switchDistance*helpTransform.forward;
				borderObjects[i].layer = LayerMask.NameToLayer("Radar");
				radarObjects[i].layer = LayerMask.NameToLayer("Invisible");

			} else {
				borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
				radarObjects[i].layer = LayerMask.NameToLayer("Radar");
			}

		}
	
	}

	void createRadarObjects() {
		radarObjects = new List<GameObject> ();
		borderObjects = new List<GameObject> ();
		foreach (GameObject o in trackedObjects) {
			GameObject k = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
			radarObjects.Add (k);
			GameObject j = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
			borderObjects.Add (j);
		}
	}
}
