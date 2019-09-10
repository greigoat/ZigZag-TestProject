using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject.GameData
{
    /// <summary>
    /// The variable of type <see cref="int"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.VariableDirectory + "Integer", fileName = "New Integer")]
    public class IntVariable : Variable<int>
    {
    }
}

