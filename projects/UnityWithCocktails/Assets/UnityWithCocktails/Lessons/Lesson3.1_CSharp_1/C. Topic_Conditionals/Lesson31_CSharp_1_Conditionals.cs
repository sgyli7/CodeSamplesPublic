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
using System;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson31_CSharp_1_Conditionals: MonoBehaviour 
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
	void Start () 
	{

		Debug.Log ("//	IF	///////////////////////");
		_doDemoOfIf();
		Debug.Log ("\n");
		Debug.Log ("//	SWITCH	///////////////////////");
		_doDemoOfSwitch();
		Debug.Log ("\n");
	
	
	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	//******************************************************
	//******************************************************
	//**	IF
	//******************************************************
	//******************************************************
	
	///<summary>
	///	DEMO: IF
	//
	///</summary>
	private void _doDemoOfIf () 
	{
		//	SET VALUE
		int totalBeersForBreakfast_int = 2;
		
		//	TEST VALUE WITH CONDITIONAL
		if (totalBeersForBreakfast_int == 0) {
			Debug.Log ("	If: Zero beers for breakfast is most healthy."); 
		} else if (totalBeersForBreakfast_int == 1) {
			Debug.Log ("	If: One beer for breakfast? You probably needed it. Ha.");
		} else if (totalBeersForBreakfast_int > 1 && totalBeersForBreakfast_int < 7 ) {
			Debug.Log ("	If: A few beers? Not bad.");
		} else {
			Debug.Log ("	If: "+totalBeersForBreakfast_int+" beers for breakfast is probably NOT healthy.");
		
		}
		
	}
	
	//******************************************************
	//******************************************************
	//**	SWITCH
	//******************************************************
	//******************************************************
	
	///<summary>
	///	DEMO: Switch
	//
	//		NOTE: Ideal for a list of SPECIFIC values and a catch-all DEFAULT value too
	//
	///</summary>
	private void _doDemoOfSwitch() 
	{
		//	SET VALUE
		int totalWinesWithDinner_int = 2;
		
		//	TEST VALUE WITH CONDITIONAL
		switch (totalWinesWithDinner_int) {
			case 0: 
				Debug.Log ("	Switch: Zero wines for dinner is most healthy."); 
				break;
			case 1: 
				Debug.Log ("	Switch: One wine for dinner is healthy too, right?"); 
				break;
			case 2: 
				Debug.Log ("	Switch: Two wines for dinner? How social of you!"); 
				break;
			default:
				Debug.Log ("	Switch: "+totalWinesWithDinner_int+" wines for dinner is probably NOT healthy.");
				break;
		}
		
		
	}
	
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events 
	//		(This is a loose term for -- handling incoming messaging)
	//
	//--------------------------------------

}
