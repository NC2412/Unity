using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    static Transform target;
    static Camera camera;

    int minDis = 3;
    float maxDis = 1.5f;
    float fovTarget;

	// Use this for initialization
	void Start () {
		camera = this.gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Golf Ball").transform;
        }	
        else
        {
            Move();
        }
	}

    void Move()
    {
        
        //float x1 = target.gameObject.transform.position.x;
        //float x2 = this.gameObject.transform.position.x;
        //float y1 = target.gameObject.transform.position.y;
        //float y2 = this.gameObject.transform.position.y;
        //float distance = Mathf.Sqrt(Mathf.Pow((y2 - y1), 2) + Mathf.Pow((x2 - x1), 2));

        Vector3 multiplier = target.gameObject.GetComponent<Rigidbody>().velocity;

        fovTarget = target.gameObject.GetComponent<Rigidbody>().velocity.y + 45;

        //Movement
        this.gameObject.transform.position = new Vector3(target.position.x, target.position.y + 2, target.position.z - 2);

        //Changes field of view to increase/decrease depending on ball speed
        if (camera.fieldOfView < fovTarget || camera.fieldOfView < 45)
        {
            this.gameObject.GetComponent<Camera>().fieldOfView += 0.1f;
        } else if (this.gameObject.GetComponent<Camera>().fieldOfView > fovTarget )
        {
            this.gameObject.GetComponent<Camera>().fieldOfView -= 0.1f;
        }


    }
}
