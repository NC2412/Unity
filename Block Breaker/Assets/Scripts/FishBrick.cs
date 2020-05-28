using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBrick : MonoBehaviour
{
    public static int fishBrickCount = 1;

    public Sprite secondHit;
    public Sprite thirdHit;
    //public Animation Destruction;
    public int maxHits = 1;


    private bool isBreakable;
    private int timesHit;
    private LevelManager levelManager;
    
    // Use this for initialization
    void Start()
    {
        fishBrickCount = 0;
        isBreakable = (this.tag == "Fish");
        if (isBreakable)
        {
            fishBrickCount++;
        }
        print(fishBrickCount);
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHits();
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = secondHit;
            return;
        }
        if (timesHit == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = thirdHit;
            return;
        }

        //Destruction = GetComponent<Animation>();
        if (timesHit >= 3)
        {
            Destroy(gameObject);
            //Destruction.Play("Destruction");
            //SimulateWin();
            fishBrickCount--;
            levelManager.FishBrickDestroyed();
            print(fishBrickCount);
        }
    }


}
