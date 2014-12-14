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
using com.rmc.projects.triple_match.model.data;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.view
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
	public class GemView : AbstractView
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

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

		
		[SerializeField]
		public SpriteRenderer _gemSpriteRenderer;
		
		[SerializeField]
		public SpriteRenderer _reticleSpriteRenderer;
		
		[SerializeField]
		public List<Sprite> _sprites;

		public delegate void OnClickedDelegate (GemView gemView);
		public OnClickedDelegate OnClicked;

		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	


		public void Initialize (GemVO gemVO, Vector3 initialLocalPositionVector3)
		{
			_gemVO = gemVO;
			
			//
			_gemSpriteRenderer.sprite = _sprites[_gemVO.GemTypeIndex];
			
			//
			transform.localPosition = initialLocalPositionVector3; 
			TweenToNewPosition();
		}
		

		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy () 
		{

		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// PUBLIC
		


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
		public void TweenToNewPosition ()
		{
			Vector3 newPosition = _GetTargetPosition();
			
			iTween.MoveTo(
				gameObject,
				iTween.Hash
				(
				iT.MoveTo.x, 		newPosition.x,
				iT.MoveTo.y,		newPosition.y,
				iT.MoveTo.easetype, iTween.EaseType.easeInOutExpo,
				iT.MoveTo.time,		TripleMatchConstants.DURATION_GEM_TWEEN_SWAP,
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
				_gemVO.RowIndex*TripleMatchConstants.ROW_SIZE, 
				_gemVO.ColumnIndex*TripleMatchConstants.COLUMN_SIZE, 
				transform.localPosition.z);
		}

		
		
		
		//--------------------------------------
		// 	Event Handlers
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