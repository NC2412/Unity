using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlight : MonoBehaviour {

    ExplosionScript explosion;
    PixelEditor pixels;

    GameObject rocket;
    GameObject player;

    Vector3 lookRotation;

    int speed = 5;

	// Use this for initialization
	void Start () {
        explosion = GameObject.Find("Script Controller").GetComponent<ExplosionScript>();
        pixels = GameObject.Find("Script Controller").GetComponent<PixelEditor>();

        rocket = this.gameObject;
        player = GameObject.Find("Player").gameObject;

        if (rocket.transform.position.x >= 0)
        {
            rocket.transform.Rotate(new Vector3(0, 0, 180));
        }
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

    void Fire()
    {
        rocket.transform.LookAt(player.transform);
        rocket.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            pixels.glitchScreen();
            explosion.Explode(rocket.transform.position, true);
        } else
        {
            explosion.Explode(rocket.transform.position, false);
        }

        Destroy(rocket);
    }
}
