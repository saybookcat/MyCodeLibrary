
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList<int> link=new LinkList<int>();
            link.Append(8);
            link.Append(1);
            link.Append(6);
            link.Append(3);
            //var result = Reverse(link.Head);
           
            Console.WriteLine(link.GetLength());
            
            link.PrintAllNode();
            Console.ReadKey();
        }

        private static Node<int> Reverse(Node<int> node)
        {
            if (node.Next == null) return node;
            var prevNdoe = Reverse(node.Next);
            var temp = node.Next;
            temp.Next = node;
            temp.Data = node.Data;
            node.Next = null;
            return prevNdoe;
        }
    }
}
