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
using UnityEngine;
using System.Collections;
using com.rmc.events;

//--------------------------------------
//  Namespace
//--------------------------------------

	
	//--------------------------------------
	//  Class
	//--------------------------------------
	
	public class TestEventDispatcherComponent : MonoBehaviour, IEventListener 
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		private EventDispatcher eventDispatcher;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		
		// PUBLIC
			void Start () {
		
			eventDispatcher = new EventDispatcher ();
			eventDispatcher.AddListener (this as IEventListener, "com.rmc.events.TestEvent");
			eventDispatcher.TriggerEvent (new TestEvent ());
			
			/*
				+ void dispatchEventListener(IEvent aIEvent)
				
				+ void addEventListener               (string aEventName, IEvent aIEvent, Delegate aDelegate)
				+ bool removeEventListener         (string aEventName, IEvent aIEvent, Delegate aDelegate)
				+ bool hasEventListener               (string aEventName, IEvent aIEvent, Delegate aDelegate)
				+ void removeAllEventListeners   (string aEventName, IEvent aIEvent)
				+ void removeAllEventListeners   (); //100% are removed
				
			*/
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Handles the event.
		/// </summary>
		/// <returns>
		/// The event.
		/// </returns>
		/// <param name='iEvent'>
		/// If set to <c>true</c> i event.
		/// </param>
		bool IEventListener.HandleEvent (IEvent iEvent) 
		{
		
			Debug.Log ("iEvent: " + iEvent);
			return true;
		}
	
	}

	



