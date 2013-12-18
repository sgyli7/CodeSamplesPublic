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
using strange.extensions.command.impl;
using com.rmc.projects.strangeioc_template2.mvcs.mvc.controller.signals;
using strange.extensions.command.api;


//--------------------------------------
//  Namespace
//--------------------------------------


namespace com.rmc.projects.strangeioc_template2.mvcs.mvc.controller.commands
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
	public class AllViewsInitializedCommand : Command
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		[Inject]
		public LoadButtonClickSignal loadButtonClickSignal{get;set;}

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
			Debug.Log ("AllViewsInitializedCommand.Execute()");

			//loadButtonClickSignal.Dispatch();

			
			injectionBinder.Bind<ICommand>().To (typeof (LoadButtonClickCommand));
			ICommand command = injectionBinder.GetInstance<ICommand>() as ICommand;
			injectionBinder.Unbind<ICommand>();
			command.data = null;
			command.Execute(); //LINE 98

			// COMPILER ERROR ON LINE 98
			// BinderException: Binder cannot fetch Bindings when the binder is in a conflicted state.
			//Conflicts: strange.extensions.command.api.ICommand
			//strange.framework.impl.Binder.GetBinding (System.Object key, System.Object name) 
			//(at Assets/Community Assets/StrangeIoC/scripts/strange/framework/impl/Binder.cs:101)

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

