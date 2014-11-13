using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListDemo
{
    public class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 引用域
        /// </summary>
        public Node<T> Next { get; set; }

        #region ctor

        /// <summary>
        /// 只包含引用域的节点
        /// </summary>
        /// <param name="p"></param>
        public Node(Node<T> p)
        {
            Next = p;
        }

        /// <summary>
        /// 包含数据域和引用域的节点
        /// </summary>
        /// <param name="val"></param>
        /// <param name="p"></param>
        public Node(T val, Node<T> p)
        {
            Data = val;
            Next = p;
        }

        /// <summary>
        /// 只包含数据域的节点
        /// </summary>
        /// <param name="val"></param>
        public Node(T val)
        {
            Data = val;
            Next = null;
        }

        /// <summary>
        /// 不包含引用域和数据域的节点
        /// </summary>
        public Node()
        {
            Data = default(T);
            Next = null;
        }

        #endregion 
    }
}
