using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// Base class of all variable references
    /// </summary>
    /// <typeparam name="TVariable"> The type of variable </typeparam>
    /// <typeparam name="TValue"> The value type of variable </typeparam>
    public abstract class VariableReference<TVariable, TValue> : ScriptableObject, IVariable<TValue>, IWriteableVariable<TValue>
        where TVariable : Variable<TValue>
    {
        [SerializeField] private TVariable variable;

        /// <summary>
        /// The variable reference
        /// </summary>
        public TVariable Variable => variable;

        /// <summary>
        /// Get the value of the referenced variable
        /// </summary>
        /// <returns> The value of the variable </returns>
        public TValue GetValue()
        {
            return variable.GetValue();
        }

        /// <summary>
        /// Set the value of the referenced variable
        /// </summary>
        /// <param name="value"> The new value assigned to the referenced variable </param>
        public void SetValue(TValue value)
        {
            variable.SetValue(value);
        }
    }

}
