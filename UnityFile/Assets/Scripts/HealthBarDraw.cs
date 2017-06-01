using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarDraw : MonoBehaviour {

    public GameObject player;
    private EnemyStatus enemyStatus;
    private Image img;
    // Use this for initialization
    void Start() {
        img = GetComponent<Image>();
        enemyStatus = player.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update() {
        img.fillAmount = enemyStatus.enemyHp * 0.01f;
        img.color = Color.Lerp(Color.red, Color.green, img.fillAmount);
    }
}
