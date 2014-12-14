using UnityEngine;

namespace com.rmc.support
{

	public abstract class SingletonMonobehavior<T> : MonoBehaviour where T : MonoBehaviour
	{

		//TODO: Suppress. warning here. Harmless
		private static T _Instance;
		public static T Instance
		{
			get
			{
				return _Instance;
			}
			set
			{
				_Instance = value;
			}

		}

		public static bool IsInstantiated()
		{
			return _Instance != null;
		}


		/// <summary>
		/// Instantiate this instance. Creates new model
		/// </summary>
		public static T Instantiate ()
		{

			if (!IsInstantiated())
			{
				GameObject go = new GameObject ();
				_Instance = go.AddComponent<T>();
				go.name = _Instance.GetType().FullName;
				DontDestroyOnLoad (go);

			}
			return _Instance;
		}


		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}
