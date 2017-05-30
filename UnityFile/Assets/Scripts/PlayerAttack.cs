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
    private float reach = 0.5f;
    private Animator anim;
    private float betweenEnemyAngle;
    private Vector2 myAnglePos;
    private Vector2 enemyAnglePos;

    public float myAtk =1;
    public float myHp = 100;
  
    public float minDistace=10000f;

    
    /*void OnTriggerStay(Collider other) {

    }*/
    // Use this for initialization
    void Awake() {
        target = null;

        anim = GetComponentInParent<Animator>();
        myAtk = GetComponentInParent<PlayerStatus>().getPlayerAtk();
        myHp = GetComponentInParent<PlayerStatus>().getPlayerHp();
        isDie = GetComponentInParent<PlayerStatus>().getIsDie();
        myPos = GetComponentInParent<Transform>();

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
           yield return new WaitForSeconds(0.5f);
        }
        
    }

    void OnTriggerEnter(Collider thiscoll) {
        if (thiscoll.transform.tag == "Enemy") {
            EnemyInRange.Add(thiscoll.gameObject);
        }
    }
    void OnTriggerExit(Collider other) {
        EnemyInRange.Remove(other.gameObject);
    }


    void attack() {
        {

            foreach (GameObject tmp in EnemyInRange) {
                Debug.Log(tmp);
                Debug.Log(EnemyInRange.Count);
                if (tmp != null) {
                    if (minDistace > Vector3.Distance(myPos.position, tmp.transform.position)) {
                        minDistace = Vector3.Distance(myPos.position, tmp.transform.position);
                        target = tmp;
                    }
                }
            }
            
            minDistace = 10000f;
            if (!(anim.GetBool("iswalking"))) {
                if (target != null) {
                    if (Mathf.Abs(Vector3.Distance(myPos.position, target.GetComponent<Transform>().position)) < reach) {
//                        Debug.Log(Mathf.Abs(Vector3.Distance(myPos.position, target.GetComponent<Transform>().position)));
                        EnemyStatus enemy = target.GetComponent<EnemyStatus>();
                        /*locationOfEnemy = ((target.transform.position - myPos.position).magnitude /
                            (target.transform.position - myPos.position).y);*/
                        
                        myAnglePos = new Vector2(myPos.position.x, myPos.position.y);
                        enemyAnglePos = new Vector2(target.transform.position.x, target.transform.position.y);
                        betweenEnemyAngle = Vector2.Angle(myAnglePos,enemyAnglePos) * Mathf.Rad2Deg;
                        Vector3 cross = Vector3.Cross(myAnglePos, enemyAnglePos);
                       
                        if (cross.z > 0)
                            betweenEnemyAngle = 360 - betweenEnemyAngle;
                        anim.SetBool("Front_Attack", false);
                        anim.SetBool("Back_Attack", false);
                        anim.SetBool("Right_Attack", false);
                        anim.SetBool("Left_Attack", false);
                        Debug.Log("angle" + betweenEnemyAngle);
                        Debug.Log("myPos:  " + myPos.position + "enemyPos: " + enemyAnglePos);
                        if ( (315 < betweenEnemyAngle && 360 >= betweenEnemyAngle) || 
                            (0 <= betweenEnemyAngle && 45 >= betweenEnemyAngle))
                            anim.SetBool("Right_Attack", true);
                        if (45 < betweenEnemyAngle && 135 >= betweenEnemyAngle)
                            anim.SetBool("Back_Attack", true);
                        if (135 < betweenEnemyAngle && 225 >= betweenEnemyAngle)
                            anim.SetBool("Left_Attack", true);
                        if (225 < betweenEnemyAngle && 315 >= betweenEnemyAngle)
                            anim.SetBool("Front_Attack", true);
                        enemy.getDamaged(myAtk);
                        //why attack motion is weird? -> Vector2.Angle return the degree of two vector based on (0,0), We want the angle based on Character position not ZeroPoint
                    }
                }
            }


        }
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
