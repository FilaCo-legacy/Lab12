using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    public class MySortedDictionary<TKey, TValue>:IEnumerator<TKey>, IEnumerable<TKey>, ICloneable
    {
        private int index = -1;
        private int _count = 0;
        public int Count { get { return _count; } }
        public List<TKey> Keys
        {
            get
            {
                List<TKey> allKeys = new List<TKey>(Count);
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
        public object Clone()
        {
            return new MySortedDictionary<TKey, TValue>(this);
        }
        private class SearchTree
        {
            private KeyValuePair<TKey, TValue> _data;
            public KeyValuePair<TKey, TValue> Data { get { return _data; } }
            private SearchTree _left, _right;
            public SearchTree Left { get { return _left; } }
            public SearchTree Right { get { return _right; } }
            public static bool Add(KeyValuePair<TKey, TValue> elem, ref SearchTree root)
            {
                if (root.Data.Key == null)
                {
                    root = new SearchTree(elem);
                    return true;
                }
                SearchTree cur = root;
                SearchTree anc = null;
                while (cur != null)
                {
                    anc = cur;
                    if ((elem.Key as IComparable).CompareTo(cur.Data.Key) == 0)
                        return false;
                   else if ((elem.Key as IComparable).CompareTo(cur.Data.Key) == -1)
                        cur = cur.Left;
                    else if ((elem.Key as IComparable).CompareTo(cur.Data.Key) == 1)
                        cur = cur.Right;
                }
                cur = new SearchTree(elem);
                if ((cur.Data.Key as IComparable).CompareTo(anc.Data.Key) == -1)
                    anc._left = cur;
                else
                    anc._right = cur;
                return true;
            }
            public static SearchTree Remove(TKey key, SearchTree root)
            {
                if (root == null)
                {
                    Console.WriteLine("Данного элемента нет в дереве");
                    return root;
                }
                if ((root.Data.Key as IComparable).CompareTo(key) == -1)
                    root._right = Remove(key, root.Right);
                else if ((root.Data.Key as IComparable).CompareTo(key) == 1)
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
            public static bool ContainsKey(TKey keyValue, SearchTree root)
            {
                if (root == null)
                    return false;
                if (root.Left != null && (root.Data.Key as IComparable).CompareTo(keyValue) == 1)
                    return ContainsKey(keyValue, root.Left);
                else if (root.Right != null && (root.Data.Key as IComparable).CompareTo(keyValue) == -1)
                    return ContainsKey(keyValue, root.Right);
                else
                    return true;
            }
            public static void CreateSearchTree(KeyValuePair<TKey, TValue>[] elems, SearchTree root)
            {
                foreach (KeyValuePair<TKey, TValue> cur in elems)
                    Add(cur, ref root);
            }
            public SearchTree(KeyValuePair<TKey,TValue> elem)
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
{0}
+--------------------------------------+
Значение:
+--------------------------------------+
{1}
+--------------------------------------+", Data.Key, Data.Value);
                if(Right != null)
                    Right.Show();
            }
            public void GetKeys(List<TKey> keys)
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
            public static TValue FindByKey(TKey keyValue, SearchTree root)
            {
                if (root == null)
                    throw new Exception("Элемента с таким ключом нет в словаре");
                if (root.Left != null && (root.Data.Key as IComparable).CompareTo(keyValue) == 1)
                    return FindByKey(keyValue, root.Left);
                else if (root.Right != null && (root.Data.Key as IComparable).CompareTo(keyValue) == -1)
                    return FindByKey(keyValue, root.Right);
                else if ((root.Data.Key as IComparable).CompareTo(keyValue) == 0)
                    return root.Data.Value;
                else
                    throw new Exception("Элемента с таким ключом нет в словаре");
            }
        }
        private SearchTree frame;
        public MySortedDictionary()
        {
            _count = 0;
            frame = new SearchTree(new KeyValuePair<TKey, TValue>(default(TKey), default(TValue)));
        }
        public MySortedDictionary(MySortedDictionary<TKey,TValue> ancDict)
        {
            foreach(TKey x in ancDict)
                this.Add(new KeyValuePair<TKey, TValue>(x, ancDict[x]));
        }
        public IEnumerator<TKey> GetEnumerator()
        {
            return Keys.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public TKey Current
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
        public bool ContainsKey(TKey keyValue)
        {
            return SearchTree.ContainsKey(keyValue, frame);
        }
        public bool ContainsValue(TValue value)
        {
            return Values.Contains<TValue>(value);
        }
        public TValue this[TKey key]
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
            set
            {
                if (ContainsKey(key))
                {
                    Remove(key);
                    Add(new KeyValuePair<TKey, TValue>(key, value));
                }
                else
                    throw new Exception("Элемент с таким ключом отсуствует");
            }
        }
        public void Add (KeyValuePair<TKey, TValue> curElem)
        {
            if (SearchTree.Add(curElem, ref frame))
                _count++;
            else
                Console.WriteLine("Элемент с таким ключом уже находится в коллекции");
        }
        public void Remove(TKey keyValue)
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
        public void Show()
        {
            frame.Show();
        }
    }
}
