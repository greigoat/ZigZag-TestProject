using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The reference variable of type <see cref="int"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.ReferenceDirectory + "Integer", fileName = "New Integer Reference")]
    public class IntReference : VariableReference<IntVariable, int>, IConditionComparable
    {
        public bool Compare(UnityEngine.Object other, ConditionOperator operation)
        {
            switch (operation)
            {
                case ConditionOperator.Equals:
                    IntReference otherAsRef = other as IntReference;
                    if (otherAsRef != null)
                    {
                        return this == otherAsRef;
                    }
                    IntVariable otherAsVar = other as IntVariable;
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
