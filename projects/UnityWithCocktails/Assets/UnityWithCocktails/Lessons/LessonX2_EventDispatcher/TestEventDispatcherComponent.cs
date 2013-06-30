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
	
	public class TestEventDispatcherComponent : MonoBehaviour
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The event dispatcher.
		/// </summary>
		private EventDispatcher eventDispatcher;
	
		/// <summary>
		/// The on event delegate.
		/// </summary>
		private EventDelegate onEventDelegate;
		
		/// <summary>
		/// The test from other scope.
		/// </summary>
		private TestFromOtherScope testFromOtherScope;
	
		/// <summary>
		/// The test from other scope2.
		/// </summary>
		private TestFromOtherScope testFromOtherScope2;
		
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
			testFromOtherScope = new TestFromOtherScope("blah1");	//PASS SIMPLE STRING FOR DEBUGGING
		 	testFromOtherScope2 = new TestFromOtherScope("blah2");	//PASS SIMPLE STRING FOR DEBUGGING
		
			//TODO, PASS INSTANCE IN OF 'this'? why?
			eventDispatcher = new EventDispatcher ();
			eventDispatcher.addEventListener 			(TestEvent.TEST_EVENT_NAME, _onCustomEvent1);
			eventDispatcher.addEventListener 			(TestEvent.TEST_EVENT_NAME, _onCustomEvent2, EventDispatcherAddMode.SINGLE_SHOT);
		
			//TEST REMOVE ALL
			//eventDispatcher.removeAllEventListeners();
		
			//TEST HAS AND REMOVE
			//Debug.Log ("	hasEventListener(): " + 	eventDispatcher.hasEventListener 	(TestEvent.TEST_EVENT_NAME, _onCustomEvent1));
			//Debug.Log ("	removeEventListener(): " + 	eventDispatcher.removeEventListener (TestEvent.TEST_EVENT_NAME, _onCustomEvent1));
			//Debug.Log ("	hasEventListener(): " + 	eventDispatcher.hasEventListener 	(TestEvent.TEST_EVENT_NAME, _onCustomEvent1));
		
		
			
		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update ()
		{
			
			if (Input.GetMouseButtonDown(0)) {
				dispatchIt();
				testFromOtherScope.dispatchIt();
				testFromOtherScope2.dispatchIt();
			}
			
		}
		
		/// <summary>
		/// Dispatchs it.
		/// </summary>
		public void dispatchIt()
		{
			eventDispatcher.dispatchEvent (new TestEvent (TestEvent.TEST_EVENT_NAME));	
			
		}
	
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	
		/// <summary>
		/// _ons the custom event1.
		/// </summary>
		/// <param name='iEvent'>
		/// I event.
		/// </param>
		public void _onCustomEvent1 (IEvent iEvent) 
		{
			Debug.Log ("	1. _onCustomEvent1(): " + iEvent);
		}

	
		/// <summary>
		/// _ons the custom event2.
		/// </summary>
		/// <param name='iEvent'>
		/// I event.
		/// </param>
		public void _onCustomEvent2 (IEvent iEvent) 
		{
			Debug.Log ("	2. _onCustomEvent2(): " + iEvent);
		}
	
	
	}

	



