using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float mSpeed = 100;
    float max = 80;
	float min = -80;
	float xRotation = 0;

    Transform player;
    Transform camera;
    

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").transform;
        camera = this.gameObject.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
            Move();
	}

    void Move() {
        var x = Input.GetAxis("Mouse X") * Time.deltaTime * mSpeed;
        var y = Input.GetAxis("Mouse Y") * Time.deltaTime * mSpeed;

        //camera.transform.Rotate(-y, 0, 0);

		xRotation = Mathf.Clamp (xRotation + y, min, max);

		camera.localEulerAngles = new Vector3 (-xRotation, 0, 0);

        player.Rotate(0, x, 0);

		/*if (camera.localEulerAngles.x >= max)
        {
			camera.localEulerAngles = new Vector3 (max, 0, 0);
        }
		if (camera.localEulerAngles.x <= min)
        {
       		camera.localEulerAngles = new Vector3(min, 0, 0);
        }*/

    }

}
