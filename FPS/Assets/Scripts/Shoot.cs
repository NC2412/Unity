using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject projectile;
	public GameObject weapon;
	public GameObject objectOne;
	public GameObject objectTwo;

    public Transform origin;

    AudioSource fire;

    float bulletSpeed;
    float fireTimer = 0.4f;

    bool canShoot;



	// Use this for initialization
	void Start () {
        canShoot = true;
        bulletSpeed = 200;
        fire = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //print
        //print(weapon.GetComponent<Animator>().GetBool("isShooting"));



        if (canShoot == false)
        {
            fireTimer -= Time.deltaTime;
        }
        if (fireTimer <= 0)
        {
            fireTimer = 0.4f;
            canShoot = true;
        }

        if (Input.GetKey (KeyCode.Mouse0) && canShoot == true) {

            canShoot = false;

            Fire ();

            
        } else {
			weapon.GetComponent<Animator>().SetBool("isShooting", false);
		}
	}

    void Fire()
    {
		
		weapon.GetComponent<Animator>().SetBool("isShooting", true);

		var  firedProjectile =  (GameObject)Instantiate(projectile, origin.position, origin.rotation);
        firedProjectile.GetComponent<Rigidbody>().velocity = firedProjectile.transform.forward * bulletSpeed;
		firedProjectile.GetComponent<Renderer> ().material.color = new Color(Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2));
		objectOne.GetComponent<Renderer> ().material.color = new Color(Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2));
		objectTwo.GetComponent<Renderer> ().material.color = new Color(Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2));
        firedProjectile.gameObject.tag = "Player Projectile";
		


        fire.Play();

		Destroy (firedProjectile, 10);
    }
}