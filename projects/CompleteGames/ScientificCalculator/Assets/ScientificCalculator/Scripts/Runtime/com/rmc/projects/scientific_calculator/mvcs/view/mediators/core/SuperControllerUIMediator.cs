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
using com.rmc.projects.scientific_calculator.mvcs.controller.signals;
using strange.extensions.mediation.impl;
using com.rmc.projects.scientific_calculator.mvcs.view.ui;
using com.rmc.exceptions;
using com.rmc.projects.scientific_calculator.mvcs.model;



//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.scientific_calculator.mvcs.model.vo;
using com.rmc.projects.scientific_calculator.mvcs.view.ui.core;
using com.rmc.projects.scientific_calculator.mvcs.model.instructions;


namespace com.rmc.projects.scientific_calculator.mvcs.view.mediators.core
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
	public class SuperControllerUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		/*
		 * NOTE: According to my tests and
		 * 		http://kendlj.wordpress.com/2014/01/03/unit-testing-strangeioc-mediator/
		 * 
		 * 		We cannot do "mediationBinder.Bind<IControllerUI>().To<VirtualControllerUIMediator>();
		 * 
		 * 		So this is a workaround
		 * 
		 **/
		public IControllerUI view 	{ get; set;}


		/// <summary>
		/// Gets or sets the game reset signal.
		/// </summary>
		/// <value>The game reset signal.</value>
		[Inject]
		public GameResetSignal gameResetSignal 		{ get; set;}


		/// <summary>
		/// Gets or sets the calculator model change signal.
		/// </summary>
		/// <value>The calculator model change signal.</value>
		[Inject]
		public CalculatorModelChangeSignal calculatorModelChangeSignal 	{ get; set;}


		/// <summary>
		/// Gets or sets the cross platform changed signal.
		/// </summary>
		/// <value>The cross platform changed signal.</value>
		[Inject]
		public CrossPlatformChangedSignal crossPlatformChangedSignal {get;set;}


		/// <summary>
		/// Gets or sets the sound play signal.
		/// </summary>
		/// <value>The sound play signal.</value>
		[Inject]
		public SoundPlaySignal soundPlaySignal {get;set;}

		/// <summary>
		/// Gets or sets the enter instruction signal.
		/// </summary>
		/// <value>The enter instruction signal.</value>
		[Inject]
		public EnterInstructionSignal enterInstructionSignal {get;set;}

		
		/// <summary>
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IScientificCalculatorModel iScientificCalculatorModel { get; set; } 


		
		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		/// <summary>
		/// Spin amount per click
		/// </summary>
		private const float _TURRET_ROTATION_PER_CLICK = 3;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			view.init();
			//
			view.uiInputChangedSignal.AddListener (_onUIInputChangedSignal);
			view.uiTestSignal.AddListener (_onUITestSignal);
			crossPlatformChangedSignal.AddListener (_onCrossPlatformChangedSignal);

		}

		private void _onUITestSignal ()
		{
			Debug.Log ("med _onUITestSignal");

		}

		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			Debug.Log ("OnRemove");
			view.uiInputChangedSignal.RemoveListener (_onUIInputChangedSignal);
			crossPlatformChangedSignal.RemoveListener (_onCrossPlatformChangedSignal);
		}
		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{

		}
		
		
		//	PUBLIC
		/// <summary>
		/// Resets the game.
		/// 
		/// </summary>
		public void _doResetGame ()
		{
			gameResetSignal.Dispatch ();

		}
		

		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// When the cross platform changed signal fires.
		/// 
		/// NOTE: 	During startup we dispatch this signal based on
		/// 		Application.platform so obvservers can handle themselves.
		/// 
		/// </summary>
		/// <param name="aRuntimePlatform">A runtime platform.</param>
		protected virtual void _onCrossPlatformChangedSignal (RuntimePlatform aRuntimePlatform) {/*override as needed*/}


		/// <summary>
		/// When the user interface input signal.
		/// </summary>
		/// <param name="aUIInputType">A user interface input type.</param>
		private void _onUIInputChangedSignal (UIInputVO aUIInputVO)
		{

			//WE CARE ONLY ABOUT INPUT 'ENTER' (NOT 'EXIT' OR 'STAY')
			if (aUIInputVO.uiInputEventType == UIInputEventType.DownEnter) {

				//Debug.Log("MED.uichanged: " + aUIInputVO.keyCode + " , " + UIInputEventType.DownEnter);

				//1. SOUND ONLY
				if (aUIInputVO.keyCode == KeyCode.KeypadEnter) {
					soundPlaySignal.Dispatch (new SoundPlayVO (SoundType.GAME_OVER_WIN));
				} else {
					soundPlaySignal.Dispatch (new SoundPlayVO (SoundType.BUTTON_CLICK));
				}


				//2. ACTIONS ONLY
				switch (aUIInputVO.keyCode){

				//************************************
				//
				//	OPERANDS
				//
				//************************************
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
					enterInstructionSignal.Dispatch ( new OperandInstruction(aUIInputVO.keyCode));
					break;


				//************************************
				//
				//	OPERATOR
				//
				//************************************
				case KeyCode.KeypadMultiply:
				case KeyCode.KeypadDivide:
				case KeyCode.KeypadPlus:
				case KeyCode.KeypadMinus:
				case KeyCode.KeypadPeriod:
					enterInstructionSignal.Dispatch ( new DecimalOperatorInstruction 	(aUIInputVO.keyCode));
					break;
				case KeyCode.KeypadEnter:
					enterInstructionSignal.Dispatch ( new EnterOperatorInstruction 		(aUIInputVO.keyCode));
					break;
				case KeyCode.L:
					enterInstructionSignal.Dispatch ( new LogOperatorInstruction		(aUIInputVO.keyCode));
					break;
				case KeyCode.Delete:
					enterInstructionSignal.Dispatch ( new ClearOperatorInstruction		(aUIInputVO.keyCode));
					break;

				//************************************
				//
				//	SPECIAL
				//
				//************************************
				case KeyCode.R:
					gameResetSignal.Dispatch ();
					break;
				case KeyCode.M:
					//TOOGLE BASED ON CURRENT VALUE
					if (iScientificCalculatorModel.calculatorMode == CalculatorMode.LinearEquations) {
						calculatorModelChangeSignal.Dispatch (CalculatorMode.Scientific);
					} else {
						calculatorModelChangeSignal.Dispatch (CalculatorMode.LinearEquations);
					}
					break;
				default:
					//NOTHING
					break;
				}


			} 



				
			
			
		}
	}
}

