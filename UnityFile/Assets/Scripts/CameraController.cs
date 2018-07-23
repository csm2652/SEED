using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float leftBorder;
    private float rightBorder;
    private float bottomBorder;
    private float topBorder;
    private float leftFullBorder, rightFullBorder, bottomFullBorder, topFullBorder;

    private Transform tr;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        updateBorder();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateBorder() {
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0)).x;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.1f)).y;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.9f)).y;
        leftFullBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        rightFullBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x;
        bottomFullBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.9f)).y;
        topFullBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1)).y;
    }

    //Mathf.Clamp(player.position.x, leftBorder, rightBorder),
    public void updatePos(Transform player) {
        //왼쪽
        if (player.position.x < leftBorder && leftFullBorder > GameManager.leftMap) {
            tr.position = new Vector3(
                tr.position.x - (rightBorder - leftBorder) / 100,
                tr.position.y,
                tr.position.z);
        }
        //오른쪽 갈때
        if (player.position.x > rightBorder && rightFullBorder < GameManager.rightMap) {
            tr.position = new Vector3(
               tr.position.x + (rightBorder - leftBorder) / 100,
               tr.position.y,
               tr.position.z);
        }
        // 위로 올라갈때
        if (player.position.y < bottomBorder && bottomFullBorder > GameManager.bottomMap) {
            tr.position = new Vector3(
                tr.position.x,
                tr.position.y - (topBorder - bottomBorder) / 100,
                tr.position.z);
        }
        //아래
        if (player.position.y > topBorder && topFullBorder < GameManager.topMap) {
            tr.position = new Vector3(
                tr.position.x,
                tr.position.y + (topBorder - bottomBorder) / 100,
                tr.position.z);
        }   
        updateBorder();

    }
}
