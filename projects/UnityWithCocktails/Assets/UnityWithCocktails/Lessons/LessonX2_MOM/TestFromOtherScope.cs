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
	
	public class TestFromOtherScope : IEventListener, IEventDispatcher
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		private EventDispatcher eventDispatcher;
	
		private EventDelegate onEventDelegate;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		
		// PUBLIC
		/// <summary>
		/// Start this instance.
		/// </summary>
		public TestFromOtherScope ()
		{
		
			eventDispatcher = new EventDispatcher ();
		
			IEventListener target = this as IEventListener;
			//
		
			/*
			 * 
			 * 		NEXT: REMOVE 'IEventListener.HandleEven' AND USE _onCustomEvent, (pass as string? Function? not-delegate somehow--)
			 * 
			 * 
			 * */
		
			eventDispatcher.addEventListener 			(target, TestEvent.EVENT_NAME, _onCustomEvent1);
			eventDispatcher.addEventListener 			(target, TestEvent.EVENT_NAME, _onCustomEvent2);
			//Debug.Log ("	hasEventListener(): " + 	eventDispatcher.hasEventListener 	(target, TestEvent.EVENT_NAME, _onCustomEvent1));
			//Debug.Log ("	removeEventListener(): " + 	eventDispatcher.removeEventListener (target, TestEvent.EVENT_NAME, _onCustomEvent1));
			//Debug.Log ("	hasEventListener(): " + 	eventDispatcher.hasEventListener 	(target, TestEvent.EVENT_NAME, _onCustomEvent1));
			
			/*
				+ void dispatchEventListener(IEvent aIEvent)
				
				+ void addEventListener          (string aEventName, IEvent aIEvent, Delegate aDelegate)
				+ bool removeEventListener       (string aEventName, IEvent aIEvent, Delegate aDelegate)
				+ bool hasEventListener          (string aEventName, IEvent aIEvent, Delegate aDelegate)
				+ void removeAllEventListeners   (string aEventName, IEvent aIEvent)
				+ void removeAllEventListeners   (); //100% are removed
				
			*/
			//_callListenerDelegate (_onCustomEvent );
		
			
		}
		
		
				
		public void dispatchIt()
		{
			eventDispatcher.dispatchEvent (new TestEvent (TestEvent.EVENT_NAME));	
			
		}
	
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		public void _onCustomEvent1 (IEvent iEvent) 
		{
			Debug.Log ("	2. _onCustomEvent1(): " + iEvent);
		}
	
	
	
		public void _onCustomEvent2 (IEvent iEvent) 
		{
			Debug.Log ("	2. _onCustomEvent2(): " + iEvent);
		}
	
	
	}

	



