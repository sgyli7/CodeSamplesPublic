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
using System;
using System.Collections.Generic;

//--------------------------------------
//  Class
//--------------------------------------
/// <summary>
/// 
/// Game object extensions - This shows how ANY native (sealed or non-sealed!) or custom class can have 
/// 		methods 'added' from the outside. 
/// 
/// Its like 'extending' that class but without needing to extend it. Magical!
/// 
/// </summary>
public static class GameObjectExtensions 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	///<summary>
	///	This is a sample getter/setter property.
	///</summary>
		
	// PUBLIC
	///<summary>
	///	This is a sample public property.
	///</summary>
	
	// PUBLIC STATIC
	///<summary>
	///	This is a sample public static property.
	///</summary>
	
	// PRIVATE
	///<summary>
	///	This is a sample private property.
	///</summary>
	
	// PRIVATE STATIC
	///<summary>
	///	This is a sample private static property.
	///</summary>
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------	
	
	// PUBLIC
	
	// PUBLIC STATIC
	///<summary>
	///	Add new functionality: Get a particular CUSTOM gameObject we call "ManagersGameObject"
	///</summary>
	public static GameObject FindManagersGameObject (this GameObject gameObject) 
	{
		return GameObject.Find ("ManagersGameObject");
		
	}
	
	///<summary>
	///	Add new functionality: Get a particular component on the CUSTOM gameObject which "ManagersGameObject"
	///</summary>
	public static Component FindManagerComponent (this GameObject gameObject, string ManagerScriptName_string) 
	{
		//1. GET GAMEOBJECT (NOTE: DOESN'T SEEM THAT I CAN CALL THE METHOD ABOVE FROM WITHIN HERE)
		GameObject managersGameObject = GameObject.Find ("ManagersGameObject");
		
		//2. RETURN COMPONENT
		return managersGameObject.GetComponent (ManagerScriptName_string);
		
	}
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------

}

