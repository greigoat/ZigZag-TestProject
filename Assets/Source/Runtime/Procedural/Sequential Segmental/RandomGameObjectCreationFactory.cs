using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestProject.Procedural
{
    /// <summary>
    /// Factory that spawns game objects in sequence and also a specific game object if with random chance percentage
    /// </summary>
    [CreateAssetMenu(menuName = "Game Object Factories/Randrom Variant Sequential Segmental GameObject Factory")]
    public class RandromVariantSequentialSegmentalGameObjectFactory : ScriptableObject, ISequentialSegmentalGameObjectFactory
    {
        [SerializeField] private GameObject defaultElementPrefab;
        [SerializeField] private GameObject variantElementPrefab;
        [SerializeField, Range(0, 100)] private int variantOccurencePercentage = 50;


        /// <summary>
        /// See <see cref="ISequentialSegmentalGameObjectFactory.Create(int)"/>
        /// </summary>
        /// <param name="indexInSequence"> See <see cref="ISequentialSegmentalGameObjectFactory.Create(int)"/> </param>
        /// <returns></returns>
        public GameObject Create(int indexInSequence)
        {
            return Instantiate(GetRandomPrefab());
        }

        /// <summary>
        /// Get specific prefab or default one depending on the chance
        /// </summary>
        /// <returns> The variant prefab or default one </returns>
        private GameObject GetRandomPrefab()
        {
            if (variantOccurencePercentage == 0)
                return defaultElementPrefab;

            var floatPercent = ((float)variantOccurencePercentage / 100);
            if (Random.value > 1 - floatPercent)
            {
                return variantElementPrefab;
            }

            return defaultElementPrefab;
        }
    }

}
