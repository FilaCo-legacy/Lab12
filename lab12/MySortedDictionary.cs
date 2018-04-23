using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    public class MySortedDictionary<TKey, TValue>:IEnumerator<IComparable>, IEnumerable<IComparable>
    {
        private int index = -1;
        private int _count = 0;
        public int Count { get { return _count; } }
        public List<IComparable> Keys
        {
            get
            {
                List<IComparable> allKeys = new List<IComparable>(Count);
                frame.GetKeys(allKeys);
                return allKeys;
            }
        }
        public List<TValue> Values
        {
            get
            {
                List<TValue> allValues = new List<TValue>(Count);
                frame.GetValues(allValues);
                return allValues;
            }
        }
        private class SearchTree
        {
            private KeyValuePair<IComparable, TValue> _data;
            public KeyValuePair<IComparable, TValue> Data { get { return _data; } }
            private SearchTree _left, _right;
            public SearchTree Left { get { return _left; } }
            public SearchTree Right { get { return _right; } }
            public static bool Add(KeyValuePair<IComparable, TValue> elem, SearchTree root)
            {
                SearchTree cur = root;
                SearchTree anc = null;
                while (cur != null)
                {
                    anc = cur;
                    if (elem.Key.CompareTo(cur.Data.Key) == 0)
                        return false;
                    if (elem.Key.CompareTo(cur.Data.Key) == -1)
                        cur = cur.Left;
                    if (elem.Key.CompareTo(cur.Data.Key) == 1)
                        cur = cur.Right;
                }
                cur = new SearchTree(elem);
                if (cur.Data.Key.CompareTo(anc.Data.Key) == -1)
                    anc._left = cur;
                else
                    anc._right = cur;
                return true;
            }
            public static SearchTree Remove(IComparable key, SearchTree root)
            {
                if (root == null)
                {
                    Console.WriteLine("Данного элемента нет в дереве");
                    return root;
                }
                if (root.Data.Key.CompareTo(key) == -1)
                    root._right = Remove(key, root.Right);
                else if (root.Data.Key.CompareTo(key) == 1)
                    root._left = Remove(key, root.Left);
                else
                {
                    Console.WriteLine("Элемент {0} подлежит удалению...", root.Data.Value);
                    if (root.Left == null && root.Right == null)
                        return null;
                    else if (root.Left == null && root.Right != null)
                        root = root.Right;
                    else if (root.Left != null && root.Right == null)
                        root = root.Left;
                    else
                    {
                        if (root.Right.Left == null)
                        {
                            root.Right._left = root.Left;
                            root = root.Right;
                        }
                        else
                        {
                            root._data = root.Right.Left.Data;
                            root.Right._left = Remove(root.Right.Left.Data.Key, root.Right.Left);
                        }
                    }
                }
                return root;

            }
            public static bool ContainsKey(IComparable keyValue, SearchTree root)
            {
                if (root == null)
                    return false;
                if (root.Left != null && root.Data.Key.CompareTo(keyValue) == 1)
                    return ContainsKey(keyValue, root.Left);
                else if (root.Right != null && root.Data.Key.CompareTo(keyValue) == -1)
                    return ContainsKey(keyValue, root.Right);
                else
                    return true;
            }
            public static void CreateSearchTree(KeyValuePair<IComparable, TValue>[] elems, SearchTree root)
            {
                foreach (KeyValuePair<IComparable, TValue> cur in elems)
                    Add(cur, root);
            }
            public SearchTree(KeyValuePair<IComparable,TValue> elem)
            {
                _data = elem;
                _left = null;
                _right = null;
            }
            public void Show()
            {
                if (Left != null)
                    Left.Show();
                Console.WriteLine(@"Ключ:
+--------------------------------------+
{1}
+--------------------------------------+
Значение:
+--------------------------------------+
{2}
+--------------------------------------+", Data.Key, Data.Value);
                if(Right != null)
                    Right.Show();
            }
            public void GetKeys(List<IComparable> keys)
            {
                if (Left != null)
                    Left.GetKeys(keys);
                keys.Add(Data.Key);
                if (Right != null)
                    Right.GetKeys(keys);
            }
            public void GetValues(List<TValue> values)
            {
                if (Left != null)
                    Left.GetValues(values);
                if (!values.Contains(Data.Value))
                    values.Add(Data.Value);
                if (Right != null)
                    Right.GetValues(values);
            }
            public static TValue FindByKey(IComparable keyValue, SearchTree root)
            {
                if (root == null)
                    throw new Exception("Элемента с таким ключом нет в словаре");
                if (root.Left != null && root.Data.Key.CompareTo(keyValue) == 1)
                    return FindByKey(keyValue, root.Left);
                else if (root.Right != null && root.Data.Key.CompareTo(keyValue) == -1)
                    return FindByKey(keyValue, root.Right);
                else
                    return root.Data.Value;
            }
        }
        private SearchTree frame;
        public MySortedDictionary()
        {
            _count = 0;
        }
        public MySortedDictionary(MySortedDictionary<TKey,TValue> ancDict)
        {
            foreach(IComparable x in ancDict)
                this.Add(new KeyValuePair<IComparable, TValue>(x, ancDict[x]));
        }
        public IEnumerator<IComparable> GetEnumerator()
        {
            return Keys.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IComparable Current
        {
            get
            {
                if (index < 0 || index > Keys.Count) throw new Exception("Индекс находился вне границ коллекции");
                return Keys[index];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                if (index < 0 || index > Keys.Count) throw new Exception("Индекс находился вне границ коллекции");
                return Keys[index];
            }
        }
        public bool MoveNext()
        {
            index++;
            if (index < Keys.Count)
                return true;
            else
            {
                Reset();
                return false;
            }
        }
        public void Reset()
        {
            index = -1;
        }
        public void Dispose()
        {

        }
        public bool ContainsKey(IComparable keyValue)
        {
            return SearchTree.ContainsKey(keyValue, frame);
        }
        public bool ContainsValue(TValue value)
        {
            return Values.Contains<TValue>(value);
        }
        public TValue this[IComparable key]
        {
            get
            {
                try
                {
                    return SearchTree.FindByKey(key, frame);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return default(TValue);
            }
        }
        public void Add (KeyValuePair<IComparable, TValue> curElem)
        {
            if (SearchTree.Add(curElem, frame))
                _count++;
            else
                Console.WriteLine("Элемент с таким ключом уже находится в коллекции");
        }
        public void Remove(IComparable keyValue)
        {
            if (ContainsKey(keyValue))
                _count--;
            frame = SearchTree.Remove(keyValue, frame);
        }
        public void Clear()
        {
            this.frame = null;
            this._count = 0;
            this.index = -1;
        }
    }
}
