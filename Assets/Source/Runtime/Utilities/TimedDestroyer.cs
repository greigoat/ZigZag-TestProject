using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Utilities
{
    /// <summary>
    /// Destroys a game object after specific amount of time
    /// </summary>
    public class TimedDestroyer : MonoBehaviour
    {
        [SerializeField] private float time;
        [SerializeField] private GameObject targetObject;
        [SerializeField] private bool disableOnly; // Should we completely destroy the object or just disable it?

        private float timer;

        public void Reset()
        {
            timer = 0;
        }

        private void Update()
        {
            if (timer == -1)
                return;

            if (timer >= time)
            {
                DestroyObject();
                timer = -1;
            }
            timer += Time.deltaTime;
        }

        private void DestroyObject()
        {
            if (disableOnly)
                targetObject.SetActive(false);
            else
                Destroy(targetObject);
        }
    }

}
