using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {
	public GameObject oBJECT;
    static GameObject instance = null;
	// Use this for initialization
	void Start () {
		if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this.gameObject;
            GameObject.DontDestroyOnLoad(oBJECT);
        }
	}
}
