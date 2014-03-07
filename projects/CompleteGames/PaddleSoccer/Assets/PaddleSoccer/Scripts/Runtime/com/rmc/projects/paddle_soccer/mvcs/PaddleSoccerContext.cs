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
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using com.rmc.projects.paddle_soccer.mvcs.controller.commands;
using com.rmc.projects.paddle_soccer.mvcs.view.ui;
using com.rmc.projects.paddle_soccer.mvcs.model;
using com.rmc.projects.paddle_soccer.mvcs.view.mediators;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs
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
	public class PaddleSoccerContext : MVCSContext
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
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.PaddleSoccerContext"/> class.
		/// </summary>
		public PaddleSoccerContext () : base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.paddle_soccer.mvcs.PaddleSoccerContext"/> class.
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="autoStartup">If set to <c>true</c> auto startup.</param>
		public PaddleSoccerContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
		{
			//Debug.Log ("PaddleSoccerContext.constructor()");
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.paddle_soccer.mvcs.PaddleSoccerContext"/> is reclaimed by garbage collection.
		/// </summary>
		~PaddleSoccerContext()
		{
			
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------

		// PUBLIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PROTECTED
		
		/// <summary>
		/// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
		/// </summary>
		protected override void addCoreComponents()
		{
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
		
		
		/// <summary>
		/// Override Start so that we can fire the StartSignal 
		/// </summary>
		override public IContext Start()
		{
			base.Start();
			StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
			startSignal.Dispatch();
			return this;
		}

		
		/// <summary>
		/// Maps the bindings.
		/// </summary>
		protected override void mapBindings()
		{
			/**
			 * MODEL
			 * 
			 * 
			**/
			injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();



			/**
			 * VIEW
			 * 
			 * 
			**/
			//
			mediationBinder.Bind<IntroUI>().To<IntroUIMediator>();
			//
			mediationBinder.Bind<PlayerPaddleUI>().To<PlayerPaddleUIMediator>();
			mediationBinder.Bind<CPUPaddleUI>().To<CPUPaddleUIMediator>();
			mediationBinder.Bind<SoccerBallUI>().To<SoccerBallUIMediator>();
			//
			mediationBinder.Bind<VirtualControllerUI>().To<VirtualControllerUIMediator>();
			mediationBinder.Bind<KeyboardControllerUI>().To<KeyboardControllerUIMediator>();
			//
			mediationBinder.Bind<GameManagerUI>().To<GameManagerUIMediator>();
			//
			mediationBinder.Bind<HUDUI>().To<HUDUIMediator>();
			mediationBinder.Bind<SoundManagerUI>().To<SoundManagerUIMediator>();
			//
			//DEBUGGING



			/**
			 * CONTROLLER
			 * 
			 * 
			**/
			//	1. (MAPPED COMMANDS) 
			commandBinder.Bind<StartSignal>().To<StartCommand>(); //TODO add once()
			commandBinder.Bind<AllViewsInitializedSignal>().To<AllViewsInitializedCommand>();//TODO add once()



			//	2. (INJECTED SIGNALS - DIRECTLY OBSERVED)
			injectionBinder.Bind<SoundPlaySignal>().ToSingleton();
			//
			injectionBinder.Bind<PlayerDoMoveSignal>().ToSingleton();

			//
			injectionBinder.Bind<PromptStartSignal>().ToSingleton();
			injectionBinder.Bind<PromptEndedSignal>().ToSingleton();
			//
			commandBinder.Bind<GameResetSignal>().To<GameResetCommand>();


			//	3. (PAIRS OF MAPPED/INJECTED SIGNALS)
			//
			commandBinder.Bind<RightPaddleScoreChangeSignal>().To<RightPaddleScoreChangeCommand>();
			injectionBinder.Bind<RightPaddleScoreChangedSignal>().ToSingleton(); 
			//
			commandBinder.Bind<LeftPaddleScoreChangeSignal>().To<LeftPaddleScoreChangeCommand>();
			injectionBinder.Bind<LeftPaddleScoreChangedSignal>().ToSingleton();
			//
			commandBinder.Bind<GameStateChangeSignal>().To<GameStateChangeCommand>();
			injectionBinder.Bind<GameStateChangedSignal>().ToSingleton();
			//
			commandBinder.Bind<CrossPlatformChangeSignal>().To<CrossPlatformChangeCommand>();
			injectionBinder.Bind<CrossPlatformChangedSignal>().ToSingleton();

			/**
			 * SERVICE
			 * 
			 * 
			**/

			//(None. This project doesn't load/send any files/data)


		}
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}


