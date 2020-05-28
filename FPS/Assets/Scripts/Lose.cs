using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour {

    public Text recap;
    

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        recap = GameObject.Find("Recap").GetComponent<Text>();

		recap.text = "Recap \n\n Time Survived: " + (int)Score.timeLasted + "\n\n Score: " + Score.score + "\n\n Waves: " + Spawn.waves;
    }
}
