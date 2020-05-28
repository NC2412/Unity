using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour {
    MapSpawner map;

    GameObject rocketLauncher;
    GameObject rocket;
    GameObject player;

    Vector3 spawnTransform = new Vector3(1, 0, 0);

    float distanceToPlayer;
    float fireDistance = 30;
    float fireTimer = 5.0f;
    

	// Use this for initialization
	void Start () {
        map = GameObject.Find("Script Controller").GetComponent<MapSpawner>();
        rocketLauncher = this.gameObject;
        rocket = Resources.Load("Prefabs/Rocket Parent") as GameObject;
        player = GameObject.Find("Player").gameObject;
        
        if (rocketLauncher.transform.position.x > 0)
        {
            spawnTransform.x *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        fireTimer -= Time.deltaTime;
        distanceToPlayer = Mathf.Sqrt(Mathf.Pow(rocketLauncher.transform.position.x - player.transform.position.x, 2) +
                                      Mathf.Pow(rocketLauncher.transform.position.z - player.transform.position.z, 2));

        if (fireTimer <= 0 && distanceToPlayer <= fireDistance)
        {
            fireTimer = 5.0f;
            FireRocket();
        }
	}

    void FireRocket()
    {
        Instantiate(rocket, rocketLauncher.transform.position + spawnTransform, rocket.transform.rotation);
    }
}
