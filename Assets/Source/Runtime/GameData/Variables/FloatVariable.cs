using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// The variable of type <see cref="float"/>
    /// </summary>
    [CreateAssetMenu(menuName = VariableEditorDirectories.VariableDirectory + "Float", fileName = "New Float")]
    public class FloatVariable : Variable<float>
    {
    }
}
