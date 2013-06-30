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
	
	public class TestFromOtherScope
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
		/// The name_string.
		/// </summary>
		private string name_string;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		
		// PUBLIC
		/// <summary>
		/// Start this instance.
		/// </summary>
		public TestFromOtherScope (string aName_string)
		{
			name_string = aName_string;
		
			eventDispatcher = new EventDispatcher ();
			eventDispatcher.addEventListener 			(TestEvent.TEST_EVENT_NAME, _onCustomEvent1);
			eventDispatcher.addEventListener 			(TestEvent.TEST_EVENT_NAME, _onCustomEvent2);

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
			Debug.Log ("	3. "+name_string+"_onCustomEvent1(): " + iEvent);
		}
	
	
		/// <summary>
		/// _ons the custom event2.
		/// </summary>
		/// <param name='iEvent'>
		/// I event.
		/// </param>
		public void _onCustomEvent2 (IEvent iEvent) 
		{
			Debug.Log ("	4. "+name_string+"_onCustomEvent2(): " + iEvent);
		}
	
	
	}

	



