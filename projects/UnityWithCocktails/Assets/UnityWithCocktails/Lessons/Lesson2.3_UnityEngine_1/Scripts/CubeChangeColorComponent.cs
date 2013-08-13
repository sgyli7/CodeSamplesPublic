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
public class CubeChangeColorComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// The _cube rotation component.
	/// </summary>
	private CubeRotateComponent _cubeRotationComponent = null;
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//--------------------------------------
		//  Accessing Components/GameObjects
		//--------------------------------------	
			
		//PERMANENTLY STORE A COMPONENT REFERENCE
		_cubeRotationComponent = GetComponent<CubeRotateComponent>();
		
		//FIND A GAMEOBJECT REFERENCE
		//GameObject managersGameObject = GameObject.Find ("ManagersGameObject") ;
		//Debug.Log ("managersGameObject: " + managersGameObject);
		
	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		//USE THE COMPONENT REFERENCE
		float rotation_float = _cubeRotationComponent.currentRotationWeCareAbout;
		
		//Debug.Log (" rotation_float: " + rotation_float);
		
		
		//CHANGE COLOR DEPEDING ON 4 ANGLES OF ROTATION
		if (rotation_float >= 0 && rotation_float <= 90) {
			//
			renderer.material.color = Color.red;

		} else {
			//
			renderer.material.color = Color.green;
			
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
