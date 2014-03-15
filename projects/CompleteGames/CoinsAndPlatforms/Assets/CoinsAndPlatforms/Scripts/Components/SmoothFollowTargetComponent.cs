using UnityEngine;
using System.Collections;



public class SmoothFollowTargetComponent : MonoBehaviour
{
	public Transform target;
	public float followSpeed = 2.0f;
	public new Transform transform;
	public Vector3 cameraOffset;
	
	private CharacterController2D _playerController;

	public bool useConstantXZ = true;
	private Vector3 _originalTransform_vector3;
	
	
	void Awake()
	{
		transform = gameObject.transform;
		_playerController = target.GetComponent<CharacterController2D>();

		//USE CONSTANT X AND Z
		if (useConstantXZ) {

			_originalTransform_vector3 = transform.position;

		}

	}
	
	
	public void LateUpdate()
	{

		if (useConstantXZ) {

			if( _playerController == null )
			{
				transform.position = Vector3.Lerp( transform.position, new Vector3 (_originalTransform_vector3.x, target.position.y, _originalTransform_vector3.z), followSpeed * Time.deltaTime );
				return;
			}
			
			if( _playerController.velocity.x > 0 )
			{
				transform.position = Vector3.Lerp( transform.position, new Vector3 (_originalTransform_vector3.x, target.position.y, _originalTransform_vector3.z), followSpeed * Time.deltaTime );
			}
			else
			{
				var leftOffset = cameraOffset;
				leftOffset.x *= -1;
				transform.position = Vector3.Lerp( transform.position, new Vector3 (_originalTransform_vector3.x, target.position.y, _originalTransform_vector3.z), followSpeed * Time.deltaTime );
			}


		} else {

			if( _playerController == null )
			{
				transform.position = Vector3.Lerp( transform.position, target.position - cameraOffset, followSpeed * Time.deltaTime );
				return;
			}
			
			if( _playerController.velocity.x > 0 )
			{
				transform.position = Vector3.Lerp( transform.position, target.position - cameraOffset, followSpeed * Time.deltaTime );
			}
			else
			{
				var leftOffset = cameraOffset;
				leftOffset.x *= -1;
				transform.position = Vector3.Lerp( transform.position, target.position - leftOffset, followSpeed * Time.deltaTime );
			}


		}
	}
	
}
