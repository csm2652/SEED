using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    public float enemyHp = 100.0f;
    public float eAttack = 9.0f;
    public bool isDie = false;
    public List<float> distanceWithPlayers = new List<float>();
	public float[] PlayersAgro = { 0f, 0f, 0f, 0f };
	public float[] GetDamegedList = {1f,1f,1f,1f};
    private Vector3 thisPos;

    private AILerp targetScripts;
    private int target;
	private bool DFIsDie;
	private bool MDIsDie;
	private bool SDIsDie;
	private bool ZLIsDie;
    // Use this for initialization

    private int maxAgro(float DF, float MD, float SD, float ZL) {
        float max = -100f;
        int index=0;
        float[] tmp = { DF, MD, SD, ZL };
        for(int i =0; i<4;i++) {
            if (max < tmp[i]) {
                index = i;
                max = tmp[i];
            }

        }

        return index;

    }
    void Awake() {
        thisPos = GetComponent<Transform>().position;
        targetScripts = GetComponent<AILerp>();
//		DFIsDie = GameManager.players [0].GetComponent<PlayerStatus> ().isDie;
//		MDIsDie = GameManager.players [1].GetComponent<PlayerStatus> ().isDie;
//		SDIsDie = GameManager.players [2].GetComponent<PlayerStatus> ().isDie;
//		ZLIsDie = GameManager.players [3].GetComponent<PlayerStatus> ().isDie;
        //distanceWithPlayer();
    }
    void Start () {
	}

    // Update is called once per frame
    void Update() {

        GetComponent<SpriteRenderer>().sortingOrder = -(int)(GetComponent<Transform>().position.y * 10);
        distanceWithPlayers.Clear();

		for (int i = 0; i < 4; i++) {
			if (GameManager.playerDie [i] == true) {
				distanceWithPlayers.Add (0f);
				PlayersAgro [i] = -1f;
			} 
			else {
				distanceWithPlayers.Add (Vector3.Distance (GameManager.players [i].transform.GetChild (0).position, thisPos));
				PlayersAgro [i] = GetDamegedList[i]/(1+distanceWithPlayers[i]);

			}
		}
//        agroDF = distanceWithPlayers[0] / (1 + getDamageDF*7);
//        agroMD = distanceWithPlayers[1] / (1 + getDamageMD*14);
//        agroSD = distanceWithPlayers[2] / (1 + getDamageSD*20);
//        agroZL = distanceWithPlayers[3] / (1 + getDamageZL*10);
        //Debug.Log(agroDF+ " " + agroMD + " " + agroSD+ " " + agroZL);

		target = maxAgro(PlayersAgro[0], PlayersAgro[1],PlayersAgro[2],PlayersAgro[3]);
		Debug.Log ("target num: " + target);
        targetScripts.target = GameManager.players[target].transform.GetChild(0);

    }

    public void getDamaged(float dmg, int character) {
		GetDamegedList [character] += dmg;
        enemyHp = enemyHp - dmg;
        if (enemyHp <= 0.0f) {
			GameObject.Find ("Enemy_Die").GetComponent<AudioSource> ().Play ();
			OnDestroy ();
         }
    }
   /* public void distanceWithPlayer() {
        if (GameManager.players != null) {
            for (int i = 0; i < GameManager.players.Count; i++) {
                //distanceWithPlayers[i] = Vector3.Distance(GameManager.players[i].transform.position, thisPos);
            }
        }
    }*/

    void OnDestroy() {
		isDie = true;
		Destroy (this.gameObject);
	}
}
