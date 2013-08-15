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
//  Class
//--------------------------------------
public class BallCollisionDetectionComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//NOTE: RIGID BODY IS THE *MAIN* PHYSICS CLASS
		//http://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.html
		

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
	//		(This is a loose term for -- handling incoming messaging)
	//
	//--------------------------------------
	/// <summary>
	/// Raises the collision enter event.
	/// 
	/// 	NOTE: The 'Ray' drawn is shown in SceneView VERY fast (pause to see it)
	///
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	void OnCollisionEnter (Collision collision ) 
	{
		
		//1. SOME THINGS WE CAN DO WITH COLLISION
		
		
		//2. CHECK THE OBJECT IN THE COLLISION
		if (collision.gameObject.name != "WoodFloorCube") {
			
			//3. CHECK ALL THE 3D POINTS OF CONTACT BETWEEN THE OBJECTS
			//Debug.Log (">>OnCollisionEnter(): " + collision.contacts);
			
			foreach (ContactPoint contactPoint in collision.contacts) {
				//Debug.Log ("	contactPoint: " + contactPoint.point);
				
				//4. DRAW A (DEBUG-ONLY) LINE TO HELP US 'SEE' THE COLLISION
				//Debug.DrawRay(contactPoint.point, contactPoint.normal, Color.white);
			}
			
		}

	}
	
	/// <summary>
	/// Raises the collision stay event.
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	void OnCollisionStay (Collision collision ) 
	{
		if (collision.gameObject.name != "WoodFloorCube") {
			//Debug.Log ("==OnCollisionStay(): " + collision.contacts);
		}
	}
	
	
	/// <summary>
	/// Raises the collision exit event.
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	void OnCollisionExit (Collision collision ) 
	{
		if (collision.gameObject.name != "WoodFloorCube") {
			//Debug.Log ("<<OnCollisionExit(): " + collision.contacts);
		}
	}
	
}

