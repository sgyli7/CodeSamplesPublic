
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
 * 
 * 
 * NOTE: 	Document modified from the original;
 * 			http://wiki.unity3d.com/index.php?title=Expose_properties_in_inspector
 * 
 * 
 * 
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using System;

//--------------------------------------
//  Namespace
//--------------------------------------
using UnityEditor;
using System.Reflection;
using UnityEngine;


namespace com.unity3d.wiki.expose_properties
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class PropertyField
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		//--------------------------------------
		//  Properties
		//--------------------------------------

		public SerializedPropertyType Type
		{
			get
			{
				return m_Type;	
			}
		}
		
		public String Name
		{	
			get
			{
				return ObjectNames.NicifyVariableName( m_Info.Name );	
			}
		}


		public System.Object m_Instance;
		public PropertyInfo m_Info;
		public SerializedPropertyType m_Type;
		
		public MethodInfo m_Getter;
		public MethodInfo m_Setter;


		//--------------------------------------
		//  Methods
		//--------------------------------------		
		public PropertyField( System.Object instance, PropertyInfo info, SerializedPropertyType type )
		{	
			
			m_Instance = instance;
			m_Info = info;
			m_Type = type;
			
			m_Getter = m_Info.GetGetMethod();
			m_Setter = m_Info.GetSetMethod();
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		public System.Object GetValue() 
		{
			return m_Getter.Invoke( m_Instance, null );
		}

		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="value">Value.</param>
		public void SetValue( System.Object value )
		{
			m_Setter.Invoke( m_Instance, new System.Object[] { value } );
		}

		/// <summary>
		/// Gets the type of the property.
		/// </summary>
		/// <returns><c>true</c>, if property type was gotten, <c>false</c> otherwise.</returns>
		/// <param name="info">Info.</param>
		/// <param name="propertyType">Property type.</param>
		public static bool GetPropertyType( PropertyInfo info, out SerializedPropertyType propertyType )
		{
			
			propertyType = SerializedPropertyType.Generic;
			
			Type type = info.PropertyType;
			
			if ( type == typeof( int ) )
			{
				propertyType = SerializedPropertyType.Integer;
				return true;
			}
			
			if ( type == typeof( float ) )
			{
				propertyType = SerializedPropertyType.Float;
				return true;
			}
			
			if ( type == typeof( bool ) )
			{
				propertyType = SerializedPropertyType.Boolean;
				return true;
			}
			
			if ( type == typeof( string ) )
			{
				propertyType = SerializedPropertyType.String;
				return true;
			}	
			
			if ( type == typeof( Vector2 ) )
			{
				propertyType = SerializedPropertyType.Vector2;
				return true;
			}
			
			if ( type == typeof( Vector3 ) )
			{
				propertyType = SerializedPropertyType.Vector3;
				return true;
			}
			
			if ( type.IsEnum )
			{
				propertyType = SerializedPropertyType.Enum;
				return true;
			}

			//NEW
			if ( type == typeof (Rect) )
			{
				propertyType = SerializedPropertyType.Rect;
				return true;
			}

			
			return false;
			
		}
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

	

	

