using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    private Vector3 targetPos;
    private Vector3 hitPosition;
    private Vector3 dir;
    private Vector3 dirXY;
    private Vector3 framePos;
    private Vector3 moveDir;
    private Vector3 mousePos;
    private Ray ray;
    private RaycastHit hitInfo;

    public bool isMoveState;
    public float moveSpeed = 10;
    private Transform tr;
    private Animator anim; 
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);//포시션을 담는 어레이가 있어서 그 어레이 안에 값을 순차적 참조해서 타겟포인트까지 따라간다?
            Debug.Log("mousepos" + mousePos.x + " " + mousePos.y);
            if (Physics.Raycast(ray, out hitInfo, 100000f))
            {
                Debug.Log("hit point: " + hitPosition);
                Debug.Log("hit object: " + hitInfo.collider.name);
                hitPosition = hitInfo.point;
                isMoveState = true;
                anim.SetBool("iswalking", true);

            }
            else
                anim.SetBool("iswalking", false);
        }
        else if (Input.GetMouseButtonUp(0))
            anim.SetBool("iswalking", false);
        if(isMoveState)
        {
            dir = hitPosition - transform.position;
            anim.SetFloat("input_x", dir.x);
            anim.SetFloat("input_y", dir.y);
            dirXY = new Vector3(dir.x, dir.y,0);

            targetPos = transform.position + dirXY;

            framePos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
            moveDir = (framePos - transform.position);

            tr.position = tr.position + moveDir;

            if(framePos == targetPos)
            {
                isMoveState = false;
            }
        }

        else
        {

        }
       
	}
}
