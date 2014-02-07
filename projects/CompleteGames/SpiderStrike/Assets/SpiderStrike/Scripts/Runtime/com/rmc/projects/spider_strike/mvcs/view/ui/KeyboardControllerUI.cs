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
using com.rmc.projects.spider_strike.mvcs.controller.signals;

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
	public class KeyboardControllerUI : SuperControllerUI, IControllerUI
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
		override protected void Start () 
		{
			
			base.Start();
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			//RESET
			if (Input.GetKeyDown (KeyCode.Return)) {
				_doPressButton (ButtonType.Reset);
			}
			
			//LEFT
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				_doPressButton (ButtonType.Left);
			}
			
			//RIGHT
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				_doPressButton (ButtonType.Right);
			}
			
			//FIRE
			if(Input.GetKeyDown (KeyCode.Space)) { 
				_doPressButton (ButtonType.Fire);
			}

		}
		
		
		// PUBLIC
		/// <summary>
		/// Init this instance.
		/// </summary>
		override public void init()
		{
			base.init();
			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
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

