using System;

namespace blarg
{
    internal class Node {
        internal int data;
        internal Node next;
        public Node(int d) {
            data = d;
            next = null;
        }
    }
    
    internal class SingleLinkedList {
        internal Node head;
    
        internal void InsertFront(int new_data) {    
            Node new_node = new Node(new_data);    
            new_node.next = this.head;    
            this.head = new_node;    
        }
        internal void InsertLast(int new_data)    
        {    
            Node new_node = new Node(new_data);    
            if (this.head == null) {    
             this.head = new_node;    
                return;    
            }    
            Node lastNode = GetLastNode();    
            lastNode.next = new_node;    
        }    
        internal Node GetLastNode() {  
            Node temp = this.head;  
            while (temp.next != null) {  
                temp = temp.next;  
            }  
            return temp;  
        }
        internal void WriteList() {
            Node temp = this.head;
            while (temp.next != null) {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
            Console.WriteLine(temp.data);
        }
        internal void KillFront() {
            Node temp = this.head.next;
            this.head.next = null;
            this.head = temp;


        }
        internal void KillLast() {
            Node temp = this.head;
            while (temp.next != this.GetLastNode()) {
                temp = temp.next;
            }
            temp.next = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sll = new SingleLinkedList();
            sll.InsertLast(74);
            sll.InsertLast(46);
            sll.InsertFront(28);
            sll.InsertLast(84);
            sll.InsertFront(52);
            sll.KillFront();
            sll.KillLast();
            sll.WriteList();
        }
    }
}
