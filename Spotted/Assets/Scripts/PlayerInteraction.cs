using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerInteraction : MonoBehaviour
{
   
    CatEnemyAI cat;
    RobotEnemyAI robot;
    BlimpMovement blimp;
    Anime anime;
    PlayerInteraction battery;
    
    Transform enemy;

    private Text connection;
    public Text blimpCall;
    public Text signal;
    public Text win;
    public Text BatteryLife;
    public Text BatteryLeft;
    
    public Camera playerCamera;
    public Camera endCamera;

    public GameObject rope;
    public GameObject player;
    public GameObject menu;
    public GameObject restart;

    CharacterController character;

    public Image reticle;

    public bool endGame;
    bool isSignalTrue;
    bool rotate;
    public static bool isBlimpCalled;

    public static int batteryLeft = 2;
    public int gameEnemy;

    public static float batteryLife = 100;
    

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        rotate = false;
        isSignalTrue = false;

        menu.gameObject.active = false;
        restart.gameObject.active = false;

        character = gameObject.GetComponentInParent<CharacterController>();
        cat = FindObjectOfType<CatEnemyAI>();
        robot = FindObjectOfType<RobotEnemyAI>();
        playerCamera.GetComponent<Camera>().enabled = true;
        endCamera.GetComponent<Camera>().enabled = false;
        playerCamera.GetComponent<AudioListener>().enabled = true;
        endCamera.GetComponent<AudioListener>().enabled = false;

        win.text = "";
    }

    void Update()
    {
        BatteryLife.text = "Battery Life: " + batteryLife;
        BatteryLeft.text = "Batteries Left: " + batteryLeft;
        
    }

    void OnTriggerEnter(Collider trigger)
    {

        if (trigger.gameObject.tag == "Battery")
        {
            print("Battery Trigger");
            Destroy(trigger.gameObject);
            PlayerInteraction.batteryLeft++;
        }

        if (trigger.gameObject.tag == "Walkie-Talkie")
        {
            gameEnemy = Random.RandomRange(1, 3);
            
            Destroy(trigger.gameObject);

            isSignalTrue = true;

            if (gameEnemy == 1)
            {
                cat.isActivated = true;
            }
            if (gameEnemy == 2)
            {
                robot.isActivated = true;
            }
            print(gameEnemy);

            signal.text = "Calculating Signal Strength...";

            this.gameObject.GetComponent<AudioSource>().Play();
        }

        if (trigger.gameObject.tag == "1 Bar Zone" && isSignalTrue == true)
        {
            signal.text = "Signal Strength: •--";
            blimpCall.text = "";
        }

        if (trigger.gameObject.tag == "2 Bar Zone" && isSignalTrue == true)
        {
            signal.text = "Signal Strength: ••-";
            blimpCall.text = "";
        }

        if (trigger.gameObject.tag == "3 Bar Zone" && isSignalTrue == true)
        {
            signal.text = "Signal Strength: •••";
            isBlimpCalled = true;

            if (isBlimpCalled == true)
            {
                blimpCall.text = "Press 'E' to call blimp";
            }
            else
            {
                blimpCall.text = "";
            }
        }

        if (trigger.gameObject.tag == "0 Bar Zone" && isSignalTrue == true)
        {
            signal.text = "Signal Strength: ---";
            blimpCall.text = "";
        }

    
       
    }
    
    void OnTriggerStay(Collider trigger)
    {

        if (trigger.gameObject.tag == "Rope")
        {
            rotate = true;
            endGame = true;
            menu.gameObject.active = true;
            restart.gameObject.active = true;
            endCamera.GetComponent<Camera>().enabled = true;
            playerCamera.GetComponent<Camera>().enabled = true;
            playerCamera.GetComponent<AudioListener>().enabled = false;
            endCamera.GetComponent<AudioListener>().enabled = true;

            signal.text = "";
            win.text = "You win";

            Destroy(player);
            Destroy(trigger.gameObject);
            Destroy(reticle);
            Destroy(BatteryLeft);
            Destroy(BatteryLife);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;

            Destroy(reticle);
            Destroy(BatteryLeft);
            Destroy(BatteryLife);

            menu.gameObject.active = true;
            restart.gameObject.active = true;

            signal.text = "";
            win.text = "You Lose";
        }

        if (col.gameObject.tag == "Water")
        {
            Time.timeScale = 0;

            Destroy(reticle);
            Destroy(BatteryLeft);
            Destroy(BatteryLife);

            menu.gameObject.active = true;
            restart.gameObject.active = true;

            signal.text = "";
            win.text = "You Drowned";
        }
    }
}
