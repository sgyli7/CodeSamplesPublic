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
namespace com.rmc.projects.coins_and_platforms.components
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
	public class ScreenWrapComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The left bound.
		/// </summary>
		private GameObject _leftBound;
		
		/// <summary>
		/// The right bound.
		/// </summary>
		private GameObject _rightBound;

		/// <summary>
		/// Initializes a new instance of the
		/// </summary>
		private EnemyPrefabWalkingComponent _enemyPrefabWalkingComponent;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public ScreenWrapComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~ScreenWrapComponent ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{

			//GRAB BOUNDS
			_leftBound = GameObject.Find ("LeftBoundPrefab");
			_rightBound = GameObject.Find ("RightBoundPrefab");

			//STORE ENEMY DATA
			_enemyPrefabWalkingComponent = GetComponent<EnemyPrefabWalkingComponent>();


		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
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
		/// <summary>
		/// Raises the trigger event2 d event.
		/// </summary>
		/// <param name="aCollider2D">A collider2 d.</param>
		void OnTriggerEnter2D (Collider2D aCollider2D)
		{
			if (aCollider2D.gameObject == _leftBound) {
				//
				float newX_float = _rightBound.transform.position.x - _rightBound.renderer.bounds.size.x/2 + .5f;
				transform.position = new Vector3 (newX_float, transform.position.y, transform.position.z);

			} else if (aCollider2D.gameObject == _rightBound) {
				//
				float newX_float = _leftBound.transform.position.x + _leftBound.renderer.bounds.size.x/2 + renderer.bounds.size.x/2;
				transform.position = new Vector3 (newX_float, transform.position.y, transform.position.z);
			}
			
		}
	}
}