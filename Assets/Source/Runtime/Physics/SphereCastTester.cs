using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject
{
    /// <summary>
    /// Casts a sphere towards specific direction and checks if any collider was hit by a sphere
    /// </summary>
    public class SphereCastTester : MonoBehaviour
    {
        [SerializeField] private float radius = 0.5f;
        [SerializeField] private float distance = 25;
        [SerializeField] private Vector3 direction = Vector3.forward;
        [SerializeField] private QueryTriggerInteraction triggerInteraction;
        [SerializeField] private GameObject testObject;
        [SerializeField] private LayerMask testLayerMask;
        [SerializeField] private string testTag;
        [SerializeField] private TestMode mode = TestMode.Object;
        [SerializeField] private Transform originTransform;

        [SerializeField] private UnityEvent onFound;
        [SerializeField] private UnityEvent onLost;

        private bool lastResult;

        private void Update()
        {
            bool result = false;
            RaycastHit hit;
            if (Physics.SphereCast(
                transform.position,
                radius,
                direction,
                out hit,
                distance,
                mode == TestMode.LayerMask ? testLayerMask.value : 0,
                triggerInteraction))
            {
                switch (mode)
                {
                    case TestMode.Object:
                        result = hit.collider.gameObject == testObject;
                        break;
                    case TestMode.LayerMask:
                        result = true;
                        break;
                    case TestMode.Tag:
                        result = hit.collider.tag == testTag;
                        break;
                }
            }

            if (!result)
            {
                if (lastResult)
                {
                    onLost.Invoke();
                }
            }
            else
            {
                if (!lastResult)
                {
                    onFound.Invoke();
                }
            }
            lastResult = result;
        }

        private void Reset()
        {
            originTransform = transform;
        }

        private void OnDrawGizmosSelected()
        {
            if (originTransform == null)
                return;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(originTransform.position, radius);
            Gizmos.DrawRay(originTransform.position, direction * distance);
            Gizmos.DrawWireSphere(originTransform.position + direction * distance, radius);
        }

        /// <summary>
        /// The test mode of the <see cref="SphereCastTester"/>
        /// </summary>
        public enum TestMode
        {
            Object,
            LayerMask,
            Tag
        }
    }

}
