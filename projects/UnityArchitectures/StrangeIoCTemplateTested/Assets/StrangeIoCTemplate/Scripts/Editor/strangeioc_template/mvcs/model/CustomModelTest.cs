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
using System.Collections.Generic;
using NUnit.Framework;
using com.rmc.projects.strangeioc_template.mvcs.controller.signals;


//--------------------------------------
//  Namespace
//--------------------------------------
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
	public class CustomModelTest
	{


		//--------------------------------------
		//  Setup
		//--------------------------------------

		//PROPERTIES TO REUSE
		private ICustomModel _iCustomModel;
		private List<string> _originalTestGameList;


		//CALLED BEFORE EVERY 'TEST' METHOD IN THIS FIXTURE
		[SetUp] 
		public void setUp()
		{
			//1. SETUP DEPENDENCIES
			_iCustomModel = new CustomModel();
			_iCustomModel.gameListUpdatedSignal = new GameListUpdatedSignal();

		}


		//CALLED AFTER EVERY 'TEST' METHOD IN THIS FIXTURE
		[TearDown] 
		public void tearDown()
		{
			_iCustomModel = null;
		}

		//--------------------------------------
		//  Tests
		//--------------------------------------
		
		[Test]
		public void testPropertyGameList_DefaultValue  ()
		{

			//SETUP

			//TEST
			Assert.AreEqual (null, _iCustomModel.gameList);

		}
		
		[Test]
		public void testPropertyGameList_SetNull  ()
		{
			
			//SETUP
			_iCustomModel.gameList = null;

			//TEST
			Assert.AreEqual (null, _iCustomModel.gameList);
			
		}




		[Test]
		public void testPropertyGameList_SetValid  ()
		{
					
			//SETTER
			_iCustomModel.gameList = _originalTestGameList;

			//TEST
			Assert.AreEqual (_originalTestGameList, _iCustomModel.gameList);
			
		}

		
		[Test]
		public void testPropertyGameList_DoClear ()
		{
			
			//SETTER
			_iCustomModel.gameList = _originalTestGameList;
			_iCustomModel.doClearAllData();
			
			//TEST
			Assert.AreEqual (null, _iCustomModel.gameList);
			
		}




		[Test]
		[MaxTime (100)] //NEEDED TO WAIT FOR HANDLER TO FIRE.
		//
		public void testPropertyGameList_SetValidDispatcher  ()
		{

			//LISTEN
			_iCustomModel.gameListUpdatedSignal.AddListener (onGameListUpdated);

			//SETUP
			_originalTestGameList = new List<string>();
			_originalTestGameList.Add ("String0");
			_originalTestGameList.Add ("String1");
			_originalTestGameList.Add ("String2");
			_originalTestGameList.Add ("String3");
			
			//SETTER
			_iCustomModel.gameList = _originalTestGameList;

			//NOW WAIT FOR EVENT HANDLER
			

			
		}



		//--------------------------------------
		//  Events
		//--------------------------------------
		public void onGameListUpdated  (List<string> aGameList)
		{
			
			//REMOVE
			_iCustomModel.gameListUpdatedSignal.RemoveListener (onGameListUpdated);

			//TEST
			Assert.AreEqual (_originalTestGameList, aGameList);
			
		}
		
		
	}
}
