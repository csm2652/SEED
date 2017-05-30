using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameObject[] players;


	// Use this for initialization
	void Start () {
        players = new GameObject[4];
        players[0] = GameObject.Find("Defender");
        players[1] = GameObject.Find("Medic");
        players[2] = GameObject.Find("Soldier");
        players[3] = GameObject.Find("Zealot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
