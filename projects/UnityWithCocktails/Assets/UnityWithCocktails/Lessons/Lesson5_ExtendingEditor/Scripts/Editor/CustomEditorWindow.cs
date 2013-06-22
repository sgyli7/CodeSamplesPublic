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
using UnityEditor;
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class CustomEditorWindow : EditorWindow 
{
		

	//--------------------------------------
	//  Attributes
	//--------------------------------------
		

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// The _my custom_string.
	/// </summary>
	private string 	_myCustom_string 		= "Hello World";
	
	/// <summary>
	/// The _is group enabled_boolean.
	/// </summary>
	private bool 	_isGroupEnabled_boolean	= false;
	
	/// <summary>
	/// The _my custom_boolean.
	/// </summary>
	private bool 	_myCustom_boolean 		= true;
	
	/// <summary>
	/// The _my custom_float.
	/// </summary>
	private float 	_myCustom_float 		= 1.23f;
	
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
		
		
	}
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI()
	{
		
		//
		GUILayout.Label 	("Demo-Only Window");
		GUILayout.Box 		(GUIContent.none, GUIStyle.none);
		//
		GUILayout.Label 	("Base Settings", EditorStyles.boldLabel);
		//
		_myCustom_string 			= EditorGUILayout.TextField ("Text Field", _myCustom_string);
		_isGroupEnabled_boolean 	= EditorGUILayout.BeginToggleGroup ("Optional Settings", _isGroupEnabled_boolean);
		_myCustom_boolean 			= EditorGUILayout.Toggle ("Toggle", _myCustom_boolean);
		_myCustom_float 			= EditorGUILayout.Slider ("Slider", _myCustom_float, -3, 3);
		EditorGUILayout.EndToggleGroup ();
		
	}
	
}
