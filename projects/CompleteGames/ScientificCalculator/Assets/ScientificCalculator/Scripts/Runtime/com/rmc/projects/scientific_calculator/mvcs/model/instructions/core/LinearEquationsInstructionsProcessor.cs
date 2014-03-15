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
namespace com.rmc.projects.scientific_calculator.mvcs.model.instructions.core
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
	public class LinearEquationsInstructionsProcessor : IInstructionsProcessor
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The i scientific calculator model.
		/// </summary>
		public IScientificCalculatorModel iScientificCalculatorModel;


		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------


		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="com.rmc.projects.scientific_calculator.mvcs.model.instructions.core.LinearEquationsInstructionsProcessor"/> class.
		/// </summary>
		/// <param name="aIScientificCalculatorModel">A I scientific calculator model.</param>
		public LinearEquationsInstructionsProcessor (IScientificCalculatorModel aIScientificCalculatorModel)
		{
			iScientificCalculatorModel 			= aIScientificCalculatorModel;
			
		}
		
		~LinearEquationsInstructionsProcessor()
		{
			
		}

		
		// PUBLIC
		/// <summary>
		/// Dos the enter instruction.
		/// </summary>
		/// <returns>The enter instruction.</returns>
		/// <param name="instruction">Instruction.</param>
		public float doEnterInstruction (Instruction instruction)
		{
			return 0;

		}
		
		/// <summary>
		/// Dos the enter process instruction stack.
		/// </summary>
		/// <returns>The enter process instruction stack.</returns>
		public float doEnterProcessInstructionStack ()
		{

			return 0;
		}

		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

