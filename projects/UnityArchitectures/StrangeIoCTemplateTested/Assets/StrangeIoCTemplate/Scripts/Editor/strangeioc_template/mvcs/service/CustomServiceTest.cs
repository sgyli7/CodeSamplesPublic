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
using NUnit.Framework;
using System.Collections.Generic;
using com.rmc.projects.strangeioc_template.mvcs.controller.signals;
using com.rmc.projects.strangeioc_template.mvcs.service;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.strangeioc_template.mvcs.service
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
		private ICustomService _iCustomService;


		//CALLED BEFORE EVERY 'TEST' METHOD IN THIS FIXTURE
		[SetUp] 
		public void setUp()
		{
			//1. SETUP DEPENDENCIES
			_iCustomService = new CustomService ();
			_iCustomService.customServiceLoadedSignal = new CustomServiceLoadedSignal();


		}
		
		
		//CALLED AFTER EVERY 'TEST' METHOD IN THIS FIXTURE
		[TearDown] 
		public void tearDown()
		{
			_iCustomService = null;
		}
		
		//--------------------------------------
		//  Tests
		//--------------------------------------
		
		[Test]
		[MaxTime (100)]
		public void testDoLoadGameList  ()
		{

			//LISTEN
			_iCustomService.customServiceLoadedSignal.AddListener (onCustomServiceLoadedSignal);

			//SETUP
			_iCustomService.doLoadGameList();
			
		}

		
		//--------------------------------------
		//  Events
		//--------------------------------------
		private void onCustomServiceLoadedSignal (List<string> aGameList)
		{

			//CLEANUP
			_iCustomService.customServiceLoadedSignal.RemoveListener (onCustomServiceLoadedSignal);

			//TEST
			Assert.AreNotEqual (null, aGameList);

		}

		
		
	}
}
