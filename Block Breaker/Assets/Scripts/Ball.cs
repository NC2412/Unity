using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (hasStarted == false)
        {
            //keeps ball loacated above ball at the start of the game
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //initiates the game witha mouse click, moves ball with given velocity.
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                print("Left click.");

                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
            }
        }
    }
}
