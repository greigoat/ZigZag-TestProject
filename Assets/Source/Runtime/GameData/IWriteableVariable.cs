using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The variable that whose value can be modified at runtime
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWriteableVariable<T>
    {
        /// <summary>
        /// Set the value of the variable
        /// </summary>
        /// <param name="value"> The new value of the variable </param>
        void SetValue(T value);
    }

}
