using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlimpMovement : MonoBehaviour {

    
    PlayerInteraction player;

    public GameObject blimp;
    public GameObject rope;
    public GameObject spotlight;

    public Text blimpCall;

    int speed = 1;

    public bool isBlimpComing;
    bool pickUp;
    
    

	// Use this for initialization
	void Start () {
        rope.gameObject.active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E) && PlayerInteraction.isBlimpCalled == true)
        {
            isBlimpComing = true;
            spotlight.active = true;

            this.gameObject.GetComponent<AudioSource>().Play();
        }

        if (isBlimpComing == true)
        {
            blimpCall.text = "";
            PickUp();
        }

        
        
    }

    public void PickUp()
    {
        blimp.transform.position += new Vector3(0.0f, 0.0f, 0.30f) * speed;
    }

    void OnTriggerEnter(Collider trigger)
    {
        pickUp = true;
        isBlimpComing = false;
        rope.gameObject.active = true;
    }
}
