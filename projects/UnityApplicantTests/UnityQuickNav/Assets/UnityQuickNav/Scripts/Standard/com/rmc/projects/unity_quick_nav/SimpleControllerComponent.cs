/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using com.rmc.exceptions;
using System.Collections.Generic;

//--------------------------------------
//  Namespace
//--------------------------------------
using System.Collections;


namespace com.rmc.projects.unity_quick_nav
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum CameraMode
	{
		CAMERA_MODE_MAIN,
		CAMERA_MODE_ZOOM

	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class SimpleControllerComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The _is in transition_boolean.
		/// </summary>
		private bool _isCameraInTransition_boolean;
		public bool isCameraInTransition {
			set{

				//IN THE SCC CLASS WE SET IF THE CAMERA IS MOVING
				//WHEN MOVING WE DISABLE THE UI
				_isCameraInTransition_boolean = value;
				guiComponent.isGUIEnabled = !_isCameraInTransition_boolean;
			}
		
		}

		// PUBLIC

		/// <summary>
		/// The GUI component.`
		/// </summary>
		public GUIComponent guiComponent;

		/// <summary>
		/// The material_list.
		/// </summary>
		public List<GameObject> wayPointGameObjects_list;

		/// <summary>
		/// The material_list.
		/// </summary>
		public List<WayPointVO> wayPoints_list;

		//PRIVATE
		/// <summary>
		/// The _current way point V.
		/// </summary>
		private WayPointVO _currentWayPointVO;



		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_doBuildWayPointList();
			setTargetWayPointByIndex (0);
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			//Debug.Log("Update ()");
			
		}


		
		// PUBLIC
		/// <summary>
		/// Changes the camera mode.
		/// </summary>
		/// <param name="aCameraMode">A camera mode.</param>
		public void setTargetWayPointByIndex (int aIndex_int)
		{
			if (_currentWayPointVO != wayPoints_list[aIndex_int]) {
				_currentWayPointVO = wayPoints_list[aIndex_int];
				_currentWayPointVO.wasVisited = true;
				//
				/*
				Camera.main.transform.position 		= wayPointVO.gameObject.transform.localPosition;
				Camera.main.transform.localRotation = wayPointVO.gameObject.transform.localRotation;
				Camera.main.transform.localScale 	= wayPointVO.gameObject.transform.localScale;
				*/
				//
				guiComponent.isGUIEnabled = true;

				StartCoroutine (transitionCameraToTargetWayPoint());
			}
		}

		/// <summary>
		/// Transitions the camera to target way point.
		/// </summary>
		/// <returns>The camera to target way point.</returns>
		IEnumerator transitionCameraToTargetWayPoint()
		{
			//USED TO TOGGLE OFF THE UI DISPLAY
			isCameraInTransition = true;

			//SETUP THE TRANSITION OVER X SECONDS
			float startTime_float = Time.time;
			float elapsedTime_float = 0;
			float durationTime_float = 2f;
			Transform previousWayPointTransform = Camera.main.transform;

			//BEFORE WE REACH THE DURATION, EASE THE CAMERA TO THE NEW TRANSFORM
			while(elapsedTime_float <= durationTime_float/3)
			{
				elapsedTime_float = Time.time - startTime_float;
				Camera.main.transform.localRotation = Quaternion.Lerp (previousWayPointTransform.localRotation, _currentWayPointVO.gameObject.transform.localRotation, (elapsedTime_float / durationTime_float));
				Camera.main.transform.position 		= Vector3.Lerp (previousWayPointTransform.position, _currentWayPointVO.gameObject.transform.position, (elapsedTime_float / durationTime_float));
				yield return null;
			}

			//USED TO TOGGLE ON (AGAIN) THE UI DISPLAY
			isCameraInTransition = false;
		}

		/// <summary>
		/// Dos the clear history.
		/// </summary>
		public void doClearHistory ()
		{
			foreach (WayPointVO wayPointVO in wayPoints_list) {
				wayPointVO.wasVisited = false;
			}
			
		}

		/// <summary>
		/// Ises the current way point.
		/// </summary>
		/// <returns><c>true</c>, if current way point was ised, <c>false</c> otherwise.</returns>
		/// <param name="wayPointVO">Way point V.</param>
		public bool isCurrentWayPoint (WayPointVO aWayPointVO)
		{
			return aWayPointVO == _currentWayPointVO;
		}

		// PUBLIC STATIC

		// PRIVATE
		/// <summary>
		/// _dos the build way point list.
		/// </summary>
		private void _doBuildWayPointList ()
		{
			wayPoints_list = new List<WayPointVO>();
			//
			foreach (GameObject gameObject in wayPointGameObjects_list) {
				
				wayPoints_list.Add (new WayPointVO (gameObject));
			}
			
		}



		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------


	}
}
