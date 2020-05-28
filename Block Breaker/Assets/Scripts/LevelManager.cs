using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel (string name)
	{
		Debug.Log ("Level load requested for: " + name);
        Application.LoadLevel(name);
	}
	
	public void QuitRequest ()
	{
        Debug.Log("I want to quit!");
	}

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }

    //Level 1 Win
    public void BrickDestroyed()
    {
        if (Brick.brickCount <= 0)
        {
            Application.LoadLevel("Win");
        }
    }

    //Level 2 win
    public void FishBrickDestroyed()
    {
        if (FishBrick.fishBrickCount <= 0)
        {
            Application.LoadLevel("Win");
        }
    }
}
