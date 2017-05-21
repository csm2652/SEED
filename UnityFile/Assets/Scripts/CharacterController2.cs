using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour {

    Vector2 Click_Point;
    Vector2 movement_vector = Vector2.zero;
    Animator anim;
    Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        {
            if (Input.GetMouseButtonDown(0))
            {
                Click_Point = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                {
                    if ((Click_Point.x > Screen.width * 0.5))
                        Click_Point.x = 1;
                    else
                        Click_Point.x = -1;
                }
                {
                    if (Click_Point.y > Screen.height)
                        Click_Point.y = 1;
                    else
                        Click_Point.y = -1;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                movement_vector = Vector2.zero;
                anim.SetBool("iswalking", false);
            }
        }
        movement_vector = Click_Point;

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input.y", movement_vector.y);
        }
     
        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
	}
}
