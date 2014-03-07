/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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
namespace com.rmc.projects.paddle_soccer.mvcs.model.vo
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// User interface input event type.
	/// </summary>
	public enum UIInputEventType
	{
		DownEnter,
		DownStay,
		DownExit,
	}

	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class UIInputVO 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// When the key code.
		/// </summary>
		public KeyCode keyCode;

		/// <summary>
		/// When the type of the input event.
		/// </summary>
		public UIInputEventType uiInputEventType;
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.UIInputVO"/> class.
		/// </summary>
		/// <param name="aKeyCode">A key code.</param>
		/// <param name="aUIInputEventType">A user interface input event type.</param>
		public UIInputVO (KeyCode aKeyCode, UIInputEventType aUIInputEventType)
		{
			keyCode 			= aKeyCode;
			uiInputEventType 	= aUIInputEventType;
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.model.vo.UIInputVO"/> is reclaimed by garbage collection.
		/// </summary>
		~UIInputVO()
		{
			
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------
		// PUBLIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

