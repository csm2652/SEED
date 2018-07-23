using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public List<GameObject> EnemyInRange;
    private Transform myPos;
    private bool isDie;
    private bool enemyIsDie = false;
    private GameObject target=null;
    private PlayerStatus myStatus;

    private Vector3 cross;
    private Animator anim;
    private float betweenEnemyTan;
    private float betweenEnemyAngle;
    private Vector2 myAnglePos;
    private Vector2 enemyAnglePos;
	private float myx_M_enex;
	private float myy_M_eney;

    public int characterNumber;
    public float AttackTime = 0.5f;
    public float myAtk =1;
    public float myHp = 100;
    public float reach = 0.5f;
    public float minDistace=10000f;

    
    /*void OnTriggerStay(Collider other) {

    }*/
    // Use this for initialization
    void Awake() {
        target = null;

		myStatus = GetComponentInParent<PlayerStatus> ();
        anim = GetComponentInParent<Animator>();
		myAtk = myStatus.pAttack;
		myHp = myStatus.playerHp;
		isDie = myStatus.isDie;
        myPos = GetComponentInParent<Transform>();
		characterNumber = myStatus.charterIndex;
    }

    void Update() {
        if(anim.GetBool("iswalking")) {
            anim.SetBool("Front_Attack", false);
            anim.SetBool("Back_Attack", false);
            anim.SetBool("Right_Attack", false);
            anim.SetBool("Left_Attack", false);
        }
        else if(EnemyInRange.Count == 0) {
            anim.SetBool("Front_Attack", false);
            anim.SetBool("Back_Attack", false);
            anim.SetBool("Right_Attack", false);
            anim.SetBool("Left_Attack", false);
        }      
    }
    void Start() {
        StartCoroutine(State());
    }
    // Update is called once per frame
    void LateUpdate () {
       
    }
    IEnumerator State() {
        while (!isDie) {
            attack();
            updateList();
           yield return new WaitForSeconds(AttackTime);
        }
        
    }

    void OnTriggerEnter(Collider thiscoll) {
        if (thiscoll.transform.tag == "Enemy") {
            EnemyInRange.Add(thiscoll.gameObject);
        }
    }
    void OnTriggerExit(Collider other) {
		Debug.Log ("some is lost:" + other);
        EnemyInRange.Remove(other.gameObject);

    }
	float distanceToPoint(float x1, float y1, float x2, float y2){
		return (float)Mathf.Sqrt (Mathf.Pow (x1 - x2, 2) + Mathf.Pow (y1 - y2, 2));
	}

    void attack() {
        

            foreach (GameObject tmp in EnemyInRange) {
                if (tmp != null) {
                    if (target == null) {
                        if (minDistace > Vector3.Distance(myPos.position, tmp.transform.position)) {
                            minDistace = Vector3.Distance(myPos.position, tmp.transform.position);
                            target = tmp;
                        }
                    }
                }
            }

            minDistace = 10000f;
            if (!(anim.GetBool("iswalking"))) {
                if (target != null) {
				if (distanceToPoint(myPos.position.x, myPos.position.y, 
					target.GetComponent<Transform>().position.x, target.GetComponent<Transform>().position.y) < reach) {
//                        Debug.Log(Mathf.Abs(Vector3.Distance(myPos.position, target.GetComponent<Transform>().position)));
                   EnemyStatus enemy = target.GetComponent<EnemyStatus>();
                        /*locationOfEnemy = ((target.transform.position - myPos.position).magnitude /
                            (target.transform.position - myPos.position).y);*/

                    myAnglePos = new Vector2(myPos.position.x, myPos.position.y);
                    enemyAnglePos = new Vector2(target.transform.position.x, target.transform.position.y);
					myx_M_enex = myAnglePos.x - enemyAnglePos.x;
					myy_M_eney = myAnglePos.y - enemyAnglePos.y;
                    // float reverse = 1/(enemyAnglePos.x - myAnglePos.x);
                      //  betweenEnemyTan = (enemyAnglePos.y - myAnglePos.y) * reverse;

                      
                        cross = Vector3.Cross(myAnglePos, enemyAnglePos);
                          
                        anim.SetBool("Front_Attack", false);
                        anim.SetBool("Back_Attack", false);
                        anim.SetBool("Right_Attack", false);
                        anim.SetBool("Left_Attack", false);


					if (myx_M_enex > 0) {
						//enemy is left side
						if (myy_M_eney > 0) {
							if (Mathf.Abs (myx_M_enex) > Mathf.Abs (myy_M_eney)) {
								anim.SetBool ("Left_Attack", true);
							} else {
								anim.SetBool ("Front_Attack", true);
							}
						} else {
							if (Mathf.Abs (myx_M_enex) > Mathf.Abs (myy_M_eney)) {
								anim.SetBool ("Left_Attack", true);
							} else {
								anim.SetBool ("Back_Attack", true);
							}
						}
					} else {
						if (myy_M_eney > 0) {
							if (Mathf.Abs (myx_M_enex) > Mathf.Abs (myy_M_eney)) {
								anim.SetBool ("Right_Attack", true);
							} else {
								anim.SetBool ("Front_Attack", true);
							}
						} else {
							if (Mathf.Abs (myx_M_enex) > Mathf.Abs (myy_M_eney)) {
								anim.SetBool ("Right_Attack", true);
							} else {
								anim.SetBool ("Back_Attack", true);
							}
						}
					}                        
						attackSound (characterNumber);
                        enemy.getDamaged(myAtk,characterNumber);
                        //why attack motion is weird? -> Vector2.Angle return the degree of two vector based on (0,0), We want the angle based on Character position not ZeroPoint  

                    }
                }
            }


        
    }
	void attackSound(int charindex){
		if(charindex == 0)
			GameObject.Find ("DF_Attack").GetComponent<AudioSource> ().Play ();
		if(charindex == 1)
			GameObject.Find ("MD_Attack").GetComponent<AudioSource> ().Play ();
		if(charindex == 2)
			GameObject.Find ("SD_Attack").GetComponent<AudioSource> ().Play ();
		if(charindex == 3)
			GameObject.Find ("ZL_Attack").GetComponent<AudioSource> ().Play ();
	}

    void updateList() {
        int max = EnemyInRange.Count;
        for (int i = 0; i < max; i+=1) {
            if (EnemyInRange[i] == null) {
                EnemyInRange.RemoveAt(i);
                max -= 1;
                i -= 1;
            }
        }
    }


}
