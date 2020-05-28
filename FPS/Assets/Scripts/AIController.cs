using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    

    Rigidbody rb;
    GameObject ai;
    GameObject target;
    public GameObject projectile;
    public GameObject weapon;
    public GameObject objectOne;
    public GameObject objectTwo;

    public ParticleSystem deathParticles;

    public Transform origin;

    AudioSource sound;
    public AudioClip fireSound;
    public AudioClip hitMarker;
    public AudioClip deathSound;

    Vector3 shouldShoot;
    Vector3 shootDistance;

    float bulletSpeed;
    float fireTimer = 2;
    float mSpeed;
    float searchRadius = 5000;

    int health = 2;

    bool canShoot;
    bool isDead = false;


    // Use this for initialization
    void Start()
    {
        ai = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        mSpeed = 8;
        bulletSpeed = 200;
        shootDistance = new Vector3(75, 75, 75);
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        sound = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");

        if (isDead == false)
        {
            Move();
            dShoot();
        }

        if (isDead == true)
        {
            Death();
        }
    }

    void Move()
    {
        agent.speed = 8;

        if (agent.destination == GameObject.Find("Player").transform.position)
        {
            return;
        }
        else
        {
            agent.SetDestination(Random.insideUnitCircle * searchRadius);
        }
    }

    void dShoot()
    {
        shouldShoot = target.transform.position - this.transform.position;

        if (canShoot == false)
        {
            fireTimer -= Time.deltaTime;
        }
        if (fireTimer <= 0)
        {
            fireTimer = 2f;
            canShoot = true;
        }

        if (shouldShoot.x <= shootDistance.x && shouldShoot.y <= shootDistance.y && shouldShoot.z <= shootDistance.z && PlayerController.FindObjectOfType<PlayerController>().isDead == false)
        {
            weapon.GetComponent<Animator>().SetBool("isShooting", true);
            agent.destination = GameObject.Find("Player").transform.position;
            ai.transform.LookAt(target.transform);

            RaycastHit hit;
            if (Physics.Raycast(origin.position, origin.TransformDirection(Vector3.forward) * 125, out hit) && canShoot == true)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    canShoot = false;
                    Shoot();
                }
            }
            Debug.DrawRay(origin.position, origin.TransformDirection(Vector3.forward) * 125, Color.white);
        }
        else
        {
            agent.SetDestination(Random.insideUnitCircle * searchRadius);
        }
    }

    void Shoot()
    {
        ai.transform.LookAt(GameObject.Find("Player").transform);



        var firedProjectile = (GameObject)Instantiate(projectile, origin.position, origin.rotation);

        firedProjectile.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        objectOne.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        objectTwo.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        firedProjectile.GetComponent<Rigidbody>().velocity = firedProjectile.transform.forward * bulletSpeed;
        firedProjectile.gameObject.tag = "Enemy Projectile";

        sound.PlayOneShot(fireSound);

        Destroy(firedProjectile, 4);
    }

    void Death()
    {
        this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = true;
        this.gameObject.GetComponent<ConstantForce>().enabled = false;
        this.gameObject.transform.Rotate(-3, -3, -3);
        ai.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player Projectile" && isDead != true)
        {
            health--;
            ai.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
            sound.PlayOneShot(hitMarker);
            Destroy(col.gameObject);
            if (health <= 0)
            {
                sound.PlayOneShot(deathSound);
                isDead = true;

                var particle = (ParticleSystem)Instantiate(deathParticles, ai.transform.position, ai.transform.rotation);

                Destroy(particle, 2);
                Destroy(ai, 2);
                
            }
        }

    }
}
