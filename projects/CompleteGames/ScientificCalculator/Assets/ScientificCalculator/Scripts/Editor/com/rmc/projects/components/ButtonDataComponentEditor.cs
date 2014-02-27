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
using UnityEditor;
using System.Linq;
using com.rmc.projects.scientific_calculator.mvcs;
using System;
using com.unity3d.wiki.expose_properties;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.scientific_calculator.components
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
	[CustomEditor(typeof(ButtonDataComponent))]
	public class ButtonDataComponentEditor : EditorWithExposedProperties 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		/// <summary>
		/// Gets the button data component.
		/// </summary>
		/// <value>The button data component.</value>
		private ButtonDataComponent buttonDataComponent {
			get{
				return target as ButtonDataComponent;
			}
		}


		// PUBLIC
		/// <summary>
		/// The _key codes_array.
		/// </summary>
		private KeyCode[] _keyCodes_array = Constants.GetKeyCodeList();

		/// <summary>
		/// The _key code selected index_int.
		/// </summary>
		private int _keyCodeSelectedIndex_int = 0;




		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		// PUBLIC
		/// <summary>
		/// Raises the enable event.
		/// </summary>
		override public void OnEnable()
		{
			//SETUP PROPERTY FIELD-RELATED MEMBERS
			base.OnEnable();
		}

		/// <summary>
		/// Raises the inspector GU event.
		/// </summary>
		public override void OnInspectorGUI ()
		{

			if ( buttonDataComponent != null ){
			

				// Draw the default inspector
				//DrawDefaultInspector();

				// DRAW CUSTOM DROPDOWN FOR OPTIONS
				_keyCodeSelectedIndex_int = Array.IndexOf<KeyCode> (_keyCodes_array, buttonDataComponent.keyCode);

				//CONVERT OPTIONS TO STRINGS FOR DISPLAY
				string[] result = _keyCodes_array.Select(aKeyCode=>aKeyCode.ToString()).ToArray();
				_keyCodeSelectedIndex_int = EditorGUILayout.Popup(Constants.INSPECTOR_LABEL_KEY_CODE, _keyCodeSelectedIndex_int, result );
				//Debug.Log ("_choiceIndex: " + _keyCodeSelectedIndex_int);

				//DRAW PROPERTY FIELD-RELATED MEMBERS
				base.OnInspectorGUI();

				//INSPECTOR CHANGED? UPDATE THE OBJECT
				buttonDataComponent.keyCode = _keyCodes_array[_keyCodeSelectedIndex_int];
				buttonDataComponent.label =  Constants.GetButtonLabelByKeyCode (buttonDataComponent.keyCode);
				EditorUtility.SetDirty(target);

			}
		}


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

