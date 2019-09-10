using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Procedural
{
    /// <summary>
    /// The factory creating game objects in form of segments in particular sequence
    /// </summary>
    public interface ISequentialSegmentalGameObjectFactory
    {
        /// <summary>
        /// Create new game object
        /// </summary>
        /// <param name="indexInSequence"> Index associated with the object in sequence </param>
        /// <returns> The game object created. Null if something goes wrong </returns>
        GameObject Create(int indexInSequence);
    }
}
