using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace TestProject.GameData
{
    /// <summary>
    /// The very barebone version of condition that can be specified in editor. For now only supports equality operator
    /// </summary>
    [Serializable]
    public class Condition
    {
        [SerializeField] private Object leftComparable;
        [SerializeField] private Object rightComparable;
        [SerializeField] private ConditionOperator operation;


        /// <summary>
        /// Evaluate the condition.
        /// </summary>
        /// <returns> true if all conditionas are met. False otherwise </returns>
        public bool Evaluate()
        {
            IConditionComparable left = leftComparable as IConditionComparable;

            if (left == null || rightComparable == null)
                return false;

            return left.Compare(rightComparable, operation);
        }
    }
}
