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
using UnityEditor;
using com.unity3d.wiki.expose_properties;
using com.rmc.projects.unity_camera_tracking;

//--------------------------------------
//  Namespace
//--------------------------------------
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
	[CustomEditor( typeof( TrackableObjectComponent ) )]
	public class TrackableObjectComponentEditor : Editor 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		/// <summary>
		/// The tracking camera component.
		/// </summary>
		TrackableObjectComponent trackableObjectComponent;
		
		/// <summary>
		/// The property field_array.
		/// </summary>
		PropertyField[] propertyField_array;
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the enable event.
		/// </summary>
		public void OnEnable()
		{
			trackableObjectComponent = target as TrackableObjectComponent;
			propertyField_array = ExposeProperties.GetProperties( trackableObjectComponent );
		}
		
		/// <summary>
		/// Raises the inspector GU event.
		/// </summary>
		public override void OnInspectorGUI () 
		{
			
			if ( trackableObjectComponent == null ){
				return;
			}
			
			this.DrawDefaultInspector();
			
			ExposeProperties.Expose( propertyField_array );
			
		}
	}
}


