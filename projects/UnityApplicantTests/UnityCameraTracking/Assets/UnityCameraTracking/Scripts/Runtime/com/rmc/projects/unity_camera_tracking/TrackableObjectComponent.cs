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
		/// <summary>
		/// Object's Priority for Camera Tracking
		/// 
		/// NOTE: Order matters, the first declared is the default when script is reset
		/// 
		/// </summary>
		public enum Priority
		{
			High,
			Low,
			None
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

				switch (_priority) {
					case Priority.None:
						_debugColor = _DEBUG_COLOR_HIGH;
						break;
					case Priority.Low:
						_debugColor = _DEBUG_COLOR_HIGH;
						break;
					case Priority.High:
						_debugColor = _DEBUG_COLOR_HIGH;
						break;
				}

			}
		}
		
		
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//\ 
		//\ BONUS VALUES
		//\ 
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

		/// <summary>
		/// The _border padding_float.
		/// </summary>
		[SerializeField][HideInInspector]
		private float _borderPadding_float = 0.2f;
		[ExposeProperty]
		public float borderPadding {
			get{
				return _borderPadding_float;
			}
			set{
				_borderPadding_float = value;
			}
		}

		
		
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
		private Color _debugColor;

		/// <summary>
		/// The _ DEBU g_ COLO r_ HIG.
		/// </summary>
		private static Color _DEBUG_COLOR_HIGH = new Color (0, 0, 1);

		//--------------------------------------
		//  Methods
		//--------------------------------------	

		//	PUBLIC 
		/// <summary>
		/// Awake this instance.
		/// </summary>
		void Awake ()
		{
			//SET IF NOT SET
			Debug.Log (priority);

		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () 
		{
			priority = _priority;
			_camera = Camera.main;

		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			Rect bounds_rect = getBoundaryRect(_zPlaneCoordinate_float);
			DebugDraw.DrawRect (bounds_rect, _zPlaneCoordinate_float, _debugColor);
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
		public Rect getBoundaryRect (float aZCoordinate_float) 
		{
			//
			return RectHelper.ConvertBoundsToRect(getBounds(), aZCoordinate_float);
		}

		/// <summary>
		/// Gets the bounds, adjusted with padding.
		/// </summary>
		/// <returns>The bounds.</returns>
		public Bounds getBounds ()
		{
			//
			Bounds expanded_bounds = renderer.bounds;
			expanded_bounds.Expand (_borderPadding_float);
			//
			return expanded_bounds;
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
