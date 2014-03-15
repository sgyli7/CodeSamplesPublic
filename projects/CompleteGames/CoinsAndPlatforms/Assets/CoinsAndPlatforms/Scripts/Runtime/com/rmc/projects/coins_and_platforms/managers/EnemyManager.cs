/**
* Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using System.Collections.Generic;
using System.Collections;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.components;


namespace com.rmc.projects.coins_and_platforms.managers
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
	public class EnemyManager : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		///<summary>
		///	Don't spawn more than this
		///</summary>
		private uint _maxBarrelCount_uint;
		public uint maxEnemyCount
		{ 
			get 
			{ 
				return _maxBarrelCount_uint; 
			}
			set 
			{ 
				_maxBarrelCount_uint = value; 
			}
		}

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// THESE SPAWN THE ENEMIES, you can have more than one boss onscreen (legacy functionality)
		/// </summary>
		private List<GameObject> _boss_list = new List<GameObject>();


		/// <summary>
		/// The _barrel_list.
		/// </summary>
		private List<GameObject> _barrel_list = new List<GameObject>();


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public EnemyManager ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~EnemyManager ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//
			StartCoroutine (SpawnEnemiesCoroutine());

			//
			_maxBarrelCount_uint 		= 1000;
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		
		// PUBLIC
		/// <summary>
		/// Adds the pipe.
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void addBoss (GameObject gameObject) 
		{

			if (!_boss_list.Contains (gameObject)) {
				//Debug.Log ("BOSS: " + gameObject);
				_boss_list.Add (gameObject);
			}

		}

		public void doDeListAllBosses() 
		{

			_boss_list = new List<GameObject>();
		}

		/// <summary>
		/// Dos the spawn.
		/// </summary>
		/// <returns>The spawn.</returns>
		/// <param name="aPosition_vector3">A position_vector3.</param>
		public GameObject doSpawn (Vector3 aPosition_vector3)
		{
			//UPDATE COUNT
			GameObject newBarrel_gameobject = SimpleGameManager.Instance.instantiateDynamicPrefab (MainConstants.BARREL_PREFAB, aPosition_vector3);
			_barrel_list.Add (newBarrel_gameobject);

			return newBarrel_gameobject;
		}


		/// <summary>
		/// Dos the despawn.
		/// </summary>
		/// <returns>The despawn.</returns>
		/// <param name="aGameObject">A game object.</param>
		public void doDespawn (GameObject aGameObject)
		{
			_barrel_list.Remove (aGameObject);
			//
			SimpleGameManager.Instance.destroyDynamicPrefab (aGameObject);
		}

		/// <summary>
		/// Dos the despawn all enemies.
		/// </summary>
		public void doDespawnAllEnemies ()
		{
			GameObject barrel_gameobject;
			for (int barrelIndex_int = _barrel_list.Count-1; barrelIndex_int >= 0; barrelIndex_int --) {
				barrel_gameobject = _barrel_list[barrelIndex_int];
				doDespawn (barrel_gameobject);
			}

		}



		
		// PUBLIC STATIC
		
		// PRIVATE
		void _doSpawnEnemyInternal ()
		{
			//PICK A PIPE RANDOMLY
			if (_canSpawnEnemy()) {
				GameObject spawnPipe = _boss_list[Random.Range( 0, _boss_list.Count )];


				//SPAWN NEXT
				if (spawnPipe) {
					spawnPipe.GetComponent<BossSpawnsBarrelsComponent>().doSpawnEnemy();
				}

			}
		}

		/// <summary>
		/// _cans the spawn enemy.
		/// </summary>
		/// <returns><c>true</c>, if spawn enemy was _caned, <c>false</c> otherwise.</returns>
		private bool _canSpawnEnemy () 
		{

			bool canSpawnEnemy_boolean;

			//
			//Debug.Log ("Is current: " + _currentEnemyCount_uint + " less than max: " + _maxEnemyCount_uint);

			//
			if (_barrel_list.Count < _maxBarrelCount_uint) {

				if (_boss_list != null && _boss_list.Count > 0){

					canSpawnEnemy_boolean = true;

				} else {

					canSpawnEnemy_boolean = false;
				}

			} else {
				canSpawnEnemy_boolean = false;
			}


			return canSpawnEnemy_boolean;

		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		private IEnumerator SpawnEnemiesCoroutine ()
		{

			//CREATE ENEMY BEHIND THE PIPE
			_doSpawnEnemyInternal();

			//WAIT AND REPEAT
			float waitTime_float = Random.Range (2,5);
			yield return new WaitForSeconds (waitTime_float);
			StartCoroutine (SpawnEnemiesCoroutine());
		}
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the click event.
		/// </summary>
		void OnClick ()
		{
			
			
		}
	}
}
