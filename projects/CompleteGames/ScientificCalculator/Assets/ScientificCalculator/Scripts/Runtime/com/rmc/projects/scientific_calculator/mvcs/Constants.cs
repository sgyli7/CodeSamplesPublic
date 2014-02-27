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
using com.rmc.projects.scientific_calculator.mvcs.model;


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
		public const string MODE_TEXT_PREFIX      		= "Mode: ";
		public static string INSPECTOR_LABEL_KEY_CODE 	= "KeyCode";









		//TODO: REMOVE OLD
		//
		public const string PROMPT_ROUND_START      = "Round {0} -- Must Kill {1}";
		public const string PROMPT_GAME_END_WIN 	= "You Won The Game!";
		public const string PROMPT_GAME_END_LOSS	= "You Lost The Game!";
		//
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

			//
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
			case KeyCode.KeypadPeriod:
				buttonLabel_string = ".";
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
			case KeyCode.KeypadEnter:
				buttonLabel_string = "=";
				break;
			case KeyCode.Delete:
				buttonLabel_string = "Clr";
				break;



			case KeyCode.L:
				buttonLabel_string = "Log";
				break;
			case KeyCode.M:
				buttonLabel_string = "Mode";
				break;
			case KeyCode.R:
				buttonLabel_string = "R";
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException(aKeyCode);
				break;
				#pragma warning restore 0162
			}

			return buttonLabel_string;
		}

		/// <summary>
		/// Determines if is acceptable key code the specified keyCode.
		/// </summary>
		/// <returns><c>true</c> if is acceptable key code the specified keyCode; otherwise, <c>false</c>.</returns>
		/// <param name="keyCode">Key code.</param>
		public static bool IsAcceptableKeyCode (KeyCode aKeyCode)
		{
			bool isAcceptableKeyCode_boolean;

			switch (aKeyCode){
			case KeyCode.Alpha0:
			case KeyCode.Alpha1:
			case KeyCode.Alpha2:
			case KeyCode.Alpha3:
			case KeyCode.Alpha4:
			case KeyCode.Alpha5:
			case KeyCode.Alpha6:
			case KeyCode.Alpha7:
			case KeyCode.Alpha8:
			case KeyCode.Alpha9:
			case KeyCode.KeypadPeriod:
			case KeyCode.KeypadMultiply:
			case KeyCode.KeypadDivide:
			case KeyCode.KeypadPlus:
			case KeyCode.KeypadMinus:
			case KeyCode.KeypadEnter:
			case KeyCode.Delete:
			case KeyCode.R:
			case KeyCode.L:
			case KeyCode.M:
				isAcceptableKeyCode_boolean = true;
				break;
				//ALLOW INPUT
			default:
				//DON'T ALLOW INPUT
				isAcceptableKeyCode_boolean = false;
				break;
			}
			
			return isAcceptableKeyCode_boolean;
		}

		
		/// <summary>
		/// Gets the key code list.
		/// </summary>
		/// <returns>The key code list.</returns>
		public static KeyCode[] GetKeyCodeList ()
		{
			return new KeyCode[]
			{ 
				KeyCode.Alpha0,
				KeyCode.Alpha1,
				KeyCode.Alpha2,
				KeyCode.Alpha3,
				KeyCode.Alpha4,
				KeyCode.Alpha5,
				KeyCode.Alpha6,
				KeyCode.Alpha7,
				KeyCode.Alpha8,
				KeyCode.Alpha9,
				KeyCode.KeypadDivide,
				KeyCode.KeypadPlus,
				KeyCode.KeypadMinus,
				KeyCode.KeypadMultiply,
				KeyCode.KeypadPeriod,
				KeyCode.X,
				KeyCode.KeypadEnter,
				KeyCode.Delete,
				
				KeyCode.R,
				KeyCode.M,
				KeyCode.L
			};
		}
		
		/// <summary>
		/// Gets the mode text by calculator mode.
		/// </summary>
		/// <returns>The mode text by calculator mode.</returns>
		/// <param name="aCalculatorMode">A calculator mode.</param>
		public static string GetModeTextByCalculatorMode (CalculatorMode aCalculatorMode)
		{
			string modeText_string;

			switch (aCalculatorMode){
			case CalculatorMode.LinearEquations:
				modeText_string = "LIN";
				break;
			case CalculatorMode.Scientific:
				modeText_string = "SCI";
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException(aCalculatorMode.ToString());
				break;
				#pragma warning restore 0162
			}

			return modeText_string;
		}


		/// <summary>
		/// Gets the operand value by key code.
		/// </summary>
		/// <param name="keyCode">Key code.</param>
		public static int GetOperandValueByKeyCode (KeyCode aKeyCode)
		{


			//
			int buttonLabel_int;
			
			//
			switch (aKeyCode){
			case KeyCode.Alpha0:
				buttonLabel_int = 0;
				break;
			case KeyCode.Alpha1:
				buttonLabel_int = 1;
				break;
			case KeyCode.Alpha2:
				buttonLabel_int = 2;
				break;
			case KeyCode.Alpha3:
				buttonLabel_int = 3;
				break;
			case KeyCode.Alpha4:
				buttonLabel_int = 4;
				break;
			case KeyCode.Alpha5:
				buttonLabel_int = 5;
				break;
			case KeyCode.Alpha6:
				buttonLabel_int = 6;
				break;
			case KeyCode.Alpha7:
				buttonLabel_int = 7;
				break;
			case KeyCode.Alpha8:
				buttonLabel_int = 8;
				break;
			case KeyCode.Alpha9:
				buttonLabel_int = 9;
				break;
			default:
				#pragma warning disable 0162
				//WE ACCEPT 0-9 NUMBERS ONLY, SO...
				throw new SwitchStatementException(aKeyCode);
				break;
				#pragma warning restore 0162
			}
			
			return buttonLabel_int;
		}
	}
}

