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
using com.rmc.projects.strangeioc_template.mvcs.controller.commands;
using com.rmc.projects.strangeioc_template.mvcs.controller.signals;
using com.rmc.projects.strangeioc_template.mvcs.model;
using com.rmc.projects.strangeioc_template.mvcs.view;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using com.rmc.projects.strangeioc_template.mvcs.view.ui;
using com.rmc.projects.strangeioc_template.mvcs.service;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.strangeioc_template.mvcs
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
	public class StrangeIoCTemplateContext : MVCSContext
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
		public StrangeIoCTemplateContext () : base()
		{
		}
		
		public StrangeIoCTemplateContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
		{
			//Debug.Log ("StrangeIoCTemplateContext.constructor()");
		}
		
		~StrangeIoCTemplateContext()
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
			//	MODEL
			injectionBinder.Bind<ICustomModel>().To<CustomModel>().ToSingleton();

			//	VIEW
			mediationBinder.Bind<CustomViewUI>().To<CustomViewUIMediator>();

			//	CONTROLLER 1. (MAPPED COMMANDS) 
			commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();
			commandBinder.Bind<AllViewsInitializedSignal>().To<AllViewsInitializedCommand>().Once ();
			//
			commandBinder.Bind<CustomServiceLoadedSignal>().To<CustomServiceLoadedCommand>();
			commandBinder.Bind<ClearButtonClickSignal>().To<ClearButtonClickCommand>();
			commandBinder.Bind<LoadButtonClickSignal>().To<LoadButtonClickCommand>();



			//	CONTROLLER 2. (INJECTED SIGNALS)
			injectionBinder.Bind<GameListUpdatedSignal>().ToSingleton();

			//	SERVICE
			injectionBinder.Bind<IService>().To<CustomService>().ToSingleton();


			


		}
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}


