using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static List<GameObject> players = new List<GameObject>();
    public static string[] playerNames = { "Defender", "Medic", "Soldier", "Zealot" };
    public static int playerNum = 4; //Updates number in manager
    GameObject temp;
	// Use this for initialization
    void Awake() {
        //players = new GameObject[4];
        
    }

	void Start () {
        foreach (string name in playerNames) {
            if ((temp = GameObject.Find(name)) != null)
                GameManager.players.Add(temp);
        }
        Debug.Log(players);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void removeOnManager(GameObject obj) {
        ;
    }
}
