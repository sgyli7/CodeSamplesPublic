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
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IScientificCalculatorModel iCalculatorModel { get; set; } 

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
			view.uiInputChangedSignal.AddListener (_onUIInputChangedSignal);
			crossPlatformChangedSignal.AddListener (_onCrossPlatformChangedSignal);
			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
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
		protected virtual void _onCrossPlatformChangedSignal (RuntimePlatform aRuntimePlatform)
		{
			//OVERRIDE FOR USEAGE

		}


		/// <summary>
		/// When the user interface input signal.
		/// </summary>
		/// <param name="aUIInputType">A user interface input type.</param>
		private void _onUIInputChangedSignal (UIInputVO aUIInputVO)
		{
			return;
			Debug.Log("_onUIInputChangedSignal");

			//SOUND ONLY
			if (aUIInputVO.uiInputEventType == UIInputEventType.DownEnter) {
				Debug.Log("_onUIInputChangedSignal");
				if (aUIInputVO.keyCode == KeyCode.KeypadEnter) {
					soundPlaySignal.Dispatch (new SoundPlayVO (SoundType.GAME_OVER_WIN));
				} else {
					soundPlaySignal.Dispatch (new SoundPlayVO (SoundType.BUTTON_CLICK));
				}

			} 


			//ACTION ONLY
			if (aUIInputVO.uiInputEventType == UIInputEventType.DownEnter) {
				Debug.Log("_onUIInputChangedSignal");
				if (aUIInputVO.keyCode == KeyCode.R) {

				} else {
					//
					gameResetSignal.Dispatch ();
				}
				
			} 
			
			
		}
	}
}

