using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListDemo
{
    public class LinkList<T>:IListDS<T>
    {
        public Node<T> Head { get; set; }

        public LinkList()
        {
            Head = null;
        }

        #region 基本操作

        public int GetLength()
        {
            //设置指针的指向头节点
            Node<T> p = Head;
            int len = 0;
            while (p != null)
            {
                len++;
                p = p.Next; //指针继续指向引用域
            }
            return len;
        }

        /// <summary>
        /// 内存将由GC清理
        /// </summary>
        public void Clear()
        {
            Head = null;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        /// <summary>
        /// 在单链表尾部追加元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Append(T item)
        {
            Node<T> node = new Node<T>(item);
            Node<T> p = new Node<T>();

            // 判断此时是否为空表，是则直接修改头结点的引用域
            if (Head == null)
            {
                Head = node;
            }
            // 不是则遍历结点，找到最后最后一个结点
            else
            {
                p = Head;
                while (p.Next != null)
                {
                    p = p.Next;
                }

                // 设置最后一个结点的引用域为追加数据元素的地址
                p.Next = node;
            }

            return true;
        }

        /// <summary>
        /// 在单链表的第i个节点的位置前插入一个值为item的节点
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool Insert(T item, int i)
        {
            if (IsEmpty())
            {
                //链表中不存在元素，无法在指定位置插入元素
                return false;
            }
            else if (i < 1)
            {
                //指定位置不合理
                return false;
            }
            else if (i == 1)
            {
                Node<T> node = new Node<T>(item);
                node.Next = Head;
                Head = node;
                return true;
            }
            else
            {
                //执行一般插入操作
                Node<T> p = Head;
                Node<T> pre=new Node<T>();
                int j = 1;

                //遍历直到当前节点的位置为i
                //如果插入位置超过单链表长度，则插入失败
                while (p.Next!=null && j<i)
                {
                    pre = p;
                    p = p.Next;
                    j++;
                }
                if (j == i)
                {
                    Node<T> node = new Node<T>(item);
                    node.Next = p;
                    pre.Next = node;
                    return true;
                }
                else
                {
                    //插入位置异常
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除单链表的第i个节点，只修改引用域
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Delete(int i)
        {
            //定义用于返回的元素
            T temp = default(T);
            if (IsEmpty())
            {
                //单链表不存在数据，操作失败
                return temp;
            }
            else if (i < 1)
            {
                //删除位置不正确，操作失败
                return temp;
            }
            else if(i==1)
            {
                Node<T> node = Head;
                Head = Head.Next;
                temp = node.Data;
            }
            else
            {
                Node<T> node=new Node<T>();
                Node<T> p = Head;
                int j = 1;

                while (p.Next!=null && j<i)
                {
                    node = p;
                    p = p.Next;
                    j++;
                }
                if (j == i)
                {
                    node.Next = p.Next;
                    temp = p.Data;
                }
                else
                {
                    //删除元素位置不正确，操作失败
                }
            }
            return temp;
        }

        /// <summary>
        /// 获取单链表第i个元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElem(int i)
        {
            // 定义要返回的元素，并赋初值
            T tmp = default(T);

            // 判断是否为空表
            if (IsEmpty())
            {
                Console.WriteLine("单链表表中不存在数据元素，无法执行获取操作，操作失败！");
            }
            // 判断用户指定的获取位置是否合理
            else if (i < 1)
            {
                Console.WriteLine("获取元素的位置不正确，无法执行获取操作，操作失败！");
            }
            // 执行获取操作，如果位置超过单链表长度，则获得到的为最后一个结点的值
            else
            {
                Node<T> p = new Node<T>();
                p = Head;
                int j = 1;

                while (p.Next != null && j < i)
                {
                    p = p.Next;
                    j++;
                }

                tmp = p.Data;
            }

            // 返回被操作的元素（或默认值）
            return tmp;
        }

        /// <summary>
        /// 在单链表中查找值为value的节点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Locate(T value)
        {
            // 定义要返回的索引，-1表示未找到或查找失败【注意：此处i表示是索引，而非位置！】
            int i;

            // 判断是否为空表
            if (IsEmpty())
            {
                Console.WriteLine("单链表表中不存在数据元素，无法执行查找操作，操作失败！");
                i = -1;
            }
            // 执行查找操作
            else
            {
                Node<T> p = new Node<T>();
                p = Head;
                i = 0;
                while (!p.Data.Equals(value) && p.Next != null)
                {
                    p = p.Next;
                    i++;
                }
            }

            // 返回查找到的索引（或默认值）
            return i;
        }

        #endregion 

        #region 高级操作
        // 打印单链表所有结点
        public void PrintAllNode()
        {
            // 判断是否为空表
            if (IsEmpty())
            {
                Console.WriteLine("单链表表中不存在数据元素，无法执行打印操作，操作失败！");
            }
            // 执行打印操作
            else
            {
                Console.WriteLine("打印单链表中的数据元素：\n");
                Node<T> p = new Node<T>();
                p = Head;
                while (p.Next != null)
                {
                    Console.Write(p.Data + "\t");
                    p = p.Next;
                }

                // 打印最后一个结点
                Console.Write(p.Data + "\t");

                Console.WriteLine();
            }
        }
        #endregion
    }
}
