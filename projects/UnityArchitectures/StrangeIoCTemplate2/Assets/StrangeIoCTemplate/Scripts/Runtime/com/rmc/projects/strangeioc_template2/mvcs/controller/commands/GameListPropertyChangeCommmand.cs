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
using com.rmc.projects.strangeioc_template2.mvcs.service;
using strange.extensions.command.impl;
using UnityEngine;
using com.rmc.projects.strangeioc_template2.mvcs.model;
using com.rmc.projects.strangeioc_template2.mvcs.controller.signals;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.property_change_signal.vo;
using com.rmc.exceptions;
using System.Collections.Generic;
using com.rmc.projects.property_change_signal.signal;


namespace com.rmc.projects.strangeioc_template2.mvcs.controller.commands
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
	public class GameListPropertyChangeCommmand : Command
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// MODEL: The main data for the app
		/// </summary>
		[Inject]
		public ICustomModel iCustomModel {get;set;}

		
		/// <summary>
		/// Gets or sets the property change signal V.
		/// </summary>
		/// <value>The property change signal V.</value>
		[Inject]
		public PropertyChangeSignalVO propertyChangeSignalVO {set;get;}


		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Execute
		///</summary>
		public override void Execute()
		{
			Debug.Log ("\t--GameListPropertyChangeCommmand.Execute("+propertyChangeSignalVO.propertyChangeType+")");

				
			switch (propertyChangeSignalVO.propertyChangeType) {

			case PropertyChangeType.CLEAR:
				//ASK TO CLEAR THE MODEL
				iCustomModel.doClear_GameList(); 
				break;
			case PropertyChangeType.UPDATE:
				//ASK TO UPDATE A VALUE IN THE MODEL
				iCustomModel.gameList = propertyChangeSignalVO.value as List<string>;
				break;
			case PropertyChangeType.UPDATED:
				//FOR THIS PROJECT, THE VIEW LISTENS DIRECTLY TO 'UPDATED'
				//OPTIONALLY, WE COULD ALSO DO SOMETHING HERE IF NEEDED
				break;
			case PropertyChangeType.REQUEST:
				//FORCE THE MODEL TO RE-SEND 'UPDATED' (WITH NO ACTUAL VALUE CHANGE)
				//		THIS HAS VERY COMMON USE CASES 
				//		(E.G. A TEMPORARY A DIALOG PROMPT THAT IS SPAWNED AT AN ARBITRARY POINT
				//		IN TIME AND MUST 'ASK' FOR EXISTING 'STALE' MODEL DATA TO POPULATE ITSELF)
				iCustomModel.doDispatchUpdated_GameList();
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException(propertyChangeSignalVO.propertyChangeType.ToString());
				break;
				#pragma warning restore 0162


			}


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

