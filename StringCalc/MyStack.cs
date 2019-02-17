using System;

namespace StringCalc
{
    class MyStack<T>
    {
        readonly int empty = 0;
        readonly int full;
        T[] items;

        int count = 0;

        public int Count
        {
            get => count;
        }

        public MyStack()
        {
            full = 100;
            items = new T[full];
        }

        public MyStack(int stackSize)
        {
            full = stackSize;
            items = new T[full];
        }

        public T this[int index]
        {
            get => items[index];
        }

        public void Push(T ch)
        {
            if (IsFull())
                throw new InvalidOperationException("Переполнение стека");
            else
                items[count++] = ch;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            items[count] = default(T);
            return item;
        }

        public T Peek()
        {
            return items[count - 1];
        }

        public void Del()
        {
            if (!IsEmpty())
                --count;
        }

        public void Clear()
        {
            count = empty;
        }

        public bool IsEmpty() => Count == empty;

        public bool IsFull() => Count == full;
    }
}
