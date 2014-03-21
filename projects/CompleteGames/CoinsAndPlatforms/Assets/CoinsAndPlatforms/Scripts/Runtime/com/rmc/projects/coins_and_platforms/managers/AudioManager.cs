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
using com.rmc.exceptions;
using System;
using com.rmc.projects.coins_and_platforms.constants;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.managers
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	//todo: move this to MainConstants?
	public enum AudioClipType
	{
		BUTTON_CLICK,
		WAYPOINT_TRIGGERED,
		PLAYER_JUMPS,
		PLAYER_LANDS,
		PLAYER_KILLS_ENEMY,
		PLAYER_FALLS_OFFSCREEN,
		COIN_COLLECTED,
		ENEMY_KILLS_PLAYER,
		GAME_START,
		GAME_OVER_WIN,
		GAME_OVER_LOSS
		
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class AudioManager : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC


		// PRIVATE
		/// <summary>
		/// The _audio source.
		/// </summary>
		private AudioSource _audioSource;

		/// <summary>
		/// ALL THE CLIPS
		/// </summary>
		private AudioClip _buttonClick_audioclip;
		private AudioClip _playerJumps_audioclip;
		private AudioClip _playerLands_audioclip;
		private AudioClip _playerFallsOffscreen_audioclip;
		private AudioClip _waypointTriggered_audioclip;
		private AudioClip _playerKillsEnemy_audioclip;
		private AudioClip _coinCollected_audioclip;
		private AudioClip _enemyKillsPlayer_audioclip;
		private AudioClip _gameStart_audioclip;
		private AudioClip _gameOverWin_audioclip;
		private AudioClip _gameOverLoss_audioclip;



		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public AudioManager ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~AudioManager ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{

			_audioSource = gameObject.AddComponent <AudioSource>();
			//
			_buttonClick_audioclip 			= _doLoadAudioClipByName (MainConstants.AUDIO_BUTTON_CLICK_01);
			_waypointTriggered_audioclip 	= _doLoadAudioClipByName (MainConstants.AUDIO_WAYPOINT_TRIGGERED_01);
			_playerFallsOffscreen_audioclip = _doLoadAudioClipByName (MainConstants.AUDIO_PLAYER_FALLS_OFFSCREEN_01);
			_playerJumps_audioclip			= _doLoadAudioClipByName (MainConstants.AUDIO_PLAYER_JUMPS_01);
			_playerLands_audioclip 			= _doLoadAudioClipByName (MainConstants.AUDIO_PLAYER_LANDS_01);
			_playerKillsEnemy_audioclip 	= _doLoadAudioClipByName (MainConstants.AUDIO_PLAYER_KILLS_ENEMY_01);
			_coinCollected_audioclip 		= _doLoadAudioClipByName (MainConstants.AUDIO_COINS_COLLECTED_01);
			_enemyKillsPlayer_audioclip     = _doLoadAudioClipByName (MainConstants.AUDIO_ENEMY_KILLS_PLAYER_01);
			_gameStart_audioclip 			= _doLoadAudioClipByName (MainConstants.AUDIO_GAME_START_01);
			_gameOverWin_audioclip 			= _doLoadAudioClipByName (MainConstants.AUDIO_GAME_OVER_WIN_01);
			_gameOverLoss_audioclip 		= _doLoadAudioClipByName (MainConstants.AUDIO_GAME_OVER_LOSS_01);


			//
			SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.GAME_START);

		}


		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}

		/// <summary>
		/// Dos the play sound.
		/// </summary>
		/// <param name="aClipName">A clip name.</param>
		public void doPlaySound (AudioClipType aClipName)
		{

			//Debug.Log ("playing : " + aClipName);

			switch (aClipName) {
			case AudioClipType.BUTTON_CLICK:
				_audioSource.PlayOneShot (_buttonClick_audioclip);
				break;
			case AudioClipType.WAYPOINT_TRIGGERED:
				_audioSource.PlayOneShot (_waypointTriggered_audioclip);
				break;
			case AudioClipType.PLAYER_JUMPS:
				_audioSource.PlayOneShot (_playerJumps_audioclip);
				break;
			case AudioClipType.PLAYER_LANDS:
				_audioSource.PlayOneShot (_playerLands_audioclip);
				break;
			case AudioClipType.PLAYER_KILLS_ENEMY:
				_audioSource.PlayOneShot (_playerKillsEnemy_audioclip);
				break;
			case AudioClipType.PLAYER_FALLS_OFFSCREEN:
				_audioSource.PlayOneShot (_playerFallsOffscreen_audioclip);
				break;
			case AudioClipType.COIN_COLLECTED:
				_audioSource.PlayOneShot (_coinCollected_audioclip);
				break;
			case AudioClipType.ENEMY_KILLS_PLAYER:
				_audioSource.PlayOneShot (_enemyKillsPlayer_audioclip);
				break;
			case AudioClipType.GAME_START:
				_audioSource.PlayOneShot (_gameStart_audioclip);
				break;
			case AudioClipType.GAME_OVER_WIN:
				_audioSource.PlayOneShot (_gameOverWin_audioclip);
				break;
			case AudioClipType.GAME_OVER_LOSS:
				_audioSource.PlayOneShot (_gameOverLoss_audioclip);
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
			

		}



		/// <summary>
		/// _loads the name of the audio clip by.
		/// </summary>
		/// <returns>The audio clip by name.</returns>
		/// <param name="aAudioClipName_string">A audio clip name_string.</param>
		private AudioClip _doLoadAudioClipByName (string aAudioClipName_string)
		{
			AudioClip audioClip = Resources.Load (aAudioClipName_string) as AudioClip;

			if (audioClip == null) {
				throw new Exception ("AudioClip '"+aAudioClipName_string+"' Cannot Be Null. Choose new path name");
			}

			return audioClip;

		}
		
		// PUBLIC
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
