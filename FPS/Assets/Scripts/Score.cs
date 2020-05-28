using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text tScore;

    public static int score;
    public static float timeLasted;


	// Use this for initialization
	void Start ()
    {
		score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timeLasted += Time.deltaTime;

        tScore.text = "Score: " + score;
	}

}
