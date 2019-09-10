using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject.Events
{
    /// <summary>
    /// Listens to the asset based event and executes respone UnityEvent.
    /// </summary>
    public class EventListener : MonoBehaviour
    {
        [SerializeField] private Event sourceEvent;
        [SerializeField] private UnityEvent onEvent;

        private void OnEnable()
        {
            sourceEvent.AddListener(OnEvent);
        }

        private void OnDisable()
        {
            sourceEvent.RemoveListener(OnEvent);
        }

        /// <summary>
        /// Response to the event
        /// </summary>
        private void OnEvent()
        {
            onEvent.Invoke();
        }
    }

}