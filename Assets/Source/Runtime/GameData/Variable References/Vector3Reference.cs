using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The reference variable of type <see cref="Vector3"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.ReferenceDirectory + "Vector3 Reference", fileName = "New Vector3 Reference")]
    public class Vector3Reference : VariableReference<Vector3Variable, Vector3>, IConditionComparable
    {
        public bool Compare(UnityEngine.Object other, ConditionOperator operation)
        {
            switch (operation)
            {
                case ConditionOperator.Equals:
                    Vector3Reference otherAsRef = other as Vector3Reference;
                    if (otherAsRef != null)
                    {
                        return this == otherAsRef;
                    }
                    Vector3Variable otherAsVar = other as Vector3Variable;
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
