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
//  Class
//--------------------------------------
public class GameManagerComponent : MonoBehaviour
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	// GETTER / SETTER
	///<summary>
	///	 Current Level
	///</summary>
	private string _currentLevel;
	public string currentLevel 
	{
		get 
		{
			return _currentLevel;
		}
		set 
		{
			_currentLevel = value;
			Application.LoadLevel (_currentLevel);
		}
	}
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	 Current Level
	///</summary>
	private List<GameObject> _model_list_gameobject = new List<GameObject>(10);
	
	///<summary>
	///	 Selected Item
	///</summary>
	private int _modelListSelectedItem_int;
	
	// PRIVATE STATIC
	///<summary>
	///	 NAME: GameObject contianing the GameManagerComponent
	///</summary>
	private static string _NAME_GAME_MANAGER = "_GameManager";
	
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
	///	 Create Instance
	///</summary>
	void Awake ()
	{
		
		//MOVE THIS INTO CONSTRUCTOR OF SINGELTON???
		
		
		
		DontDestroyOnLoad (gameObject);
		

		_model_list_gameobject.Add (GameObject.Find ("HousePrefab"));
		_model_list_gameobject.Add(GameObject.Find ("SmallBuildingPrefab"));
		_model_list_gameobject.Add(GameObject.Find ("TallBuildingPrefab"));
		
		loadNextModel();
		
	}
	
	///<summary>
	///	 Destroy Instance
	///</summary>
	public void OnApplicationQuit() 
	{ 
		//
		_Instance = null;
	}
	
	///<summary>
	///	 Constructor
	///</summary>
	private GameManagerComponent( )
	{
		//
		
		
	}
	

	
	///<summary>
	///	 Level
	///</summary>
	public void loadPreviousModel ()
	{
		_modelListSelectedItem_int --;
		_doCorrectIndex();
		_loadCurrentModel();
		
	}
		
	///<summary>
	///	 Level
	///</summary>
	public void loadNextModel ()
	{
		_modelListSelectedItem_int ++;
		_doCorrectIndex();
		_loadCurrentModel();

	}
	
	///<summary>
	///	 Level
	///</summary>
	private void _doCorrectIndex ()
	{
		if (_modelListSelectedItem_int < 0) {
			_modelListSelectedItem_int = _model_list_gameobject.Count -1;
		} else if (_modelListSelectedItem_int > _model_list_gameobject.Count -1) {
			_modelListSelectedItem_int = 0;
		}
	}
	
	
	///<summary>
	///	 Level
	///</summary>
	private void _loadCurrentModel ()
	{
		
		Debug.Log ("NOW: " + _modelListSelectedItem_int);
		
		ModelComponent modelComponent0 = _model_list_gameobject[0].GetComponent<ModelComponent>();
		ModelComponent modelComponent1 = _model_list_gameobject[1].GetComponent<ModelComponent>();
		ModelComponent modelComponent2 = _model_list_gameobject[2].GetComponent<ModelComponent>();
		
		switch (_modelListSelectedItem_int) {
			case (0):
				modelComponent0.wayPoint = GameObject.Find ("Waypoint1");
				modelComponent1.wayPoint = GameObject.Find ("Waypoint2");
				modelComponent2.wayPoint = GameObject.Find ("Waypoint0");
				break;
			case (1):
				modelComponent0.wayPoint = GameObject.Find ("Waypoint0");
				modelComponent1.wayPoint = GameObject.Find ("Waypoint1");
				modelComponent2.wayPoint = GameObject.Find ("Waypoint2");
				break;
			case (2):
				modelComponent0.wayPoint = GameObject.Find ("Waypoint2");
				modelComponent1.wayPoint = GameObject.Find ("Waypoint0");
				modelComponent2.wayPoint = GameObject.Find ("Waypoint1");
				break;
		}


	}
		

	
	///<summary>
	///	 Level
	///</summary>


	// PUBLIC STATIC
	///<summary>
	///	Find a GameObject by name within parent GameObject
	///</summary>
	private static GameObject FindGameObjectsWithName(string pRoot, string pName)
    {
        Transform pTransform = GameObject.Find(pRoot).GetComponent<Transform>();
        foreach (Transform trs in pTransform) {
            if (trs.gameObject.name == pName)
                return trs.gameObject;
        }
       return null;
    }
	
	///<summary>
	///	Create a child GameObject by name but only if it doesn't already exist
	///</summary>
	private static GameObject _CreateChildGameObjectIfNotAlreadyCreated(string desiredChildGameObjectName_string)
    {
		GameObject child_gameobject = GameManagerComponent.FindGameObjectsWithName (GameManagerComponent._NAME_GAME_MANAGER,desiredChildGameObjectName_string);
		if (child_gameobject == null) {
			child_gameobject = Instantiate (new GameObject (desiredChildGameObjectName_string)) as GameObject;
			child_gameobject.name = desiredChildGameObjectName_string; //without this the name is "DynamicGameObjects (Clone)" - not sure why
			child_gameobject.transform.parent = _Instance.gameObject.transform;
		}
		return child_gameobject;
	}
	
	
	///<summary>
	///	 Instance
	///</summary>
	private static GameManagerComponent _Instance;
	public static GameManagerComponent Instance 
	{
		get 
		{
			
			if (_Instance == null) {
				
				//CREATE GO, BUT ONLY IF ITS NOT ALREADY MANUALLY BEEN PLACED ON STAGE (WHICH IS USUALLY IS)
				GameObject gameManager = GameObject.Find (GameManagerComponent._NAME_GAME_MANAGER);
				if (gameManager == null) {
					gameManager = Instantiate (new GameObject (GameManagerComponent._NAME_GAME_MANAGER)) as GameObject;
					Debug.Log ("GameManager.constructor()");
				}
				
				//CREATE SCRIPT ON GO
				_Instance = gameManager.GetComponent<GameManagerComponent>();
				if (_Instance == null) {
					_Instance = gameManager.AddComponent<GameManagerComponent>(); 	
				}
				
			} 
			
			//INITIALIZE
			GameManagerComponent._CreateChildGameObjectIfNotAlreadyCreated( GameManagerComponent._NAME_DYNAMIC_GAME_OBJECTS);
			GameManagerComponent._CreateChildGameObjectIfNotAlreadyCreated(GameManagerComponent._NAME_STATIC_GAME_OBJECTS);
			
			return _Instance;
		}
	}
	
	

	// PRIVATE
	
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}

