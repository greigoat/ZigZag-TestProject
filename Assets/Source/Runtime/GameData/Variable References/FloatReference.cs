using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The reference variable of type <see cref="float"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.ReferenceDirectory + "Float", fileName = "New Float Reference")]
    public class FloatReference : VariableReference<FloatVariable, float>, IConditionComparable
    {
        public bool Compare(UnityEngine.Object other, ConditionOperator operation)
        {
            switch (operation)
            {
                case ConditionOperator.Equals:
                    FloatReference otherAsRef = other as FloatReference;
                    if (otherAsRef != null)
                    {
                        return this == otherAsRef;
                    }
                    FloatVariable otherAsVar = other as FloatVariable;
                    if (otherAsVar != null)
                    {
                        return Variable == otherAsVar;
                    }
                    break;
            }

            return false;
        }
    }
}
