using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    //Gameobjects
    public GameObject player;
    public GameObject lookAt;

    public float speed = 5;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = player.transform.position - transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    //Camera Movement
    void CameraMovement()
    {
        
        float h = Input.GetAxis("Mouse X") * speed;
        float v = Input.GetAxis("Mouse Y") * speed;
        player.transform.Rotate(0, h, 0);
		lookAt.transform.Rotate(v, h, 0);


		float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = player.transform.position - (rotation * offset);

		transform.LookAt(lookAt.transform);

       
    }
}
