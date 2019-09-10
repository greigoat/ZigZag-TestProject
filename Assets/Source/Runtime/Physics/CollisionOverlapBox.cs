using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
///  Detects collision on a box.
///  Does not require a rigidbody to function.
/// </summary>
public class CollisionOverlapBox : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 size = Vector3.one;
    [SerializeField] private Vector3 centerOffset;
    [SerializeField] private bool triggerOnlyDetection;
    [SerializeField] private LayerMask collisionMask = new LayerMask() { value = 0 };

    [Header("Events")]
    [SerializeField] private CollisionUnityEvent onCollisionEnter;
    [SerializeField] private CollisionUnityEvent onCollisionStay;
    [SerializeField] private CollisionUnityEvent onCollisionExit;

#if UNITY_EDITOR
    [Header("Collision Debugging")]
    [SerializeField] private bool alwaysShowGizmo;
    [SerializeField] private bool changeGizmoColor;
    [SerializeField] private Color collisionGizmoColor = Color.red;
#endif

    private List<Collider> registeredColliders = new List<Collider>();

    private void Update()
    {
        Vector3 halfExtents = size;
        halfExtents.Scale(transform.localScale);
        halfExtents *= .5f;

        Collider[] hitColliders = Physics.OverlapBox(
            transform.position + centerOffset,
            halfExtents,
            transform.rotation, 
            collisionMask);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            var collider = hitColliders[i];
            if (!registeredColliders.Contains(collider))
            {
                if (!triggerOnlyDetection || (triggerOnlyDetection && collider.isTrigger))
                {
                    if (!registeredColliders.Contains(collider))
                        registeredColliders.Add(collider);

                    onCollisionEnter.Invoke(collider);
                }
            }
        }

        for (int i = registeredColliders.Count - 1; i >= 0; i--)
        {
            Collider collider = registeredColliders[i];
            if (Array.IndexOf(hitColliders, collider) == -1)
            {
                registeredColliders.RemoveAt(i);
                if (!triggerOnlyDetection || (triggerOnlyDetection && collider.isTrigger))
                {
                    onCollisionExit.Invoke(collider);
                }
            }
            else if (!triggerOnlyDetection || (triggerOnlyDetection && collider.isTrigger))
            {
                onCollisionStay.Invoke(collider);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        var gizmosColor = Gizmos.color;
        Gizmos.color = registeredColliders.Count > 0 ? collisionGizmoColor : Color.green;
        Vector3 size = this.size;
        size.Scale(transform.localScale);

        Gizmos.DrawWireCube(transform.position + centerOffset, size);
        Gizmos.color = gizmosColor;
    }

    private void OnDrawGizmos()
    {
        if (alwaysShowGizmo)
        {
            OnDrawGizmosSelected();
        }
    }

    /// <summary>
    /// Representation of the collision unity event.
    /// </summary>
    [Serializable]
    private class CollisionUnityEvent : UnityEvent<Collider> { }
}
