using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab12
{
    public class MySortedDictionary<K, T>
    {
        private class SearchTree
        {
            KeyValuePair<IComparable, T> _data;
            SearchTree _left, _right;
            void Add(KeyValuePair<IComparable,T> elem)
            {
                SearchTree cur = this;
                SearchTree anc = null;
                while (cur != null)
                {
                    anc = cur;
                    if (elem.Key.CompareTo(cur._data.Key) == 0)
                        return;
                    if (elem.Key.CompareTo(cur._data.Key) == -1)
                        cur = cur._left;
                    if (elem.Key.CompareTo(cur._data.Key) == 1)
                        cur = cur._right;
                }
                cur = new SearchTree(elem);
                if (cur._data.Key.CompareTo(anc._data.Key) == -1)
                    anc._left = cur;
                else
                    anc._right = cur;
            }
            SearchTree(params KeyValuePair<IComparable,T>[] elems)
            {
                _data = elems[0];
                _left = null;
                _right = null;
                for (int i = 1; i < elems.Length; i++)
                    Add(elems[i]);
            }
            void Show(ref int iter)
            {
                if (_left != null)
                {
                    _left.Show(ref iter);
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
+--------------------------------------+", iter+1, _data.Key, _data.Value);
                iter++;
                if(_right != null)
                {
                    _right.Show(ref iter);
                    iter++;
                }
            }
        }
        public int Capacity;
        public MySortedDictionary(int initCapacity=10)
        {
        }
        public MySortedDictionary(MySortedDictionary<K,T> ancDict)
        {

        }
    }
}
