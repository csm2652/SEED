using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject dest;
    private float speed = 0.025f;
    private float thresholdDiff = 0.05f;
    private Animator anim;
    private Transform tr;
    private Transform destTr;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        destTr = dest.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(tr.position.y*10);

    }

    void FixedUpdate () { 
        Vector3 diff = destTr.position - tr.transform.position;
        anim.SetBool("iswalking", false);
        if (diff.magnitude > thresholdDiff) {
            Vector3 move = diff.normalized * speed;
            //tr.position += move;
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", diff.normalized.x);
            anim.SetFloat("input_y", diff.normalized.y);
        }
    }
}
