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
using com.rmc.projects.scientific_calculator.mvcs.controller.signals;
using UnityEngine;
using com.rmc.projects.scientific_calculator.mvcs.model.vo;
using com.rmc.exceptions;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.scientific_calculator.mvcs.model.instructions;
using com.rmc.projects.scientific_calculator.mvcs.model.instructions.core;


namespace com.rmc.projects.scientific_calculator.mvcs.model
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum CalculatorMode
	{
		Scientific,
		LinearEquations
	}

	public enum CalculatorState
	{
		AppendingOperands,
		NotAppendingOperands
	}


	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class ScientificCalculatorModel  : IScientificCalculatorModel
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER



		/// <summary>
		/// The _calculator mode.
		/// </summary>
		private CalculatorMode _calculatorMode;
		public CalculatorMode calculatorMode
		{ 
			get{
				return _calculatorMode;
			}
			set
			{
				_calculatorMode = value;
				calculatorModeChangedSignal.Dispatch (_calculatorMode);
				//
				if (_calculatorMode == CalculatorMode.Scientific) {
					_iInstructionsProcessor = new ScientificInstructionsProcessor(this);

				} else {
					_iInstructionsProcessor = new LinearEquationsInstructionsProcessor(this);

				}

				
			}
		}

		/// <summary>
		/// Gets or sets the calculator mode changed signal.
		/// </summary>
		/// <value>The calculator mode changed signal.</value>
		[Inject]
		public CalculatorModelChangedSignal calculatorModeChangedSignal { get; set;}


		/// <summary>
		/// The state of the _calculator.
		/// </summary>
		private CalculatorState _calculatorState;
		public CalculatorState calculatorState
		{ 
			get{
				return _calculatorState;
			}
			set
			{
				_calculatorState = value;
				
			}
		}
		

		/// <summary>
		/// The _display text_string.
		/// </summary>
		private string _displayText_string;
		public string displayText
		{ 
			get{
				return _displayText_string;
			}
			set
			{
				_displayText_string = value;
				displayTextChangedSignal.Dispatch (_displayText_string);
			}
		}

		/// <summary>
		/// Gets or sets the display text changed signal.
		/// </summary>
		/// <value>The display text changed signal.</value>
		[Inject]
		public DisplayTextChangedSignal displayTextChangedSignal { get; set;}


		/// <summary>
		/// The _display value_float.
		/// </summary>
		private float _displayValue_float;
		public float displayValue
		{ 
			get{
				return _displayValue_float;
			}
			set
			{
				_displayValue_float = value;
				if (!float.IsNaN (_displayValue_float)) {
					displayText = _displayValue_float.ToString();
				} else {
					displayText = "";
				}
			}
		}

		/// <summary>
		/// The __instructions stack.
		/// 
		/// NOTE: All private
		/// 
		/// </summary>
		private IInstructionsProcessor __iInstructionsProcessor;
		private IInstructionsProcessor _iInstructionsProcessor
		{ 
			get{
				return __iInstructionsProcessor;
			}
			set
			{
				//clear stack so we forget all history once you toggle mode
				doClearInstructionsStack();


				//add new processor
				__iInstructionsProcessor = value;

			}
		}


		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE


		/// <summary>
		/// The _instructions stack.
		/// </summary>
		private InstructionsStack _instructionsStack;

		// PRIVATE STATIC


		//--------------------------------------
		//  Methods
		//--------------------------------------

		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.scientific_calculator.mvcs.model.ScientificCalculatorModel"/> class.
		/// </summary>
		public ScientificCalculatorModel( )
		{
			//Debug.Log ("ScientificCalculatorModel.constructor()");
			calculatorModeChangedSignal = new CalculatorModelChangedSignal();
			displayTextChangedSignal	= new DisplayTextChangedSignal();
			
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.scientific_calculator.mvcs.model.ScientificCalculatorModel"/> is reclaimed by garbage collection.
		/// </summary>
		~ScientificCalculatorModel()
		{
			
		}


		/// <summary>
		/// Posts the construct.
		/// 
		/// 
		///  NOTE: **TIMING** THIS IS STEP 2 OF 3
		/// 
		/// 
		/// </summary>
		[PostConstruct]
		public void postConstruct ()
		{
			//Debug.Log ("POST CONST");
		}





		/// <summary>
		/// Dos the reset model.
		/// 
		/// 
		/// 
		///  NOTE: **TIMING** THIS IS STEP 3 OF 3
		/// 
		/// 
		/// </summary>
		public void doResetModel ()
		{

			//Debug.Log ("doResetModel()");
			displayText 	= "";
			calculatorMode 	= CalculatorMode.Scientific;
			calculatorState = CalculatorState.AppendingOperands;
		}

		/// <summary>
		/// Dos the clear instructions stack.
		/// </summary>
		public void doClearInstructionsStack ()
		{
			_instructionsStack = new InstructionsStack();
			displayText 	= "";
		}


		/// <summary>
		/// Dos the enter instruction.
		/// </summary>
		/// <param name="instruction">Instruction.</param>
		public void doEnterInstruction (Instruction aInstruction) {


			//HANDLE INSTRUCTIONS UNIQUELY DEPENDING ON CalculatorMode
			displayValue = _iInstructionsProcessor.doEnterInstruction(aInstruction);


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

