using UnityEditor;
using UnityEngine;
using System.Collections;
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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.managers.mom
{
	
	enum ScriptableTableItemType
	{
		INVALID,
		SCRIPT_ONLY,
		SCRIPTABLE_UNUSED,
		SCRIPTABLE_USED
		
	}
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Test event.
	/// </summary>
	[System.Serializable]
	public class ScriptableTableItem
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		ScriptableObject  scriptableObject;
		SerializedProperty managers_serializedproperty;
		ScriptableTableItemType scriptableTableItemType;
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
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
		public ScriptableTableItem (ScriptableObject aScriptableObject, SerializedProperty aManagers_serializedproperty)
		{
			scriptableObject = aScriptableObject;
			managers_serializedproperty = aManagers_serializedproperty;
			
			
			
			IEnumerator iEnumerator =  managers_serializedproperty.GetEnumerator();
			
			bool isFound_boolean = false;
			IManager iManager;
			while (iEnumerator.MoveNext()) {
				
				iManager = ((iEnumerator.Current as SerializedProperty).objectReferenceValue as IManager);
				//
				if ( iManager == scriptableObject) {
					isFound_boolean = true;
					break;
				} else {
					
					Debug.Log ("iEnumerator.Current: " + iManager);
					int x = 10;
				}
			}
			
			Debug.Log ("is : " + scriptableObject.GetType() + " =? " +  typeof (BaseManager));
			if (scriptableObject.GetType() == typeof (BaseManager)) {
				scriptableTableItemType = ScriptableTableItemType.INVALID;

			} else {
				
				if (isFound_boolean) {
					scriptableTableItemType = ScriptableTableItemType.SCRIPTABLE_USED;
				} else {
					scriptableTableItemType = ScriptableTableItemType.SCRIPTABLE_UNUSED;
				}
			}
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		//~ScriptableTableItem ( )
		//{
			//Debug.Log ("ScriptableTableItem.deconstructor()");
			
		//}
		
		/// <summary>
		/// Dos the layout GU.
		/// </summary>
		public void doLayoutGUI ()
		{

			
			///
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.ObjectField (scriptableObject, typeof (ScriptableObject));
			switch (scriptableTableItemType) {
				case ScriptableTableItemType.INVALID:
					break;
				case ScriptableTableItemType.SCRIPT_ONLY:
					if (GUILayout.Button ("SCRIPT_ONLY")) {
					
					}
					break;
				case ScriptableTableItemType.SCRIPTABLE_USED:
					if (GUILayout.Button ("SCRIPTABLE_USED")) {
					
					}
					break;
				case ScriptableTableItemType.SCRIPTABLE_UNUSED:
					if (GUILayout.Button ("SCRIPTABLE_UNUSED")) {
					
					}
					break;
				
			}
			EditorGUILayout.EndHorizontal();
		}
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

