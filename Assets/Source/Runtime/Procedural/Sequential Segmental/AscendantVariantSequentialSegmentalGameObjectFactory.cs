using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TestProject.Procedural
{
    /// <summary>
    /// Factory that spawns game objects in sequence and also a specific game object variant when index in sequence is ascendant
    /// </summary>
    [CreateAssetMenu(menuName = "Game Object Factories/Ascendant Variant TileFactory")]
    public class AscendantVariantSequentialSegmentalGameObjectFactory : ScriptableObject, ISequentialSegmentalGameObjectFactory
    {
        [SerializeField] private GameObject defaultElementPrefab;
        [SerializeField] private GameObject ascendantVariantElementPrefab;
        [SerializeField] private int objectsPerSegment = 5;


        // TODO: Implement object pooling
        //private ObjectPool<GameObject> defaultPool = new ObjectPool<GameObject>();
        //private ObjectPool<GameObject> ascendantPool = new ObjectPool<GameObject>();

            /// <summary>
            /// See <see cref="ISequentialSegmentalGameObjectFactory.Create(int)"/>
            /// </summary>
            /// <param name="indexInSequence"></param>
            /// <returns></returns>
        public GameObject Create(int indexInSequence)
        {
            GameObject element;

            if (GetIsSequentialAscendant(indexInSequence, objectsPerSegment))
            {
                element = Instantiate(ascendantVariantElementPrefab);
            }
            else
                element = Instantiate(defaultElementPrefab);

            return element;
        }

        /// <summary>
        /// Is index in sequence an index of the ascendant
        /// </summary>
        /// <param name="indexInSequence"> The index in sequence </param>
        /// <param name="objectsPerSegment"> The defintion of segment </param>
        /// <returns> true if ascendant, false otherwise </returns>
        private bool GetIsSequentialAscendant(int indexInSequence, int objectsPerSegment)
        {
            int segmentIndex = indexInSequence / objectsPerSegment;
            int repeatingSegmentIndex = (int)Mathf.Repeat(segmentIndex, objectsPerSegment);
            int ascendantPosition = repeatingSegmentIndex + segmentIndex * objectsPerSegment;
            return ascendantPosition == indexInSequence;
        }
    }

}
