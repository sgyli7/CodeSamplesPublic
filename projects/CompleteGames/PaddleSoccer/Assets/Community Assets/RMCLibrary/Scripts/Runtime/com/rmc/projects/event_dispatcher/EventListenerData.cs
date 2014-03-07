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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.event_dispatcher
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Test event.
	/// </summary>
	public class EventListenerData
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		/// <summary>
		/// When the _event listener.
		/// </summary>
		private object _eventListener;
		public object eventListener 
		{ 
			get
			{
				return _eventListener;
			}
			set
			{
				_eventListener = value;
				
			}
		}
		
		/// <summary>
		/// When the _event name_string.
		/// </summary>
		private string _eventName_string;
		public string eventName 
		{ 
			get
			{
				return _eventName_string;
			}
			set
			{
				_eventName_string = value;
				
			}
		}
		
		
		
		/// <summary>
		/// When the _event delegate.
		/// </summary>
		private EventDelegate _eventDelegate;
		public EventDelegate eventDelegate 
		{ 
			get
			{
				return _eventDelegate;
			}
			set
			{
				_eventDelegate = value;
				
			}
		}
		
		private EventDispatcherAddMode _eventListeningMode;
		public EventDispatcherAddMode eventListeningMode 
		{ 
			get
			{
				return _eventListeningMode;
			}
			set
			{
				_eventListeningMode = value;
				
			}
		}
		
		
		
		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Destructor
		//--------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.EventListenerData"/> class.
		/// </summary>
		/// <param name="aEventListener">A event listener.</param>
		/// <param name="aEventName_string">A event name_string.</param>
		/// <param name="aEventDelegate">A event delegate.</param>
		/// <param name="aEventListeningMode">A event listening mode.</param>
		public EventListenerData (object aEventListener, string aEventName_string, EventDelegate aEventDelegate, EventDispatcherAddMode aEventListeningMode )
		{
			_eventListener 		= aEventListener;
			_eventName_string 	= aEventName_string;
			_eventDelegate		= aEventDelegate;
			_eventListeningMode	= aEventListeningMode;
			
			
			
		}
		
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.event_dispatcher.EventListenerData"/> is reclaimed by garbage collection.
		/// </summary>
		~EventListenerData ( )
		{
			//Debug.Log ("EventListenerData.deconstructor()");
			
		}
		
		//--------------------------------------
		//  Methods
		//--------------------------------------

		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		

	}
}

