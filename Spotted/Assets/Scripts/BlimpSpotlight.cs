using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlimpSpotlight : MonoBehaviour {
    
    Transform enemy;

    public bool search;

	// Use this for initialization
	void Start () {
        this.gameObject.active = false;
	}

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindWithTag("Enemy").transform;
        this.transform.LookAt(enemy);
    }
}
