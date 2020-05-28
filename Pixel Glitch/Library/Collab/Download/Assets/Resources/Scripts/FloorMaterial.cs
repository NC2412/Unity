using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaterial : MonoBehaviour {
    MapSpawner mapSpawn;
    
    PixelEditor pixel;
    
    public Color color;
    
    public float colorVal = 255;
    public int totalSpawnCount = 1;
    public int totalDeathCount = 0;

    void Start()
    {

        pixel = GameObject.Find("Script Controller").GetComponent<PixelEditor>();
        mapSpawn = GameObject.Find("Script Controller").GetComponent<MapSpawner>();
    }

    public void Update()
    {
        
    }

    public void colorChange(float timeScale)
    {
        colorVal -= Time.deltaTime * timeScale;
        color = new Color32(255, (byte)colorVal, (byte)colorVal, 0);


        //Sets color of ground in each spawned section
        for (int i = totalDeathCount; i <= totalSpawnCount; i++)
        {
            mapSpawn.totalSpawnedSections[i].transform.Find("Ground").gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }

}
