using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour {

    public Camera camera;
    private Vector3 origin;

    public int moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonDown(1))
  //      {
  //          origin = Input.mousePosition;

  //          camera.transform.Rotate()
  //      }
        if (Input.GetMouseButtonDown(0))
        {
            origin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - origin);
        Vector3 move = new Vector3(pos.x * moveSpeed, 0, pos.y * moveSpeed);

        camera.transform.Rotate(move, Space.World);
    }
}
