using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	private bool isDie = false;
	private GameObject target=null;

	private Transform myPos;
	private Vector3 cross;
	private float betweenEnemyTan;
	private float betweenEnemyAngle;
	private Vector2 myAnglePos;
	private Vector2 enemyAnglePos;

	public float Attacktime = 0.1f;
	public List<GameObject> PlayerInRange;
	public float myAtk = 3f;
	public float reach = 0.1f;
	public float minDistace=10000f;
	public GameObject getPlayerSpParent = null;

	void Awake(){
		myAtk = GetComponent<EnemyStatus> ().eAttack;
		isDie = GetComponent<EnemyStatus>().isDie;
		myPos = GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider thiscoll) {
		getPlayerSpParent = thiscoll.transform.root.gameObject;
		Debug.Log (getPlayerSpParent.tag);
		if ((new List<string>{"Medic","Soldier","Zealot","Defender"}).Contains(getPlayerSpParent.tag)) {
			PlayerInRange.Add (getPlayerSpParent);
			StartCoroutine (State ());
		}
	}
	void OnTriggerExit(Collider other) {
		PlayerInRange.Clear();
	}

	float distanceToPoint(float x1, float y1, float x2, float y2){
		return (float)Mathf.Sqrt (Mathf.Pow (x1 - x2, 2) + Mathf.Pow (y1 - y2, 2));
	}

	IEnumerator State() {
		while (!isDie) {
			attack();
			updateList();
			yield return new WaitForSeconds(Attacktime);
		}

	}

	void attack() {
		foreach (GameObject tmp in PlayerInRange) {
			if (tmp != null) {
				if (target == null) {
					if (minDistace > Vector3.Distance (myPos.position, tmp.transform.position)) {
						minDistace = Vector3.Distance (myPos.position, tmp.transform.position);
						target = tmp;
					}
				}
			}
		}
	
		if (target != null) {
		//	Debug.Log ("target = " + target);
		//	Debug.Log (distanceToPoint(myPos.position.x, myPos.position.y,
		//		target.GetComponent<Transform>().position.x, target.GetComponent<Transform>().position.y));
			if (distanceToPoint(myPos.position.x, myPos.position.y, 
				target.GetComponent<Transform>().position.x, target.GetComponent<Transform>().position.y) < reach) {
				target.GetComponent<PlayerStatus> ().getDamaged (myAtk);
			}
		}
		target = null;
		minDistace = 10000f;
	}

	void updateList() {
		int max = PlayerInRange.Count;
		for (int i = 0; i < max; i+=1) {
			if (PlayerInRange[i] == null) {
				PlayerInRange.RemoveAt(i);
				max -= 1;
				i -= 1;
			}
		}
	}

}
