using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public GameObject origin;
    public float speed = 5;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = origin.transform.position - transform.position;
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
        origin.transform.Rotate(0, h, 0);

        float desiredAngle = origin.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(Input.mousePosition.y, desiredAngle, 0);
        transform.position = origin.transform.position - (rotation * offset);

        transform.LookAt(origin.transform);

       
    }
}
