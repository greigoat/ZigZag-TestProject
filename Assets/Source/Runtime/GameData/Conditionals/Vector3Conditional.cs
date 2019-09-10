using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{    
    /// <summary>
     /// The conditional variable of type <see cref="Vector3"/>
     /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.ConditionalDirectory + "Vector3", fileName = "New Vector3 Conditional")]
    public class Vector3Conditional : Conditional<Vector3Variable, Vector3>
    {
    }
}