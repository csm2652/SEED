using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public float playerHp = 100.0f;
    public float pAttack = 10.0f;
    public bool isDie;
   
    public float getPlayerHp() {
        return playerHp;
    }
    public float getPlayerAtk() {
        return pAttack;
    }
    public bool getIsDie() {
        return isDie;
    }
    // Use this for initialization
    void Awake () {
        isDie = false;
        playerHp = 100.0f;
        pAttack = 10.0f;
    //ThisController = gameObject.transform.parent.gameObject.GetComponent<Un>;
}
	void Update() {

    }
	// Update is called once per frame
	void FixedUpdate () {

	}
}
