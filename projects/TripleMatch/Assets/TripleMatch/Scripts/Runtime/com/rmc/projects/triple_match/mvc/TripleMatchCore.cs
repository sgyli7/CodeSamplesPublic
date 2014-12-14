using UnityEngine;
using System.Collections.Generic;
using com.rmc.projects.triple_match.model;
using com.rmc.projects.triple_match.controller;
using com.rmc.projects.triple_match.view;
using com.rmc.support;
using System.Collections;


namespace com.rmc.projects.triple_match.view
{

	public class TripleMatchCore : SingletonMonobehavior<TripleMatchCore> 
	{


		/// <summary>
		/// All views for the game
		/// </summary>
		[SerializeField]
		private List<AbstractView> _abstractViews;



		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{

			//	MODEL
			Model.Instantiate();

			//	CONTROLLER
			Controller.Instantiate();
			Controller.Instance.Initialize (Model.Instance);


			//	VIEW
			foreach (AbstractView abstractview in _abstractViews)
			{
				abstractview.Initialize (Model.Instance, Controller.Instance);
			}

			//	Mimic 'Game Reset' Click
			//	After short delay ...
			//		1. of 1 frame or more for View to be 'ready'
			//		2. and its also a delay for cosmetics
			StartCoroutine (_startGame_Coroutine());
		}


		/// <summary>
		/// Update this instance.
		/// </summary>
		protected void Update () 
		{
		
		}


		/// <summary>
		/// Starts the game after short delay.
		/// </summary>
		private IEnumerator _startGame_Coroutine ()
		{
			yield return new WaitForSeconds (TripleMatchConstants.DELAY_TO_START_GAME);

			//	Mimic 'Game Reset' Click
			Controller.Instance.GameReset();

			yield return 0;
		}
	}
}
