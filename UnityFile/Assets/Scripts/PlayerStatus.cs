using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public float playerHp = 100.0f;
    public float Attack = 10.0f;

    private ArrayList EnemyInRange;
    private GameObject ThisController;

    void isAttack(GameObject Enemy) {
       
    }

    void OnTriggerEnter (Collider thiscoll) {
        if(thiscoll.gameObject.tag == "Unit") {

        }
    }

	// Use this for initialization
	void Start () {
        //ThisController = gameObject.transform.parent.gameObject.GetComponent<Un>;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
