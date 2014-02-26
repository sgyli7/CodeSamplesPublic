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
using com.rmc.exceptions;


namespace com.rmc.projects.scientific_calculator.mvcs
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
	/// Store constant values (ex. text for display)
	/// 
	/// </summary>
	public class Constants
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		public static string INSPECTOR_LABEL_KEY_CODE 	= "KeyCode";



		//TODO: 
		//
		public const string PROMPT_ROUND_START      = "Round {0} -- Must Kill {1}";
		public const string PROMPT_GAME_END_WIN 	= "You Won The Game!";
		public const string PROMPT_GAME_END_LOSS	= "You Lost The Game!";
		//
		public const string HUD_CLICK_ANYWHERE      = "Tap/Click Anywhere To Continue\n\n\n<size=15>Left Arrow / Right Arrow, Space To Fire, Return To Reset</size>";
		public const string HUD_HEALTH      		= "Health: {0}";
		public const string HUD_SCORE      			= "Score: {0}";

			
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------

		// PUBLIC

		// PUBLIC STATIC
		
		/// <summary>
		/// Gets the button label by key code.
		/// </summary>
		/// <returns>The button label by key code.</returns>
		/// <param name="aKeyCode">A key code.</param>
		public static string GetButtonLabelByKeyCode (KeyCode aKeyCode)
		{
			string buttonLabel_string;


			//
			switch (aKeyCode){
			case KeyCode.Alpha0:
				buttonLabel_string = "0";
				break;
			case KeyCode.Alpha1:
				buttonLabel_string = "1";
				break;
			case KeyCode.Alpha2:
				buttonLabel_string = "2";
				break;
			case KeyCode.Alpha3:
				buttonLabel_string = "3";
				break;
			case KeyCode.Alpha4:
				buttonLabel_string = "4";
				break;
			case KeyCode.Alpha5:
				buttonLabel_string = "5";
				break;
			case KeyCode.Alpha6:
				buttonLabel_string = "6";
				break;
			case KeyCode.Alpha7:
				buttonLabel_string = "7";
				break;
			case KeyCode.Alpha8:
				buttonLabel_string = "8";
				break;
			case KeyCode.Alpha9:
				buttonLabel_string = "9";
				break;
			case KeyCode.Return:
				buttonLabel_string = "Enter";
				break;
			case KeyCode.Delete:
				buttonLabel_string = "Clear";
				break;
			case KeyCode.KeypadMultiply:
				buttonLabel_string = "*";
				break;
			case KeyCode.KeypadDivide:
				buttonLabel_string = "/";
				break;
			case KeyCode.KeypadPlus:
				buttonLabel_string = "+";
				break;
			case KeyCode.KeypadMinus:
				buttonLabel_string = "-";
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException(aKeyCode);
				break;
				#pragma warning restore 0162
			}

			return buttonLabel_string;
		}

		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------


	}
}

