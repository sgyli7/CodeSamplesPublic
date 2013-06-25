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
using UnityEditor;
using com.rmc.managers.mom;

//--------------------------------------
//  Class
//--------------------------------------
public class MOMEditor : Editor 
{
		

	//--------------------------------------
	//  Attributes
	//--------------------------------------
		

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	//private SerializedObject _MOM;
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	// PUBLIC
	/// <summary>
	/// Initializes a new instance of the <see cref="MOMEditor"/> class.
	/// </summary>
	public MOMEditor ()
	{
		
		
	}
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	/// <summary>
	/// Raises the enable event.
	/// </summary>
	public void OnEnable()
	{
		//_MOM = new SerializedObject(target);
	}
	
	
	/// <summary>
	/// Raises the inspector GU event.
	/// </summary>
	/*
	override public void OnInspectorGUI () 
	{
		base.OnInspectorGUI();
		return;
		
		
		//USE DEFAULT ABOVE, LATER USE CUSTOM BELOW
		
		
		
		//REQUIRED: WHY?
		_MOM.Update();
		
		//USE BLUE HIGHLIGHT AS EDITING
		EditorGUIUtility.LookLikeInspector();
		
		//ADD AS EDITABLE - A PROPERTY
		SerializedProperty managersList = _MOM.FindProperty ("managersList");
		EditorGUILayout.PropertyField (managersList, true);
		
		//REQUIRED: WHY?
		_MOM.ApplyModifiedProperties();
		
		
		return;

		

		
		//MOVE ITEMS TO RIGHT A SMALL AMOUNT
		EditorGUI.indentLevel++;
		
		//ADD AS EDITABLE - A PROPERTY
		SerializedProperty myCustomString = _MOM.FindProperty ("myCustomString");
		
		if (myCustomString.stringValue == "") {
			EditorGUILayout.HelpBox ("This value must be not null", MessageType.Warning);
		} else {
			EditorGUILayout.HelpBox ("Thanks, this value is valid.", MessageType.Info);
		}
		EditorGUI.indentLevel++;
		
		EditorGUILayout.PropertyField (myCustomString, true);
		
		
		//ADD AS EDITABLE - A PROPERTY
		SerializedProperty myCustomObject = _MOM.FindProperty ("myCustomObject");
		EditorGUILayout.PropertyField (myCustomObject, false);
		
        if (myCustomObject.isExpanded) {
			foreach (SerializedProperty p in myCustomObject) {
				
				//DEMO - use sliders or not, you decide.
				if (p.name == "x") {
					GUILayoutOption[] guiLayoutOptions = new GUILayoutOption[2];
					guiLayoutOptions[0]= GUILayout.Height (100);
					guiLayoutOptions[1]= GUILayout.Width (200);
                	EditorGUILayout.Slider (p, 0, 100); //, g);
				} else {
					EditorGUILayout.PropertyField (p);
				}
					
			}

        }
		
		
		//SAVE CHANGES TO DISK (OPTIONAL)
        if (GUI.changed) {
        	EditorUtility.SetDirty(target);
		}
		
		//
		//GUILayout.BeginArea ( new Rect (0,0,300,300));
		if (GUILayout.Button ("Rest All?" )) {
			(target as MyCustomComponent).reset();
		}
		//GUILayout.EndArea();
		

    }
    */
}
