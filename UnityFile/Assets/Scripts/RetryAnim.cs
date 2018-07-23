using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryAnim : MonoBehaviour {

	public Animator retryAnim;	
	// Use this for initialization
	void Start () {
		retryAnim = GetComponent<Animator> ();
		retryAnim.SetBool ("isGameOver", false);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("retryanim: "+GameManager.gameOver);
		if (GameManager.gameOver) {
			Debug.Log ("inside retry anime: " + GameManager.gameOver);
			retryAnim.SetBool ("isGameOver", true);
		}
	}
}
