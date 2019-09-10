using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The object gets notified when released / not used by a source anymore.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface INotifyObjectReleased<T>
{
    void OnObjectReleased(T releasedObject);
}
