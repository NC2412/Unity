using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {
	
	


	void OnCollisionEnter(Collision col){
		this.GetComponent<Renderer> ().material.color = new Color(Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2),Random.Range (0, 2));
	}
}
