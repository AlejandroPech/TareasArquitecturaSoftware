using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasArquitecturaSoftware.Builder
{
    public class Builder
    {
        public static void MainBuilder()
        {
            var director = new Director();
            var builder1 = new ConcreteBuilder1();
            var builder2 = new ConcreteBuilder2();
            director.Builder1 = builder1;
            director.Builder2 = builder2;

            Console.WriteLine("Standard basic product1:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder1.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product1:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder1.GetProduct().ListParts());

            Console.WriteLine("Custom product2:");
            builder2.BuildPartA();
            builder2.BuildPartC();
            Console.Write(builder2.GetProduct().ListParts());
        }
        
    }

    public class Director
    {
        private IBuilder _builder1;
        private IBuilder _builder2;
        public IBuilder Builder1
        {
            set { _builder1 = value; }
        }
        public IBuilder Builder2
        {
            set { _builder2 = value; }
        }
        public void BuildMinimalViableProduct()
        {
            this._builder1.BuildPartA();
        }
        public void BuildMinimalViableProduct2()
        {
            this._builder2.BuildPartA();
        }
        public void BuildFullFeaturedProduct()
        {
            this._builder1.BuildPartA();
            this._builder1.BuildPartB();
            this._builder1.BuildPartC();
        }
        public void BuildFullFeaturedProduct2()
        {
            this._builder2.BuildPartA();
            this._builder2.BuildPartB();
            this._builder2.BuildPartC();
        }
    }

    public interface IBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();
    }
    public class ConcreteBuilder1 : IBuilder
    {
        private Product1 _product = new Product1();
        public ConcreteBuilder1()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product1();
        }
        public void BuildPartA()
        {
            this._product.Add("PartA1");
        }

        public void BuildPartB()
        {
            this._product.Add("PartB1");
        }

        public void BuildPartC()
        {
            this._product.Add("PartC1");
        }

        public Product1 GetProduct()
        {
            Product1 result = this._product;

            this.Reset();

            return result;
        }
    }

    public class ConcreteBuilder2 : IBuilder
    {
        private Product2 _product = new Product2();
        public ConcreteBuilder2()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product2();
        }
        public void BuildPartA()
        {
            this._product.Add("PartA2");
        }

        public void BuildPartB()
        {
            this._product.Add("PartB2");
        }

        public void BuildPartC()
        {
            this._product.Add("PartC2");
        }

        public Product2 GetProduct()
        {
            Product2 result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product1
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }

    public class Product2
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }
}
