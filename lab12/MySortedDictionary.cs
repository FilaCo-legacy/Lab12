using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    public class MySortedDictionary<K, T>:IEnumerable<T>, IEnumerator<T>, ICloneable
    {
        private int _count;
        public int Count { get { return _count; } }
        private int _capacity;
        public int Capacity { get { if (_capacity < Count) _capacity = Count * 2; return _capacity; } }
        public IComparable[] Keys
        {
            get
            {
                int ind = 0;
                IComparable[] arr = new IComparable[Count];
                frame.GetKeys(ref ind, ref arr);
                return arr;
            }
        }
        public T[] Values
        {
            get
            {
                int ind = 0;
                T[] arr = new T[Count];
                frame.GetValues(ref ind, ref arr);
                return arr;
            }
        }
        private class SearchTree
        {
            private KeyValuePair<IComparable, T> data;
            private SearchTree left, right;
            public static void Add(KeyValuePair<IComparable, T> elem, SearchTree root)
            {
                SearchTree cur = root;
                SearchTree anc = null;
                while (cur != null)
                {
                    anc = cur;
                    if (elem.Key.CompareTo(cur.data.Key) == 0)
                        return;
                    if (elem.Key.CompareTo(cur.data.Key) == -1)
                        cur = cur.left;
                    if (elem.Key.CompareTo(cur.data.Key) == 1)
                        cur = cur.right;
                }
                cur = new SearchTree(elem);
                if (cur.data.Key.CompareTo(anc.data.Key) == -1)
                    anc.left = cur;
                else
                    anc.right = cur;

            }
            public static SearchTree Remove(IComparable key, SearchTree root)
            {
                if (root == null)
                {
                    Console.WriteLine("Данного элемента нет в дереве");
                    return root;
                }
                if (root.data.Key.CompareTo(key) == -1)
                    root.right = Remove(key, root.right);
                else if (root.data.Key.CompareTo(key) == 1)
                    root.left = Remove(key, root.left);
                else
                {
                    Console.WriteLine("Элемент {0} подлежит удалению...", root.data.Value);
                    if (root.left == null && root.right == null)
                        return null;
                    else if (root.left == null && root.right != null)
                        root = root.right;
                    else if (root.left != null && root.right == null)
                        root = root.left;
                    else
                    {
                        if (root.right.left == null)
                        {
                            root.right.left = root.left;
                            root = root.right;
                        }
                        else
                        {
                            root.data = root.right.left.data;
                            root.right.left = Remove(root.right.left.data.Key, root.right.left);
                        }
                    }
                }
                return root;

            }
            public static bool ContainsKey(IComparable keyValue, SearchTree root)
            {
                if (root == null)
                    return false;
                if (root.left != null && root.data.Key.CompareTo(keyValue) == 1)
                    return ContainsKey(keyValue, root.left);
                else if (root.right != null && root.data.Key.CompareTo(keyValue) == -1)
                    return ContainsKey(keyValue, root.right);
                else
                    return true;
            }
            public static void CreateSearchTree(KeyValuePair<IComparable, T>[] elems, SearchTree root)
            {
                foreach (KeyValuePair<IComparable, T> cur in elems)
                    Add(cur, root);
            }
            public SearchTree(KeyValuePair<IComparable,T> elem)
            {
                data = elem;
                left = null;
                right = null;
            }
            public void Show(ref int iter)
            {
                if (left != null)
                {
                    left.Show(ref iter);
                    iter++;
                }
                Console.WriteLine(@"Номер элемента: {0}
Ключ:
+--------------------------------------+
{1}
+--------------------------------------+
Значение:
+--------------------------------------+
{2}
+--------------------------------------+", iter+1, data.Key, data.Value);
                iter++;
                if(right != null)
                {
                    right.Show(ref iter);
                    iter++;
                }
            }
            public void GetKeys(ref int iter, ref IComparable[] keys)
            {
                if (left != null)
                {
                    left.GetKeys(ref iter, ref keys);
                    iter++;
                }
                keys[iter] = data.Key;
                iter++;
                if (right != null)
                {
                    right.GetKeys(ref iter, ref keys);
                    iter++;
                }
            }
            public void GetValues(ref int iter, ref T[] values)
            {
                if (left != null)
                {
                    left.GetValues(ref iter, ref values);
                    iter++;
                }
                values[iter] = data.Value;
                iter++;
                if (right != null)
                {
                    right.GetValues(ref iter, ref values);
                    iter++;
                }
            }
        }
        private SearchTree frame;
        public MySortedDictionary(int initCapacity=10)
        {
            _capacity = initCapacity;
        }
        public MySortedDictionary(MySortedDictionary<K,T> ancDict)
        {

        }
        public bool ContainsKey(IComparable keyValue)
        {

        }
    }
}
