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
using System.Collections.Generic;
using com.rmc.projects.triple_match.mvc.model.data;
using com.rmc.core.audio;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.mvc.view.view_components
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
	public class GemViewComponent : MonoBehaviour
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// 	GETTER / SETTER

		private GemVO _gemVO;
		public GemVO GemVO
		{
			get
			{
				return _gemVO;
			}
			set
			{
				_gemVO = value;
			}
		}

		


		// 	PUBLIC
		public delegate void OnClickedDelegate (GemViewComponent gemView);
		public OnClickedDelegate OnClicked;

		
		// 	PRIVATE
		[SerializeField]
		private SpriteRenderer _gemSpriteRenderer;
		
		[SerializeField]
		private SpriteRenderer _reticleSpriteRenderer;
		
		[SerializeField]
		private List<Sprite> _sprites;

		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	

		/// <summary>
		/// Initialize the specified gemVO and initialLocalPositionVector3.
		/// </summary>
		/// <param name="gemVO">Gem V.</param>
		/// <param name="initialLocalPositionVector3">Initial local position vector3.</param>
		public void Initialize (GemVO gemVO, Vector3 initialLocalPositionVector3)
		{
			_gemVO = gemVO;
			
			//
			_gemSpriteRenderer.sprite = _sprites[_gemVO.GemTypeIndex];
			
			//
			transform.localPosition = initialLocalPositionVector3; 
			TweenToNewPositionEntry();
		}
		

		
		//--------------------------------------
		//	Unity Methods
		//--------------------------------------
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		protected void OnDestroy () 
		{

		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		//	PUBLIC
		


		/// <summary>
		/// Destroy this instance.
		/// </summary>
		public void Destroy ()
		{
			Destroy (gameObject);
		}

		
		
		/// <summary>
		/// Tweens to new position.
		/// </summary>
		public void TweenToNewPositionEntry ()
		{
			_TweenToNewPosition (TripleMatchConstants.GetGemTweenEntryDelay(_gemVO), _GetTargetPosition());
			
		}

		/// <summary>
		/// Tweens to new position.
		/// </summary>
		public void TweenToNewPositionSwap (float delayToStart_float)
		{
			_TweenToNewPosition (delayToStart_float, _GetTargetPosition());

			//	SOUND
			if (AudioManager.IsInstantiated())
			{
				AudioManager.Instance.PlayAudioResourcePath (TripleMatchConstants.PATH_GEM_SWAP_AUDIO, TripleMatchConstants.VOLUME_SCALE_SFX_1);
			}
			
		}


		/// <summary>
		/// Tweens to new position exit.
		/// </summary>
		public void TweenToNewPositionExit ()
		{

			//	ADD PHYSICS TO THIS (OTHERWISE NON-PHYSICS GAME) JUST TO GET A NICE FALLING GEM APPEARANCE
			gameObject.AddComponent<Rigidbody2D>();
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			gameObject.GetComponent<Rigidbody2D>().AddForce ( TripleMatchConstants.GetGemExitPhysicsForce());
			_ShrinkAndExplode();
		}





		//	PRIVATE

		private void _ShrinkAndExplode ()
		{

			iTween.ScaleTo(
				_gemSpriteRenderer.gameObject,
				iTween.Hash
				(
				iT.ScaleTo.x, 		0.6f,
				iT.ScaleTo.y,		0.6f,
				iT.ScaleTo.easetype, iTween.EaseType.easeInOutExpo,
				iT.ScaleTo.time,	0.5f,
				iT.ScaleTo.delay, 	0
				)
				);

			GameObject gemExplosionPrefab = Instantiate (Resources.Load (TripleMatchConstants.PATH_GEM_EXPLOSION_PREFAB)) as GameObject;
			gemExplosionPrefab.GetComponent<GemExplosionViewComponent>().Initialize (_gemVO);
			gemExplosionPrefab.transform.SetParent (transform, false);

		}

		/// <summary>
		/// Tweens to new position.
		/// </summary>
		private void _TweenToNewPosition (float durationGemTweenDelay_float, Vector3 targetPosition_vector3)
		{
			iTween.MoveTo(
				gameObject,
				iTween.Hash
				(
				iT.MoveTo.x, 		targetPosition_vector3.x,
				iT.MoveTo.y,		targetPosition_vector3.y,
				iT.MoveTo.easetype, iTween.EaseType.easeInOutExpo,
				iT.MoveTo.time,		TripleMatchConstants.DURATION_GEM_TWEEN_SWAP,
				iT.MoveTo.delay, 	durationGemTweenDelay_float,
				iT.MoveTo.islocal,	 true
				)
				);
			
		}
		
		
		/// <summary>
		/// Toggle Highlight - use alpha
		/// 
		/// 	OPTION: Add outline, dropshadow, targeting reticle, etc... instead of alpha
		/// 
		/// </summary>
		public void SetIsHighlighted (bool isHighlighted)
		{
			Color color = _gemSpriteRenderer.material.color;
			
			
			if (isHighlighted)
			{
				color.a = 0.9f;
				
			}
			else
			{
				color.a = 1f;
			}
			
			_gemSpriteRenderer.material.color = color;
			_reticleSpriteRenderer.enabled = isHighlighted;
		}
		
		


		
		
		//	PRIVATE
		
		
		/// <summary>
		/// _s the get target position.
		/// </summary>
		private Vector3 _GetTargetPosition ()
		{
			return new Vector3 (
				_gemVO.ColumnIndex*TripleMatchConstants.COLUMN_SIZE, 
				-_gemVO.RowIndex*TripleMatchConstants.ROW_SIZE, 
				transform.localPosition.z);
		}

		
		
		
		//--------------------------------------
		//	Event Handlers
		//--------------------------------------

		/// <summary>
		/// Raises the mouse down event.
		/// </summary>
		private void OnMouseDown ()
		{
			
			if (OnClicked != null)
			{
				OnClicked (this);
			}
			
		}
		
		/// <summary>
		/// Raises the mouse up event.
		/// </summary>
		private void OnMouseUp ()
		{
			
			//	OPTION: USE THIS INSTEAD OF OnMouseDown in all cases for a different UX
			
		}
	}
}