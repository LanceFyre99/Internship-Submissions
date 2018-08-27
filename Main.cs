using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
    public class Program
    {
	    public class FolderPreferences
	    {
		    public List<string> Folders2Secure { get; set; }
		    public List<string> Folders2Delete { get; set; }
	    }
	
	    public static void Main()
	    {
		    var input = new StreamReader("YamlTest.yml");

		    var deserializerBuilder = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention());

            var deserializer = deserializerBuilder.Build();

            var result = deserializer.Deserialize<FolderPreferences>(input);

            Console.WriteLine("Folders2Delete:");
            foreach (var item in result.Folders2Delete) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Folders2Secure:");
            foreach (var item in result.Folders2Secure) {
                Console.WriteLine(item);
            }
	    }
    }
}