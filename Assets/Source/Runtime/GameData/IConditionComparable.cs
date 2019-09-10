using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The interface for an object that can be compared using the <see cref="Condition"/>
    /// </summary>
    public interface IConditionComparable
    {
        /// <summary>
        /// Compare two objects using the <see cref="ConditionOperator"/>
        /// </summary>
        /// <param name="other"> the object compared with this object </param>
        /// <param name="operation"> the comparison operation to perform </param>
        /// <returns></returns>
        bool Compare(Object other, ConditionOperator operation);
    }
}