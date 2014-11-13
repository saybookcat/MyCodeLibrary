using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Arithmetic
{
    public class LinkList
    {
        public class LinkNode
        {
            public int Data { get; set; }

            public LinkNode Next { get; set; }
        }

        private LinkNode _head;

        public void Add(int data)
        {
            if (_head == null)
            {
                _head = new LinkNode() {Data = data};
            }
            else
            {
                Add(_head,data);
            }
        }

        public void Add(LinkNode node, int data)
        {
            if (node.Next == null)
            {
                node.Next = new LinkNode() {Data = data};
            }
        }

        public void Add2(int data)
        {
            LinkNode node = new LinkNode() {Data = data};
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                LinkNode temp = _head;
                while (temp.Next!=null)
                {
                    temp = temp.Next;
                }
                temp.Next = node;
            }
        }
    }

}
