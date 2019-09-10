using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TestProject.Utilities
{
    /// <summary>
    /// Object pooling for optimizations. Unused
    /// </summary>
    /// <typeparam name="T"> The type used by pool </typeparam>
    public class ObjectPool<T> where T : new()
    {
        private readonly Stack<T> stack = new Stack<T>();

        public int Count { get; private set; }

        public T GetObject(Func<T> factory = null)
        {
            T obj;
            if (stack.Count == 0)
            {
                obj = factory != null ? factory.Invoke() : new T();
                Count++;
            }
            else
                obj = stack.Pop();

            return obj;
        }

        public void ReleaseObject(T obj)
        {
            if (stack.Count > 0 && stack.Peek().Equals(obj))
                return; //!!

            stack.Push(obj);
        }

        public void Free()
        {
            //if (deleter != null)
            //    foreach (var obj in stack)
            //        deleter(obj);

            stack.Clear();
        }
    }

}
