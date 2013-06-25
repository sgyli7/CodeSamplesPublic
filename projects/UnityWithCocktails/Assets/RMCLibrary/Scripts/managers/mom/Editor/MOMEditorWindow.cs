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
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using com.rmc.utilities;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.managers.mom
{
	//--------------------------------------
	//  Class
	//--------------------------------------
	[ExecuteInEditMode()]  
	public class MOMEditorWindow : EditorWindow 
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
		/// <summary>
		/// The mom_serialized object.
		/// </summary>
		private SerializedObject _mom_serializedObject;
		
		/// <summary>
		/// The _my custom_string.
		/// </summary>
		private Vector2 _scrollPosition_vector2;
		
		/// <summary>
		/// The _padding right_int.
		/// </summary>
		private int _bannerPaddingRight_int = 10;
		
		/// <summary>
		/// The is enabled_serializedproperty.
		/// </summary>
		private SerializedProperty _isEnabled_serializedproperty;
		
		/// <summary>
		/// The is visible in hierarchy_serializedproperty.
		/// </summary>
		private SerializedProperty _isVisibleInHierarchy_serializedproperty;
		
		/// <summary>
		/// The managers list_serializedproperty.
		/// </summary>
		private SerializedProperty _managersList_serializedproperty;
					
		
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
				
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			//CALLED DURING PLAY IF [ExecuteInEditMode()] DOES NOT EXIST (ABOVE THIS CLASS)
			//CALLED DURING PLAY OR EDIT IF [ExecuteInEditMode()] DOES EXIST (ABOVE THIS CLASS)
		}
		
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _gets the target references.
		/// </summary>
		private void _getTargetReferences ()
		{
			//
			_mom_serializedObject 						= new SerializedObject(MOM.Instance);
			//
			_isEnabled_serializedproperty 				= _mom_serializedObject.FindProperty ("isEnabled");
			_isVisibleInHierarchy_serializedproperty 	= _mom_serializedObject.FindProperty ("isVisibleInHierarchy");
			//
			_managersList_serializedproperty 			= _mom_serializedObject.FindProperty ("managersList");
			
		}
		
		private Texture2D tabIcon_texture2D 	= Resources.Load("MOMEditorWindowTabIcon") as Texture2D;
		private Texture2D bannerImage_texture2D = Resources.Load("MOMEditorWindowBannerImage") as Texture2D;
 
		
			
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the enable event.
		/// </summary>
		public void OnEnable()
		{
			//GRAB FRESH
			_getTargetReferences();
			//
			EditorWindowUtility.SetEditorWindowTabIcon (this, tabIcon_texture2D);
			
				
			
		}
	
		
		/// <summary>
		/// Raises the GU event.
		/// </summary>
		public void OnGUI()
		{
			
			//RARELY, THIS IS NULL
			if (_mom_serializedObject == null) {
				_getTargetReferences();
			}
			
			//LOAD CHANGES
			_mom_serializedObject.Update();
			
			
			GUI.enabled = true; //FOR THE TOP OF THE PAGE HERE...
			
				
			//
			EditorWindowUtility.DebugLogAllPropertiesForSerializedProperty(_mom_serializedObject);
			
			
			//STYLE INFO
			GUIStyle bold_guistyle 	= new GUIStyle();
			bold_guistyle.fontStyle = FontStyle.Bold;
			
			
			//TODO, MAKE IMAGE FILL THE 'BOX' (OR CHOOSE SOMETHING OTHER THAN 'BOX');
			//bannerImage_texture2D.width 	= 300;
			//bannerImage_texture2D.height 	= 50;
			bannerImage_texture2D.wrapMode = TextureWrapMode.Repeat;
			GUILayout.Box(bannerImage_texture2D,GUILayout.Width(position.width - _bannerPaddingRight_int),GUILayout.Height(40)); 
			//GUILayout.Label(bannerImage_texture2D,GUILayout.Width(position.width - 7),GUILayout.Height(50)); 
			
			
			//
			GUILayoutOption[] scrollViewMenu_options = new GUILayoutOption[1];
			scrollViewMenu_options[0] = GUILayout.MinWidth (position.width);
			//scrollViewMenu_options[1] = GUILayout.MaxWidth (position.width);
			_scrollPosition_vector2 = EditorGUILayout.BeginScrollView (_scrollPosition_vector2, scrollViewMenu_options);
			{
				
				//*****************************************************
				//*****************************************************
				//**	OVERVIEW
				//*****************************************************
				//*****************************************************
				EditorGUILayout.Separator();
				EditorGUILayout.LabelField ("Overview", bold_guistyle);
				
				EditorGUI.indentLevel++;
				EditorGUILayout.BeginVertical();
				{
					//
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel ("Enabled?");
					_isEnabled_serializedproperty.boolValue = EditorGUILayout.Toggle (_isEnabled_serializedproperty.boolValue);	
					EditorGUILayout.EndHorizontal();
					
					//TOGGLE FOR THE PAGE BELOW
					GUI.enabled = _isEnabled_serializedproperty.boolValue;
					
					//
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel ("Visible In Hierarchy?");
					_isVisibleInHierarchy_serializedproperty.boolValue = EditorGUILayout.Toggle (_isVisibleInHierarchy_serializedproperty.boolValue);	
					EditorGUILayout.EndHorizontal();
					
				}
				EditorGUILayout.EndVertical();
				EditorGUI.indentLevel--;

				
				//*****************************************************
				//*****************************************************
				//**	MANAGERS
				//*****************************************************
				//*****************************************************
				EditorGUILayout.Separator();
				
				//
				string manager_string = "Managers";
				EditorGUILayout.LabelField (manager_string, bold_guistyle );
				EditorGUI.indentLevel++;
				if (MOM.Instance.managersList.Count == 0) {
					
					//NO MANAGERS
					EditorGUILayout.HelpBox ("Add Managers", MessageType.Info);
					
						
				} else {
						
					//
					IEnumerator managersList_ienumerator = _managersList_serializedproperty.GetEnumerator();
						
					SerializedProperty 	managerListItem_serializedproperty;
					ScriptableObject 	scriptableObject;
					string 				scriptableObjectName_string;
					string				scriptableObjectTooltip_string;
					while (managersList_ienumerator.MoveNext()) {
					
						//
						EditorGUILayout.BeginHorizontal();
						{
							managerListItem_serializedproperty = managersList_ienumerator.Current as SerializedProperty;
							scriptableObject = managerListItem_serializedproperty.objectReferenceValue as ScriptableObject;
							//
							if (scriptableObject.name != "") {
								scriptableObjectName_string 	= scriptableObject.name;
								scriptableObjectTooltip_string 	= scriptableObject.name;
							} else {
								scriptableObjectName_string 	= "Drag Asset ->";	
								scriptableObjectTooltip_string 	= "Drag Asset Here.";
							}
							
							managerListItem_serializedproperty.objectReferenceValue = (ScriptableObject)EditorGUILayout.ObjectField(new GUIContent (scriptableObjectName_string, scriptableObjectTooltip_string), scriptableObject, typeof(MonoScript), false);

	
							if (GUILayout.Button (new GUIContent("Delete", "Delete This Manager"))) {
								_onManagerListItemDeleteClick (managerListItem_serializedproperty);
							}
						EditorGUILayout.EndHorizontal();
					
						}
					}
					
					

				}
				
				//GUILayoutOption[] buttonMenu_options = new GUILayoutOption[2]; //NEEDED?
				EditorGUILayout.BeginHorizontal();
				{
					EditorGUILayout.Space ();
					
					//TOGGLE VISIBILITY FOR THIS SPECIFIC SECTION
					GUI.enabled = _isAddNewManagerEnabled();
					if (GUILayout.Button (new GUIContent ("Add New Manager", "Add New Manager"))) {
						_onAddNewManagerClick();
					}
					
					//TOGGLE VISIBILITY BACK TO OVERALL VALUE
					GUI.enabled = _isEnabled_serializedproperty.boolValue;
				}
				EditorGUILayout.EndHorizontal();
				
				
				//
				EditorGUI.indentLevel--;
				
				
			}

			//*****************************************************
			//*****************************************************
			//**	BOTTOM MENU
			//*****************************************************
			//*****************************************************
			EditorGUILayout.Separator();
			EditorGUILayout.LabelField ("Menu", bold_guistyle);
			
			//GUILayoutOption[] buttonMenu_options = new GUILayoutOption[2]; //NEEDED?
			EditorGUI.indentLevel ++;
			EditorGUILayout.BeginHorizontal();
			{
				if (GUILayout.Button (new GUIContent("?", "?"))) {
					
				}
			}
			EditorGUI.indentLevel --;
			EditorGUILayout.EndHorizontal();
			
			
			
			//
			EditorGUILayout.LabelField ("Scripts", bold_guistyle);
			EditorGUI.indentLevel ++;
			_getEditorPopupForIManagerScripts();
			EditorGUI.indentLevel --;
			//
			EditorGUILayout.LabelField ("Assets", bold_guistyle);
			EditorGUI.indentLevel ++;
			_getEditorPopupForIManagerAssets();
			EditorGUI.indentLevel --;

			
			//*****************************************************
			//*****************************************************
			//**	BOTTOM MENU
			//*****************************************************
			//*****************************************************
			EditorGUILayout.Separator();
			EditorGUILayout.LabelField ("Instructions", bold_guistyle);
			//
			EditorGUI.indentLevel++;
			string textArea_string = "" +
				"\n" +
				"1. Create a script which extends AbstractManager.\n" + 
				"2. Convert script to asset using Menu -> MOM -> Convert.\n" +
				"3. Click 'Add Manager' above.\n" +
				"4. Drag script from project to above.\n" + 
				"\n";
			EditorGUILayout.TextArea (textArea_string);
			EditorGUI.indentLevel--;
			
			
			
			
			//END
			EditorGUILayout.EndScrollView();
			
			
			//SAVE CHANGES
			_mom_serializedObject.ApplyModifiedProperties();
			
			//SAVE TO DISK - WHICH PARAMETER?
			if (GUI.changed) {
				EditorUtility.SetDirty( MOM.Instance);
			}
			
			//OTHER THINGS?
			//_mom_serializedObject.UpdateIfDirtyOrScript ();
			
			
			//REPAINT THIS WINDOW (NEEDED?)
			//Repaint();
			//autoRepaintOnSceneChange = true;
			
		}
		
					
		void OnHierarchyChange ()
		{
			//CALLED WHEN GOs ARE ADDED/REMOVED/REPARENTED IN HIERARCHY
			//NOT NEEDED
		}
		
		/// <summary>
		/// _ises the add new manager enabled.
		/// </summary>
		/// <returns>
		/// The add new manager enabled.
		/// </returns>
		private bool _isAddNewManagerEnabled ()
		{
			bool isAddNewManagerEnabled_boolean = true;
			//
			IEnumerator managersList_ienumerator = _managersList_serializedproperty.GetEnumerator();
						
			SerializedProperty 	managerListItem_serializedproperty;
			ScriptableObject 	scriptableObject;
			while (managersList_ienumerator.MoveNext()) {
			
				managerListItem_serializedproperty = managersList_ienumerator.Current as SerializedProperty;
				scriptableObject = managerListItem_serializedproperty.objectReferenceValue as ScriptableObject;
				//
				if ((scriptableObject.name.Length == 0)) {
					//IF JUST ONE LACKS A TITLE THEN YOU CAN'T ADD MORE	
					isAddNewManagerEnabled_boolean = false;
					break;
				}
				
			}
			
			return isAddNewManagerEnabled_boolean;
		}
		
		
		/// <summary>
		/// _gets the editor popup for I manager scripts.
		/// </summary>
		public static void _getEditorPopupForIManagerScripts ()
		{
			
			//TODO CHANGE TO IMANANGER TYPE
			System.Type type = typeof (AbstractManager);
			List<Object> resourcesFound = Object.FindObjectsOfTypeIncludingAssets(type).Cast<Object>().Where ( (item) => (item.GetType().Name.Contains("Manager") )).ToList();
			//
			
			EditorGUILayout.LabelField ("C: " + resourcesFound.Count);
			string[] popupListOfScriptableObjects = new string[resourcesFound.Count];
			string nextName_string;
			
			//
			for (int count_int = 0; count_int < resourcesFound.Count; count_int ++) {
				
				nextName_string = resourcesFound[count_int].GetType().FullName; 
				//
				if (!popupListOfScriptableObjects.Contains (nextName_string) ) {
					popupListOfScriptableObjects[count_int] = nextName_string;
				}
			}
			
			//
			EditorGUILayout.Popup (0, popupListOfScriptableObjects);
			
		}

		/// <summary>
		/// _gets the editor popup for all valid assets.
		/// </summary>
		public static void _getEditorPopupForIManagerAssets ()
		{
			//TODO CHANGE TO IMANANGER TYPE
			System.Type type = typeof (AbstractManager);
			List<AbstractManager> resourcesFound = Resources.FindObjectsOfTypeAll(type).Cast<AbstractManager>().Where ( (item) => (item.GetType() != typeof (AbstractManager) )).ToList();
			
			string[] popupListOfScriptableObjects = new string[resourcesFound.Count];
			EditorGUILayout.LabelField ("C: " + resourcesFound.Count);
			int count_int = 0;
			foreach (AbstractManager scriptableObject in resourcesFound) {
				
				popupListOfScriptableObjects[count_int] = scriptableObject.GetType().FullName.ToString() + count_int;
				count_int++;
				
			}
			
			EditorGUILayout.Popup (0, popupListOfScriptableObjects);
		}
		
	
		
		
	    public static MonoScript[] GetScriptAssetsOfType<T>()
	    {
		    MonoScript[] scripts = (MonoScript[])Object.FindObjectsOfTypeIncludingAssets( typeof( MonoScript ) );
		     
		    List<MonoScript> result = new List<MonoScript>();
		     
		    foreach( MonoScript m in scripts )	{
				
		    	if( m.GetClass() != null && m.GetClass().IsSubclassOf( typeof( T ) ) ){
		    		result.Add( m );
		   	 	}
		    }
		    return result.ToArray();
	    }
		
		/// <summary>
		/// _ons the manager list item delete click.
		/// </summary>
		/// <param name='managerListItem_serializedproperty'>
		/// Manager list item_serializedproperty.
		/// </param>
		private void _onManagerListItemDeleteClick (SerializedProperty managerListItem_serializedproperty)
		{
			
			System.Type type = managerListItem_serializedproperty.objectReferenceValue.GetType();
			GenericsUtility.invokeGenericMethodByType (MOM.Instance, "removeManager", type);
			
				
		}
		
		/// <summary>
		/// _ons the add new manager click.
		/// </summary>
		private void _onAddNewManagerClick ()
		{
			MOM.Instance.addManager<AbstractManager>();
			//EditorUtility.DisplayDialog ("blah", "what", "yes", "Cancel");
		}
		
	}
}
