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
namespace com.rmc.projects.unity_car_racer
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
	public class AxleComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The _steering rotation_float.
		/// </summary>
		private float _steeringRotation_float;
		public float steeringRotation 
		{
			get{
				return _steeringRotation_float;
			}
			set{
				_steeringRotation_float = value;
			}
		}

		// PUBLIC
		/// <summary>
		/// The left wheel_gameobject.
		/// </summary>
		public GameObject leftWheel_gameobject;

		/// <summary>
		/// The right wheel_gameobject.
		/// </summary>
		public GameObject rightWheel_gameobject;

		
		// PUBLIC STATIC
		
		// PRIVATE


		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () {

			steeringRotation = 0;
			
		}
		
		// Update is called once per frame
		void Update () {
			leftWheel_gameobject.transform.localRotation = Quaternion.Euler ( new Vector3 (0, steeringRotation, 0));
			rightWheel_gameobject.transform.localRotation = Quaternion.Euler ( new Vector3 (0, steeringRotation, 0));
		}

		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

