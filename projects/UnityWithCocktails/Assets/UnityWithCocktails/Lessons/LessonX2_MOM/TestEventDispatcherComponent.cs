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
	
	public class TestEventDispatcherComponent : MonoBehaviour, IEventListener, IEventDispatcher
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
		
	TestFromOtherScope testFromOtherScope;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		
		// PUBLIC
		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start () {
		
		
			//TEST FROM OTHER CLASS
			 testFromOtherScope = new TestFromOtherScope();
		
			//TEST FROM THIS CLASS (BELOW)...
		
		
			eventDispatcher = new EventDispatcher ();
		
			IEventListener target = this as IEventListener;

		
		
		/*
		 * 
		 * 
		 * 		NEXT
		 * 
		 * 			1) see if we can NOT pass in target, but instead determine it in the ED.cs class
		 * 			2) see if we can make both _onCustomEvent1 and _onCustomEvent2 fire properly. (Currently only first is called due to non-unique key issue in ED.cs)
		 * 			3) cleanup
		 * 			4) test on iphone (try in standalone project to be sure its not one of these other crazy classes causing issue
		 * 			5) post USAGE API (not internals in blog post) twitter and ask for feedback.
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 */
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
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
	
	
		void Update ()
		{
			
			if (Input.GetMouseButtonDown(0)) {
				Debug.Log ("downnnnn");	
				dispatchIt();
				testFromOtherScope.dispatchIt();
			}
			
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
		bool HandleEvent (IEvent iEvent) 
		{
			Debug.Log ("iEvent: " + iEvent);
			return true;
		}
	
	
		public void _onCustomEvent1 (IEvent iEvent) 
		{
			Debug.Log ("	1. _onCustomEvent1(): " + iEvent);
		}
	
	
	
		public void _onCustomEvent2 (IEvent iEvent) 
		{
			Debug.Log ("	1. _onCustomEvent2(): " + iEvent);
		}
	
	
	}

	



