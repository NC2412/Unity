using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour {

    //Creates a list of all possible maps to spawn
    public List<GameObject> totalSpawnedSections = new List<GameObject>();
    List<string> spawnableSections = new List<string>();

    FloorMaterial ground;
    PlayerMovement pointOfNoReturn;

    public GameObject player;
    GameObject newObject;
    

    Vector3 spawnLocation = new Vector3(0, 0, 79);
    
    int spawnDistance = 80;
    int destroyDistance = 100;
    int nextDestroyObject = 0;
    int randSpawn = 0;
    

	// Use this for initialization
	void Start () {
        //Adds spawnable map sections to list
        spawnableSections.Add("Safe Map");
        spawnableSections.Add("Rocket Map");

        //Sets scripts to instances
        ground = GameObject.Find("Script Controller").GetComponent<FloorMaterial>();
        pointOfNoReturn = GameObject.Find("Script Controller").GetComponent<PlayerMovement>();
        

        //Finds first instance of Safe Map to add to totalSpawnedSections
        if (GameObject.Find("Safe Map"))
        {
            totalSpawnedSections.Add(GameObject.Find("Safe Map"));
        }
	}
	
	// Update is called once per frame
	void Update () {

        //Checks if player has made enough progress into the game to spawn a new map
       if ((spawnLocation.z - player.transform.position.z) <= spawnDistance)
            spawnMap(spawnLocation);
        
       //Checks if player has made enough progress into the game to destroy furthest map section
       if ((player.transform.position.z - destroyDistance) >= totalSpawnedSections[nextDestroyObject].transform.position.z)
        destroyMap(totalSpawnedSections[nextDestroyObject]);
        
	}

    public void spawnMap(Vector3 location)
    {
        //Sets new spawnLocation, changes position of the point of no return
        spawnLocation.z += 60;

        //Spawns Safe Map every five instances of a new spawn
        if (totalSpawnedSections.Count % 5 == 0)
        {
            randSpawn = 0;
        } else
        {
            randSpawn = Random.RandomRange(1, spawnableSections.Count);
        }

        //Spawns new object; Sets name of newObject for ease; adds object to totalSpawnedSections
        newObject = Instantiate(Resources.Load("Prefabs/" + spawnableSections[randSpawn]), location, Quaternion.identity) as GameObject;
        newObject.name = newObject.name + " " + totalSpawnedSections.Count;
        totalSpawnedSections.Add(newObject);

        ground.totalSpawnCount++;
    }

    public void destroyMap(GameObject destroyThisObject)
    {
        //Destroys furthes map section
        Destroy(destroyThisObject);
        nextDestroyObject++;
        ground.totalDeathCount++;
    }
}
