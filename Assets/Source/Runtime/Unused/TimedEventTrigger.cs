using System.Collections;
using System.Collections.Generic;
using TestProject.GameData;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject.Utilities
{
    /// <summary>
    /// Unused
    /// </summary>
    public class TimedEventTrigger : MonoBehaviour
    {
        [SerializeField] private Object time;
        [SerializeField] private UnityEvent onEvent;

        private float timer;

        public float Time => ((IVariable<float>)time).GetValue();

        private void OnValidate()
        {
            if (!(time is IVariable<float>))
            {
                time = null;
            }
        }

        private void Update()
        {
            if (timer == -1)
                return;

            if (timer >= Time)
            {
                timer = -1;
                onEvent.Invoke();
            }

            timer += UnityEngine.Time.deltaTime;
        }

        public void Reset()
        {
            timer = 0;
        }
    }

}
