using System;
using System.IO;
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
    class Program
    {
        static void Main(string[] args)
        {
            var input = new StreamReader(path: "YamlTest.yml");

            var yaml = new YamlStream();
            yaml.Load(input);

            var deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();

            var stuff = deserializer.Deserialize<Stuff>(input);

            var mapping =
                (YamlMappingNode)yaml.Documents[0].RootNode;
            /*
            foreach (var entry in mapping.Children)
            {
                Console.WriteLine(((YamlScalarNode)entry.Key).Value);
            }

            var Statistics = (YamlSequenceNode)mapping.Children[new YamlScalarNode("Statistics")];
            
            foreach (YamlMappingNode Stat in Statistics) {
                Console.WriteLine(
                    "{0}\t{1}",
                    Stat.Children[new YamlScalarNode("Name")],
                    Stat.Children[new YamlScalarNode("Hardness")],
                    Stat.Children[new YamlScalarNode("Height")],
                    Stat.Children[new YamlScalarNode("Width")],
                    Stat.Children[new YamlScalarNode("Thickness")]
                );
            }
            */
            Console.WriteLine(stuff.Stringy);
            //Console.WriteLine(stuff.Num2);
        }
        public class Stuff {
            public int Num1 { get; set; }
            public int Num2 { get; set; }
            public string Stringy { get; set; }
        }
    }
}