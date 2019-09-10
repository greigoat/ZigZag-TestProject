using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The base class of all variables that can return different values based on specified conditions. 
    /// </summary>
    /// <typeparam name="TVariable">The type of the result variable</typeparam>
    /// <typeparam name="TValue"> The type of the result variable value </typeparam>
    public abstract class Conditional<TVariable, TValue> : ScriptableObject, IVariable<TValue>
    where TVariable : ScriptableObject, IVariable<TValue>
    {
        [Header("TODO: Implement custom editor for this")]
        public ConditionList[] conditions;
        public TVariable[] values;
        public TVariable defaultValue;

        /// <summary>
        /// See <see cref="IVariable{T}.GetValue"/>
        /// </summary>
        /// <returns> See <see cref="IVariable{T}.GetValue "/></returns>
        public TValue GetValue()
        {
            for (int i = 0; i < conditions.Length; i++)
            {
                bool result = true;
                for (int j = 0; j < conditions[i].Count; j++)
                {
                    if (!conditions[i][j].Evaluate())
                        result = false;
                }

                if (result)
                {
                    return values[i].GetValue();
                }
            }

            return defaultValue.GetValue();
        }
    }
}
