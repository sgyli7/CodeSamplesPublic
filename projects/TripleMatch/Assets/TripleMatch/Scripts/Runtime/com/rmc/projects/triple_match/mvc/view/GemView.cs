using UnityEngine;
using System.Collections.Generic;
using com.rmc.projects.triple_match.model.data;


namespace com.rmc.projects.triple_match.view
{
	
	
	public class GemView : AbstractView
	{

		[SerializeField]
		public SpriteRenderer _gemSpriteRenderer;

		[SerializeField]
		public SpriteRenderer _reticleSpriteRenderer;

		[SerializeField]
		public List<Sprite> _sprites;

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

		public delegate void OnClickedDelegate (GemView gemView);
		public OnClickedDelegate OnClicked;


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


		public void Initialize (GemVO gemVO, Vector3 initialLocalPositionVector3)
		{
			_gemVO = gemVO;

			//
			_gemSpriteRenderer.sprite = _sprites[_gemVO.GemTypeIndex];

			//
			transform.localPosition = initialLocalPositionVector3; 
			TweenToNewPosition();
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		override protected void Start () 
		{
			
		}
		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		override protected void Update () 
		{
			
		}


		/// <summary>
		/// Destroy this instance.
		/// </summary>
		public void Destroy ()
		{
			Destroy (gameObject);
		}

		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy () 
		{
		}


		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _Render ()
		{

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
