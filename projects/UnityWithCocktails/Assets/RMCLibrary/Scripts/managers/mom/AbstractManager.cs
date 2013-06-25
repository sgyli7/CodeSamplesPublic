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
	public class AbstractManager : ScriptableObject, IManager
	{
	
		
		//TRIED TO REMOVE 'ELEMENT 0', FAILED
		public string Name = "hello";
		
		public override string ToString ()
		{
			 return Name;
		}
		
		
		
		
		
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The _can receive update.
		/// </summary>
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
		public AbstractManager ( )
		{
			//Debug.Log ("AbstractManager.constructor()");
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~AbstractManager ( )
		{
			//Debug.Log ("AbstractManager.constructor()");
			
		}
		
		// PUBLIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		virtual public void onAddManager()
		{
			Debug.Log ("AbstractManager.onAddManager() - remove this soon");
			
		}
		
		virtual public void onReset(IManager iManager)
		{
			Debug.Log ("AbstractManager.onReset("+iManager+") - remove this soon");
			
		}
		
		virtual public void onUpdate()
		{
			//Debug.Log ("AbstractManager.onUpdate() - remove this soon");
			
		}
		
		virtual public void onRemoveManager()
		{
			Debug.Log ("AbstractManager.onRemoveManager() - remove this soon");
			
		}
		

		
		
	}
}

