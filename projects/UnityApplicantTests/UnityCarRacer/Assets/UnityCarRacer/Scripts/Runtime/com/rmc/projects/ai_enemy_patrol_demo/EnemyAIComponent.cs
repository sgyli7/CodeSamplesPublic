using UnityEngine;
using System.Collections;

public class EnemyAIComponent : MonoBehaviour {


	public Transform wayPoint;

	private NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
	
		_navMeshAgent = GetComponent<NavMeshAgent> ();
		_navMeshAgent.SetDestination (wayPoint.transform.position);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
