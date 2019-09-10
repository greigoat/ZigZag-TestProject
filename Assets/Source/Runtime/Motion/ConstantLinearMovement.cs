using System.Collections;
using System.Collections.Generic;
using TestProject.GameData;
using UnityEngine;

namespace TestProject
{
    /// <summary>
    /// The constant linear of the movement of the object.
    /// </summary>
    public class ConstantLinearMovement : MonoBehaviour
    {
        [SerializeField] private Object moveVector;
        [SerializeField] private Object moveVectorMultiplier;
        [SerializeField] private bool ignoreTimeScale = false;
        [SerializeField] private Transform targetTransform;

        /// <summary>
        /// The movement vector
        /// </summary>
        public Vector3 MoveVector => ((IVariable<Vector3>)moveVector).GetValue();

        /// <summary>
        /// The movement vector multiplier
        /// </summary>
        public float MoveVectorMultiplier => ((IVariable<float>)moveVectorMultiplier).GetValue();

        /// <summary>
        /// The movement vector variable
        /// </summary>
        public Object MoveVectorVariable { get => moveVector; set => moveVector = value; }

        /// <summary>
        /// The movement vector multiplier variable
        /// </summary>
        public Object MoveVectorMultiplierVariable { get => moveVectorMultiplier; set => moveVectorMultiplier = value; }


        private void OnValidate()
        {
            if (!(moveVector is IVariable<Vector3>))
            {
                moveVector = null;
            }
            if (!(moveVectorMultiplier is IVariable<float>))
            {
                moveVectorMultiplier = null;
            }
        }

        private void Update()
        {
            float timeDelta = ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
            Vector3 moveVector = MoveVector;
            float multiplier = MoveVectorMultiplier;
            targetTransform.position += moveVector * multiplier * timeDelta;
        }

        private void Reset()
        {
            targetTransform = transform;
        }
    }

}
