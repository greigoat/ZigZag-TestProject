using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The conditional variable of type <see cref="float"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.ConditionalDirectory + "Float", fileName = "New Float Conditional")]

    public class FloatConditional : Conditional<FloatVariable, float>
    {
    }

}
