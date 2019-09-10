using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject.Events
{
    /// <summary>
    /// Asset based event that can work isolated from the scene.
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Event")]
    public class Event : ScriptableObject
    {
        [SerializeField] private UnityEvent onEvent;

        /// <summary>
        /// Add runtime listener to the event
        /// </summary>
        /// <param name="eventListener"> Callback function </param>
        public void AddListener(UnityAction eventListener)
        {
            onEvent.AddListener(eventListener);
        }

        /// <summary>
        /// Remove runtime listener from the event
        /// </summary>
        /// <param name="eventListener"> Callback function </param>
        public void RemoveListener(UnityAction eventListener)
        {
            onEvent.RemoveListener(eventListener);
        }

        /// <summary>
        /// Rise the event.
        /// </summary>
        public void Rise()
        {
            onEvent.Invoke();
        }
    }

}