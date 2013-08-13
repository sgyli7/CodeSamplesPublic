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
public class CubeRotateComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	///<summary>
	///	The rotational value of interest
	///</summary>
	private float _currentRotationWeCareAbout_float;
	public float currentRotationWeCareAbout { 
		get 
		{ 
			//OPTIONAL: CONTROLL ACCESS TO PRIVATE VALUE
			return _currentRotationWeCareAbout_float; 
		}
		set 
		{ 
			//OPTIONAL: CONTROLL ACCESS TO PRIVATE VALUE
			_currentRotationWeCareAbout_float = value; 
		}
	}
	
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
		//ROTATE THE OBJECT
		transform.Rotate (new Vector3 (.8f, 0, 0));
		
		//STORE THE VALUE OF INTEREST
		_currentRotationWeCareAbout_float = transform.rotation.eulerAngles.x;
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
