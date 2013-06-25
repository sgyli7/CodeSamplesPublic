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
		/// The _is hidden in hierarchy_serializedproperty.
		/// </summary>
		private SerializedProperty _isHiddenInHierarchy_serializedproperty;
		
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
			_isHiddenInHierarchy_serializedproperty 	= _mom_serializedObject.FindProperty ("isHiddenInHierarchy");
			//
			_managersList_serializedproperty 			= _mom_serializedObject.FindProperty ("managersList");
		}
		
		private Texture2D tabIcon_texture2D 		= Resources.Load("MOMEditorWindowTabIcon") as Texture2D;
		private Texture2D hierarchyItem_texture2D 	= Resources.Load("MOMHierarchyItemIcon") as Texture2D;
		private Texture2D bannerImage_texture2D 	= Resources.Load("MOMEditorWindowBannerImage") as Texture2D;
 
		
			
		
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
			
			EditorApplication.hierarchyWindowItemOnGUI += _onHierarchyWindowItemOnGUI;
			EditorApplication.hierarchyWindowChanged += _onHierarchyWindowChanged;
				
			
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
			
			EditorGUIUtility.LookLikeControls();
			
			GUI.enabled = true; //FOR THE TOP OF THE PAGE HERE...
			
				
			//DEBUG.LOG() ALL PROPERTIES OF 'MOM'
			//EditorWindowUtility.DebugLogAllPropertiesForSerializedProperty(_mom_serializedObject);
			
			
			//STYLE INFO
			GUIStyle bold_guistyle 	= new GUIStyle();
			bold_guistyle.fontStyle = FontStyle.Bold;
			
			
			//TODO, MAKE IMAGE FILL THE 'BOX' (OR CHOOSE SOMETHING OTHER THAN 'BOX');
			//bannerImage_texture2D.width 	= 300;
			//bannerImage_texture2D.height 	= 50;
			bannerImage_texture2D.wrapMode = TextureWrapMode.Repeat;
			GUILayout.Box(bannerImage_texture2D,GUILayout.Width(position.width - _bannerPaddingRight_int),GUILayout.Height(40)); 
			//GUILayout.Label(bannerImage_texture2D,GUILayout.Width(position.width - 7),GUILayout.Height(50)); 
			
			//OPTIONS
			GUILayoutOption[] wideToggleGUILayoutOptions = new GUILayoutOption[1];
			wideToggleGUILayoutOptions[0] = GUILayout.MaxWidth (30);
			
			//OPTIONS
			GUILayoutOption[] skinnyToggleGUILayoutOptions = new GUILayoutOption[2];
			skinnyToggleGUILayoutOptions[0] = GUILayout.MaxWidth (14);
			skinnyToggleGUILayoutOptions[1] = GUILayout.MinWidth (14);
			
			//OPTIONS
			GUILayoutOption[] buttonGUILayoutOptions = new GUILayoutOption[2];
			buttonGUILayoutOptions[0] = GUILayout.MaxWidth (60);
			buttonGUILayoutOptions[1] = GUILayout.MinWidth (60);
			
			//OPTIONS
			GUILayoutOption[] scriptableObjectFieldOptions = new GUILayoutOption[2];
			scriptableObjectFieldOptions[0] = GUILayout.MaxWidth (250);
			scriptableObjectFieldOptions[1] = GUILayout.MinWidth (250);
			
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
					_isEnabled_serializedproperty.boolValue = EditorGUILayout.Toggle (_isEnabled_serializedproperty.boolValue, wideToggleGUILayoutOptions);	
					EditorGUILayout.EndHorizontal();
					
					//TOGGLE FOR THE PAGE BELOW
					GUI.enabled = _isEnabled_serializedproperty.boolValue;
					
					//
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel ("Hide In Hierarchy?");
					_isHiddenInHierarchy_serializedproperty.boolValue = EditorGUILayout.Toggle (_isHiddenInHierarchy_serializedproperty.boolValue, wideToggleGUILayoutOptions);	
					EditorGUILayout.PrefixLabel ("(Must Hit Play then Pause)");
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
				if (MOM.Instance.managersList.Count == 0) {
					
					//NO MANAGERS
					EditorGUILayout.HelpBox ("Add Managers", MessageType.Info);
					
						
				} else {
					
					//
					EditorGUI.indentLevel++;
					_managersList_serializedproperty.isExpanded = EditorGUILayout.Foldout(_managersList_serializedproperty.isExpanded, new GUIContent ("Expand"));
				
					EditorGUI.indentLevel++;
					if (_managersList_serializedproperty.isExpanded) {
						
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
								
								EditorGUILayout.Toggle (false, skinnyToggleGUILayoutOptions);
								
								//
								managerListItem_serializedproperty.objectReferenceValue = (ScriptableObject) EditorGUILayout.ObjectField(new GUIContent (scriptableObjectName_string, scriptableObjectTooltip_string), scriptableObject, typeof(ScriptableObject), false, scriptableObjectFieldOptions);
	
								
									
					
		
								if (GUILayout.Button (new GUIContent("Delete", "Delete This Manager"), buttonGUILayoutOptions)) {
									_onManagerListItemDeleteClick (managerListItem_serializedproperty);
								}
							EditorGUILayout.EndHorizontal();
						
							}
						}
						
					}///////////					

				}
				
				EditorGUI.indentLevel--;
				
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
				EditorGUILayout.Space();
				if (GUILayout.Button (new GUIContent("What", "?"))) {
					
				}
			}
			
			EditorGUILayout.EndHorizontal();
			EditorGUI.indentLevel --;
			
			
			
			EditorGUI.indentLevel ++;
			EditorGUILayout.LabelField ("Scripts");
			EditorGUI.indentLevel ++;
			_getEditorPopupForIManagerScripts();
			EditorGUI.indentLevel --;
			//
			EditorGUILayout.LabelField ("Assets");
			EditorGUI.indentLevel ++;
			_getEditorPopupForIManagerAssets();
			EditorGUI.indentLevel --;
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
			
			
			//SAVE TO DISK - WHICH PARAMETER?
			if (GUI.changed) {
				_mom_serializedObject.ApplyModifiedProperties();
				_mom_serializedObject.UpdateIfDirtyOrScript();
				EditorUtility.SetDirty( MOM.Instance);
				
			}
			
			
			//DOESN'T SEEM TO WORK--
			//Debug.Log ("calling repaint hier");
			//EditorApplication.RepaintHierarchyWindow();
			
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
			
			//EditorGUILayout ("C: " + resourcesFound.Count());
			string[] popupListOfScriptableObjects = new string[resourcesFound.Count];
			int count_int = 0;
			foreach (Object scriptableObject in resourcesFound) {
				
				popupListOfScriptableObjects[count_int] = scriptableObject.GetType().FullName.ToString();
				count_int++;
				
			}
			
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
			int count_int = 0;
			foreach (AbstractManager scriptableObject in resourcesFound) {
				
				popupListOfScriptableObjects[count_int] = scriptableObject.GetType().FullName.ToString();
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
		
		/// <summary>
		/// _ons the hierarchy window item on GU.
		/// </summary>
		/// <param name='instanceID'>
		/// Instance I.
		/// </param>
		/// <param name='selectionRect'>
		/// Selection rect.
		/// </param>
		private void _onHierarchyWindowItemOnGUI (int aInstanceID_int, Rect aSelection_rect)
		{
			GameObject gameObject = EditorUtility.InstanceIDToObject(aInstanceID_int) as GameObject;
			
			//
			if (_isMOMGameObjectOrChildOfMOMGameObject(gameObject) ) {
				
				Rect icon_rect = aSelection_rect;
				icon_rect.x = aSelection_rect.x + aSelection_rect.width - 22;
				icon_rect.y--;
				icon_rect.width = 22;
				icon_rect.height = 22;
				
				GUI.Label (icon_rect, hierarchyItem_texture2D);	
			}
			
		}
		
		/// <summary>
		/// _ises the MOM game object or child of MOM game object.
		/// </summary>
		/// <param name='gameObject'>
		/// Game object.
		/// </param>
		private bool _isMOMGameObjectOrChildOfMOMGameObject (GameObject aGameObject)
		{
			bool isMOMGameObjectOrChildOfMOMGameObject_boolean = false;
			
			if (aGameObject != null) {
				
				
				if (aGameObject == MOM.Instance.gameObject) {
					
					//IS THE MOM
					return true;
				} else if (aGameObject.transform.parent != null ) {
					
					if (aGameObject.transform.parent.gameObject == MOM.Instance.gameObject) {
						//ITS PARENT IS THE MOM
						return true;	
					}
				}
				
			} 
			
			return isMOMGameObjectOrChildOfMOMGameObject_boolean;
			
		}
		
		
		/// <summary>
		/// _ons the hierarchy window changed.
		/// </summary>
		private void _onHierarchyWindowChanged ()
		{
			Debug.Log ("_onHierarchyWindowChanged()");
			
		}
		
	}
}
