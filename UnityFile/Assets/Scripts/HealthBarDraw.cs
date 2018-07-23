using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarDraw : MonoBehaviour {

    public GameObject player;
    private EnemyStatus enemyStatus;
	private PlayerStatus playerStatus;
    private Image img;
    // Use this for initialization
    void Start() {
        img = GetComponent<Image>();
		if (player.tag == "Enemy") {
			enemyStatus = player.GetComponent<EnemyStatus> ();
		} 
		else {
			playerStatus = player.GetComponent<PlayerStatus> ();
		}
    }

    // Update is called once per frame
    void Update() {
		if (img.fillAmount == 0) {
			Destroy (this.gameObject);
		}
		if (player.tag == "Enemy") {
			img.fillAmount = enemyStatus.enemyHp * 0.01f;
			img.color = Color.Lerp (Color.red, Color.green, img.fillAmount);
		} 
		else {
			img.fillAmount = playerStatus.playerHp * 0.001f;
			img.color = Color.Lerp (Color.red, Color.green, img.fillAmount);
		}
	}
}
