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
using System.Collections.Generic;
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson31_CSharp_1_Loops_And_More : MonoBehaviour 
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
		
		//*********************************************************************
		//
		//	UNITY WITH COCKTAILS THEME: COCKTAILS
		//
		//*********************************************************************
		
		Debug.Log ("//	WHILE LOOP	/////////////////");
		_doDemo_WhileLoop();
		Debug.Log ("//	DO WHILE LOOP	/////////////");
		_doDemo_DoWhileLoop();	
		Debug.Log ("//	FOR LOOP	/////////////////");
		_doDemo_ForLoop();
		Debug.Log ("//	FOR LOOP W/BREAK	/////////");
		_doDemo_ForLoopBreak();
		Debug.Log ("//	FOR LOOP W/CONTINUE	/////////");
		_doDemo_ForLoopContinue();
		Debug.Log ("//	FOR EACH LOOP		/////////");
		_doDemo_ForLoopEach();
		
		Debug.Log ("//	SWITCH STATEMENT	/////////");
		_doDemo_SwitchStatement();
	}
	
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	///<summary>
	///	DEMO
	///
	///	NOTE: http://www.tutorialspoint.com/csharp/csharp_while_loop.htm
	///
	///</summary>
	private void _doDemo_WhileLoop () 
	{
		//	DEFINE VARIABLES
        int countCurrent_int = 0;
		const int COUNT_MAX_INT = 3;

        //	RUN LOOP
        while (countCurrent_int < COUNT_MAX_INT) {
			
            Debug.Log("	VALUE: " +  countCurrent_int);
            countCurrent_int++;
        }
	
	
	}

	///<summary>
	///	DEMO
	///
	///	NOTE: http://www.tutorialspoint.com/csharp/csharp_do_while_loop.htm
	///
	///</summary>
	private void _doDemo_DoWhileLoop () 
	{
		//	DEFINE VARIABLES
        int countCurrent_int = 0;
		const int COUNT_MAX_INT = 3;

        //	RUN LOOP
		do {
			
            Debug.Log("	VALUE: " +  countCurrent_int);
            countCurrent_int++;
			
		} while (countCurrent_int < COUNT_MAX_INT);
			

	}
	
	
	///<summary>
	///	DEMO
	///
	///</summary>
	private void _doDemo_ForLoop () 
	{
		//	DEFINE VARIABLES
        int countCurrent_int = 0;
		const int COUNT_MAX_INT = 3;

        //	RUN LOOP
        for (countCurrent_int = 0; countCurrent_int < COUNT_MAX_INT; countCurrent_int++) {
			
            Debug.Log("	VALUE: " +  countCurrent_int);
        }
	
	}

	
	///<summary>
	///	DEMO
	///
	///</summary>
	private void _doDemo_ForLoopBreak () 
	{
		//	DEFINE VARIABLES
        int countCurrent_int = 0;
		const int COUNT_MAX_INT = 3;
		const int COUNT_AT_BREAK_INT = 1;

        //	RUN LOOP
        for (countCurrent_int = 0; countCurrent_int < COUNT_MAX_INT; countCurrent_int++) {
			
			//BREAK SKIPS ALL LINES BELOW AND ENDS THE LOOP FOREVER
			if (countCurrent_int == COUNT_AT_BREAK_INT) {
				break;	
			}
            Debug.Log("	VALUE: " +  countCurrent_int);
        }
	
	
	}
	
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemo_ForLoopContinue () 
	{
		//	DEFINE VARIABLES
        int countCurrent_int = 0;
		const int COUNT_MAX_INT = 3;
		const int COUNT_AT_CONTINUE_INT = 1;

        //	RUN LOOP
        for (countCurrent_int = 0; countCurrent_int < COUNT_MAX_INT; countCurrent_int++) {
			
			//CONTINUE SKIPS ALL LINES BELOW AND RESUMES THE TOP OF THE LOOP
			if (countCurrent_int == COUNT_AT_CONTINUE_INT) {
				continue;	
			}
            Debug.Log("	VALUE: " +  countCurrent_int);
        }
	
	
	}
	

	///<summary>
	///	DEMO
	///</summary>
	private void _doDemo_ForLoopEach () 
	{
		//	DEFINE VARIABLES
        string [] strings_array = new string[3];
		strings_array[0] = "white";
		strings_array[1] = "red";
		strings_array[2] = "blend";

        //	RUN LOOP
        foreach (string currentValue_string in strings_array) {
			
            Debug.Log("	VALUE: " +  currentValue_string);
        }
	
	
	}
	

	///<summary>
	///	DEMO
	///
	/// NOTE: http://www.tutorialspoint.com/csharp/switch_statement_in_csharp.htm
	///
	///</summary>
	private void _doDemo_SwitchStatement () 
	{
		//	DEFINE VARIABLES
        int countCurrent_int = 1;
		
		
		//	RUN THE SWITCH
		switch (countCurrent_int) {
			case 0:
				Debug.Log("	SWITCH IS ZERO");
				break;
			case 1:
				Debug.Log("	SWITCH IS ONE");
				break;
			default:
				Debug.Log("	SWITCH IS DEFAULT (NOT 0 OR 1)");
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
