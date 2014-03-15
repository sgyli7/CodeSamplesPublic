/**
* Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using System.Collections.Generic;
using System.Collections;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.managers
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
	public class PlatformManager : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _pipes_list.
		/// </summary>
		private List<GameObject> _platformsList_gameobject = new List<GameObject>();

		/// <summary>
		/// The minimum rotation angle_float.
		/// </summary>
		public float minimumRotationAngle_float = 10f;

		/// <summary>
		/// The maximum rotation angle_float.
		/// </summary>
		public float maximumRotationAngle_float = -10f;

		/// <summary>
		/// The _current Z rotation_float.
		/// </summary>
		private float _currentZRotation_float;


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public PlatformManager ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~PlatformManager ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
		
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		
		// PUBLIC
		
		public void addPlatform (GameObject gameObject) 
		{

			_platformsList_gameobject.Add (gameObject);


			//DISABLE ROTATIONS FOR THIS DEMO
			//doRandomizeAllPlatformsRotation();

		}
		
		public void removePlatform (GameObject gameObject) 
		{
			

		}
		
		public void doRandomizeAllPlatformsRotation ()
		{
		
			foreach (GameObject platform in _platformsList_gameobject) {
			
				_doRandomizePlatformRotation (platform);
			
			}
		
		}


		/// <summary>
		/// Dos the de list all platforms.
		/// </summary>
		public void doDeListAllPlatforms ()
		{
			//DON'T REMOVE THE GRAPHICS, JUST REMOVE FROM THE LIST
			_platformsList_gameobject = new List<GameObject>();
		}

		//PRIVATE

		/// <summary>
		/// _dos the randomize platform rotation.
		/// </summary>
		/// <param name="aGameObject">A game object.</param>
		private void _doRandomizePlatformRotation (GameObject aGameObject)
		{
		

			//STORE TEMP, because method uses current
			float nextZRotation_float = _doGetRandomZRotation();

			//USE IT
			_currentZRotation_float = nextZRotation_float;
			aGameObject.transform.rotation = Quaternion.AngleAxis(_currentZRotation_float, Vector3.forward);
		
		}


		/// <summary>
		/// _dos the get random Z rotation.
		/// </summary>
		/// <returns>The get random Z rotation.</returns>
		private float _doGetRandomZRotation ()
		{
			List<float> validRotationsList_float = new List<float>();
			validRotationsList_float.Add (-30);
			validRotationsList_float.Add (0);
			validRotationsList_float.Add (30);

			//DON'T REPEAT CURRENT ROTATION
			float nextRotationZ_float = _currentZRotation_float;
			while (nextRotationZ_float == _currentZRotation_float){
				nextRotationZ_float = validRotationsList_float[Random.Range (0, validRotationsList_float.Count)];
			} 
			
			return nextRotationZ_float;	
		}
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
