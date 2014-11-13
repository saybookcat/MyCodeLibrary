using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListDemo
{
    /// <summary>
    /// 泛型线性表接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListDS<T>
    {
        int GetLength();
        void Clear();

        /// <summary>
        /// 判断链表是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 附加一个元素到链表结尾
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Append(T item);


        /// <summary>
        /// 在链表的i位置插入元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        bool Insert(T item, int i);

        /// <summary>
        /// 删除链表i位置的元素，并返回被删除的元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T Delete(int i);

        /// <summary>
        /// 取得链表位置i的元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T GetElem(int i);

        /// <summary>
        /// 按值查找链表中首个符合条件的元素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int Locate(T value);
    }
}
