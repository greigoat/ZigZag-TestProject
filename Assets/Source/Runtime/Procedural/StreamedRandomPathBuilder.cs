using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TestProject.GameData;


using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TestProject.Procedural
{
    // TODO: Optimize. (object pooling)
    // IResetable
    public class StreamedRandomPathBuilder : MonoBehaviour
    {
        [SerializeField] private Transform streamerTransform;
        [SerializeField] private Object[] possibleDirections;
        [SerializeField] private Object initialDirection;
        [SerializeField] private Vector3 buildOffset;
        [SerializeField] private float minViewDistance = 3;
        [SerializeField] private Object elementsPerSegment;
        [SerializeField] private Object elementFactory;
        [SerializeField] private ElementCreateUnityEvent onElementCreated;

        private int elementsCreated; // ToDo: Handle overflow
        private List<Transform> elements = new List<Transform>();

        /// <summary>
        /// The amount of elements created per segment
        /// </summary>
        private int ElementsPerSegment => Mathf.Max(1, ((IVariable<int>)elementsPerSegment).GetValue());

        /// <summary>
        /// The factory used for creation of elements
        /// </summary>
        public ISequentialSegmentalGameObjectFactory ElementFactory { get => (ISequentialSegmentalGameObjectFactory)elementFactory; }

        /// <summary>
        /// The initial direction of the path
        /// </summary>
        public Vector3 InitialDirection => ((IVariable<Vector3>)initialDirection).GetValue();

        public void Reset()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] != null)
                    Destroy(elements[i].gameObject);
            }

            elements.Clear();

            elementsCreated = 0;
        }

        private void OnValidate()
        {
            // Ensure our object references are actual variables
            if (!(elementsPerSegment is IVariable<int>))
            {
                elementsPerSegment = null;
            }

            for (int i = 0; i < possibleDirections.Length; i++)
            {
                if (!(possibleDirections[i] is IVariable<Vector3>))
                {
                    possibleDirections[i] = null;
                }
            }

            if (!(initialDirection is IVariable<Vector3>))
                initialDirection = null;

            // Ensure the reference is ISequentialSegmentalGameObjectFactory
            if (elementFactory is GameObject efg)
            {
                elementFactory = (Object)efg.GetComponent<ISequentialSegmentalGameObjectFactory>();
            }
            else if (!(elementFactory is ISequentialSegmentalGameObjectFactory))
                elementFactory = null;
        }

        private void Update()
        {
            RemovedDestroyedElements();
            EnsurePathBuilt();
        }

        /// <summary>
        /// Get random direction from <see cref="possibleDirections"/>
        /// </summary>
        /// <returns></returns>
        private Vector3 GetRandomDirection()
        {
            if (possibleDirections.Length == 0)
            {
                return Vector3.forward;
            }

            return ((IVariable<Vector3>)possibleDirections[Random.Range(0, possibleDirections.Length)]).GetValue();
        }

        /// <summary>
        /// Ensure that path is built for the streamer object specified by <see cref="minViewDistance"/>
        /// </summary>
        private void EnsurePathBuilt()
        {
            if (elements.Count == 0)
            {
                elementsCreated = 0;
                Vector3 direcion = InitialDirection;
                CreateElement(transform.position);
                for (int i = 0; i < ElementsPerSegment - 1; i++)
                {
                    ExpandSingle(direcion);
                }
            }
            else
            {
                var latestElement = elements[elements.Count - 1];
                if (Vector3.Distance(latestElement.position, streamerTransform.position) < minViewDistance)
                {
                    Expand(GetRandomDirection());
                }
            }
        }

        /// <summary>
        /// Removes any destroyed (null) elements.
        /// </summary>
        private void RemovedDestroyedElements()
        {
            elements.RemoveAll(e => e == null); // ToDo: Check if peeks managed one or overloaded operator
        }

        /// <summary>
        /// Expand the path towards given direction with N amount of tiles specified by <see cref="ElementsPerSegment"/>
        /// </summary>
        /// <param name="direction"> The direction </param>
        private void Expand(Vector3 direction)
        {
            for (int i = 0; i < ElementsPerSegment; i++)
            {
                ExpandSingle(direction);
            }
        }

        /// <summary>
        /// Expand the path towards given direciton with one element
        /// </summary>
        /// <param name="direction"> The direction </param>
        /// <returns></returns>
        private GameObject ExpandSingle(Vector3 direction)
        {
            var fromPosition = elements[elements.Count - 1].transform.position;
            var x = fromPosition.x + direction.x * buildOffset.x;
            var y = fromPosition.y + direction.y * buildOffset.y;
            var z = fromPosition.z + direction.z * buildOffset.z;

            return CreateElement(new Vector3(x, y, z));
        }

        /// <summary>
        /// Create element at specified point in world space.
        /// </summary>
        /// <param name="point"> The point in world space </param>
        /// <returns></returns>
        private GameObject CreateElement(Vector3 point)
        {
            GameObject element = ElementFactory.Create(elementsCreated++);
            Transform elementTransform = element.transform;
            elementTransform.position = point;
            elements.Add(elementTransform);
            onElementCreated.Invoke(element);
            return element;
        }

        /// <summary>
        /// The definition of unity event that is called when an element is created
        /// </summary>
        [Serializable]
        public class ElementCreateUnityEvent : UnityEvent<GameObject> { }

        //private void Truncate()
        //{
        //    if (elements.Count == 0)
        //        return;

        //    elements[0].OnRelease();
        //    onReleaseElement.Invoke(elements[0]);
        //    elements.RemoveAt(0);
        //}

        //private void CreateStartTileBlock(Transform transform)
        //{
        //    var size = startBlockSize;
        //    var space = elementOffset;
        //    var startPosX = -space.x * size.x / 2 + space.x / 2;
        //    var startPosY = -space.y * size.y / 2 + space.y / 2;
        //    var startPosZ = -space.z * size.z / 2 + space.z / 2;
        //    float posX = startPosX;
        //    float posY = startPosY;
        //    float posZ = startPosZ;

        //    for (int x = 0; x < size.x; x++)
        //    {
        //        for (int y = 0; y < size.y; y++)
        //        {
        //            for (int z = 0; z < size.z; z++)
        //            {
        //                Vector3 origin = transform.TransformPoint(new Vector3(posX,posY,posZ));

        //                Add(origin);

        //                posZ += space.z;
        //            }

        //            posY += space.y;
        //            posZ = startPosZ;
        //        }

        //        posX += space.x;
        //        posY = startPosY;
        //    }
        //}

        //[Serializable]
        //public class ElementReleaseEvent : UnityEvent<IPathElement> { }
    }

}
