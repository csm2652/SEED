using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    public float enemyHp = 100.0f;
    public float eAttack = 10.0f;
    public bool isDie = false;
    public float distanceWithPlayer1;
    public float distanceWithPlayer2;
    public float distanceWithPlayer3;
    public float distanceWithPlayer4;

    private Vector3 thisPos;
    // Use this for initialization
    public bool getIsDie() {
        return isDie;
    }
    void Awake() {
        thisPos = GetComponent<Transform>().position;
        //GameManager.players.Length
        distanceWithPlayer(GameObject.Find("PlayerSp1").transform.position,
            GameObject.Find("PlayerSp2").transform.position,
            GameObject.Find("PlayerSp3").transform.position,
            GameObject.Find("PlayerSp4").transform.position);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(GetComponent<Transform>().position.y * 10);
        Debug.Log(distanceWithPlayer1);
        Debug.Log(distanceWithPlayer2);
    }

    public void getDamaged(float dmg) {
        enemyHp = enemyHp - dmg;
        Debug.Log("hp: " + enemyHp);
        if (enemyHp <= 0.0f) {
            Destroy(this.gameObject);
         }
    }
    public void distanceWithPlayer(Vector3 distance1,Vector3 distance2, Vector3 distance3, Vector3 distance4) {
        distanceWithPlayer1 = Vector3.Distance(distance1, thisPos);
        distanceWithPlayer2 = Vector3.Distance(distance2, thisPos);
        distanceWithPlayer3 = Vector3.Distance(distance3, thisPos);
        distanceWithPlayer4 = Vector3.Distance(distance4, thisPos);
    }

    void OnDestroy() {
        isDie = true;
    }
}
