using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void Loadlevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }
}
