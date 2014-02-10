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
using strange.extensions.mediation.impl;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.spider_strike.mvcs.model.vo;
using com.rmc.exceptions;
using System.Collections.Generic;
using System.Linq;


namespace com.rmc.projects.spider_strike.mvcs.view.ui
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
	public class SoundManagerUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The audio channel01_gameobject.
		/// </summary>
		public GameObject audioChannel01_gameobject;

		/// <summary>
		/// The audio channel02_gameobject.
		/// </summary>
		public GameObject audioChannel02_gameobject;

		/// <summary>
		/// The audio channel02_gameobject.
		/// </summary>
		public GameObject audioChannel03_gameobject;

		
		/// <summary>
		/// The audio clip_list.
		/// </summary>
		public List<AudioClip> audioClip_list;

		// PUBLIC STATIC

		// PRIVATE
		/// <summary>
		/// The audio source01.
		/// </summary>
		private AudioSource _audioSource01;
		
		/// <summary>
		/// The audio source02.
		/// </summary>
		private AudioSource _audioSource02;

		/// <summary>
		/// The audio source02.
		/// </summary>
		private AudioSource _audioSource03;

		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();

			//TODO: CHANGE THIS TO A LIST BASED SYSTEM FOR MORE CHANNELS?
			_audioSource01 = audioChannel01_gameobject.GetComponent<AudioSource>();
			_audioSource02 = audioChannel02_gameobject.GetComponent<AudioSource>();
			_audioSource03 = audioChannel03_gameobject.GetComponent<AudioSource>();


		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			
			
		}

		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
		}
		
		// PUBLIC
		/// <summary>
		/// Plaies the sound.
		/// </summary>
		/// <param name="aSoundPlayVO">A sound play V.</param>
		public void playSound (SoundPlayVO aSoundPlayVO)
		{
			switch (aSoundPlayVO.soundType){
			case SoundType.BUTTON_CLICK:
				_audioSource01.clip = _getAudioClipByName ("ButtonClick01");
				_audioSource01.Play ();
				break;
			case SoundType.TURRET_FIRE:
				_audioSource01.clip = _getRandomAudioClipFromNameArray ( new string[] {"TurretFire01","TurretFire02"} );
				_audioSource01.Play ();
				break;
			case SoundType.ENEMY_FOOSTEP:
				_audioSource03.clip = _getRandomAudioClipFromNameArray ( new string[] {"EnemyFootstep01","EnemyFootstep02"} );
				_audioSource03.Play ();
				break;
			case SoundType.ENEMY_ATTACK:
				_audioSource01.clip = _getRandomAudioClipFromNameArray ( new string[] {"EnemyAttack01","EnemyAttack02"} );
				_audioSource01.Play ();
				break;
			case SoundType.ENEMY_DAMAGED:

				//overlaps fire sound, so skip this?
				//_audioSource01.clip = _getAudioClipByName ("ButtonClick01");
				//_audioSource01.Play ();
				break;

			case SoundType.ENEMY_DIE:
				_audioSource03.clip = _getRandomAudioClipFromNameArray ( new string[] {"EnemyDie01","EnemyDie02"});
				_audioSource03.Play ();

				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
		}

		/// <summary>
		/// Plaies the music.
		/// </summary>
		public void playMusic ()
		{
			_audioSource02.clip = _getAudioClipByName ("BackgroundMusic01");
			_audioSource02.loop = true;
			_audioSource02.Play ();
		}

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _gets the name of the audio clip by.
		/// </summary>
		/// <returns>The audio clip by name.</returns>
		/// <param name="aName_string">A name_string.</param>
		private AudioClip _getAudioClipByName (string aName_string)
		{
			return audioClip_list.Where(audioClip => audioClip.name == aName_string).SingleOrDefault();
		}

		/// <summary>
		/// _gets the random audio clip from name array.
		/// </summary>
		/// <returns>The random audio clip from name array.</returns>
		/// <param name="aString_array">A string_array.</param>
		private AudioClip _getRandomAudioClipFromNameArray (string[] aString_array)
		{
			string name_string = aString_array[Random.Range (0, aString_array.Length)];
			return _getAudioClipByName (name_string);
		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		
		
	}
}

