using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Utilities
{
    /// <summary>
    /// An extension to the transform component with usefull utility methods.
    /// </summary>
    public class TransformExtension : MonoBehaviour
    {
        [SerializeField] private Transform targetTrasnform;
        private Vector3 initialLocalScale;
        private Vector3 initialPosition;

        /// <summary>
        /// Reset position of the transform to the position since component was enabled.
        /// </summary>
        public void ResetPosition()
        {
            targetTrasnform.position = initialPosition;
        }

        /// <summary>
        /// Reset local scale of the transform to the scale since component was enabled
        /// </summary>
        public void ResetLocalScale()
        {
            targetTrasnform.localScale = initialLocalScale;
        }

        private void Awake()
        {
            initialLocalScale = targetTrasnform.localScale;
            initialPosition = targetTrasnform.position;
        }

        private void Reset()
        {
            targetTrasnform = transform;
        }
    }
}
