//C# Unity event manager that uses strings in a hashtable over delegates and events in order to
//allow use of events without knowing where and when they're declared/defined.
//by Billy Fletcher of Rubix Studios
using UnityEngine;
using System.Collections;
using com.rmc.events;
using System.Linq.Expressions;
 

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.events
{
	
	
	//--------------------------------------
	//  PACKAGE PROPERTIES
	//--------------------------------------
	public delegate void EventDelegate (IEvent iEvent);
	
	
	
	//--------------------------------------
	//  CLASS
	//--------------------------------------
	public class EventDispatcher
	{
			
					
	    private Hashtable _eventListenerDatas_hashtable = new Hashtable();
	 
	 
		/// <summary>
		/// Adds the event listener.
		/// </summary>
		/// <returns>
		/// The event listener.
		/// </returns>
		/// <param name='aEventListener'>
		/// If set to <c>true</c> a event listener.
		/// </param>
		/// <param name='aEventType_string'>
		/// If set to <c>true</c> a event name_string.
		/// </param>
		/// <param name='aEventDelegate'>
		/// If set to <c>true</c> a event delegate.
		/// </param>
	    public bool addEventListener(IEventListener aIEventListener, string aEventType_string, EventDelegate aEventDelegate)
	    {
			
			
	        if (aIEventListener == null || aEventType_string == null) {
	            Debug.Log("Event Manager: addEventListener failed due to no listener or event name specified.");
	            return false;
	        }
	 
			
			//	OUTER
			string keyForOuterHashTable_string = _getKeyForOuterHashTable (aEventType_string);
	        if (!_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string) ) {
	            _eventListenerDatas_hashtable.Add(keyForOuterHashTable_string, new Hashtable());
			}
	 
			//	INNER
	        Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
			EventListenerData eventListenerData = new EventListenerData (aIEventListener, aEventType_string, aEventDelegate);
			//
			string keyForInnerHashTable_string = _getKeyForInnerHashTable (eventListenerData);
	        if (inner_hashtable.Contains(keyForInnerHashTable_string)) {
	            Debug.Log("Event Manager: Listener: " + keyForInnerHashTable_string + " is already in list for event: " + keyForOuterHashTable_string);
	            return false; //listener already in list
	        }
	 
			//	ADD
	        inner_hashtable.Add(keyForInnerHashTable_string, eventListenerData);
			Debug.Log ("	ADDED AT: " + keyForInnerHashTable_string + " = " +  eventListenerData);
			
			
	        return true;
	    }
		
		
	    /// <summary>
	    /// Hases the event listener.
	    /// </summary>
	    /// <returns>
	    /// The event listener.
	    /// </returns>
	    /// <param name='aIEventListener'>
	    /// If set to <c>true</c> a I event listener.
	    /// </param>
	    /// <param name='aEventType_string'>
	    /// If set to <c>true</c> a event name_string.
	    /// </param>
	    /// <param name='aEventDelegate'>
	    /// If set to <c>true</c> a event delegate.
	    /// </param>
	    public bool hasEventListener(IEventListener aIEventListener, string aEventType_string, EventDelegate aEventDelegate)
	    {
			
			//	OUTER
			string keyForOuterHashTable_string = _getKeyForOuterHashTable (aEventType_string);
	        if (!_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string)) {
	            return false;
			}
	        
			//	INNER
			Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
			string keyForInnerHashTable_string = _getKeyForInnerHashTable (new EventListenerData (aIEventListener, aEventType_string, aEventDelegate));
			//
			if (!inner_hashtable.Contains(keyForInnerHashTable_string)) {
	            return false;
			}
	 
	        return true;
	    }
		
	    /// <summary>
	    /// Removes the event listener.
	    /// </summary>
	    /// <returns>
	    /// The event listener.
	    /// </returns>
	    /// <param name='aIEventListener'>
	    /// If set to <c>true</c> a I event listener.
	    /// </param>
	    /// <param name='aEventType_string'>
	    /// If set to <c>true</c> a event name_string.
	    /// </param>
	    /// <param name='aEventDelegate'>
	    /// If set to <c>true</c> a event delegate.
	    /// </param>
	    public bool removeEventListener(IEventListener aIEventListener, string aEventType_string, EventDelegate aEventDelegate)
	    {
			/*
			 * 
			 * 	TODO - SHOULD REUSE 'HAS-A' METHOD IN HERE, RIGHT?
			 * 
			 * */
			
			//	OUTER
			string keyForOuterHashTable_string = _getKeyForOuterHashTable (aEventType_string);
	        if (!_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string)) {
	            return false;
			}
	 
			
			//	INNER
			Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
			string keyForInnerHashTable_string = _getKeyForInnerHashTable (new EventListenerData (aIEventListener, aEventType_string, aEventDelegate));
	        if (!inner_hashtable.Contains(keyForInnerHashTable_string)) {
	            return false;
			}
	 
			
	        inner_hashtable.Remove(aIEventListener);
	        return true;
	    }
	 
	    /// <summary>
	    /// Dispatchs the event.
	    /// </summary>
	    /// <returns>
	    /// The event.
	    /// </returns>
	    /// <param name='aIEvent'>
	    /// If set to <c>true</c> a I event.
	    /// </param>
	    public bool dispatchEvent(IEvent aIEvent)
	    {
			
			//	OUTER
	        string keyForOuterHashTable_string = _getKeyForOuterHashTable (aIEvent.type);
	        if (!_eventListenerDatas_hashtable.ContainsKey(keyForOuterHashTable_string))
	        {
	            Debug.Log("Event Manager: Event \"" + keyForOuterHashTable_string + "\" triggered has no listeners!");
	            return false; //No listeners for event so ignore it
	        }
	 
			//	INNER
			Hashtable inner_hashtable = _eventListenerDatas_hashtable[keyForOuterHashTable_string] as Hashtable;
			IEnumerator i = inner_hashtable.GetEnumerator();
			DictionaryEntry dictionaryEntry;
			EventListenerData eventListenerData;
	        while (i.MoveNext()) {
				
				dictionaryEntry = (DictionaryEntry)i.Current;
				eventListenerData = dictionaryEntry.Value as EventListenerData;
				Debug.Log ("find: " + eventListenerData );
				eventListenerData.eventDelegate (aIEvent);
				//eventListenerData.eventDelegate (aIEvent);
	        }
	 
	        return true;
	    }

		
	    public void OnApplicationQuit()
	    {
	        _eventListenerDatas_hashtable.Clear();
	    }
		
		
		private string _getKeyForOuterHashTable (string aEventType_string)
		{
			return aEventType_string;
		}
		
		private string _getKeyForInnerHashTable (EventListenerData eventListenerData)
		{
			//TODO: MAKE THIS MORE UNIQUE SO YOU CAN LISTEN TO THE SAME EVENT 2 TIMES FROM THE SAME SCOPE (FRINGE CASE)
			return eventListenerData.eventListener.GetType().FullName + eventListenerData.eventName + eventListenerData.eventDelegate.ToString();
		}
	}
}