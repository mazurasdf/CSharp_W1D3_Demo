using System;
using System.Collections.Generic;

namespace Abstract
{
    //list method signatures, include properties
    //checklist for a class
    //defines what a class DOES
    interface IRandomize
    {
        void Randomize();
        void Reverse();
        List<string> Items{get;}
    }

    // implement methods, add fields, allow for children
    // define what a class IS
    abstract class Lunch
    {
        protected List<string> items;
        public Lunch()
        {
            items = new List<string>();
        }

        public virtual void Add(string item){
            items.Add(item);
        }
        public abstract void Eat();
    }

    class Sandwich: Lunch, IRandomize
    {
        public List<string> Items{get{return items;}}
        public Sandwich() : base(){
            items.Add("bread");
            items.Add("bread");
        }

        public void Randomize()
        {
            Random rand = new Random();
            for(int i = 1; i < items.Count - 1; ++i)
            {
                int place = rand.Next(1, items.Count - 1);
                string temp = items[i];
                items[i] = items[place];
                items[place] = temp;
            }
        }

        public void Reverse()
        {
            Console.WriteLine("reverse");
        }

        public override void Eat()
        {
            Console.WriteLine("yum!");
        }
        public override void Add(string ingredient)
        {
            items.Insert(items.Count-1, ingredient);
        }
    }

    class NamesInHat : IRandomize
    {
        private List<string> names;
        public List<string> Items{get{return names;}}

        public NamesInHat(){
            names = new List<string>();
        }

        public void Randomize(){
            Random rand = new Random();
            for(int i = 0; i < names.Count; ++i)
            {
                int place = rand.Next(names.Count);
                string temp = names[i];
                names[i] = names[place];
                names[place] = temp;
            }
        }

        public void Reverse(){
            Console.WriteLine("reverse");
        }
        public void Add(string[] newNames)
        {
            for(int i = 0; i < newNames.Length; ++i)
            {
                names.Add(newNames[i]);
            }
        }

        public void Add(string name)
        {
            names.Add(name);
        }
    }


    class Program
    {
        public static void Randomize(IEnumerable<object> items){
            
        }
        static void Main(string[] args)
        {
            // NamesInHat hat = new NamesInHat();
            // hat.Add(new string[] {"Mike", "Eric", "Mitchell"});
            // hat.Add("Cam");
            // hat.Add("Brett");
            // Console.WriteLine("[{0}]", string.Join(", ", hat.Items));
            // hat.Randomize();
            // Console.WriteLine("[{0}]", string.Join(", ", hat.Items));

            Sandwich disaster = new Sandwich();
            disaster.Add("peanut butter");
            disaster.Add("jelly");
            disaster.Add("honey baked ham");
            disaster.Add("pastrami");
            disaster.Add("tilapia");
            disaster.Add("grapes");
            disaster.Add("cheese");
            disaster.Add("tums");
            disaster.Add("mayo");
            disaster.Add("pickle juice");
            disaster.Add("Shoe");
            Console.WriteLine("[{0}]", string.Join(", ", disaster.Items));
            disaster.Randomize();
            Console.WriteLine("[{0}]", string.Join(", ", disaster.Items));            
        }
    }
}
