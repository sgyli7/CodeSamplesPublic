/**
* Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
* code [at] RivelloMultimediaConsulting [dot] com                                                  
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
using System.Collections;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.berlinminijam
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
	public class EnemyPrefabWalkingComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// Gets or sets the spawner.
		/// </summary>
		/// <value>The spawner.</value>
		private GameObject _spawner_gameobject;
		public GameObject spawner 
		{
			get
			{
				return _spawner_gameobject;
			}
			set
			{
				_spawner_gameobject = value;
				
			}
		}
		
		private bool _isFacingRight_boolean;
		public bool isFacingRight 
		{
			get
			{
				return _isFacingRight_boolean;
			}
			set
			{
				_isFacingRight_boolean = value;
				//
				if (_isFacingRight_boolean) {
					_movement_vector3 = new Vector3 (0.03f, 0, 0); //MOVE RIGHT
					transform.localScale = new Vector3 (1, 1, 1);
				} else {
					_movement_vector3 = new Vector3 (-0.03f, 0, 0);
					transform.localScale = new Vector3 (-1, 1, 1);
				}
				
			}
		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Enemies the prefab walking component.
		/// </summary>
		/// <returns>The prefab walking component.</returns>
		private Vector3 _movement_vector3;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public EnemyPrefabWalkingComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~EnemyPrefabWalkingComponent ( )
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
			
			transform.Translate (_movement_vector3);
		}
		
		// PUBLIC
		/// <summary>
		/// Dos the change walking direction.
		/// </summary>
		public void doChangeWalkingDirection ()
		{
			Debug.Log ("--");
			Debug.Log ("was: " + _movement_vector3);
			isFacingRight = !isFacingRight;
			Debug.Log ("is: " + _movement_vector3);
		}
		
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