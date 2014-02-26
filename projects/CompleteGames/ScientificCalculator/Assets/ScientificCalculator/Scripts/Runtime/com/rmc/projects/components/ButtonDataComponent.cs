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

//--------------------------------------
//  Namespace
//--------------------------------------
using System;
using com.unity3d.wiki.expose_properties;
using com.rmc.projects.scientific_calculator.mvcs;


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
	
	[Serializable]
	public class ButtonDataComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC

		/// <summary>
		/// The key code.
		/// </summary>
		public KeyCode keyCode;


		/// <summary>
		/// The maximum z distance the camera can be to z=0
		/// </summary>
		[SerializeField][HideInInspector]
		private float _distanceMax_float = 15;
		[ExposeProperty]
		public float distanceMax {
			get{
				return _distanceMax_float;
			}
			set{
				
				_distanceMax_float = Mathf.Clamp (value, 0, Mathf.Infinity) ;
				//Debug.Log ("_distanceMax_float: " + _distanceMax_float);
				
			}
		}

		
		/// <summary>
		/// Start this instance.
		/// </summary>
		public string label;


		// PRIVATE
		/// <summary>
		/// The user interface label.
		/// </summary>
		private UILabel _uiLabel;



		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	

		// PUBLIC


		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{
			if (_uiLabel == null) {
				_uiLabel = GetComponentInChildren<UILabel>();
			}
		}

		public void OnGUI ()
		{
			if (_uiLabel == null) {
				_uiLabel = GetComponentInChildren<UILabel>();
			}

		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update ()
		{
			//TODO: MOVE THIS TO ONLY OCCUR IN A SETTER (IN BOTH EDITOR AND PLAY MODE!!!)
			_doUpdateLabelText();

		}

		/// <summary>
		/// Updates the label.
		/// </summary>
		private void _doUpdateLabelText ()
		{

			if (label != null) {
				_uiLabel.text = label;
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

