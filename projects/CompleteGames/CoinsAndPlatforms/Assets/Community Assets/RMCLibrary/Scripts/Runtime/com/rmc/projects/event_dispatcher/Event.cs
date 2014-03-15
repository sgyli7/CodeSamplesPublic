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
	public class Event : IEvent
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// When the _type_string.
		/// </summary>
		private string _type_string;
		string IEvent.type { 
			get
			{
				return _type_string;
			}
			set
			{
				_type_string = value;
				
			}
		}
		
		/// <summary>
		/// When the _target_object.
		/// </summary>
		private object _target_object;
		object IEvent.target { 
			get
			{
				return _target_object;
			}
			set
			{
				_target_object = value;
				
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
		/// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.Event"/> class.
		/// </summary>
		/// <param name="aType_str">A type_str.</param>
		public Event (string aType_str )
		{
			//
			_type_string = aType_str;
			
			
		}
		

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.event_dispatcher.Event"/> is reclaimed by garbage collection.
		/// </summary>
		~Event ( )
		{
			//Debug.Log ("Event.deconstructor()");
			
		}
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	

		// PUBLIC

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		

	}
}

