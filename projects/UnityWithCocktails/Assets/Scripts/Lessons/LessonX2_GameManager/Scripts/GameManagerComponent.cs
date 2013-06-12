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
	private readonly List<string> _level_list_string = new List<string>()
    {
        "TestLevel1",
		"TestLevel2"
    };
	
	
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
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Created: " + GameManagerComponent.Instance);
		//
		loadNextLevel();
		
		//
		//if (GameManagerComponent.Instance == null) {
			//
		//}
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
	public void loadPreviousLevel ()
	{
		if (_currentLevel == null) {
			currentLevel = _level_list_string[0];
		} else {
			//CURRENT
			int currentIndex_int = _level_list_string.IndexOf (currentLevel);
			//NEXT
			currentIndex_int--;
			//CORRECT
			currentLevel = _getCorrectedLevelNameByIndex(currentIndex_int);
		}
	}

	
	///<summary>
	///	 Level
	///</summary>
	public void loadNextLevel ()
	{
		if (_currentLevel == null) {
			currentLevel = _level_list_string[0];
		} else {
			//CURRENT
			int currentIndex_int = _level_list_string.IndexOf (currentLevel);
			//NEXT
			currentIndex_int++;
			//CORRECT
			currentLevel = _getCorrectedLevelNameByIndex(currentIndex_int);
		}
	}
	
	///<summary>
	///	 Level
	///</summary>
	public string _getCorrectedLevelNameByIndex (int aDesiredIndex_int)
	{
		int correctedIndex_int;
		//
		if (aDesiredIndex_int < 0) {
			correctedIndex_int = _level_list_string.Count-1;
		} else if (aDesiredIndex_int >= _level_list_string.Count) {
			correctedIndex_int = 0;
		} else {
			correctedIndex_int = aDesiredIndex_int;
		}
		return _level_list_string[correctedIndex_int];
	}



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
				
				//CREATE GO
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
				
				Debug.Log ("GameManagerComponent.constructor() _Instance: " + _Instance);
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

