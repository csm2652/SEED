using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestController : MonoBehaviour {
    private Vector3 targetPos;
    private Vector3 hitPosition;
    private Vector3 dir;
    private Vector3 dirXY;
    private Vector3 framePos;
    private Vector3 moveDir;
    private Vector3 mousePos;
    private Ray ray;
    private RaycastHit hitInfo;

    public GameObject myPlayer;
    private Transform myPlayerTr;
    private Collider myPlayerCol;

    //private float inputTreshold = 0.1f;

    //private GameObject target;
    // Use this for initialization
    private bool isMoveState = false;
    private Transform tr;
    private Collider myCol;
    private float moveSpeed = 3;



    /*private bool MyTr(bool isMove) {
         Vector3 now = Camera.main.ScreenToWorldPoint
              (new Vector3(Input.mousePosition.x,
              Input.mousePosition.y,
              -Camera.main.transform.position.z));
         if (Mathf.Abs(Vector3.Distance(now, this.transform.position)) < 0.1f) {
             isMove = true;
         } else
             isMove = false;
         return isMove;
     }*/
    /*void CastRay() {
        target = null;
        
        Vector2 pos = Camera.main.ScreenToWorldPoint
            (Input.mousePosition);
        hitInfo = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hitInfo.collider != null) {
            Debug.Log(hitInfo.collider.name);
            target = hitInfo.collider.gameObject;
        }
    }*/
    void Start() {
        tr = GetComponent<Transform>();
        myPlayerTr = myPlayer.GetComponent<Transform>();
        myPlayerCol = myPlayer.GetComponent<Collider>();
        myCol = GetComponent<Collider>();

        isMoveState = false;

    }

    void FixedUpdate() {
        /*if (Input.GetMouseButton(0)) {
            CastRay();
        }*/
        if (isMoveState) {
            mousePos = Camera.main.ScreenToWorldPoint
               (new Vector3(Input.mousePosition.x,
               Input.mousePosition.y,
               -Camera.main.transform.position.z));
            tr.position = mousePos;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Physics.Raycast(pos, -Vector3.back, out hitInfo);
            Debug.Log(hitInfo.collider);
            if (hitInfo.collider == myCol || hitInfo.collider == myPlayerCol) {
                isMoveState = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            isMoveState = false;
        }
    }

}
