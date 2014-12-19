/**
* Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.core.support;
using com.rmc.core.exceptions;
using System;


namespace com.rmc.core.audio
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
	public class AudioManager : SingletonMonobehavior<AudioManager> 
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


		// PRIVATE STATIC
		
		//--------------------------------------
		//  Constructor / Creation
		//--------------------------------------	
		
		/// <summary>
		/// Initialize the specified instance.
		/// </summary>
		/// <param name="instance">Instance.</param>
		public void Initialize ()
		{

		}


		//--------------------------------------
		//  Unity Methods
		//--------------------------------------

		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{

			_audioSource = gameObject.AddComponent <AudioSource>();
			//
			_buttonClick_audioclip 	= _doLoadAudioClipByName ("Audio/SoundEffects/ButtonClick01");

		}


		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}


		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------


		/// <summary>
		/// Dos the play sound.
		/// </summary>
		/// <param name="aClipName">A clip name.</param>
		public void PlaySound (AudioClipType audioClipType)
		{

			//Debug.Log ("playing : " + aClipName);

			switch (audioClipType) {
			case AudioClipType.BUTTON_CLICK:
				_audioSource.PlayOneShot (_buttonClick_audioclip);
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
		private AudioClip _doLoadAudioClipByName (string audioClipName_string)
		{
			AudioClip audioClip = Resources.Load (audioClipName_string) as AudioClip;

			if (audioClip == null) {
				throw new Exception ("AudioClip '"+audioClipName_string+"' Cannot Be Null. Choose new path name");
			}

			return audioClip;

		}
		
		// PUBLIC
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
