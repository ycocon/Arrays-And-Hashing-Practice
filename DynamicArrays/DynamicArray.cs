using System.Collections;

public class DynamicArray<T> : IEnumerable<T>
{
    private T[] _items;
    private int _size;

    public DynamicArray()
    {
        _items = Array.Empty<T>();
        _size = 0;
    }

    // level 1
    public int Count => _size;
    public int Capacity => _items.Length;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException();

            return _items[index];
        }
        set => _items[index] = value;
    }

    public void Add(T item)
    {
        if (_items.Length == _size)
        {
            if (_items.Length == 0)
            {
                Array.Resize(ref _items, 4);
            }
            else
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
        }

        _size += 1;
        _items[_size - 1] = item;
    }

    // level 2
    bool AreEqual(T a, T b)
    {
        return EqualityComparer<T>.Default.Equals(a, b);
    }

    public void Insert(int index, T item)
    {
        if (index + 1 > _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        // Add capacity when needed
        if (_items.Length == _size)
        {
            if (_items.Length == 0)
            {
                Array.Resize(ref _items, 4);
            }
            else
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
        }

        for (int i = _size - 1; i >= index; i--)
        {
            _items[i + 1] = _items[i];

            if (i == index)
            {
                _items[i] = item;
            }
        }

        _size += 1;
    }

    public void RemoveAt(int index)
    {
        if (index + 1 > _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        for (int i = index; i < _size - 1; i++)
        {
            if (i + 1 < _size)
            {
                _items[i] = _items[i + 1];
            }
            else
            {
                _items[i] = default!;
            }
        }

        _size -= 1;
    }

    public bool Remove(T item)
    {
        bool isFound = false;

        for (int i = 0; i < _size; i++)
        {
            if (AreEqual(_items[i], item))
            {
                isFound = true;
            }

            if (isFound)
            {
                if (i + 1 < _size)
                {
                    _items[i] = _items[i + 1];
                }
                else
                {
                    _items[i] = default!;
                }
            }
        }

        if (isFound) _size -= 1;

        return isFound;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (AreEqual(_items[i], item))
            {
                return true;
            }
        }

        return false;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (AreEqual(_items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _items[i] = default!;
        }

        _size = 0;
    }

    // apply IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _size; i++)
            yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}