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
using com.unity3d.wiki.expose_properties;
using com.rmc.projects.utilities;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.utilities;
using System.Collections.Generic;


namespace com.rmc.projects.unity_camera_tracking
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class TrackingCameraComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ REQUIRED VALUES
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



		/// <summary>
		/// The maximum z distance the camera to 0
		/// </summary>
		[SerializeField][HideInInspector]
		private float _distanceMax_float = 15;
		[ExposeProperty]
		public float distanceMax {
			get{
				return _distanceMax_float;
			}
			set{
				_distanceMax_float = value;
			}
		}

		
		/// <summary>
		/// The default z distance the camera to 0
		/// </summary>
		[SerializeField][HideInInspector] 
		private float _distanceDefault_float = 8;
		[ExposeProperty]
		public float distanceDefault {
			get{
				return _distanceDefault_float;
			}
			set{
				_distanceDefault_float = value;
			}
		}

		/// <summary>
		/// The _viewport bounds_rect.
		/// </summary>
		[SerializeField][HideInInspector] 
		private Rect _viewportBounds_rect = new Rect (-30, -35, 60, 70);
		[ExposeProperty]
		public Rect viewportBounds {
			get{
				return _viewportBounds_rect;
			}
			set{
				_viewportBounds_rect = value;
			}
		}


		/// <summary>
		/// Gets the instance.
		/// 
		/// NOTE: To enable simple, direct communication between core classes
		///       this demo uses _instance. This approach is for demo-only.
		/// 
		/// 
		/// 
		/// </summary>
		/// <value>The instance.</value>
		private static TrackingCameraComponent _instance;
		public static TrackingCameraComponent instance {
			get {
				return _instance;
			}
		}


		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ BONUS VALUES
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		
		
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ OTHER VALUES
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		/// <summary>
		/// The _lerp target.
		/// </summary>
		private LerpTarget _distance_lerptarget;

		/// <summary>
		/// The minimum z distance the camera to 0
		/// </summary>
		private float _distanceMin_float = 5;

		/// <summary>
		/// The _distance acceleration_float.
		/// </summary>
		private float _distanceAcceleration_float = 0.5f;


		/// <summary>
		/// The _z plane coordinate_float.
		/// 
		/// NOTE: all 2d projection calculations occur on this plane
		/// 
		/// </summary>
		private const float _zPlaneCoordinate_float = 0;


		/// <summary>
		/// The _trackable object components_list.
		/// 
		/// NOTE: 	We could maintain a unique list for the Priority!= Priority.None objects,
		/// 		but for simplicity of demo we will just check priority every frame.
		/// 
		/// </summary>
		private List<TrackableObjectComponent> _trackableObjectComponents_list;

		//--------------------------------------
		//  Methods
		//--------------------------------------

		//	PUBLIC 

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () 
		{

			//
			_trackableObjectComponents_list = new List<TrackableObjectComponent>();
			TrackingCameraComponent._instance = this;


			//NOTE: WE USE NEGATIVES BECAUSE THE 'DISTANCE' IS IN THE NEGATIVE QUADRANT (OF CARTESIAN COORDS)
			_distance_lerptarget = new LerpTarget (transform.position.z, -_distanceMin_float, -_distanceMax_float, _distanceAcceleration_float);

			_distance_lerptarget.targetValue = -_distanceDefault_float;
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//_distance_lerptarget.targetValue = _distance_lerptarget.targetValue + 0.1f;


			//UPDATE POSITION
			_distance_lerptarget.lerpCurrentToTarget (Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, transform.position.y, _distance_lerptarget.current);

			//CORRECT POSITION
			_doKeepViewportWithinBounds();

			//DRAW RECTS
			_doDrawRectForViewport();
			_doDrawRectForViewportBounds();
			_doDrawOneRectForAllTrackableObjects();
			_doDrawCenterPointCrosshairsForRectOfAllTrackableObjects();
			
		}


		/// <summary>
		/// Updates the trackable object component by priority.
		/// </summary>
		/// <param name="trackableObjectComponent">Trackable object component.</param>
		public void updateTrackableObjectComponentByPriority (TrackableObjectComponent aPotentiallyTrackableObjectComponent )
		{

			if (!_trackableObjectComponents_list.Contains (aPotentiallyTrackableObjectComponent)) {

				//NOT IN LIST? MAYBE ADD IT
				if (aPotentiallyTrackableObjectComponent.isTrackable()){
					_trackableObjectComponents_list.Add (aPotentiallyTrackableObjectComponent);
				}
			} else {

				//ALREADY IN LIST? MAYBE REMOVE IT
				if (!aPotentiallyTrackableObjectComponent.isTrackable()){
					_trackableObjectComponents_list.Remove (aPotentiallyTrackableObjectComponent);
				}
			}

			Debug.Log ("and : " + _trackableObjectComponents_list.Count);


		}


		//	PRIVATE 




		/// <summary>
		/// _dos the keep viewport within bounds.
		/// </summary>
		private void _doKeepViewportWithinBounds ()
		{
			

			
		}


		/// <summary>
		/// _dos the draw one rect for all trackable objects.
		/// 
		/// NOTE: WE LOOP THROUGH OBJECTS OF INTEREST AND DRAW A RECT AROUND ALL
		/// 
		/// </summary>
		private void _doDrawOneRectForAllTrackableObjects ()
		{
			DebugDraw.DrawRect (_getRectForAllTrackableObjects(), _zPlaneCoordinate_float);
		}

		/// <summary>
		/// _dos the draw center point crosshairs for rect of all trackable objects.
		/// </summary>
		private void _doDrawCenterPointCrosshairsForRectOfAllTrackableObjects ()
		{
			DebugDraw.DrawCenterPointCrosshairsForRect (_getRectForAllTrackableObjects(), _zPlaneCoordinate_float);
		}

		
		/// <summary>
		/// _gets the rect for all trackable objects.
		/// </summary>
		/// <returns>The rect for all trackable objects.</returns>
		private Rect _getRectForAllTrackableObjects ()
		{
			Rect allTrackableObjects_rect = new Rect();
			Rect oneTrackableObject_rect;
			bool isFirstObject_boolean = true;
			foreach (TrackableObjectComponent trackableObjectComponent in _trackableObjectComponents_list) {
				
				//
				oneTrackableObject_rect = trackableObjectComponent.getBoundsRect (_zPlaneCoordinate_float);
				
				
				//FIRST TIME THROUGH ADOPT THE RECT OF OBJECT #1 AS A STARTING POINT
				if (isFirstObject_boolean) {
					//
					isFirstObject_boolean = false;
					
					allTrackableObjects_rect = new Rect (
						oneTrackableObject_rect.x, 
						oneTrackableObject_rect.y, 
						oneTrackableObject_rect.width, 
						oneTrackableObject_rect.height);
					
				} else {
					
					//THEN EXPAND THE RECT TO INCLUDE ALL OTHERS
					
					//CHECK LOWER LEFT
					if (oneTrackableObject_rect.xMin < allTrackableObjects_rect.xMin) {
						allTrackableObjects_rect.x = oneTrackableObject_rect.x;
					}
					if (oneTrackableObject_rect.yMin < allTrackableObjects_rect.yMin) {
						allTrackableObjects_rect.yMin = oneTrackableObject_rect.yMin;
					}
					
					//CHECK UPPER RIGHT
					if (oneTrackableObject_rect.xMax > allTrackableObjects_rect.xMax) {
						allTrackableObjects_rect.xMax = oneTrackableObject_rect.xMax;
					}
					if (oneTrackableObject_rect.yMax > allTrackableObjects_rect.yMax) {
						allTrackableObjects_rect.yMax = oneTrackableObject_rect.yMax;
					}
					
				}
				//Debug.Log (allTrackableObjects_rect);
			}
			
			return allTrackableObjects_rect;
		}
		


		/// <summary>
		/// _dos the draw rect for viewport.
		/// </summary>
		private void _doDrawRectForViewport ()
		{

			Rect viewportBounds_rect = _getViewportBoundsRect(_zPlaneCoordinate_float);

			DebugDraw.DrawRect (viewportBounds_rect, _zPlaneCoordinate_float);

		}


		/// <summary>
		/// _dos the draw rect for viewport bounds.
		/// </summary>
		private void _doDrawRectForViewportBounds ()
		{
			DebugDraw.DrawRect (_viewportBounds_rect, _zPlaneCoordinate_float);
			
		}




		/// <summary>
		/// _gets the viewport bounds rect.
		/// </summary>
		/// <returns>The viewport bounds rect.</returns>
		/// <param name="aZCoordinate_float">A Z coordinate_float.</param>
		private Rect _getViewportBoundsRect (float aZCoordinate_float) 
		{

			Vector3 p1 = camera.ViewportToWorldPoint(new Vector3(0,0,camera.transform.position.z));// use z or nearPlane?
			Vector3 p2 = camera.ViewportToWorldPoint(new Vector3(1,0,camera.transform.position.z));
			Vector3 p3 = camera.ViewportToWorldPoint(new Vector3(1,1,camera.transform.position.z));
			//
			float width   	= (p2 - p1).magnitude;
			float height 	= (p3 - p2).magnitude;
			//
			Rect viewportBounds_rect = new Rect (p1.x, p1.y, -width, -height);
			
			return viewportBounds_rect;
		}






		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the enable event.
		/// </summary>
		public void OnEnable ()
		{

			//FOR DEBUGGING, ALLOWS TO ENABLE/DISABLE SCRIPT CHECKBOX AT RUNTIME AND 
			// TO RESUME FUNCTIONALITY
			//Debug.Log ("ok");
			if (_distance_lerptarget != null) {
				_distance_lerptarget.targetValue = -_distanceDefault_float;
			}

		}


	}


}
