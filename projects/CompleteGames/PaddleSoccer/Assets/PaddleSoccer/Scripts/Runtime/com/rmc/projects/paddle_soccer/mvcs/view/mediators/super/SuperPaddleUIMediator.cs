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
using strange.extensions.mediation.impl;
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using com.rmc.projects.paddle_soccer.mvcs.model.vo;
using com.rmc.projects.paddle_soccer.mvcs.model;
using com.rmc.projects.animation_monitor;
using com.rmc.projects.paddle_soccer.mvcs.view.ui.super;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.mediators
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
	public class SuperPaddleUIMediator : Mediator
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
		public IPaddleUI view 	{ get; set;}


		/// <summary>
		/// Gets or sets the sound play signal.
		/// </summary>
		/// <value>The sound play signal.</value>
		[Inject]
		public SoundPlaySignal soundPlaySignal { get; set;}
		
		/// <summary>
		/// MODEL: The main game data
		/// </summary>
		[Inject]
		public IGameModel iGameModel { get; set; } 
		
		
		/// <summary>
		/// Gets or sets the game state changed signal.
		/// </summary>
		/// <value>The game state changed signal.</value>
		[Inject]
		public GameStateChangedSignal gameStateChangedSignal {set; get;}


		// PUBLIC

		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC

		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			view.init();
			//Debug.Log ("test: " + view.animation.getUIAnimationCompleteSignal() );
			gameStateChangedSignal.AddListener (_onGameStateChangedSignal);
			


		}

		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			gameStateChangedSignal.RemoveListener (_onGameStateChangedSignal);
			

		}

		
		//	PUBLIC
		
		
		// PRIVATE



		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// When the game state changed signal.
		/// </summary>
		/// <param name="aGameState">A game state.</param>
		virtual protected void _onGameStateChangedSignal (GameState aGameState)
		{
			//OVERRIDE FOR USAGE
			
		}





		/// <summary>
		/// When the user interface animation complete signal.
		/// </summary>
		/// <param name="aUIAnimationMonitorEventVO">A user interface animation monitor event V.</param>
		virtual protected void _onUIAnimationCompleteSignal (AnimationMonitorEventVO aUIAnimationMonitorEventVO )
		{
			//OVERRIDE FOR USAGE

		}
	}
}

