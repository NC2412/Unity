using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public ParticleSystem particles;

    GameObject player;

    CameraMovement cam;

    void Start()
    {
        cam = GameObject.Find("Script Controller").GetComponent<CameraMovement>();
        player = GameObject.Find("Player").gameObject;
    }

    public void Explode(Vector3 position, bool isPlayer)
    {
        float magnitude;

        if (isPlayer == true)
        {
            magnitude = 1;
        }
        else
        {
            magnitude = (1 / (position.z - player.transform.position.z));
        }
            

        StartCoroutine(cam.Shake(0.1f, magnitude));

        var particle = Instantiate(particles, position, Quaternion.identity);

        Destroy(particle, 1);
    }
}
