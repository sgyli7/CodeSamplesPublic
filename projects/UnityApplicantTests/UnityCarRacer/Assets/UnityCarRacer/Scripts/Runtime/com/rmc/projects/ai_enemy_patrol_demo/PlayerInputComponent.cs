using UnityEngine;
using System.Collections;

public class PlayerInputComponent : MonoBehaviour {
		
	[ExposeProperty]
	public GameObject wayPoint  {

		set{
			_navMeshAgent.SetDestination (value.transform.position);
		}
	}

	
	private NavMeshAgent _navMeshAgent;
	
	// Use this for initialization
	void Start () {
		
		_navMeshAgent = GetComponent<NavMeshAgent> ();

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

