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
public class BlockRaycastComponent : MonoBehaviour 
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

	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		//	SETUP POSITION/DIRECTION/DISTANCE
		Vector3 rayOrigin_vector3 = transform.position;
		Vector3 rayDirection_vector3 = transform.TransformDirection (Vector3.down);
		float distanceToCheck_float = 2; //HIGHER # = MORE PROCESSING POWER NEEDED
		
		
		//	SHOW A 'DEBUG ONLY' LINE ABOUT OUR LOGIC
		Debug.DrawRay(rayOrigin_vector3, rayDirection_vector3, Color.white, distanceToCheck_float);
		
		
		//	SETUP RAY TO PASS INTO FUNCTION
		//	SETUP RAYCASTHIT TO 'RETURN' FROM THE FUNCTION
		Ray ray = new Ray (rayOrigin_vector3, rayDirection_vector3);
		RaycastHit raycastHit = new RaycastHit ();
		
		
		//	SHOOT A RAY 'DOWN' TO TEST DISTANCE FROM 'BLOCK' TO 'FLOOR'
		if (Physics.Raycast (ray, out raycastHit, distanceToCheck_float) ) {
			//Debug.Log ("raycastHit.distance: " + raycastHit.distance);
		}
		

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

	
}
