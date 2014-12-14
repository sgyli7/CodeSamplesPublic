using UnityEngine;
using System.Collections.Generic;
using com.rmc.projects.triple_match.model.data;


namespace com.rmc.projects.triple_match.view
{
	
	
	public class GemView : AbstractView
	{

		[SerializeField]
		public SpriteRenderer _spriteRenderer;

		[SerializeField]
		public List<Sprite> _sprites;

		private GemVO _gemVO;


		public void Initialize (GemVO gemVO)
		{
			_gemVO = gemVO;

			//
			_spriteRenderer.sprite = _sprites[_gemVO.GemTypeIndex];

			//
			transform.localPosition = new Vector3 (_gemVO.RowIndex*0.4f, _gemVO.ColumnIndex*0.4f, transform.localPosition.z);
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
		
		
	}
	
}
