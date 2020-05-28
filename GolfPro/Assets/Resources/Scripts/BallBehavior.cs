using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehavior : MonoBehaviour
{

    public static GameObject golfBall;
    public static GameObject directionArrow;
    public static Slider pBar;

    static bool isGrounded = true;
    static bool functionCalled = false;
    bool powerSaved = false;
    bool isInHazard = false;

    float power;
    float arrowDegrees;
    int arrowRotation;
    int pBarTarget = 1;

    // Use this for initialization
    void Start()
    {
        pBar = this.gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Slider>();

        arrowDegrees = 45;
        arrowRotation = 2;

        golfBall = this.gameObject;
        if (golfBall == null)
        {
            print("Golfball not loaded");
        }

        directionArrow = GameObject.Find("Direction Arrow");


        directionArrow.SetActive(false);
        pBar.gameObject.SetActive(false);
    }

    void Update()
    {
        if (this.gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0) && functionCalled == false)
        {
            //Creates shot direction arrow
            directionArrow.SetActive(true);
            directionArrow.transform.position = new Vector3(golfBall.gameObject.transform.position.x, golfBall.gameObject.transform.position.y + 0.1f, golfBall.gameObject.transform.position.z + 0.3f);

            directionArrow.transform.Rotate(0, 0, 0);

            pBar.gameObject.SetActive(true);

            functionCalled = true;
        }

        if (functionCalled == true && directionArrow != null)
        {
            ShotSpecs();
        }
    }

    void ShotSpecs()
    {
        if (directionArrow.transform.rotation.z * 90 <= -arrowDegrees || directionArrow.transform.rotation.z * 90 >= arrowDegrees)
        {
            arrowRotation *= -1;
        }

        directionArrow.transform.Rotate(new Vector3(0, 0, (arrowRotation)));

        if (powerSaved == false)
        {
            if (pBar.value == 1)
            {
                pBarTarget = 0;
            }
            else if (pBar.value == 0)
            {
                pBarTarget = 1;
            }
            if (pBar.value < pBarTarget)
            {
                pBar.value += 0.025f;
            }
            else
            {
                pBar.value -= 0.025f;
            }
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true && powerSaved == false)
        {
            pBar.value = pBar.value;

            powerSaved = true;
        }

        if (powerSaved == true)
        {
            HitBall();
        }
    }

    

    void HitBall()
    {
        float xVelocity = (directionArrow.transform.rotation.z * 90) * pBar.value; 
        float yVelocity = 0;
        float zVelocity = 0;

        if (isInHazard != true)
        {
            yVelocity = 1000 * pBar.value;
            zVelocity = 1000 * pBar.value;
        } else
        {
            yVelocity = 750 * pBar.value;
            zVelocity = 750 * pBar.value;
        }

        if (Input.GetKey(KeyCode.Mouse0) && isGrounded == true)
        {
            golfBall.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-(xVelocity * 15), yVelocity, zVelocity));
            isGrounded = false;

            directionArrow.SetActive(false);
            pBar.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fairway" || col.gameObject.tag == "Start" || col.gameObject.tag == "Sand")
        {
            isGrounded = true;
            functionCalled = false;
            powerSaved = false;

            if (col.gameObject.tag == "Sand")
            {
                isInHazard = true;
            }
            else
            {
                isInHazard = false;
            }
        }
    }
}
