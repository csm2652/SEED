using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealingButton : MonoBehaviour {

	public float cooltime = 8f;
	public bool okToUse = true;

	private Image healingImage;

	// Use this for initialization
	void Start () {
		healingImage = GetComponent <Image> ();

	}
	IEnumerator CooltimeView(){
		while (!okToUse) {
			healingImage.fillAmount +=  1/cooltime;		
			if (healingImage.fillAmount >= 1) {
				okToUse = true;
			}
			yield return new WaitForSeconds (1f);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void Healing(){
		if (!(GameManager.players [1].GetComponent<PlayerStatus> ().isDie)) {
			for (int i = 0; i < 4; i++) {
					Debug.Log (GameManager.players [i].GetComponent<PlayerStatus> ().playerHp);
					GameManager.players [i].GetComponent<PlayerStatus> ().playerHp += 300;
				if (GameManager.players [i].GetComponent<PlayerStatus> ().playerHp > 1000) {
					GameManager.players [i].GetComponent<PlayerStatus> ().playerHp = 1000;
				}
					Debug.Log (GameManager.players [i].GetComponent<PlayerStatus> ().playerHp);
			}
			Debug.Log ("healing!!!!");
		} else {
			Debug.Log ("N.o.t. healing!!!!");
		}

		healingImage.fillAmount = 0;
		okToUse = false;
		StartCoroutine (CooltimeView());
	}
}
