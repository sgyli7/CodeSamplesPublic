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
using com.rmc.projects.scientific_calculator.mvcs.model.vo;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.scientific_calculator.components;
using com.rmc.exceptions;
using com.rmc.projects.scientific_calculator.mvcs.view.ui.core;
using com.rmc.projects.scientific_calculator.mvcs.view.signals;


namespace com.rmc.projects.scientific_calculator.mvcs.view.ui
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
	public class ScientificCalculatorUI : SuperControllerUI, IControllerUI
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		// PUBLIC
		/// <summary>
		/// Display of Input/Output
		/// </summary>
		public GameObject displayTextGO;


		/// <summary>
		/// Display of Mode Name
		/// </summary>
		public GameObject modeTextGO;
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The DisplayText UILabel
		/// </summary>
		private UILabel _displayText_uilabel;

		/// <summary>
		/// The mode UILabel
		/// </summary>
		private UILabel _modeText_uilabel;


		
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
			_displayText_uilabel = displayTextGO.GetComponentInChildren<UILabel>();
			_modeText_uilabel	 = modeTextGO.GetComponentInChildren<UILabel>();
			setDisplayText	("");
			setModeText 	("");
			
		}
		

		// PUBLIC
		/// <summary>
		/// Init this instance.
		/// </summary>
		override public void init()
		{
			base.init();

		}


		//
		public override void Update()
		{
			//
			base.Update();

		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
		}





		/// <summary>
		/// Sets the display text.
		/// </summary>
		/// <param name="aDisplayText_string">A display text_string.</param>
		public void setDisplayText (string aDisplayText_string)
		{
			_displayText_uilabel.text = aDisplayText_string;
			
		}

		/// <summary>
		/// Sets the mode text.
		/// </summary>
		/// <param name="aDisplayText_string">A display text_string.</param>
		public void setModeText (string aDisplayText_string)
		{
			_modeText_uilabel.text = aDisplayText_string;
			
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

