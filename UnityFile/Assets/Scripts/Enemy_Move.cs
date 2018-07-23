using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {
    private float speed = 0.025f;
    private Animator anim;
    private Vector3 diff;
    private AILerp AILerpScripts;
    private float thresholdDiff = 0.05f;
    private Vector3 move;
	// Use this for initialization
	void Awake () {
        AILerpScripts = GetComponent<AILerp>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (AILerpScripts.target != null) {
            diff = AILerpScripts.target.position - this.transform.position;

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
}
