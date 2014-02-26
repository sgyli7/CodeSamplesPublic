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
using strange.extensions.mediation.impl;
using com.rmc.projects.scientific_calculator.mvcs.model.vo;
using com.rmc.exceptions;
using System.Collections.Generic;
using System.Linq;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.scientific_calculator.mvcs.view.ui
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
		/// When the audio clip_list.
		/// </summary>
		public List<AudioClip> audioClip_list;

		// PUBLIC STATIC

		// PRIVATE
		/// <summary>
		/// When the _audio source game object_list.
		/// </summary>
		private List<GameObject> _audioSourceGameObject_list;

		/// <summary>
		/// When the _audio source_list.
		/// </summary>
		private List<AudioSource> _audioSource_list;

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

			_doCreateAllAudioSources();


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

			//Debug.Log ("playSound: " + aSoundPlayVO.soundType);
			switch (aSoundPlayVO.soundType){
			case SoundType.BUTTON_CLICK:
				_getAudioSourceByIndex(0).clip = _getAudioClipByName ("ButtonClick01");
				_getAudioSourceByIndex(0).Play ();
				break;
			case SoundType.GAME_OVER_WIN:
				_getAudioSourceByIndex(1).clip = _getAudioClipByName ("GameOverWin");
				_getAudioSourceByIndex(1).Play ();
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException(aSoundPlayVO.soundType);
				break;
				#pragma warning restore 0162
			}
		}


		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Do create all audio sources.
		/// </summary>
		void _doCreateAllAudioSources ()
		{
			_audioSourceGameObject_list = new List<GameObject>();
			_audioSource_list 			= new List<AudioSource>();
			GameObject nextAudioSource_gameobject;
			#pragma warning disable 0219
			foreach (AudioClip audioClip in audioClip_list) {
				
				nextAudioSource_gameobject = new GameObject ();
				nextAudioSource_gameobject.name = "AudioSource";
				nextAudioSource_gameobject.transform.parent = transform;
				nextAudioSource_gameobject.AddComponent<AudioSource>();
				//
				_audioSourceGameObject_list.Add (nextAudioSource_gameobject);
				_audioSource_list.Add (nextAudioSource_gameobject.GetComponent<AudioSource>());
			}
			#pragma warning restore 0219
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="com.rmc.projects.spider_strike.mvcs.view.ui.SoundManagerUI"/> class.
		/// </summary>
		/// <param name="aIndex_int">A index_int.</param>
		private AudioSource _getAudioSourceByIndex (int aIndex_int)
		{

			return _audioSource_list[aIndex_int];

		}




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

