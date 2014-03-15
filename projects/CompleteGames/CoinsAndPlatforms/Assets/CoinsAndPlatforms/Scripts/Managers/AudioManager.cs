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
using System.Collections.Generic;
using System.Collections;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.berlinminijam
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
			PLAYER_JUMPS,
			PLAYER_LANDS,
			BARREL_LANDS,
			PLAYER_HIT_BY_BARREL,
			COVER_CLOSES,
			BOSS_THROWS_BARREL

		}
		
		// PRIVATE
		/// <summary>
		/// The _audio source.
		/// </summary>
		private AudioSource _audioSource;

		/// <summary>
		/// ALL THE CLIPS
		/// </summary>
		private AudioClip _playerJumps_audioclip;
		private AudioClip _playerLands_audioclip;
		private AudioClip _barrelLands_audioclip;
		private AudioClip _playerHitByBarrel_audioclip;
		private AudioClip _coverCloses_audioclip;
		private AudioClip _bossThrowsBarrel_audioclip;


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
			_playerJumps_audioclip 			= Resources.Load("PlayerJumpFromGround") as AudioClip;
			_playerLands_audioclip 			= Resources.Load("PlayerLandOnGround") as AudioClip;
			_playerHitByBarrel_audioclip 	= Resources.Load("PlayerHitByBarrel") as AudioClip;
			_barrelLands_audioclip 			= Resources.Load("BarrelCollideWithGround") as AudioClip;
			_coverCloses_audioclip 			= Resources.Load("CoverCloses") as AudioClip;
			_bossThrowsBarrel_audioclip 	= Resources.Load("BossThrowsBarrel") as AudioClip;

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

			//Debug.Log ("playing : " + aClipName);

			switch (aClipName) {
			case CLIP_NAME.PLAYER_JUMPS:
				_audioSource.PlayOneShot (_playerJumps_audioclip);
				break;
			case CLIP_NAME.PLAYER_LANDS:
				_audioSource.PlayOneShot (_playerLands_audioclip);
				break;
			case CLIP_NAME.PLAYER_HIT_BY_BARREL:
				_audioSource.PlayOneShot (_playerHitByBarrel_audioclip);
				break;
			case CLIP_NAME.BARREL_LANDS:
				_audioSource.PlayOneShot (_barrelLands_audioclip);
				break;
			case CLIP_NAME.COVER_CLOSES:
				_audioSource.PlayOneShot (_coverCloses_audioclip);
				break;
			case CLIP_NAME.BOSS_THROWS_BARREL:
				_audioSource.PlayOneShot (_bossThrowsBarrel_audioclip);
				break;


			}
			

		}
		
		// PUBLIC
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
