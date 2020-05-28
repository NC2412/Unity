using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour {

    public GameObject player;
    public GameObject laser;

    private LineRenderer line;

    public Light fireLight;

    float distanceToPlayer;
    float fireDistance = 20;

	// Use this for initialization
	void Start () {
        
        line = this.gameObject.GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Mathf.Sqrt(Mathf.Pow(laser.transform.position.x - player.transform.position.x, 2) +
                                      Mathf.Pow(laser.transform.position.z - player.transform.position.z, 2));

        if (distanceToPlayer <= fireDistance)
        {
            fireLight.intensity += Time.deltaTime * 40;

            if (fireLight.intensity >= 200)
            {
                StartCoroutine(FireLaser());
                fireLight.intensity = 0;
            }
        }
    }

    IEnumerator FireLaser()
    {
        RaycastHit hit;

        line.enabled = true;
        line.SetPosition(0, laser.transform.position);

        if (Physics.Raycast(laser.transform.position, Vector3.right, out hit))
        {
           
                line.SetPosition(1, hit.point);
                line.startColor = Color.red;
                line.endColor = Color.blue;
            
        }

        yield return new WaitForSeconds(1);

        line.enabled = false;
    }
}
