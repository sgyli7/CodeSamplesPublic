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
using System;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using strange.extensions.injector.api;
using strange.extensions.injector.impl;
using com.rmc.projects.strangeioc_template.mvcs.controller.signals;



//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.strangeioc_template.mvcs.service;
using strange.extensions.command.api;
using com.rmc.projects.strangeioc_template.mvcs.controller.commands;
using strange.extensions.command.impl;


namespace com.rmc.projects.strangeioc_template.mvcs.model
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
	[TestFixture]
	public class CustomServiceTest
	{
		
		
		//--------------------------------------
		//  Setup
		//--------------------------------------
		
		//PROPERTIES TO REUSE
		private ICustomService _customService;
		private IInjectionBinder _injectionBinder;
		private ICommandBinder _commandBinder;
		
		
		//CALLED BEFORE EVERY 'TEST' METHOD IN THIS FIXTURE
		[SetUp] 
		public void setUp()
		{
			//1. BIND THE CLASS TO BE TESTED
			//   *AND* ANY INJECTIONS WITHIN THE CLASS TO BE TESTED
			_injectionBinder = new InjectionBinder ();
			_injectionBinder.Bind<IInjectionBinder>().ToValue(_injectionBinder);
			_injectionBinder.Bind<CustomServiceLoadedSignal>().ToSingleton();
			_injectionBinder.Bind<ICustomService>().To<CustomService>().ToSingleton();
			_injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();

			//2. OTHER BINDINGS NEEDED FOR COMMAND TO EXECUTE
			_injectionBinder.Bind<ICustomModel>().To<CustomModel>().ToSingleton();
			_injectionBinder.Bind<GameListUpdatedSignal>().ToSingleton();
			_commandBinder =  _injectionBinder.GetInstance<ICommandBinder>() as ICommandBinder;
			_commandBinder.Bind<CustomServiceLoadedSignal>().To<CustomServiceLoadedCommand>();
			
			//3. GET INSTANCE FROM INJECTOR
			_customService = _injectionBinder.GetInstance<ICustomService>() as ICustomService;
			Debug.Log ("_customService: " + _customService);


		}
		
		
		//CALLED AFTER EVERY 'TEST' METHOD IN THIS FIXTURE
		[TearDown] 
		public void tearDown()
		{
			_customService = null;
			_injectionBinder = null; //MUST I CALL .Unbind() before?
		}
		
		//--------------------------------------
		//  Tests
		//--------------------------------------
		
		[Test]
		[MaxTime (100)]
		public void testDoLoadGameList  ()
		{

			//LISTEN
			_customService.customServiceLoadedSignal.AddListener (onCustomServiceLoadedSignal);

			//SETUP
			_customService.doLoadGameList();
			
		}

		
		//--------------------------------------
		//  Events
		//--------------------------------------
		private void onCustomServiceLoadedSignal (List<string> aGameList)
		{

			//CLEANUP
			_customService.customServiceLoadedSignal.RemoveListener (onCustomServiceLoadedSignal);

			//TEST
			Assert.AreNotEqual (null, aGameList);

		}

		
		
	}
}
