using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// Base class of all variables in form of an asset (<see cref="ScriptableObject"/>)
    /// </summary>
    /// <typeparam name="T">The type of the variable</typeparam>
    public abstract class Variable<T> : ScriptableObject, IVariable<T>, IWriteableVariable<T>
    {
        [SerializeField] private T value;

        /// <summary>
        /// See <see cref="IWriteableVariable{T}.SetValue(T)"/>
        /// </summary>
        /// <param name="value">See <see cref="IWriteableVariable{T}.SetValue(T)"/></param>
        public void SetValue(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// See <see cref="IVariable{T}.GetValue"/>
        /// </summary>
        /// <returns> See <see cref="IVariable{T}.GetValue"/></returns>
        public T GetValue()
        {
            return value;
        }
    }

}
