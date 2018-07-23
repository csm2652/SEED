using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static List<GameObject> players = new List<GameObject>();
    public static string[] playerNames = { "Defender", "Medic", "Soldier", "Zealot" };
    public static int playerNum = 4; //Updates number in manager
	public static bool[] playerDie = {false,false,false,false};
	public static bool gameOver;



    public static float leftMap = 0f;
    public static float rightMap = 10f;
    public static float topMap = 0f;
    public static float bottomMap = -6f;
	public static int current_level = 0;
	public GameObject enemy;
	public GameObject[] destroyList;
    GameObject temp;


	private Image healingButton;
	private Text levelText;
	// Use this for initialization
    void Awake() {

		gameOver = false;
        
        foreach (string name in playerNames) {
            if ((temp = GameObject.Find(name)) != null)
                GameManager.players.Add(temp);
        }
        StartCoroutine(this.makeEnemy());
    }

	void Start () {
		levelText = GameObject.Find ("LevelImage").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		levelText.text = "[ Level" + current_level+ " ]";

		for (int i = 0; i < 4; i++) {
			if (playerDie [i] == false) {
				Debug.Log (playerDie[0] + "" + playerDie[1] + "" + playerDie[2] + "" + playerDie[3]);
				break;
			}
			else if (i == 3) {
				gameOver = true;
				Debug.Log ("gameover: " + gameOver);

			}
		}

		if(gameOver && Input.GetKeyDown(KeyCode.Y)){
			
			destroyList = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject tmp in destroyList) {
				Destroy (tmp);
			}
			ResetScene ();
			Application.LoadLevel(Application.loadedLevel);
		}
    }
		
	void ResetScene(){
		current_level = 0;
		gameOver = false;
		for (int i = 0; i < 4; i++) {
			playerDie [i] = false;	
		}
		players.Clear ();
	}

    GameObject randomInstantiateEnemy() {
       return Instantiate(enemy, new Vector3(
                Random.RandomRange(GameManager.leftMap + 0.3f, GameManager.rightMap - 0.3f),
                Random.RandomRange(GameManager.bottomMap + 0.3f, GameManager.topMap - 0.3f),
                0f), Quaternion.identity) as GameObject;
    }

    IEnumerator makeEnemy() {
		while (!gameOver) {
            for (int i = 0; i <= current_level+2; i++) {
                randomInstantiateEnemy();
            }
			current_level += 1;
			yield return new WaitForSeconds (8f);
        }

    }
}
