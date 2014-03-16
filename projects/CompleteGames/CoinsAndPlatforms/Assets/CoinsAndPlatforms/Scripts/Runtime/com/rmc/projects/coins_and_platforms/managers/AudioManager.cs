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
using com.rmc.exceptions;


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
	public class AudioManager : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		public enum CLIP_NAME
		{
			BUTTON_CLICK,
			PLAYER_JUMPS,
			PLAYER_LANDS,
			PLAYER_KILLS_ENEMY,
			ENEMY_KILLS_PLAYER,
			GAME_OVER_WIN,
			GAME_OVER_LOSS

		}

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
		private AudioClip _playerKillsEnemy_audioclip;
		private AudioClip _enemyKillsPlayer_audioclip;
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

			return;
			_audioSource = gameObject.AddComponent <AudioSource>();
			//
			_buttonClick_audioclip 			= _loadAudioClipByName ("PlayerJumpFromGround");
			_playerJumps_audioclip			= _loadAudioClipByName ("PlayerLandOnGround");
			_playerLands_audioclip 			= _loadAudioClipByName ("PlayerLandOnGround");
			_playerKillsEnemy_audioclip 	= _loadAudioClipByName ("PlayerHitByBarrel");
			_enemyKillsPlayer_audioclip     = _loadAudioClipByName ("PlayerHitByBarrel");
			_gameOverWin_audioclip 			= _loadAudioClipByName ("CoverCloses");
			_gameOverLoss_audioclip 		= _loadAudioClipByName ("BossThrowsBarrel");

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
		public void doPlaySound (CLIP_NAME aClipName)
		{

			return;
			//Debug.Log ("playing : " + aClipName);

			switch (aClipName) {
			case CLIP_NAME.BUTTON_CLICK:
				_audioSource.PlayOneShot (_buttonClick_audioclip);
				break;
			case CLIP_NAME.PLAYER_JUMPS:
				_audioSource.PlayOneShot (_playerJumps_audioclip);
				break;
			case CLIP_NAME.PLAYER_LANDS:
				_audioSource.PlayOneShot (_playerLands_audioclip);
				break;
			case CLIP_NAME.PLAYER_KILLS_ENEMY:
				_audioSource.PlayOneShot (_playerKillsEnemy_audioclip);
				break;
			case CLIP_NAME.ENEMY_KILLS_PLAYER:
				_audioSource.PlayOneShot (_enemyKillsPlayer_audioclip);
				break;
			case CLIP_NAME.GAME_OVER_WIN:
				_audioSource.PlayOneShot (_gameOverWin_audioclip);
				break;
			case CLIP_NAME.GAME_OVER_LOSS:
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
		private AudioClip _loadAudioClipByName (string aAudioClipName_string)
		{
			return _loadAudioClipByName ("/Audio/SoundEffects/" + aAudioClipName_string) as AudioClip;

		}
		
		// PUBLIC
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
