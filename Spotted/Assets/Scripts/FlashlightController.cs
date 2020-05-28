using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
    
    public Light flashlight;

    public bool IsFlashlightOn;
	// Use this for initialization
	void Start () {
        flashlight = GetComponent<Light>();
        IsFlashlightOn = false;
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKeyDown(KeyCode.F) && IsFlashlightOn == false)
            {
            IsFlashlightOn = true;
                flashlight.intensity = 2;

                
            }
            else if (Input.GetKeyDown(KeyCode.F) && IsFlashlightOn == true)
            {
            IsFlashlightOn = false;
                flashlight.intensity = 0;
            }

        if (IsFlashlightOn == true)
        {
            PlayerInteraction.batteryLife -= Time.smoothDeltaTime;
            if (PlayerInteraction.batteryLife <= 0)
            {
                PlayerInteraction.batteryLeft--;
                PlayerInteraction.batteryLife = 100;
            }
        }
        else
        {
            PlayerInteraction.batteryLife = PlayerInteraction.batteryLife;
        }
        if (PlayerInteraction.batteryLeft <= 0)
        {
            PlayerInteraction.batteryLife = 0;
            flashlight.intensity = 0;
        }
    }
    
}
