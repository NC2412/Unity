using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioSource sound;
    public AudioClip footSteps;

    public ParticleSystem deathParticles;

    public Camera cam;

    float mSpeed = 10;
    float jumpHeight = 500;
    float timer = 4;

    bool isGrounded;
    public bool isDead = false;
    bool playSound = false;
    bool isMoving = false;

    int health = 100;

    public Rigidbody rb;

    public Transform weapon;
    public Transform player;

    private Text reticle;
    private Text tHealth;

    // Use this for initialization
    void Start()
    {
        reticle = GameObject.Find("Reticle").GetComponent<Text>();
        tHealth = GameObject.Find("Health").GetComponent<Text>();
        sound = this.gameObject.GetComponent<AudioSource>();
        player = this.gameObject.transform;

        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print
        //print (isGrounded);

        if (isDead != true)
        {
            Move();
            Scope();
        }

        tHealth.text = "Health: " + health + "%";
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * mSpeed);
            isMoving = true;
            if (sound.isPlaying == false && isGrounded == true)
            {
                sound.PlayOneShot(footSteps);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * mSpeed);
            isMoving = true;
            if (sound.isPlaying == false && isGrounded == true)
            {
                sound.PlayOneShot(footSteps);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * mSpeed);
            isMoving = true;
            if (sound.isPlaying == false && isGrounded == true)
            {
                sound.PlayOneShot(footSteps);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * mSpeed);
            isMoving = true;
            if (sound.isPlaying == false && isGrounded == true)
            {
                sound.PlayOneShot(footSteps);
            }
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
            isMoving = false;
            sound.enabled = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            mSpeed = 200;
        }

        else
        {
            isMoving = false;
            mSpeed = 10;
            sound.enabled = true;
        }


       



    }

    void Scope()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            weapon.transform.localPosition = new Vector3(0, -0.14f, 1);
            reticle.text = " ";

            if (isGrounded == true)
            {
                mSpeed = 5;
            }
            cam.fieldOfView = 45;
        }
        else
        {
            weapon.transform.localPosition = new Vector3(0.3f, -0.2f, 1);
            reticle.text = "+";
            mSpeed = 10;

            cam.fieldOfView = 60;
        }


    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Enemy Projectile")
        {
            health = health - 20;
            if (health <= 0)
            {
                isDead = true;
                Destroy(player.gameObject);
            }
        }
        if (col.gameObject.tag == "Out Of Bounds")
        {
            isDead = true;
            Destroy(player.gameObject);
        }
    }
}
