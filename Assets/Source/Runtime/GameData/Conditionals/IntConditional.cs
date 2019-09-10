using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The conditional variable of type <see cref="int"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.ConditionalDirectory + "Integer", fileName = "New Integer Conditional")]
    public class IntConditional : Conditional<IntVariable, int>
    {
    }
}
