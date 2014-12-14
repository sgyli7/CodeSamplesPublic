using UnityEngine;
using com.rmc.support;
using System.Collections.Generic;
using System.Collections;
using com.rmc.projects.triple_match.model.data;


namespace com.rmc.projects.triple_match.model
{

	public class Model: SingletonMonobehavior<Model>
	{ 

		private GemVO[,] _gemVOs;
		public GemVO[,] GemVOs
		{
			get
			{
				return _gemVOs;
			}

		}


		//

		public delegate void OnGameResettedDelegate ();
		public OnGameResettedDelegate OnGameResetted;


		/// <summary>
		/// 
		/// Score
		/// 	Model - stores it
		/// 	View - displays it (via delegate listening)
		/// 	Controller - updates it
		/// 
		/// </summary>
		public delegate void OnScoreChangedDelegate (int newScore);
		public OnScoreChangedDelegate OnScoreChanged;
		private int _score;
		public int Score 
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
				if (OnScoreChanged != null)
				{
					OnScoreChanged (_score);
				}
			}
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{
			Debug.Log ("MOdel.Start()");
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
		}
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		protected void Update () 
		{
		
		}


		/// <summary>
		/// Resets the game.
		/// </summary>
		public void GameReset ()
		{

			Score = 0;



			//	CLEAR EXISTING GEMS
			foreach (GemVO gemVO in _gemVOs)
			{
				//	TODO: CLEAR EACH
			}
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];


			//	CREATE ALL NEW GEMS
			GemVO nextGemVO;
			int nextGemTypeIndex;
			//
			for (int rowIndex_int = 0; rowIndex_int < TripleMatchConstants.MAX_ROWS; rowIndex_int++)
			{
				for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
				{
					//	SET INDEX (THIS MEANS THE COLOR)
					nextGemTypeIndex = Random.Range (0, TripleMatchConstants.MAX_GEM_TYPE_INDEX);

					//	CREATE 1 NEW GEM
					nextGemVO = new GemVO (rowIndex_int, columnIndex_int, nextGemTypeIndex);
					_gemVOs[rowIndex_int, columnIndex_int] = nextGemVO;
				}
			}


			Debug.Log (this);

			if (OnGameResetted != null)
			{
				OnGameResetted ();
			}
		}




		/// <summary>
		/// Show nice debuggable output
		/// </summary>
		override public string ToString ()
		{
			string s = "";
			s+= "[Model] (Single Click For *Gem* Grid Output)";
			s+= "\n";
			for (int x = 0; x < _gemVOs.GetLength(0); x += 1) 
			{
				for (int y = 0; y < _gemVOs.GetLength(1); y += 1) 
				{
					s += _gemVOs[x,y].GemTypeIndex;
				}
				s += "\n";
			}
			return s;
			
		}
	}
}
