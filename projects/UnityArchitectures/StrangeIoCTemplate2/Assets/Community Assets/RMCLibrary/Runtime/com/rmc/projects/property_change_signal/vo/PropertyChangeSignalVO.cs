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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.property_change_signal.vo
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	/// <summary>
	/// Property change type.
	/// 
	/// USAGES (M-MODEL, V-VIEW, C-CONTROLLER)
	/// 	
	/// 	REQUEST: V,C ASKS FOR VALUE FROM M
	/// 	CLEAR: 	V,C ASKS TO CLEAR THE VALUE FROM M
	/// 	UPDATE: V,C ASKS TO UPDATE AN EXISTING VALUE FROM M
	/// 	UPDATED: M DISPATCHES WHEN VALUE HAS CHANGED, TYPICALLY M, C LISTEN.
	/// 
	/// </summary>
	public enum PropertyChangeType
	{
		CLEAR, 
		UPDATE,
		REQUEST,
		UPDATED
	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class PropertyChangeSignalVO 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER

		/// <summary>
		/// The type of the _property change.
		/// </summary>
		private PropertyChangeType _propertyChangeType;
		public PropertyChangeType propertyChangeType { 
			get
			{
				return _propertyChangeType;
			}
			set
			{
				_propertyChangeType = value;
			}
		}


		/// <summary>
		/// The _new value_object.
		/// </summary>
		private object _value_object;
		public object value {
			get
			{
				return _value_object;
			}
			set
			{
				_value_object = value;
			}
		}


		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		public PropertyChangeSignalVO (PropertyChangeType aPropertyChangeType )
		{
			//THIS 1 REQUIRES 1 ARGUMENT, ALWAYS
			if (aPropertyChangeType == PropertyChangeType.CLEAR) {
				//
				//Debug.Log("--PropertyChangeSignalVO.constructor ("+aPropertyChangeType+")");
				_propertyChangeType = aPropertyChangeType;
				_value_object 		= null;
			}
			
		}

		public PropertyChangeSignalVO (PropertyChangeType aPropertyChangeType, object aValue_object )
		{

			//THESE 2 REQUIRE 2 ARGUMENTS, ALWAYS
			if (	aPropertyChangeType == PropertyChangeType.UPDATE ||
			    	aPropertyChangeType == PropertyChangeType.UPDATED	) {

				//
				//Debug.Log("--PropertyChangeSignalVO.constructor ("+aPropertyChangeType+","+aValue_object+")");
				_propertyChangeType = aPropertyChangeType;
				_value_object 		= aValue_object;
			}
			
		}

		~PropertyChangeSignalVO()
		{
			
		}
		
		// PUBLIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}



