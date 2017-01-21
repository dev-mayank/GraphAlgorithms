using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class Heap<T> where T : IComparable
    {
        private List<T> _items;
        private int _top = -1;

        public Heap()
        {
            _items = new List<T>();
        }

        public void AddItems(params T[] items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void AddItem(T item)
        {
            _items.Add(item);
            _top++;
            HeapifyUp();
        }

        public T Poll()
        {
            if (_top == -1)
                throw new Exception("No Elements in heap");

            var item = _items[0];
            _items[0] = _items[_top];
            HeapifyDown();
            _items.RemoveAt(_top);
            _top--;
            return item;
        }

        public T Peek()
        {
            if (_top == -1)
                throw new Exception("No Elements in heap");

            return _items[0];
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private bool HasParent(int index)
        {
            return index > 0;
        }

        private int GetParentIndex(int index)
        {
            return index / 2;
        }

        private bool HasLeftChild(int index)
        {
            return _items.Count - 1 >= GetLeftChildIndex(index);
        }

        private bool HasRightChild(int index)
        {
            return _items.Count - 1 >= GetRightChildIndex(index);
        }

        private T GetLeftChild(int index)
        {
            return _items[GetLeftChildIndex(index)];
        }

        private T GetRightChild(int index)
        {
            return _items[GetRightChildIndex(index)];
        }

        private T GetParent(int index)
        {
            return _items[GetParentIndex(index)];
        }

        private void Swap(int index1, int index2)
        {
            var data = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = data;
        }

        private void HeapifyDown()
        {
            int index = 0;

            while (HasLeftChild(index) && GetLeftChildIndex(index) <= _top)
            {
                var smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) 
                    && GetRightChildIndex(index) <= _top 
                    && (GetRightChild(index).CompareTo(GetLeftChild(index)) < 0))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (_items[index].CompareTo(_items[smallerChildIndex]) < 0)
                {
                    break;
                }

                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }

        private void HeapifyUp()
        {
            var index = _top;

            while (HasParent(index))
            {
                var parentIndex = GetParentIndex(index);
                if (_items[parentIndex].CompareTo(_items[index]) < 0)
                {
                    break;
                }

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}