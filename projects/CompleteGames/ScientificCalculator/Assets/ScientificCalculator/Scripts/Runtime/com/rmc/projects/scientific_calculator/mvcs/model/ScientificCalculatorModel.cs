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

				
			}
		}

		/// <summary>
		/// Gets or sets the calculator mode changed signal.
		/// </summary>
		/// <value>The calculator mode changed signal.</value>
		[Inject]
		public CalculatorModelChangedSignal calculatorModeChangedSignal { get; set;}



		/// <summary>
		/// The _calculator mode.
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



		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE

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
			displayText = "";
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

