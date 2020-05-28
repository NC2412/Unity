using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_01 : MonoBehaviour {
    public Sprite Completed;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if (Brick.brickCount <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Completed;
        }
	}
}
