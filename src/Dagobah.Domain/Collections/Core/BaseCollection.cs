using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dagobah.Domain.Collections.Core
{
    public abstract class BaseCollection<T> : ICollection<T>
    {
        #region Atributtes

        protected readonly ICollection<T> Collection;

        #endregion

        #region Constructors

        public BaseCollection()
        {
            Collection = new Collection<T>();
        }

        public BaseCollection(IList<T> list)
        {
            Collection = new Collection<T>(list);
        }

        #endregion

        #region Methods

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }

        #endregion

        #region ICollection

        public int Count => Collection.Count;

        public bool IsReadOnly => Collection.IsReadOnly;

        public virtual void Add(T item) => Collection.Add(item);

        public virtual void Clear() => Collection.Clear();

        public bool Contains(T item) => Collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Collection.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => Collection.GetEnumerator();

        public virtual bool Remove(T item) => Collection.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
