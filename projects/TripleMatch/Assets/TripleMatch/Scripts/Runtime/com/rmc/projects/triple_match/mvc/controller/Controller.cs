using UnityEngine;
using System.Collections;
using com.rmc.support;
using com.rmc.projects.triple_match.model;


namespace com.rmc.projects.triple_match.controller
{
	
	public class Controller: SingletonMonobehavior<Controller>
	{


		private Model _model;


		/// <summary>
		/// Initialize the specified instance.
		/// </summary>
		/// <param name="instance">Instance.</param>
		public void Initialize (Model model)
		{
			_model = model;
		}

		
		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{
			
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
			_model.GameReset();
		}
	}
}
