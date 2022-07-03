namespace Lab8
{
    public interface ICollectionType<T> where T : class 
    {
        void Add(T myList);
        void Insert(int index, T myList);
        void RemoveAt(int index);
        void Clear();
        void Show();
        void Print();
    }
}
