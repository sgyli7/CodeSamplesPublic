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
using strange.extensions.mediation.impl;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.spider_strike.mvcs.view.ui
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
	public class EnemyUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The target_game object.
		/// </summary>
		public GameObject target_gameObject;
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//*************************************************
			//******* MIGRATE THIS LOGIC TO MEDIATOR **********
			//*************************************************
			//************* SO, USE PUBLIC METHODS HERE  ******
			//*************************************************
			if (!isAtAttackingDistance()) {

				doFaceTarget();
				doMoveToTarget();
			}
			//*************************************************
			//*************************************************
			//*************************************************



			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
		}
		
		// PUBLIC

		/// <summary>
		/// _ises at attacking distance.
		/// </summary>
		/// <returns><c>true</c>, if at attacking distance was _ised, <c>false</c> otherwise.</returns>
		public bool isAtAttackingDistance ()
		{
			return Vector3.Distance (transform.position, target_gameObject.transform.position) < 1;
		}
		
		/// <summary>
		/// _dos the face target.
		/// </summary>
		public void doFaceTarget ()
		{
			float rotationSpeed = 1.0f;
			
			transform.rotation = Quaternion.Slerp
				(
					transform.rotation,
					Quaternion.LookRotation(target_gameObject.transform.position - transform.position),
					rotationSpeed
				);
		}
		
		/// <summary>
		/// _dos the move to target.
		/// </summary>
		public void doMoveToTarget ()
		{
			float moveSpeed = 1.0f;
			
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			
		}

		
		// PUBLIC STATIC
		
		// PRIVATE

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------


	}
}

