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
	public class MOM : MonoBehaviour
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
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
			//Debug.Log ("Update");
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
		
		/// <summary>
		/// The I managers.
		/// </summary>
		public List<AbstractManager> IManagers = new List<AbstractManager>();
		
		public ArrayList arrayList;
		
		public AbstractManager[] man;
		
		
		
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
			Component component = gameObject.GetComponent (typeof (T));
			IManager existing_imanager = component as IManager;
			
			//
			if (existing_imanager == null) {
				component = gameObject.AddComponent ( typeof (T));
				existing_imanager = component as IManager;
				existing_imanager.onAddManager();
			}
			return (T) existing_imanager;
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
			Component component = gameObject.GetComponent (typeof (T));
			IManager existing_imanager = component as IManager;
			
			if (existing_imanager == null) {
				return false; //failed
				
			} else {
				existing_imanager.onRemoveManager();
				return true;
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
		public T getManager <T> () where T : IManager
		{
			IManager existing_imanager = addManager<T>();
			return (T) existing_imanager;
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
					
						//2. ADD FLAGS TO HIDE EVERYTHING FROM HIERARCHY (OPTIONAL)
						//MOM_gameobject.hideFlags = HideFlags.HideInHierarchy;
					}
					
					//3. CREATE A COMPONENT ON THE GAME OBJECT
					_Instance = MOM_gameobject.GetComponent<MOM>();
					if (_Instance == null) {
						_Instance = MOM_gameobject.AddComponent<MOM>(); 	
						
						//XXXXX. TEMPORARY***** ADD MANAGERS (SHOULD BE DONE FROM OUTSIDE)
						Debug.Log("1");
						_Instance.addManager<LevelManager>();
						Debug.Log("2");
						LevelManager levelManager = _Instance.getManager<LevelManager>();
						levelManager.loadNextLevel();
						Debug.Log("3");
						_Instance.removeManager<LevelManager>();
						
					}
					
					
					//4. INITIALIZE A FEW CHILDREN TO ACT LIKE FOLDERS FOR FUTURE GO'S
					MOM._CreateChildGameObjectIfNotAlreadyCreated(_Instance.gameObject, MOM._NAME_DYNAMIC_GAME_OBJECTS);
					MOM._CreateChildGameObjectIfNotAlreadyCreated(_Instance.gameObject, MOM._NAME_STATIC_GAME_OBJECTS);
					
					
					
				} 
				
				return _Instance;
			}
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

