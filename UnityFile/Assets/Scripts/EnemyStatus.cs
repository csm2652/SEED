using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    public float enemyHp = 100.0f;
    public float eAttack = 10.0f;
    public bool isDie = false;
    public float[] distanceWithPlayers = new float[GameManager.playerNum];

    private Vector3 thisPos;
    // Use this for initialization
    public bool getIsDie() {
        return isDie;
    }
    void Awake() {
        thisPos = GetComponent<Transform>().position;
        
        distanceWithPlayer();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(GetComponent<Transform>().position.y * 10);
       // Debug.Log(distanceWithPlayers[1]);
    }

    public void getDamaged(float dmg) {
        enemyHp = enemyHp - dmg;
        Debug.Log(this.name + "hp: " + enemyHp);
        if (enemyHp <= 0.0f) {
            Destroy(this.gameObject);
         }
    }
    public void distanceWithPlayer() {
        if (GameManager.players != null) {
            for (int i = 0; i < GameManager.players.Count; i++) {
                distanceWithPlayers[i] = Vector3.Distance(GameManager.players[i].transform.position, thisPos);
            }
        }
    }

    void OnDestroy() {
        isDie = true;
    }
}
