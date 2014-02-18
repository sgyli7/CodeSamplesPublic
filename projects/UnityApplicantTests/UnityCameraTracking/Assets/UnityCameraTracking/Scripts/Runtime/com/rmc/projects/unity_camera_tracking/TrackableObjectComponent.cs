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
using com.rmc.utilities;
using com.unity3d.wiki.expose_properties;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.unity_camera_tracking
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// Object's Priority for Camera Tracking
	/// 
	/// NOTE: Order matters, the first declared is the default when script is reset
	/// 
	/// </summary>
	public enum TrackingPriority
	{
		High,
		Low,
		None
	}

	
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
		private TrackingPriority _trackingPriority;
		[ExposeProperty]
		public TrackingPriority trackingPriority {
			get{
				return _trackingPriority;
			}
			set{
				_trackingPriority = value;

				//
				_doRefreshProperties();

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
		/// The debug color
		/// </summary>
		private Color _debugColor;


		//--------------------------------------
		//  Methods
		//--------------------------------------	

		//	PUBLIC 

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () 
		{
			_doRefreshProperties();

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
		/// Determines if this item is fit for tracking. 
		/// </summary>
		/// <returns><c>true</c>, if trackable was ised, <c>false</c> otherwise.</returns>
		public bool isTrackable() 
		{

			return enabled && gameObject.activeInHierarchy && _trackingPriority != TrackingPriority.None;

		}

		/// <summary>
		/// The boundary including padding
		/// </summary>
		/// <returns>The bounds rect.</returns>
		/// <param name="aZCoordinate_float">A Z coordinate_float.</param>
		public Rect getBoundaryRect (float aZCoordinate_float) 
		{
			//
			return RectHelper.ConvertBoundsToRect(getBounds(), aZCoordinate_float);
		}

		/// <summary>
		/// The boundary including padding.
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
		/// <summary>
		/// Refresh properties.
		/// 
		/// NOTE: This allows for hot-swapping priority in the live via the inspector.
		/// 
		/// NOTE: This allows for hot-swapping the enabled checkbox on the GameObject or this script
		/// 
		/// </summary>
		/// <returns><c>true</c>, if refresh properties was _doed, <c>false</c> otherwise.</returns>
		private void _doRefreshProperties() 
		{
			//REFRESH COLOR
			_debugColor = Constants.GetDebugColorByPriority (_trackingPriority);

			//REFRESH LIST OF OBJECTS
			if (TrackingCameraComponent.instance) {
				TrackingCameraComponent.instance.updateTrackableObjectComponentByPriority (this);
			}

		}

		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the enable event.
		/// </summary>//
		void OnEnable ()
		{
			//REFRESH PRIORITY
			_doRefreshProperties();

		}

		/// <summary>
		/// Raises the disable event.
		/// </summary>//
		void OnDisable ()
		{

			//REFRESH PRIORITY
			_doRefreshProperties();
			
		}
		
	}
}
