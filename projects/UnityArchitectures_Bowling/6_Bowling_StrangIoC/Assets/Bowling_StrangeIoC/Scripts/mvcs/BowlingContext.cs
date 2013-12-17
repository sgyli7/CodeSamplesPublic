/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.bowling_strangeioc.mvc.controller.commands;
using com.rmc.projects.bowling_strangeioc.mvc.controller.signals;
using com.rmc.projects.bowling_strangeioc.mvc.model;
using com.rmc.projects.bowling_strangeioc.mvc.view;
using com.rmc.projects.bowling_strangeioc.mvc.view.ui;
using com.rmc.projects.bowling_strangeioc.mvcs.view.ui;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_strangeioc
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
	public class BowlingContext : MVCSContext
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
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		public BowlingContext () : base()
		{
		}
		
		public BowlingContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
		{
			//Debug.Log ("BowlingContext.constructor()");
		}
		
		~BowlingContext()
		{
			
		}
		
		//	PUBLIC
		
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
			injectionBinder.Bind<IGameStateModel>().To<GameStateModel>().ToSingleton();
			injectionBinder.Bind<IGameScoreModel>().To<GameScoreModel>().ToSingleton();



			/**
			 * VIEW
			 * 
			 * 
			**/
			mediationBinder.Bind<BowlingBallUI>().To<BowlingBallUIMediator>();
			mediationBinder.Bind<BowlingPinUI>().To<BowlingPinUIMediator>();
			mediationBinder.Bind<UserInputUI>().To<UserInputUIMediator>();
			mediationBinder.Bind<GUIUI>().To<GUIUIMediator>();


			/**
			 * CONTROLLER
			 * 
			 * 
			**/
			//	1. (MAPPED COMMANDS) 
			commandBinder.Bind<StartSignal>().To<StartCommand>(); //TODO add once()
			commandBinder.Bind<AllViewsInitializedSignal>().To<AllViewsInitializedCommand>();//TODO add once()

			//	2. (INJECTED SIGNALS - DIRECTLY OBSERVED)
			injectionBinder.Bind<BowlingBallDoMoveSignal>().ToSingleton();

			//	3. (PAIRS OF MAPPED/INJECTED SIGNALS)
			commandBinder.Bind<InputModeChangeSignal>().To<InputModeChangeCommand>();
			injectionBinder.Bind<InputModeChangedSignal>().ToSingleton(); 
			//
			commandBinder.Bind<BowlingBallStateChangeSignal>().To<BowlingBallStateChangeCommand>();
			injectionBinder.Bind<BowlingBallStateChangedSignal>().ToSingleton(); 
			//
			commandBinder.Bind<TotalPinsKnockedOverChangeSignal>().To<TotalPinsKnockedOverChangeCommand>();
			injectionBinder.Bind<TotalPinsKnockedOverChangedSignal>().ToSingleton();


			Debug.Log ("1.5 BowlingContext.mapBindings() ended, so all bindings 'exist'.");

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


