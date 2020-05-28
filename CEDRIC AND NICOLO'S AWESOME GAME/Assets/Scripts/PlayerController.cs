using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Third person cameras
    private Camera rightRear;
    private Camera leftRear;
    public Camera FPSCamera;

    //Gameobjects
    private Rigidbody player;
    private GameObject playerObject;

    //ANIME
    private Animator anime;

    //Hundreds of booleans
    bool RightRear;
    bool isGrounded;


    //You'll float too
    float mSpeed = 1.5f;
    float hSpeed = 2.0f;
    float vSpeed = 2.0f;
    float yaw = 0;
    float pitch = 0;
    float PosX;
    float PosZ;

    //Timers
    double jumpTime = 5;

    


    // Use this for initialization
    void Start()
    {
        leftRear = GameObject.Find("Left Rear Camera").GetComponent<Camera>();
        rightRear = GameObject.Find("Right Rear Camera").GetComponent<Camera>();
        playerObject = GameObject.Find("Player Object");
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();

        leftRear.enabled = false;
        rightRear.enabled = true;
        RightRear = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CameraAngle();
        }

        //MoveCamera();

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded == true)
        {
            Jump();
            isGrounded = false;
        }

        //if (isGrounded == true)
        //{
            Move();
        //}
        
    }

    //Switching camera angle
    void CameraAngle()
    {
        //if (rearCamera.transform.position.x >= 0.5)
        //{
        //    rearCamera.transform.position = new Vector3 (player.transform.position.x - 1, 1.779f, 0);
        //}

        //else
        //{
        //    rearCamera.transform.position = new Vector3(player.transform.position.x + 1, 1.779f, 0);
        //}

        if (RightRear == false)
        {
            leftRear.enabled = false;
            rightRear.enabled = true;
            RightRear = true;
        }
        else if(RightRear == true)
        {
            leftRear.enabled = true;
            rightRear.enabled = false;
            RightRear = false;
        }
    }

    void Move()
    {
       // playerObject.transform.position = player.transform.position;

        PosX = player.transform.position.x;
        PosZ = player.transform.position.z;

        if (player.velocity.x <= 0 )
        {
            anime.SetInteger("FSpeed", 0);
        }

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mSpeed = 2;
        }
        else
        {
            mSpeed = 1.5f;
        }
        print(mSpeed);

        //forward
        if (Input.GetKey(KeyCode.W))
        {
            anime.SetInteger("FSpeed", 1);
            player.transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
			//anime.Play ("HumanoidRun");
            
        }

		/*

        //left
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * mSpeed * Time.deltaTime);
        }

        //back
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * mSpeed * Time.deltaTime);
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * mSpeed * Time.deltaTime);
        }

		*/

        else
        {
            PosX = player.transform.position.x;
            PosZ = player.transform.position.z;
        }
    }

    void Jump()
    {
        Vector3 velocity = new Vector3(player.velocity.x, player.velocity.y + 175.0f, player.velocity.z);
        
        player.AddForce(velocity);

        anime.SetBool("IsGrounded", false);
		//anime.Play("HumanoidJumpForwardRight");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Wall")
        {
            isGrounded = true;
            anime.SetBool("IsGrounded", true);
        }
    }
}
