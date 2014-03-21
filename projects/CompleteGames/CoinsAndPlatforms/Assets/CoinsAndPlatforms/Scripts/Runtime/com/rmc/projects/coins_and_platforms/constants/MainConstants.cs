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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.constants
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
	public class MainConstants : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC

		//*************************
		//  GAME OBJECT NAMES
		//*************************
		public static string ScoreGUIText 			= "ScoreGUIText";
		public static string ScoreGUIText2 			= "ScoreGUIText2";
		public static string LivesGUIText 			= "LivesGUIText";
		public static string LivesGUIText2 			= "LivesGUIText2";
		public static string PromptGUIText 			= "PromptGUIText";
		public static string PromptGUIText2 		= "PromptGUIText2";
		public static string StartWaypoint 			= "StartWaypoint";
		public static string PlayerUnPrefab 		= "PlayerUnPrefab";

		
		//*************************
		//  RESOURCES: PREFABS
		//*************************
		public static string RisingPointsPrefab   	= "Prefabs/RisingPointsPrefab";

		
		//*************************
		//  RESOURCES: SOUNDS
		//*************************
		public static string AUDIO_BUTTON_CLICK_01 				= "Audio/SoundEffects/ButtonClick01";
		public static string AUDIO_WAYPOINT_TRIGGERED_01		= "Audio/SoundEffects/WaypointTriggered01";
		public static string AUDIO_PLAYER_FALLS_OFFSCREEN_01	= "Audio/SoundEffects/PlayerFallsOffscreen01";
		public static string AUDIO_PLAYER_JUMPS_01 				= "Audio/SoundEffects/PlayerJumps01";
		public static string AUDIO_PLAYER_LANDS_01 				= "Audio/SoundEffects/PlayerLands01";
		public static string AUDIO_PLAYER_KILLS_ENEMY_01 		= "Audio/SoundEffects/PlayerKillsEnemy01";
		public static string AUDIO_COINS_COLLECTED_01			= "Audio/SoundEffects/CoinCollected01";
		public static string AUDIO_ENEMY_KILLS_PLAYER_01 		= "Audio/SoundEffects/EnemyKillsPlayer01";
		public static string AUDIO_GAME_OVER_WIN_01				= "Audio/SoundEffects/GameOverWin01";
		public static string AUDIO_GAME_OVER_LOSS_01			= "Audio/SoundEffects/GameOverLoss01";
		public static string AUDIO_GAME_START_01				= "Audio/SoundEffects/GameStart01";
		public static string AUDIO_BACKGROUND_MUSIC_01			= "Audio/Music/BackgroundMusic01";



		//*************************
		//  TAGS
		//*************************
		public static string PLAYER_TAG				= "Player";
		public static string ENEMY_TAG				= "Enemy";


		//*************************
		//  LAYERS
		//*************************
		public static string ENEMY_LAYER 			= "EnemyLayer";
		public static string END_WAYPOINT_LAYER 	= "EndWaypointLayer";
		public static string PLATFORM_LAYER 		= "PlatformLayer";


		//*************************
		//  TRIGGERS
		//*************************
		public static string UNIVERSAL_WALKING_TRIGGER 		= "WalkingTrigger";
		public static string UNIVERSAL_IDLE_TRIGGER 		= "IdleTrigger";
		public static string PLAYER_JUMPING_TRIGGER 		= "JumpingTrigger";
		public static string UNIVERSAL_DYING_TRIGGER 		= "DyingTrigger";

		//*************************
		//  DISPLAY TEXT
		//*************************
		public static string TEXT_PROMPT_GAME_OVER_WIN  	 = "You Won!";
		public static string TEXT_PROMPT_GAME_OVER_LOSS   	= "You Lost...";
		public static string TEXT_SCORE  	 				= "Score: ";
		public static string TEXT_LIVES   					= "Lives: ";
		public static string TEXT_POINTS   					= " pts";
		//
	
		//*************************
		//  MODEL DATA
		//*************************
		public static float GAME_MODEL_INITIAL_SCORE		= 0;
		public static float GAME_MODEL_INITIAL_LIVES		= 3;



		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
