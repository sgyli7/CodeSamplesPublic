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
using com.rmc.exceptions;


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
		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.property_change_signal.vo.PropertyChangeSignalVO"/> class.
		/// </summary>
		/// <param name="aPropertyChangeType">A property change type.</param>
		public PropertyChangeSignalVO (PropertyChangeType aPropertyChangeType )
		{
			//THESE 2 TYPES REQUIRES 1 ARGUMENT, ALWAYS
			//Debug.Log("--PropertyChangeSignalVO.constructor ("+aPropertyChangeType+")");
			//
			switch (aPropertyChangeType) {
				
			case PropertyChangeType.CLEAR:
				_propertyChangeType = aPropertyChangeType;
				_value_object 		= null;
				break;
			case PropertyChangeType.REQUEST:
				_propertyChangeType = aPropertyChangeType;
				break;
			default:
				#pragma warning disable 0162
				//ANY OTHER VALUES ARE NOT ACCEPTABLE IN THIS CONTEXT
				throw new SwitchStatementException(propertyChangeType.ToString());
				break;
				#pragma warning restore 0162
				
			}
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.property_change_signal.vo.PropertyChangeSignalVO"/> class.
		/// </summary>
		/// <param name="aPropertyChangeType">A property change type.</param>
		/// <param name="aValue_object">A value_object.</param>
		public PropertyChangeSignalVO (PropertyChangeType aPropertyChangeType, object aValue_object )
		{

			//Debug.Log("--PropertyChangeSignalVO.constructor ("+aPropertyChangeType+","+aValue_object+")");
			//THESE 2 TYPES REQUIRE 2 ARGUMENTS, ALWAYS
			//
			switch (aPropertyChangeType) {
				
			case PropertyChangeType.UPDATE:
			case PropertyChangeType.UPDATED:
				_propertyChangeType = aPropertyChangeType;
				_value_object 		= aValue_object;
				break;
			default:
				#pragma warning disable 0162
				//ANY OTHER VALUES ARE NOT ACCEPTABLE IN THIS CONTEXT
				throw new SwitchStatementException(propertyChangeType.ToString());
				break;
				#pragma warning restore 0162
				
			}

		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="com.rmc.projects.property_change_signal.vo.PropertyChangeSignalVO"/> is reclaimed by garbage collection.
		/// </summary>
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



