using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.GameData
{
    /// <summary>
    /// Serialized list of <see cref="Condition"/>
    /// </summary>
    [Serializable]
    public class ConditionList : IList<Condition>
    {
        [SerializeField] private List<Condition> list;

        public Condition this[int index] { get => ((IList<Condition>)list)[index]; set => ((IList<Condition>)list)[index] = value; }

        public int Count => ((IList<Condition>)list).Count;

        public bool IsReadOnly => ((IList<Condition>)list).IsReadOnly;

        public void Add(Condition item)
        {
            ((IList<Condition>)list).Add(item);
        }

        public void Clear()
        {
            ((IList<Condition>)list).Clear();
        }

        public bool Contains(Condition item)
        {
            return ((IList<Condition>)list).Contains(item);
        }

        public void CopyTo(Condition[] array, int arrayIndex)
        {
            ((IList<Condition>)list).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Condition> GetEnumerator()
        {
            return ((IList<Condition>)list).GetEnumerator();
        }

        public int IndexOf(Condition item)
        {
            return ((IList<Condition>)list).IndexOf(item);
        }

        public void Insert(int index, Condition item)
        {
            ((IList<Condition>)list).Insert(index, item);
        }

        public bool Remove(Condition item)
        {
            return ((IList<Condition>)list).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Condition>)list).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Condition>)list).GetEnumerator();
        }
    }
}
