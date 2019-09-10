using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Utilities
{
    /// <summary>
    /// The utility class containing useful math methods
    /// </summary>
    public static class MathUtility
    {
        /// <summary>
        /// Test if point is inside sphere
        /// </summary>
        /// <param name="point"> The point to test </param>
        /// <param name="sphereOrigin"> The origin/center of the sphere </param>
        /// <param name="radius"> The radius of the sphere </param>
        /// <returns></returns>
        public static bool GetIsPointInsideSphere(Vector3 point, Vector3 sphereOrigin, float radius)
        {
            float x = point.x;
            float y = point.y;
            float z = point.z;
            float cx = sphereOrigin.x;
            float cy = sphereOrigin.y;
            float cz = sphereOrigin.z;
            float r = radius;

            return (x - cx) * (x - cx) + (y - cy) * (y - cy) + (z - cz) * (z - cz) < r * r;
        }
    }
}
