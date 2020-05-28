using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    GameObject camera;
    GameObject camShake;
    GameObject player;

    float xPos;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.Find("Camera Parent").gameObject;
        camShake = GameObject.Find("Main Camera").gameObject;
        player = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        xPos = player.transform.position.x / 2;

        camera.transform.position = new Vector3(xPos, 16, (player.transform.position.z - 13));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        

        Vector3 originalPos = camShake.transform.localPosition;

        float x, y, z, curTime;
        
        curTime = 0.0f;

        while (curTime < duration)
        {
            x = Random.RandomRange(-1, 1) * magnitude;
            y = Random.RandomRange(-1, 1) * magnitude;
            z = Random.RandomRange(-1, 1) * magnitude;

            camShake.transform.localPosition = new Vector3(x, y, z);

            curTime += Time.deltaTime;

            yield return null;
        }


        camShake.transform.localPosition = originalPos;
    }
}
