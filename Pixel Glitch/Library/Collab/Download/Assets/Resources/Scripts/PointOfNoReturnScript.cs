using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfNoReturnScript : MonoBehaviour {

    GameObject pointOfNoReturn;

    MapSpawner map;

    int index = 0;

	// Use this for initialization
	void Start () {
        pointOfNoReturn = this.gameObject;
        map = GameObject.Find("Script Controller").GetComponent<MapSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		if (map.totalSpawnedSections.Count >= 3)
        {
            NewPosition();
        }
	}

    void NewPosition()
    {
        index = map.totalSpawnedSections.Count - 3;

        pointOfNoReturn.transform.position = new Vector3(0, -1, map.totalSpawnedSections[index].gameObject.transform.position.z - 22);
    }
}
