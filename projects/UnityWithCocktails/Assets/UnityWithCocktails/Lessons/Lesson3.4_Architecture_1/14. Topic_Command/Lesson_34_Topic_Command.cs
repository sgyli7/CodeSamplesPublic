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
using System.Collections;
using command_pattern;
using command_pattern_example;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson_34_Topic_Command: MonoBehaviour 
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
		
		/*
		 *  PATTERN:		Command
		 * 
		 *	DEFINITION:  	Encapsulate a request as an object, thereby letting you parameterize 
		 *					clients with different requests, queue or log requests, and support 
		 *					undoable operations. 
		 * 
		 * 
		 * 	REFERENCE: 		http://www.dofactory.com/Patterns/PatternCommand.aspx#_self1
		*/
		
		Debug.Log ("\n");
		Debug.Log ("//	COMMAND	///////////////////////");
		_doDemoOfPattern();

		
		

	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// _dos the demo of the pattern.
	/// </summary>
	private void _doDemoOfPattern ()
	{
		
		//CREATE A COMMAND MANAGER. IN A FULL PROJECT THIS COULD BE A SINGLETON 
		//	TO FACILITATE ACCESS FROM MORE SCOPES
		CommandManager commandManager = new CommandManager();
		
		// DO A FEW 'THINGS' AND KEEP THEM IN A LIST FOR AN OPTIONAL UNDO
		commandManager.executeCommand ( new SampleCommand());
		commandManager.executeCommand ( new SampleCommand());
		
		//CALL THE UNDO ON BOTH OF THE PREVIOUSLY EXECUTED COMMANDS
		commandManager.undo();
		commandManager.undo();
		
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
