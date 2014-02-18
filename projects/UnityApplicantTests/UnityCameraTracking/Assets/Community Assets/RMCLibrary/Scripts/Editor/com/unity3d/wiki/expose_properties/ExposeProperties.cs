
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
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using com.unity3d.wiki.expose_properties;
using UnityEngine;
using System;

//--------------------------------------
//  Namespace
//--------------------------------------
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
	public static class ExposeProperties
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		//--------------------------------------
		//  Methods
		//--------------------------------------

		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <returns>The properties.</returns>
		/// <param name="obj">Object.</param>
		public static PropertyField[] GetProperties( System.Object obj )
		{
			
			List< PropertyField > fields = new List<PropertyField>();
			
			PropertyInfo[] infos = obj.GetType().GetProperties( BindingFlags.Public | BindingFlags.Instance );
			
			foreach ( PropertyInfo info in infos )
			{
				
				if ( ! (info.CanRead && info.CanWrite) )
					continue;
				
				object[] attributes = info.GetCustomAttributes( true );
				
				bool isExposed = false;
				
				foreach( object o in attributes )
				{
					if ( o.GetType() == typeof( ExposePropertyAttribute ) )
					{
						isExposed = true;
						break;
					}
				}
				
				if ( !isExposed )
					continue;
				
				SerializedPropertyType type = SerializedPropertyType.Integer;
				
				if( PropertyField.GetPropertyType( info, out type ) )
				{
					PropertyField field = new PropertyField( obj, info, type );
					fields.Add( field );
				}
				
			}
			
			return fields.ToArray();
			
		}


		/// <summary>
		/// Expose the specified properties.
		/// </summary>
		/// <param name="properties">Properties.</param>
		public static void Expose( PropertyField[] properties )
		{
			
			GUILayoutOption[] emptyOptions = new GUILayoutOption[0];
			
			EditorGUILayout.BeginVertical( emptyOptions );
			
			foreach ( PropertyField field in properties )
			{
				
				EditorGUILayout.BeginHorizontal( emptyOptions );
				
				switch ( field.Type )
				{
				case SerializedPropertyType.Integer:
					field.SetValue( EditorGUILayout.IntField( field.Name, (int)field.GetValue(), emptyOptions ) ); 
					break;
					
				case SerializedPropertyType.Float:
					field.SetValue( EditorGUILayout.FloatField( field.Name, (float)field.GetValue(), emptyOptions ) );
					break;
					
				case SerializedPropertyType.Boolean:
					field.SetValue( EditorGUILayout.Toggle( field.Name, (bool)field.GetValue(), emptyOptions ) );
					break;
					
				case SerializedPropertyType.String:
					field.SetValue( EditorGUILayout.TextField( field.Name, (String)field.GetValue(), emptyOptions ) );
					break;
					
				case SerializedPropertyType.Vector2:
					field.SetValue( EditorGUILayout.Vector2Field( field.Name, (Vector2)field.GetValue(), emptyOptions ) );
					break;
					
				case SerializedPropertyType.Vector3:
					field.SetValue( EditorGUILayout.Vector3Field( field.Name, (Vector3)field.GetValue(), emptyOptions ) );
					break;
					
				case SerializedPropertyType.Enum:
					field.SetValue(EditorGUILayout.EnumPopup(field.Name, (Enum)field.GetValue(), emptyOptions));
					break;
					
					//NEW
				case SerializedPropertyType.Rect:
					field.SetValue(EditorGUILayout.RectField(field.Name, (Rect)field.GetValue(), emptyOptions));
					break;
					
				default:
					
					break;
					
				}
				
				EditorGUILayout.EndHorizontal();
				
			}
			
			EditorGUILayout.EndVertical();
			
		}


		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}







