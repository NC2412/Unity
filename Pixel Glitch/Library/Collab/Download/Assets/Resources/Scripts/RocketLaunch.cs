using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour {

    GameObject rocketLauncher;
    GameObject rocket;
    GameObject player;

    Vector3 spawnTransform = new Vector3(1, 0, 0);
    Vector3 distanceToPlayer;

    float fireDistance = 20;
    float fireTimer = 5.0f;

	// Use this for initialization
	void Start () {
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
        distanceToPlayer = rocketLauncher.gameObject.transform.position - player.transform.position;

        
        // && distanceToPlayer.z > -fireDistance || distanceToPlayer.z < fireDistance
        if (fireTimer <= 0)
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
