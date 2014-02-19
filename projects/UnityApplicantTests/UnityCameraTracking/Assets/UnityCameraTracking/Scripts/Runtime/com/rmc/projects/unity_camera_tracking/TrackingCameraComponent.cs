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
using com.rmc.utilities;
using System.Collections.Generic;
using com.rmc.projects.unity_camera_tracking;
using System.Linq;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.unity_camera_tracking
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum ZoomMode
	{
		ZoomingIn,
		ZoomingOut,
		None

	}

	public enum TrackingMode
	{
		CurrentlyTracking,
		CurrentlyNotTracking
	}
	
	
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
		/// The maximum z distance the camera can be to z=0
		/// </summary>
		[SerializeField][HideInInspector]
		private float _distanceMax_float = 15;
		[ExposeProperty]
		public float distanceMax {
			get{
				return _distanceMax_float;
			}
			set{

				_distanceMax_float = Mathf.Clamp (value, _distanceMin_float, Mathf.Infinity) ;

				//NOTE: min=max here because we are dealing with negative space.
				if (_zPosition_lerptarget != null) {
					_zPosition_lerptarget.minimum = -_distanceMax_float;
				}
			}
		}


		/// <summary>
		/// The minimum z distance the camera can be to z=0
		/// </summary>
		[SerializeField][HideInInspector]
		private float _distanceMin_float = 5;
		[ExposeProperty]
		public float distanceMin {
			get{
				return _distanceMin_float;
			}
			set{
				_distanceMin_float = Mathf.Clamp (value, 0, _distanceMax_float) ;

				//NOTE: max=min here because we are dealing with negative space.
				if (_zPosition_lerptarget != null) {
					_zPosition_lerptarget.maximum = -_distanceMin_float;
				}
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
				_distanceDefault_float = Mathf.Clamp (value, _distanceMin_float, _distanceMax_float) ;

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

		/// <summary>
		/// Optional border padding (for debug rendering & all detection)
		/// </summary>
		[SerializeField][HideInInspector]
		private float _borderPadding_float = 1f;
		[ExposeProperty]
		public float borderPadding {
			get{
				return _borderPadding_float;
			}
			set{
				_borderPadding_float = Mathf.Clamp (value, 0, Mathf.Infinity);
				_hasBordingPaddingChanged_boolean = true;
			}
		}

		

		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ OTHER VALUES
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		
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
		/// The _distance acceleration_float.
		/// </summary>
		private float _zPositionAcceleration_float = 1f;
		

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
		/// The _current camera tracking priority.
		/// 
		/// NOTE: !IMPORTANT!. This alone defines the target x,y for the camera
		/// 
		/// NOTE: It is TrackingPriority.Low unless all objects cannot fit,
		/// 	  Then it defaults to TrackingPriority.High
		/// 
		/// 
		/// </summary>
		private TrackingPriority _currentCameraTrackingPriority;

		/// <summary>
		/// The _current zoom mode.
		/// NOTE: Used to prevent jitter.
		/// </summary>
		private ZoomMode _currentZoomMode;

		/// <summary>
		/// The _last zoom mode.
		/// NOTE: Used to prevent jitter.
		/// </summary>
		private ZoomMode _lastZoomMode;


		/// <summary>
		/// The _tracking mode.
		/// NOTE: Used to prevent jitter.
		/// </summary>
		private TrackingMode _trackingMode;

		/// <summary>
		/// The _has bording padding changed_boolean.
		/// </summary>
		private bool _hasBordingPaddingChanged_boolean;

		//--------------------------------------
		//  Methods
		//--------------------------------------

		//	PUBLIC 

		/// <summary>
		/// Start this instance.
		/// </summary>
	 	void Start () 
		{

			//DEFAULT
			_currentCameraTrackingPriority = TrackingPriority.Low;

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
			_zPosition_lerptarget = new LerpTarget (transform.position.z, -_distanceDefault_float, -_distanceMax_float, -_distanceMin_float, _zPositionAcceleration_float);
		
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{



			//DRAW RECTS
			_doDrawRectForViewport();
			_doDrawRectForViewportBoundary();
			_doDrawOneRectForAllTrackableObjects(TrackingPriority.High);
			_doDrawOneRectForAllTrackableObjects(TrackingPriority.Low);
			_doDrawCenterPointCrosshairsForRectOfAllTrackableObjects(TrackingPriority.Low);
			_doDrawCenterPointCrosshairsForRectOfAllTrackableObjects(TrackingPriority.High);
			_doDrawLineBetweenCrosshairs (TrackingPriority.High, TrackingPriority.Low);


		}

		/// <summary>
		/// Update/corrections
		/// 
		/// NOTE: We 'correct' positioning here
		/// NOTE: I'm not positive this is better than using 'Update'. Experimenting...
		/// 
		/// </summary>
		void LateUpdate ()
		{
			//UPDATE POSITION
			_doTrackCameraForOneRectForAllTrackableObjects();

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



		}



		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ MOVEMENT
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		/// <summary>
		/// Dolly the Camera (Move in Z axis)
		/// </summary>
		private void _doDollyCamera ()
		{
			Rect viewport_rect 									= _getViewportRect(_zPlaneCoordinate_float);
			Rect highAndLowTrackableObjects_rect 				= _getRectForAllTrackableObjects(TrackingPriority.Low);
			bool areAllHighAndLowTrackableObjectsInView_boolean = RectHelper.IsRectWithinRect (viewport_rect, highAndLowTrackableObjects_rect);
			//
			Rect currentTarget_rect 							= _getRectForAllTrackableObjects(_currentCameraTrackingPriority);
			bool isCurrentTargetRectWithinBoundary_boolean 		= RectHelper.IsRectWithinRect (_viewportBoundary_rect, currentTarget_rect);



			//
			//********************************
			//1. IF WE CAN SEE LOW+HIGH THEN ALWAYS ZOOM IN MORE
			//********************************
			if (areAllHighAndLowTrackableObjectsInView_boolean) {
				_doUpdateZPositionTargetValue (isCurrentTargetRectWithinBoundary_boolean, areAllHighAndLowTrackableObjectsInView_boolean, 0.05f);
				if (_currentCameraTrackingPriority == TrackingPriority.High) {
					_currentCameraTrackingPriority = TrackingPriority.Low;
				}
			} else {
				 

				//********************************
				//2. IF WE CAN'T SEE LOW+HIGH AND CANNOT ZOOM OUT MORE, THEN CHANGE FOCUS
				//TO JUST THE HIGH PRIORITY OBJECTS
				//********************************
				if (_zPosition_lerptarget.targetValue == _zPosition_lerptarget.minimum) {
					if (_currentCameraTrackingPriority == TrackingPriority.Low) {
						_currentCameraTrackingPriority = TrackingPriority.High;
					}
				}
				_doUpdateZPositionTargetValue (isCurrentTargetRectWithinBoundary_boolean, areAllHighAndLowTrackableObjectsInView_boolean, -0.05f);

			}

			//UPDATE POSITION
			_zPosition_lerptarget.lerpCurrentToTarget (1);
			transform.position = new Vector3 (transform.position.x, transform.position.y, _zPosition_lerptarget.targetValue);


		}

		/// <summary>
		/// _dos the track camera for one rect for all trackable objects.
		/// </summary>
		private void _doTrackCameraForOneRectForAllTrackableObjects()
		{

			//
			Rect allTrackableObjects_rect 	= _getRectForAllTrackableObjects(_currentCameraTrackingPriority);

			//UPDATE TARGET
			_xPosition_lerptarget.targetValue = allTrackableObjects_rect.center.x; 
			_yPosition_lerptarget.targetValue = allTrackableObjects_rect.center.y; 
			DebugDraw.DrawCenterPointCross (allTrackableObjects_rect, _zPlaneCoordinate_float, Constants.DEBUG_COLOR_VIEWPORT_CENTERPOINT);

			//STORE IF ITS TRACKING
			if (Mathf.Abs (_xPosition_lerptarget.deltaCurrentToTargetValue) < 0.5f && 
			    Mathf.Abs (_yPosition_lerptarget.deltaCurrentToTargetValue) < 0.5f) {
				_trackingMode = TrackingMode.CurrentlyNotTracking;
			} else {
				_trackingMode = TrackingMode.CurrentlyTracking;
			}

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


		/// <summary>
		/// _dos the update Z position target value.
		/// </summary>
		/// <param name="aViewportResizeDelta_float">A viewport resize delta_float.</param>
		/// <param name="aLastViewportResizeDelta_float">A last viewport resize delta_float.</param>
		/// <param name="aChangeAmount_float">A change amount_float.</param>
		private void _doUpdateZPositionTargetValue (bool aIsCurrentTargetRectWithinBoundary_boolean, bool aAreAllHighAndLowTrackableObjectsInView_boolean,  float aChangeAmount_float)
		{

			if (aIsCurrentTargetRectWithinBoundary_boolean) {

				if (Mathf.Sign (aChangeAmount_float) < 0) {
					_currentZoomMode = ZoomMode.ZoomingOut;
				} else {
					_currentZoomMode = ZoomMode.ZoomingIn;
				}

				//********************************
				//TEST FLAGS TO PREVENT JITTER 
				//********************************
				if (_hasBordingPaddingChanged_boolean ||
				    _trackingMode == TrackingMode.CurrentlyTracking ||
				    _lastZoomMode == _currentZoomMode) {

					//if (aIsCurrentTargetRectWithinBoundary_boolean) {
						_zPosition_lerptarget.targetValue += aChangeAmount_float;
						_lastZoomMode = _currentZoomMode;
					//}
				}


				//RESET/UPDATE FLAGS
				_hasBordingPaddingChanged_boolean = false;
			}
		}


		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ DRAWING
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


		/// <summary>
		/// Draw one rect for all trackable objects.
		/// 
		/// NOTE: WE LOOP THROUGH OBJECTS OF INTEREST AND DRAW A RECT AROUND ALL
		/// 
		/// </summary>
		private void _doDrawOneRectForAllTrackableObjects (TrackingPriority aTrackingPriority)
		{

			DebugDraw.DrawRect (_getRectForAllTrackableObjects(aTrackingPriority), _zPlaneCoordinate_float, Constants.GetDebugColorByPriority (aTrackingPriority));
		}

		/// <summary>
		/// Draw center point crosshairs for rect of all trackable objects.
		/// </summary>
		private void _doDrawCenterPointCrosshairsForRectOfAllTrackableObjects (TrackingPriority aTrackingPriority)
		{
			DebugDraw.DrawCenterPointCrosshairsForRect (_getRectForAllTrackableObjects(aTrackingPriority), _zPlaneCoordinate_float, Constants.GetDebugColorByPriority (aTrackingPriority));
		}

		/// <summary>
		/// _dos the draw line between crosshairs.
		/// </summary>
		/// <param name="aTrackingPriority1">A tracking priority1.</param>
		/// <param name="aTrackingPriority2">A tracking priority2.</param>
		private void _doDrawLineBetweenCrosshairs (TrackingPriority aTrackingPriority1, TrackingPriority aTrackingPriority2)
		{
			DebugDraw.DrawLineBetweenCrosshairs (_getRectForAllTrackableObjects(aTrackingPriority1), _getRectForAllTrackableObjects(aTrackingPriority2), _zPlaneCoordinate_float, Constants.DEBUG_COLOR_VIEWPORT_CENTERPOINT);

		}
		
		/// <summary>
		/// Draw rect for viewport.
		/// </summary>
		private void _doDrawRectForViewport ()
		{
			
			Rect viewport_rect = _getViewportRect(_zPlaneCoordinate_float);
			DebugDraw.DrawRect (viewport_rect, _zPlaneCoordinate_float, Constants.DEBUG_COLOR_VIEWPORT);
			
		}
		
		
		/// <summary>
		/// Draw rect for viewport bounds.
		/// </summary>
		private void _doDrawRectForViewportBoundary ()
		{
			//_viewportBoundary_rect
			DebugDraw.DrawRect (_viewportBoundary_rect,  _zPlaneCoordinate_float, Constants.DEBUG_COLOR_VIEWPORT_BOUNDARY);
			
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
		private Rect _getRectForAllTrackableObjects (TrackingPriority aMinimumPriority)
		{
			//
			Bounds allTrackableObjects_bounds;
			Rect allTrackableObjects_rect = new Rect();

			//********************************
			//MAKE A FILTERED LIST (ASSUME PRIORITY = NONE BY DEFAULT)
			//********************************
			List<TrackableObjectComponent> _prioritizedTrackableObjectComponents_list  = _trackableObjectComponents_list ;

			switch (aMinimumPriority) {
			case TrackingPriority.Low:
				_prioritizedTrackableObjectComponents_list  =	(List<TrackableObjectComponent>)_trackableObjectComponents_list.Where (
					trackableObjectComponent => trackableObjectComponent.trackingPriority == TrackingPriority.Low || trackableObjectComponent.trackingPriority == TrackingPriority.High).ToList();
				break;
			case TrackingPriority.High:
					_prioritizedTrackableObjectComponents_list  =	(List<TrackableObjectComponent>)_trackableObjectComponents_list.Where (
						trackableObjectComponent => trackableObjectComponent.trackingPriority == aMinimumPriority).ToList();
				break;
			}

			//********************************
			//CREATE A BOUNDS THAT ENCAPSULATES ALL OBJECTS OF INTEREST
			//********************************
			if (_prioritizedTrackableObjectComponents_list.Count > 0) {

				//ENCAPSULATE NEEDS US TO START WITH A NON-'EMPTY' INSTANCE
				allTrackableObjects_bounds = _prioritizedTrackableObjectComponents_list[0].getBoundsWithProjection(camera);
				//
				foreach (TrackableObjectComponent trackableObjectComponent in _prioritizedTrackableObjectComponents_list) {

					allTrackableObjects_bounds.Encapsulate (trackableObjectComponent.getBoundsWithProjection(camera));
				}
				allTrackableObjects_rect = RectHelper.ConvertBoundsToRect (allTrackableObjects_bounds, _zPlaneCoordinate_float);
			} 

			//
			return RectHelper.Expand (allTrackableObjects_rect, _borderPadding_float );
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
			if (_zPosition_lerptarget != null) {
				_zPosition_lerptarget.targetValue = -_distanceDefault_float;
			}

		}


	}


}
