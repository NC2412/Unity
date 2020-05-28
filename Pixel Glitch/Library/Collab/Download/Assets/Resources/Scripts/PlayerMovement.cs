using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Scripts
    FloorMaterial floor;
    PointOfNoReturnScript pointOfNoReturn;

    //GameObject
    GameObject player;

    //Vector3
    Vector3 prevPos;
    Vector3 curPos;


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").gameObject;

        pointOfNoReturn = GameObject.Find("Point of No Return").GetComponent<PointOfNoReturnScript>();
        floor = GameObject.Find("Script Controller").GetComponent<FloorMaterial>();
	}
	
	public void move(Vector3 playerDirection)
    {
        
        //sets max speed on x direction
        if (playerDirection.x >= 10)
        {
            playerDirection.x = 10;
        }
        else if (playerDirection.x <= -10)
        {
            playerDirection.x = -10;
        }

        //sets max speed on z direction
        if (playerDirection.z >= 10)
        {
            playerDirection.z = 10;
        }
        else if (playerDirection.z <= -10)
        {
            playerDirection.z = -10;
        }
        
        //moves player in correct direction
        player.transform.Translate(playerDirection * Time.deltaTime);

        //Moves player forward if they are past point of no return
        if (player.transform.position.z <= pointOfNoReturn.gameObject.transform.position.z)
        {
            player.transform.Translate(new Vector3(0, 0, 0.2f));
        }
    }

    public void detectForwardMovement()
    {
        prevPos = curPos;
        curPos = player.transform.position;

        //Checks if player position is moving forward
        //  - changes color of floor
        if (curPos.z - prevPos.z <= 0)
        {
            floor.colorChange(40);
        }
        else
        {
            floor.colorChange(0);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Door Trigger")
        {
            //Resets floor color if player moves to new portion of map (checkpoint)
            floor.colorVal = 255;

            //Destroys door trigger so player cannot keep resetting floor color
            Destroy(col.gameObject);
        }
    }
}
