using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemyAI: MonoBehaviour {

    Transform player;
    public GameObject enemy;
    public bool isActivated;
    float travelSpeed = 5.0f;
	AudioSource sound;
	float soundPlay = 10;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		sound = gameObject.GetComponent<AudioSource> ();
	}



    void Update()
    {
        if (isActivated == true)
        {
            Follow();
            this.gameObject.tag = "Enemy";
        }



        //IsVisible();
    }

    public void Follow()
    {
        Vector3 lookAtPlayer = player.transform.position - enemy.transform.position;

        enemy.transform.rotation = Quaternion.LookRotation(lookAtPlayer);
        enemy.transform.position += enemy.transform.forward * travelSpeed * Time.smoothDeltaTime;
    }
    

    void IsVisible()
    {
        if (this.gameObject.GetComponent<Renderer>().isVisible == true)
        {
            travelSpeed = 1;
        }
        if (this.gameObject.GetComponent<Renderer>().isVisible == false)
        {
            travelSpeed = 5;
        }
    }
}
