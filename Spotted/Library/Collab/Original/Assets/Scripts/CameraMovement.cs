using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    static GameObject destroyedCamera = null;
    public GameObject Camera;
    public Camera camera;
    new Vector3 rotate;
    
    // Use this for initialization
    void Start()
    {
        rotate = new Vector3(0.0f, 0.1f, 0.0f);
        if (Application.loadedLevelName != "Game")
        {
            if (destroyedCamera != null)
            {
                Destroy(Camera);
            }
            else {
                GameObject.DontDestroyOnLoad(Camera);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.Rotate(rotate);
        
    }
}