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

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.utilities;
using com.unity3d.wiki.expose_properties;


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
	public class TrackableObjectComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		public enum Priority
		{
			None,
			Low,
			High
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
		/// Object's Priority for Camera Tracking
		/// 
		/// NONE: 	Not Tracked
		/// LOW: 	Tracked
		/// HIGH: 	Tracked
		/// 
		/// If the camera cannot track all objects due to limitations, 
		/// it will emphasise tracking for HIGH objects.
		/// 
		/// 
		/// </summary>
		[SerializeField][HideInInspector]
		private Priority _priority;
		[ExposeProperty]
		public Priority priority {
			get{
				return _priority;
			}
			set{
				_priority = value;

				//on initial enable, the instance is not there yet. thats ok
				if (TrackingCameraComponent.instance) {
					TrackingCameraComponent.instance.updateTrackableObjectComponentByPriority (this);
				}
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
		/// The _z plane coordinate_float.
		/// 
		/// NOTE: all 2d projection calculations occur on this plane
		/// 
		/// </summary>
		private const float _zPlaneCoordinate_float = 0;

		/// <summary>
		/// The _camera.
		/// </summary>
		private Camera _camera;

		/// <summary>
		/// The _ DEBU g_ COLO.
		/// </summary>
		private static Color _DEBUG_COLOR = new Color (0, 0, 1);

		//--------------------------------------
		//  Methods
		//--------------------------------------	

		//	PUBLIC 

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () 
		{
			priority = Priority.High;
			_camera = Camera.main;

		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			Rect bounds_rect = getBoundsRect(_zPlaneCoordinate_float);
			DebugDraw.DrawRect (bounds_rect, _zPlaneCoordinate_float, _DEBUG_COLOR);
		}


		/// <summary>
		/// Ises the trackable.
		/// </summary>
		/// <returns><c>true</c>, if trackable was ised, <c>false</c> otherwise.</returns>
		public bool isTrackable() 
		{
			return enabled && gameObject.activeInHierarchy && _priority != Priority.None;

		}

		/// <summary>
		/// _gets the bounds rect.
		/// </summary>
		/// <returns>The bounds rect.</returns>
		/// <param name="aZCoordinate_float">A Z coordinate_float.</param>
		public Rect getBoundsRect (float aZCoordinate_float) 
		{
			return BoundsHelper.ConvertBoundsToRect(getBounds(), aZCoordinate_float);
		}

		/// <summary>
		/// Gets the bounds.
		/// </summary>
		/// <returns>The bounds.</returns>
		public Bounds getBounds ()
		{
			return renderer.bounds;
		}


		//	PRIVATE 

		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the enable event.
		/// </summary>//
		void OnEnable ()
		{
			//REFRESH PRIORITY
			priority = _priority;

		}

		/// <summary>
		/// Raises the disable event.
		/// </summary>//
		void OnDisable ()
		{

			//REFRESH PRIORITY
			priority = _priority;
			
		}
		
	}
}
