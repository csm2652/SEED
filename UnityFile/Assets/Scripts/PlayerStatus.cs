using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public float playerHp = 100.0f;
	public float pAttack;
    public bool isDie;
	public float defend = 1f;
	public int charterIndex = 1;
   
    // Use this for initialization
    void Awake () {
        isDie = false;
    //ThisController = gameObject.transform.parent.gameObject.GetComponent<Un>;
}
	void Start(){
		
	}
	public void getDamaged(float dmg) {
		playerHp = playerHp + (defend - dmg);
//		Debug.Log(this.name + "hp: " + playerHp);
		if (playerHp <= 0.0f) {
			isDie = true; 
			GameObject.Find ("Player_Die").GetComponent<AudioSource> ().Play ();
			GameManager.playerDie [charterIndex] = true;
			StartCoroutine( dieCheck ());
		}
	}
	IEnumerator dieCheck(){
		yield return new WaitForSeconds(0.01f);
		if (isDie) {
			Destroy (this.gameObject);
		}
	}
	void Update() {
		Debug.Log (this.gameObject + "Hp: " + playerHp);
    }
	// Update is called once per frame
	void FixedUpdate () {

	}
}
