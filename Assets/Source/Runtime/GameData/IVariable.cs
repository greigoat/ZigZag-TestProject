using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The representation of a variable
    /// </summary>
    /// <typeparam name="T">The type of the variable</typeparam>
    public interface IVariable<T>
    {
        /// <summary>
        /// Get the value from the variable
        /// </summary>
        /// <returns> The value of the variable </returns>
        T GetValue();
    }

}