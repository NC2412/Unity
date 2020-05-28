using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    //TODO: make outer circle move, make center circle not exceed outer circle

    PlayerMovement player;

    public GameObject outerCircle;
    public GameObject centerCircle;

    Vector3 origin;
    Vector3 playerDirection;
    Vector3 centerCirclePosition;

    float centerCircleToOuterCircle;
    float followDistance = 100;

    bool outerCircleHasOrigin;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        origin = outerCircle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player.detectForwardMovement();

        if (Input.touchCount > 0)
        {
            touchActivator();
        }
        else
        {
            //Resets joystick position
            outerCircle.transform.position = origin;
            centerCircle.gameObject.transform.position = outerCircle.gameObject.transform.position;
            

            //Lets compiler know outer circle doesnt have a place to be
            //  - outer circle sets position of itself to position of the first instance of a touch
            outerCircleHasOrigin = false;
        }
    }

    public void touchActivator()
    {

        //Checks if outer circle has origin
        //  - this statement allows for the outer cirlce to not move around
        if (outerCircleHasOrigin == false)
        {
            outerCircle.transform.position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, -1);
            outerCircleHasOrigin = true;
        }

        //Sets center cirlce to position of first instance of finger touch
        centerCirclePosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, -1);

        //Sets player direction to the calculated Vector3 position
        playerDirection = new Vector3((centerCircle.transform.position.x - outerCircle.transform.position.x) / 4,
                                      0,
                                      (centerCircle.transform.position.y - outerCircle.transform.position.y)) / 4;

        //Following sequence calculates joystick positions
        centerCircleToOuterCircle = Mathf.Sqrt(Mathf.Pow(centerCircle.transform.position.x - outerCircle.transform.position.x, 2) +
                                               Mathf.Pow(centerCircle.transform.position.y - outerCircle.transform.position.y, 2));
        //This statement moves outercircle in relation to centercircle
        if (centerCircleToOuterCircle >= followDistance)
        {
            outerCircle.transform.Translate(new Vector3(playerDirection.x, playerDirection.z, 0));
        }
        //moves center joystick
        centerCircle.transform.position = centerCirclePosition;
        //calls move player method
        player.move(playerDirection);
        
    }

}
