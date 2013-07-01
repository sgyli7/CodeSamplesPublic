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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using com.rmc.events;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.managers.mom
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Abstract manager.
	/// </summary>
	[System.Serializable]
	public class BaseManager : ScriptableObject, IManager
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The _can receive update.
		/// </summary>
		[SerializeField] 
		private bool _canReceiveUpdate = true;
		public bool canReceiveUpdate
		{
			set {
				_canReceiveUpdate = value;
			}
			get {
				
				return _canReceiveUpdate;	
			}
			
		}
		
		/// <summary>
		/// The _event dispatcher.
		/// </summary>
		private EventDispatcher _eventDispatcher;
		public EventDispatcher eventDispatcher
		{
			get {
				
				return _eventDispatcher;	
			}
			
		}
		
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	 Constructor
		///</summary>
		public BaseManager ( )
		{
			//Debug.Log ("AbstractManager.constructor()");
			_eventDispatcher = new EventDispatcher (this);
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~BaseManager ( )
		{
			//Debug.Log ("AbstractManager.constructor()");
			
			
		}
		
		// PUBLIC
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="com.rmc.managers.mom.AbstractManager"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="com.rmc.managers.mom.AbstractManager"/>.
		/// </returns>
		public override string ToString ()
		{
			 return GetType().FullName;
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the add manager.
		/// </summary>
		virtual public void onAddManager(){}
		
		/// <summary>
		/// Ons the reset.
		/// </summary>
		/// <param name='iManager'>
		/// I manager.
		/// </param>
		virtual public void onReset(IManager iManager){}
		
		/// <summary>
		/// Ons the update.
		/// </summary>
		virtual public void onUpdate(){}
		
		/// <summary>
		/// Ons the remove manager.
		/// </summary>
		virtual public void onRemoveManager(){}
		

		//--------------------------------------
		//  IEventDispatcher
		
		
		// FOLD THIS INTO ONE-LINE PER METHOD - WE CAN COPY/PASTE FROM HERE TO WHEREVER NEEDED
		
		//--------------------------------------
	    public bool addEventListener(string aEventName_string, EventDelegate aEventDelegate)
	    {
			return _eventDispatcher.addEventListener (aEventName_string, aEventDelegate);
		}
	  
		public bool addEventListener( EventDelegate aEventDelegate, string aEventName_string)
	    {
			return _eventDispatcher.addEventListener( aEventDelegate, aEventName_string);
		}
		
	    public bool addEventListener(string aEventName_string, EventDelegate aEventDelegate, EventDispatcherAddMode aEventDispatcherAddMode)
	    {
			return _eventDispatcher.addEventListener(aEventName_string, aEventDelegate, aEventDispatcherAddMode);
		}
		
	    public bool hasEventListener(string aEventName_string, EventDelegate aEventDelegate)
	    {
			return _eventDispatcher.hasEventListener(aEventName_string, aEventDelegate);
		}
		
		
	    public bool removeEventListener(string aEventName_string, EventDelegate aEventDelegate)
	    {
			return _eventDispatcher.removeEventListener(aEventName_string, aEventDelegate);
		}
		
	    public bool removeAllEventListeners()
	    {
			return _eventDispatcher.removeAllEventListeners();
		}
		
		
	    public bool dispatchEvent(IEvent aIEvent)
	    {
			return _eventDispatcher.dispatchEvent(aIEvent);
		}
		
	}
}

