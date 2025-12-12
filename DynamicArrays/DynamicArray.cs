public class DynamicArray<T>
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
        get => _items[index];
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
    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public int IndexOf(T item)
    {
        return _items.IndexOf(item);
    }

    public void Clear()
    {
        Array.Clear(_items);
    }
}