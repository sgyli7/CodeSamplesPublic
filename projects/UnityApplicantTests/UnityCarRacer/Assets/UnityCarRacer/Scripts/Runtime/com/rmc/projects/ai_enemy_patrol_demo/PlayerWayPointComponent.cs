using UnityEngine;
using System.Collections;

public class PlayerWayPointComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {


			
			//	HANDLE MOVE
			//	NOTE: IF YOUR MOUSE 'HITS' THE InvisibleMouseDetectionCubeLayer GAMEOBJECT THEN ITS A LEGAL POSITION
			//	NOTE: THE "BowlingBallPrefab" HAS A LAYER OF "Ignore Raycast", WHICH WE REQUIRE
			//
			RaycastHit raycastHit;
			Debug.Log ("Camera.main: " + Camera.current);
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity)) {
				
				if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer ("FloorLayer")) {
					transform.position = new Vector3 (raycastHit.point.x, raycastHit.point.y, transform.position.z);
				}
			} 


		}
	
	}
}
