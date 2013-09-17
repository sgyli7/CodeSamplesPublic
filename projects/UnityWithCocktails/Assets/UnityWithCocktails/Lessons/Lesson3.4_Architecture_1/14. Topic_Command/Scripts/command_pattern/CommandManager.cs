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
using System.Collections;
using System.Collections.Generic;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace command_pattern
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
	public class CommandManager 
	{
		

		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		private List<IUndoableCommand> _iUndoableCommands;
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public CommandManager ()
		{
			//
			//Debug.Log ("CommandManager.constructor()");
			
			_iUndoableCommands = new List<IUndoableCommand>(); 
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~CommandManager ( )
		{
			//Debug.Log ("CommandManager.deconstructor()");
			
		}
		
		
		
		// PUBLIC
	
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <returns>
		/// The command.
		/// </returns>
		/// <param name='aICommand'>
		/// A I command.
		/// </param>
		public void executeCommand (ICommand aICommand) 
		{
			aICommand.execute();
			
			if (aICommand is IUndoableCommand) {
				_iUndoableCommands.Add (aICommand as IUndoableCommand);
			}
			
		}
		
		
		/// <summary>
		/// Undo this instance.
		/// </summary>
		public void undo ()
		{
			if (_iUndoableCommands.Count > 0) {
				IUndoableCommand toBeRemoved_iundoablecommand = _iUndoableCommands[_iUndoableCommands.Count-1];
				toBeRemoved_iundoablecommand.undo();
				_iUndoableCommands.RemoveAt (_iUndoableCommands.Count-1);
			}
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
