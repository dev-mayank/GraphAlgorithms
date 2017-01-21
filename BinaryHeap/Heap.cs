using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class Heap<T>
    {
        private List<T> _items;
        private int _top = -1;

        public Heap()
        {
            _items = new List<T>();
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
                throw Exception("No Elements in heap");
        }

        public T Peek()
        {
            if (_top == -1)
                throw Exception("No Elements in heap");

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
            return _top > 0;
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

        private T Getparent()
        {

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

            while (HasLeftChild(index))
            {
                var smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (_items[index] < _items[smallerChildIndex])
                {
                    break;
                }

                Swap(index, GetLeftChildIndex(index));
                index = smallerChildIndex;
            }
        }

        private void HeapifyUp()
        {
            var index = _top;

            while(HasParent(index))
            {
                var parentIndex = GetParentIndex(index);
                if (_items[parentIndex] < _items[index])
                {
                    break;
                }

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}