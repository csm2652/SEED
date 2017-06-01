using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static List<GameObject> players = new List<GameObject>();
    public static string[] playerNames = { "Defender", "Medic", "Soldier", "Zealot" };
    public static int playerNum = 4; //Updates number in manager
    public GameObject enemy;

    public static float leftMap = 0f;
    public static float rightMap = 20f;
    public static float topMap = 0f;
    public static float bottomMap = -20f;
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
        StartCoroutine(this.makeEnemy());
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void removeOnManager(GameObject obj) {
        ;
    }

    GameObject randomInstantiateEnemy() {
       return Instantiate(enemy, new Vector3(
                Random.RandomRange(GameManager.leftMap, GameManager.rightMap),
                Random.RandomRange(GameManager.bottomMap, GameManager.topMap),
                0f), Quaternion.identity) as GameObject;
    }

    IEnumerator makeEnemy() {
        while (true) {
            for (int i = 0; i < 10; i++) {
                randomInstantiateEnemy();
            }
            yield return new WaitForSeconds(10f);
        }

    }
}
