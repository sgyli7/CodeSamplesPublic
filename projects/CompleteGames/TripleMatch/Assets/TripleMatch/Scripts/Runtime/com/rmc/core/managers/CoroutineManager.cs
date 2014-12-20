/**
* Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.core.support;
using System;
using System.Collections;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.core.managers
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
	/// <summary>
	/// Coroutine manager. Main purpose;
	/// 
	/// 	1. Allow non-monobehavior classes to call coroutines easily
	/// 	2. Allow monobehavior classes to call methods after a delay (with less boilerplate code)
	/// 	
	/// 
	/// </summary>
	public class CoroutineManager : SingletonMonobehavior<CoroutineManager> 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// 	GETTER / SETTER
		
		// 	PUBLIC
		
		// 	PUBLIC STATIC
		
		
		// 	PRIVATE
		
		// 	PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Creation
		//--------------------------------------	
		
		
		
		//--------------------------------------
		//  Unity Methods
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
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------


		/// <summary>
		/// Waits for seconds to call.
		/// </summary>
		/// <param name="callback">Callback.</param>
		/// <param name="delayBeforeCalling_float">Delay before calling_float.</param>
		public void WaitForSecondsToCall(Action callback_action, float delayBeforeCalling_float)
		{
			StartCoroutine (_WaitForSecondsToCall (callback_action, delayBeforeCalling_float));
		}

		/// <summary>
		/// _s the wait for seconds to call.
		/// </summary>
		/// <returns>The wait for seconds to call.</returns>
		/// <param name="callback">Callback.</param>
		/// <param name="delayBeforeCalling_float">Delay before calling_float.</param>
		private IEnumerator _WaitForSecondsToCall(Action callback_action, float delayBeforeCalling_float)
		{
			yield return new WaitForSeconds (delayBeforeCalling_float);
			callback_action();
		}
				
		
		// 	PUBLIC
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
