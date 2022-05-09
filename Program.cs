using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace POO2_ListeChanee
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.AddHead("1");
            myLinkedList.AddHead("2");
            myLinkedList.AddHead("3");
            Console.WriteLine(myLinkedList.GetSize());
            Console.WriteLine(myLinkedList.GetHead());
            Console.WriteLine(myLinkedList.GetTail());
            Console.WriteLine(myLinkedList.isEmpty());
            foreach (MyNode node in myLinkedList)
            {
                Console.WriteLine(node.ToString());
            }
            Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            
        }
    }
    class MyLinkedList : IEnumerator, IEnumerable
    {
        private MyNode head;
        private MyNode tail;
        private int count = 0;
        int position = -1;
        //IEnumerator and IEnumerable require these methods.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < GetSize());
        }
        //IEnumerable
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return GetNodeByPosition(position); }
        }
        private MyNode GetNodeByPosition(int position)
        {
            int startingPosition = 0;
            MyNode current = head;
            while (startingPosition < position)
            {
                current = current.Next;
                startingPosition++;
            }
            return current;
        }
        public void AddHead(object input)
        {
            MyNode newNode = new MyNode(input);
            if (this.head == null)
            {
                this.tail = newNode;
            }
            else if (this.head == this.tail)
            {
                newNode.Next = this.head;
            }
            else
            {
                newNode.Next = this.head;
                newNode.Previous = this.tail;
                newNode.Next.Previous = newNode;
            }
            this.head = newNode;
            count++;
        }
        public void RemoveHead()
        {
            if (this.head != null)
            {
                if (this.head == this.tail)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.head = this.head.Next;
                    this.head.Previous = this.tail;
                    this.count--;
                    if (this.count == 1)
                    {
                        this.tail = this.head;
                    }
                }
            }

        }
        public void AddTail(object input)
        {
            MyNode newNode = new MyNode(input);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else if (this.head == this.tail)
            {
                this.head.Next = newNode;
            }
            else
            {
                newNode.Next = this.head;
                newNode.Previous = this.tail;
                newNode.Previous.Next = newNode;
            }
            this.tail = newNode;
            count++;
        }
        public void RemoveTail()
        {
            if (this.head != null)
            {
                if (this.head == this.tail)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.tail = this.tail.Previous;
                    this.tail.Next = this.head;
                    this.count--;
                    if (this.count == 1)
                    {
                        this.head = this.tail;
                    }
                }
            }
        }

        public bool isEmpty()
        {
            return this.head == null;
        }
        public MyNode GetHead()
        {
            return head;
        }
        public MyNode GetTail()
        {
            return tail;
        }
        public int GetSize()
        {
            return count;
        }
    }

    class MyNode
    {
        private MyNode previous;
        private MyNode next;
        public object data;
        public MyNode(object data)
        {
            this.data = data;
        }
        public MyNode Previous
        {
            get { return previous; }
            set { previous = value; }
        }
        public MyNode Next
        {
            get { return next; }
            set { next = value; }
        }
        public override string ToString()
        {
            return this.data.ToString();
        }
    }

}
