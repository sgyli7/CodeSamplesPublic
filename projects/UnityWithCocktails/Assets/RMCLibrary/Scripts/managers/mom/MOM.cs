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
using UnityEngineInternal;
using System.Collections;
using System.Collections.Generic;
using com.rmc.utilities;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.managers.mom
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// MOM = Manager of Managers. One singleton to rule them all.
	/// </summary>
	[ExecuteInEditMode()] 
	public class MOM : MonoBehaviour
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
			
		// SETTER / GETTER
		
		/// <summary>
		/// The _is visible in hierarchy_boolean.
		/// </summary>
		/// 
		/// 	NOTE: I TRIED PRIVATE WITH SERIALIZED, ALL THAT WORKS GREAT *BUT* THE GETTER/SETTER ISN'T CALLED FROM THE EDITOR, SO GETTER/SETTER HAS LIMITED VALUE WITH THIS EDITOR-CENTRIC PROPERTY
		/// 
		[SerializeField] 
		public bool isEnabled = true;
		
		/// <summary>
		/// The _is visible in hierarchy_boolean.
		/// </summary>
		/// 
		/// 	NOTE: I TRIED PRIVATE WITH SERIALIZED, ALL THAT WORKS GREAT *BUT* THE GETTER/SETTER ISN'T CALLED FROM THE EDITOR, SO GETTER/SETTER HAS LIMITED VALUE WITH THIS EDITOR-CENTRIC PROPERTY
		/// 
		[SerializeField] 
		public bool isVisibleInHierarchy = true;
		
		// PRIVATE STATIC
		///<summary>
		///	 NAME: GameObject contianing the MOM
		///</summary>
		private static string _NAME_MOM = "_MOM";
		
		///<summary>
		///	 NAME: GameObject containing any static children (manually placed in heirarchy)
		///</summary>
		private static string _NAME_STATIC_GAME_OBJECTS = "_StaticGameObjects";
		
		///<summary>
		///	 NAME: GameObject containing any dynamically children (dynamically placed via code)
		///</summary>
		private static string _NAME_DYNAMIC_GAME_OBJECTS = "_DynamicGameObjects";
			
	
	
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		///<summary>
		///	 Persist Instance
		///</summary>
		public void Awake() 
		{ 
			//
			DontDestroyOnLoad (this);
			
			if (_Instance == null) {
				#pragma warning disable 0219
				MOM dummy_mom = MOM.Instance; //trick singleton into instantiating if it doesn't exist yet.
				#pragma warning restore 0219
			}
		}
		
		
		///<summary>
		///	 Destroy Instance
		///</summary>
		public void OnApplicationQuit() 
		{ 
			//
			_Instance = null; //NOTE, ITS STILL SITTING IN HIERARCHY?
			
			//TODO, SHOULD IT DELETE FROM HIERARCHY?
		}
	
		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update() 
		{ 
			//DO MOM STUFF
			//Debug.Log("updateMOM");
			_doUpdateHideFlagsForGameObject(gameObject);
			
			
			/*
			 * 
			 * NOTE: 	WE ARE CALLING UPDATE ON IMANAGERS DURING PLAY (GOOD) AND ALSO 
			 * 			DURING EDIT (OVERKILL?????) DUE TO 	[ExecuteInEditMode()]  ABOVE
			 * 
			 */
			//THEN DO MANAGER STUFF
			foreach (IManager iManager in _Instance.managersList) {
				if (iManager.canReceiveUpdate) {
					iManager.onUpdate();
				}
			}
		}
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		private MOM ( )
		{
			//Debug.Log ("MOM.constructor()");
			
		}
		
		public void destroy()
		{
			Debug.Log ("MOM.destroy(): " + gameObject);
			DestroyImmediate (gameObject);	
		}
		
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			MANAGERS FUNCTIONALITY
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		public List<AbstractManager> managersList = new List<AbstractManager>();
		
		
		/// <summary>
		/// Adds the manager.
		/// </summary>
		/// <returns>
		/// The manager.
		/// </returns>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
		public T addManager <T> () where T : IManager
		{
			
			//
			IManager found_imanager;
			
			//NOTE: LIMIT - ONLY 1 MANAGER OF EACH TYPE MAY EXIST.
			if (hasManager<T>()) {
				
				found_imanager = getManager<T>();
				
			} else {
				
				found_imanager = _addManagerByForce<T>();
				
			} 
				
			
			//RETURN
			return (T) found_imanager;
		}
		
		/// <summary>
		/// _adds the manager by force.
		/// </summary>
		/// <returns>
		/// The manager by force.
		/// </returns>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
		public T _addManagerByForce <T> () where T : IManager
		{
			//REMOVE IF EXISTS
			if (hasManager<T>()) {
				removeManager<T>();
			} 
			
			//
			IManager found_imanager;
			
				
			//CREATE
			var newInstance = ScriptableObject.CreateInstance(typeof(T));
			found_imanager = (IManager) newInstance;
			
			//ADD
			managersList.Add ((AbstractManager)found_imanager);
			
			//DISPATCH 'I' WAS ADDED
			found_imanager.onAddManager();
			
			
			//DISPATCH 'ANOTHER MANAGER' WAS ADDED
			foreach (IManager iManager in _Instance.managersList) {
				
				//TODO: DECIDE IF A MANAGER SHOULD GET ONRESET() WHEN ITSELF IS ADDED. FOR NOW, YES!
				//if (iManager != found_imanager) {
					iManager.onReset(found_imanager);	
				//}
			}
			
			//RETURN
			return (T) found_imanager;
		}

	
		/// <summary>
		/// Hases the manager.
		/// </summary>
		/// <returns>
		/// The manager.
		/// </returns>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
		public bool hasManager <T> () where T : IManager
		{
			ScriptableObject scriptableObject = managersList.Find ( man => (man.GetType() == typeof(T))	);
			IManager found_imanager = (IManager) scriptableObject;
			return (found_imanager != null);
		}
		
		/// <summary>
		/// Gets the manager.
		/// </summary>
		/// <returns>
		/// The manager.
		/// </returns>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
		public T getManager <T> () where T : IManager
		{
			ScriptableObject scriptableObject = managersList.Find ( man => (man.GetType() == typeof(T))	);
			IManager found_imanager = (IManager) scriptableObject;
			return (T) found_imanager;
		}

		
		/// <summary>
		/// ReAdd all managers.
		/// </summary>
		public void reAddAllManagersFromInspector ()
		{
			
			//COPY FROM MASTER LIST (FROM INSPECTOR)
			List <AbstractManager> copyOFManagersList = new List<AbstractManager>(managersList);
			
			//CLEAR MASTER LIST
			managersList.RemoveAll ( (abstractManager) => true); //remove 'all'
			
			//ADD FROM COPY TO MASTER LIST
			//	NOTE: THIS PROPERLY CALLS THE ADD EVENTS WITHOUT THE DELETE EVENTS
			
			
			IManager iManager;
			for (int index_int = copyOFManagersList.Count -1; index_int >= 0 ; index_int --) {
				
				//
				iManager = copyOFManagersList[index_int];
				//
				System.Type type = iManager.GetType();
				GenericsUtility.invokeGenericMethodByType (MOM.Instance, "_addManagerByForce", type);
			
			}
			
		}
		
		
		/// <summary>
		/// Gets the manager.
		/// </summary>
		/// <returns>
		/// The manager.
		/// </returns>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
		public bool removeManager <T> () where T : IManager
		{
			IManager existing_imanager = getManager<T>();
			bool wasSuccessful_boolean = false;
			
			if (existing_imanager == null) {
				wasSuccessful_boolean = false; //failed
				
			} else {
				
				existing_imanager.onRemoveManager();
				wasSuccessful_boolean = managersList.Remove ((AbstractManager)existing_imanager);
			}
			
			//
			return wasSuccessful_boolean;
			
		}
		
		
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			HANDLE DYNAMIC INSTANTIATION (THIS IS PERMANENT CODE)
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Adds the one dynamic test game objects. Put into the dynamic section of hierarchy (optional)
		/// 
		/// NOTE: In the future we'd want similiar functionality for prefabs
		/// 
		/// </summary>
		public void instantiateDynamicGameObject (string aDesiredName_str )
		{
			GameObject gameObject = new GameObject (aDesiredName_str);
			gameObject.transform.parent = _FindChildGameObjectWithName (_Instance.gameObject.name, _NAME_DYNAMIC_GAME_OBJECTS).transform;
			DontDestroyOnLoad (gameObject);
		}
	
	
		/// <summary>
		/// Removes all dynamic test game objects.
		/// </summary>
		public void removeDynamicGameObject (string aDesiredName_str)
		{
			//TODO....
			
			
		}
			
		
	
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			TEST INSTANTIATION (THIS IS DEMO ONLY CODE)
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Adds the one dynamic test game objects.
		/// </summary>
		public void addOneDynamicTestGameObjects ()
		{
			instantiateDynamicGameObject ("DynamicTestGameObject");
		}
	
		/// <summary>
		/// Removes all dynamic test game objects.
		/// </summary>
		public void removeAllDynamicTestGameObjects ()
		{
			GameObject gameObject = _FindChildGameObjectWithName (_Instance.gameObject.name, _NAME_DYNAMIC_GAME_OBJECTS);
			_RemoveChildGameObjectsWithName (gameObject.name, "DynamicTestGameObject"); 
		}
			
		
	
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			HELPER FUNCTIONS 
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
			
			
		// PUBLIC STATIC
		///<summary>
		///	Find a GameObject by name within parent GameObject
		///</summary>
		private static GameObject _FindChildGameObjectWithName(string pRoot, string pName)
	    {
	        Transform pTransform = GameObject.Find(pRoot).GetComponent<Transform>();
	        foreach (Transform trs in pTransform) {
	            if (trs.gameObject.name == pName)
	                return trs.gameObject;
	        }
	       return null;
	    }
		
		///<summary>
		///	Remove a GameObject by name within parent GameObject
		///</summary>
		private static void _RemoveChildGameObjectsWithName(string pRoot, string pName)
	    {
	        Transform pTransform = GameObject.Find(pRoot).GetComponent<Transform>();
	        foreach (Transform trs in pTransform) {
	            if (trs.gameObject.name == pName) {
	                Destroy (trs.gameObject);
				}
	        }
	    }
		
		///<summary>
		///	Create a child GameObject by name but only if it doesn't already exist
		///</summary>
		private static GameObject _CreateChildGameObjectIfNotAlreadyCreated(GameObject aParent_gameobject, string desiredChildGameObjectName_string)
	    {
			GameObject child_gameobject = MOM._FindChildGameObjectWithName (aParent_gameobject.name, desiredChildGameObjectName_string);
			if (child_gameobject == null) {
				//
				child_gameobject = new GameObject (desiredChildGameObjectName_string);
				DontDestroyOnLoad (child_gameobject);
				child_gameobject.transform.parent = aParent_gameobject.transform;
			} 
			return child_gameobject;
		}
		
	
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			SINGLETON SETUP
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		
		///<summary>
		///	 Instance SETTER/GETTER
		///</summary>
		private static MOM _Instance;
		public static MOM Instance 
		{
			get 
			{
				
				//IF THERE IS NOT ALREADY AN INSTANCE CREATED
				if (_Instance == null) {
					
					//1. CREATE A GAME OBJECT (IF MISSING)
					GameObject MOM_gameobject =  GameObject.Find (MOM._NAME_MOM);
					if (MOM_gameobject == null) {
						MOM_gameobject = new GameObject (MOM._NAME_MOM);
					
					}
					
					//3. CREATE A COMPONENT ON THE GAME OBJECT
					_Instance = MOM_gameobject.GetComponent<MOM>();
					if (_Instance == null) {
						_Instance = MOM_gameobject.AddComponent<MOM>(); 
						
					}
						
					
					//5. TEMPORARY***** ADD MANAGERS (SHOULD BE DONE FROM OUTSIDE)
					_Instance.reAddAllManagersFromInspector();
						
					
					//6. INITIALIZE A FEW CHILDREN TO ACT LIKE FOLDERS FOR FUTURE GO'S
					MOM._CreateChildGameObjectIfNotAlreadyCreated(_Instance.gameObject, MOM._NAME_DYNAMIC_GAME_OBJECTS);
					MOM._CreateChildGameObjectIfNotAlreadyCreated(_Instance.gameObject, MOM._NAME_STATIC_GAME_OBJECTS);
					
					
					
				} 
				
									
				//4. ADD FLAGS TO HIDE EVERYTHING FROM HIERARCHY (OPTIONAL)
				_doUpdateHideFlagsForGameObject(_Instance.gameObject);
					
				
				return _Instance;
			}
		}
		
		/// <summary>
		/// _dos the update hide flags for game object.
		/// </summary>
		/// <param name='aGameObject'>
		/// A game object.
		/// </param>
		private static void _doUpdateHideFlagsForGameObject(GameObject aGameObject)
		{
			if (_Instance.isVisibleInHierarchy) {
				aGameObject.hideFlags = aGameObject.hideFlags ^ HideFlags.HideInHierarchy;
			} else {
				aGameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			/*
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			Debug.Log ("aGameObject.hideFlags: " + aGameObject.hideFlags);
			*/
		}
		
		
		
		/// <summary>
		///  debug log game object count.
		/// </summary>
		private static void _DebugLogGameObjectCount()
		{
			GameObject[] allGameobjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; Debug.Log("COUNT: " + allGameobjects.Length);
					
		}
		
	
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

