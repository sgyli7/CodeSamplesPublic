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
		/// <summary>
		/// Store the last zoom operation to prevent
		/// jitter from camera movement
		/// </summary>
		public enum ZoomMode
		{
			ZoomOut,
			ZoomIn

		}
		
		
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
		private Rect _viewportBoundary_rect = new Rect (-30, -35, 60, 70);
		[ExposeProperty]
		public Rect viewportBoundary {
			get{
				return _viewportBoundary_rect;
			}
			set{
				_viewportBoundary_rect = value;
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
		//\ LERP: X (WITH SPECIFIC EASING/ACCELERATION)
		//\ 
		//\ 
		//\ NOTE: 	This allows camera unique behavior (tracking vs dollying)
		//\ 		Which would be desired in a platformer for example.
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		/// <summary>
		/// The target position (X) for camera. 
		/// 
		/// NOTE: With easing/acceleration
		/// 
		/// </summary>
		private LerpTarget _xPosition_lerptarget;

		/// <summary>
		/// The minimum position
		/// </summary>
		private float _xPositionMin_float = 0; 

		/// <summary>
		/// The maximum position
		/// </summary>
		private float _xPositionMax_float = 100;

		/// <summary>
		/// The _distance acceleration_float.
		/// </summary>
		private float _xPositionAcceleration_float = 3.5f;


		
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\
		//\ LERP: Y (WITH SPECIFIC EASING/ACCELERATION)
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		
		/// <summary>
		/// The target position (Y) for camera. 
		/// 
		/// NOTE: With easing/acceleration
		/// 
		/// </summary>
		private LerpTarget _yPosition_lerptarget;
		
		/// <summary>
		/// The minimum position
		/// </summary>
		private float _yPositionMin_float = 0; 
		
		/// <summary>
		/// The maximum position
		/// </summary>
		private float _yPositionMax_float = 0;

		
		/// <summary>
		/// The _distance acceleration_float.
		/// </summary>
		private float _yPositionAcceleration_float = 3.5f;
		


		
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ LERP: Z (WITH SPECIFIC EASING/ACCELERATION)
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		
		/// <summary>
		/// The target position (Z) for camera. 
		/// 
		/// NOTE: With easing/acceleration
		/// 
		/// </summary>
		private LerpTarget _zPosition_lerptarget;
		
		/// <summary>
		/// The minimum z distance the camera to 0
		/// </summary>
		private float _distanceMin_float = 5;
		
		/// <summary>
		/// The _distance acceleration_float.
		/// </summary>
		private float _distanceAcceleration_float = 0;


		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ OTHER VALUES
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


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

		/// <summary>
		/// The _ DEBU g_ COLO.
		/// </summary>
		private static Color _DEBUG_COLOR_VIEWPORT_RECT = new Color (1, 1, 1);

		/// <summary>
		/// The _ DEBU g_ COLO.
		/// </summary>
		private static Color _DEBUG_COLOR_VIEWPORT_BOUNDS_RECT = new Color (1, 0, 0);

		/// <summary>
		/// The _ DEBU g_ COLO.
		/// </summary>
		private static Color _DEBUG_COLOR_TRACKABLE_RECT = new Color (.5f, .5f, .5f);


		/// <summary>
		/// Store the last zoom operation to prevent
		/// jitter from camera movement
		/// </summary>
		private ZoomMode _last_zoommode;

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


			//X
			float xPositionTemporaryTarget_float = 20;
			_xPosition_lerptarget = new LerpTarget (transform.position.x, xPositionTemporaryTarget_float, _xPositionMin_float, _xPositionMax_float, _xPositionAcceleration_float);

			//
			//Y
			float yPositionTemporaryTarget_float = 20;
			_yPosition_lerptarget = new LerpTarget (transform.position.y, yPositionTemporaryTarget_float, _yPositionMin_float, _yPositionMax_float, _yPositionAcceleration_float);

			//Z
			//NOTE: WE USE NEGATIVES BECAUSE THE 'DISTANCE' IS IN THE NEGATIVE QUADRANT (OF CARTESIAN COORDS)
			//NOTE, WE REVERSE MIN/MAX HERE BY DESIGN BECAUSE OF NEGATIVE VALUES
			_zPosition_lerptarget = new LerpTarget (transform.position.z, -_distanceDefault_float, -_distanceMax_float, -_distanceMin_float, _distanceAcceleration_float);
			_zPosition_lerptarget.isDebugging_boolean = true;
		
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//UPDATE POSITION
			_doTrackCameraForOneRectForAllTrackableObjects();



			//DRAW RECTS
			_doDrawRectForViewport();
			_doDrawRectForViewportBoundary();
			_doDrawOneRectForAllTrackableObjects();
			_doDrawCenterPointCrosshairsForRectOfAllTrackableObjects();


		}

		/// <summary>
		/// Lates the update.
		/// 
		/// NOTE: We 'correct' positioning here
		/// 
		/// </summary>
		void LateUpdate ()
		{

			//CORRECT POSITION
			_doDollyCamera();
			_doKeepViewportWithinBounds();
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

			//Debug.Log ("and : " + _trackableObjectComponents_list.Count);


		}


		//	PRIVATE 



		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ MOVEMENT
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		/// <summary>
		/// _dos the dolly camera.
		/// </summary>
		private void _doDollyCamera ()
		{
			Rect viewport_rect 				= _getViewportRect(_zPlaneCoordinate_float);
			Rect allTrackableObjects_rect 	= _getRectForAllTrackableObjects();
			//
			if (RectHelper.isRectWithinRect (viewport_rect, allTrackableObjects_rect)) {
				_zPosition_lerptarget.targetValue += 0.1f;
				//Debug.Log ("IN  : " + _zPosition_lerptarget.targetValue);
				//_last_zoommode = ZoomMode.ZoomOut;
			} else {
				_zPosition_lerptarget.targetValue -= 0.1f;
				//Debug.Log ("OUT : " + _zPosition_lerptarget.targetValue);
				//_last_zoommode = ZoomMode.ZoomIn;

		}


			//UPDATE POSITION
			//_zPosition_lerptarget.targetValue = -40 ;
			_zPosition_lerptarget.lerpCurrentToTarget (Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, transform.position.y, _zPosition_lerptarget.targetValue);
			//Debug.Log (transform.position.z);


		}

		/// <summary>
		/// _dos the track camera for one rect for all trackable objects.
		/// </summary>
		private void _doTrackCameraForOneRectForAllTrackableObjects()
		{

			Rect allTrackableObjects_rect 	= _getRectForAllTrackableObjects();

			//UPDATE TARGET
			_xPosition_lerptarget.targetValue = allTrackableObjects_rect.center.x; 
			_yPosition_lerptarget.targetValue = allTrackableObjects_rect.center.y; 

			//DO LERP
			_xPosition_lerptarget.lerpCurrentToTarget (Time.deltaTime);
			_yPosition_lerptarget.lerpCurrentToTarget (Time.deltaTime);

			//WITH EASING
			transform.position = new Vector3 (_xPosition_lerptarget.current, _yPosition_lerptarget.current, transform.position.z);

		}
		
		
		/// <summary>
		/// _dos the keep viewport within bounds.
		/// </summary>
		private void _doKeepViewportWithinBounds ()
		{

			Rect viewport_rect = _getViewportRect(_zPlaneCoordinate_float);

			//HORIZONTAL
			_xPosition_lerptarget.minimum = _viewportBoundary_rect.xMin + viewport_rect.width/2;
			_xPosition_lerptarget.maximum = _viewportBoundary_rect.xMax - viewport_rect.width/2;

			//VERTICAL
			_yPosition_lerptarget.minimum = _viewportBoundary_rect.yMin + viewport_rect.height/2;
			_yPosition_lerptarget.maximum = _viewportBoundary_rect.yMax - viewport_rect.height/2;
			
		}


		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ DRAWING
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


		/// <summary>
		/// _dos the draw one rect for all trackable objects.
		/// 
		/// NOTE: WE LOOP THROUGH OBJECTS OF INTEREST AND DRAW A RECT AROUND ALL
		/// 
		/// </summary>
		private void _doDrawOneRectForAllTrackableObjects ()
		{
			DebugDraw.DrawRect (_getRectForAllTrackableObjects(), _zPlaneCoordinate_float, _DEBUG_COLOR_TRACKABLE_RECT);
		}

		/// <summary>
		/// _dos the draw center point crosshairs for rect of all trackable objects.
		/// </summary>
		private void _doDrawCenterPointCrosshairsForRectOfAllTrackableObjects ()
		{
			DebugDraw.DrawCenterPointCrosshairsForRect (_getRectForAllTrackableObjects(), _zPlaneCoordinate_float, _DEBUG_COLOR_TRACKABLE_RECT);
		}

		
		/// <summary>
		/// _dos the draw rect for viewport.
		/// </summary>
		private void _doDrawRectForViewport ()
		{
			
			Rect viewport_rect = _getViewportRect(_zPlaneCoordinate_float);
			DebugDraw.DrawRect (viewport_rect, _zPlaneCoordinate_float, _DEBUG_COLOR_VIEWPORT_RECT);
			
		}
		
		
		/// <summary>
		/// _dos the draw rect for viewport bounds.
		/// </summary>
		private void _doDrawRectForViewportBoundary ()
		{
			//_viewportBoundary_rect
			DebugDraw.DrawRect (_viewportBoundary_rect,  _zPlaneCoordinate_float, _DEBUG_COLOR_VIEWPORT_BOUNDS_RECT);
			
		}



		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ OTHER
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		/// <summary>
		/// _gets the rect for all trackable objects.
		/// 
		/// NOTE: 	POSSIBLE OPTIMIZATION --STORE THIS RECT AND ONLY 
		/// 		UPDATE UPON CHANGES TO _trackableObjectComponents_list
		/// 
		/// 
		/// NOTE:   WHEN _trackableObjectComponents_list.Count == 0, THE CAMERA
		/// 		WILL LOOK AT 0,0 BECAUSE OF ' new Rect();' and that is acceptable
		/// 
		/// 
		/// </summary>
		/// <returns>The rect for all trackable objects.</returns>
		private Rect _getRectForAllTrackableObjects ()
		{
			//
			Bounds allTrackableObjects_bounds;
			Rect allTrackableObjects_rect = new Rect();
			//
			if (_trackableObjectComponents_list.Count > 0) {
				allTrackableObjects_bounds = _trackableObjectComponents_list[0].getBounds();
				//
				foreach (TrackableObjectComponent trackableObjectComponent in _trackableObjectComponents_list) {
					allTrackableObjects_bounds.Encapsulate (trackableObjectComponent.getBounds());
				}
				allTrackableObjects_rect = RectHelper.ConvertBoundsToRect (allTrackableObjects_bounds, _zPlaneCoordinate_float);
			} 

			//
			return allTrackableObjects_rect;
		}
		


		/// <summary>
		/// _gets the viewport bounds rect.
		/// </summary>
		/// <returns>The viewport bounds rect.</returns>
		/// <param name="aZCoordinate_float">A Z coordinate_float.</param>
		private Rect _getViewportRect (float aZCoordinate_float) 
		{

			Vector3 p1_vector3 = camera.ViewportToWorldPoint(new Vector3(0,0,camera.transform.position.z));// use z or nearPlane?
			Vector3 p2_vector3 = camera.ViewportToWorldPoint(new Vector3(1,0,camera.transform.position.z));
			Vector3 p3_vector3 = camera.ViewportToWorldPoint(new Vector3(1,1,camera.transform.position.z));
			//
			float width_float   = (p2_vector3 - p1_vector3).magnitude;
			float height_float 	= (p3_vector3 - p2_vector3).magnitude;
			//
			Rect viewportBounds_rect = new Rect (p1_vector3.x - width_float, p1_vector3.y - height_float, width_float, height_float);
			//
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
			if (_zPosition_lerptarget != null) {
				_zPosition_lerptarget.targetValue = -_distanceDefault_float;
			}

		}


	}


}
