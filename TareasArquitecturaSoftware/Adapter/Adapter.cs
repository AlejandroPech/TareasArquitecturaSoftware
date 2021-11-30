using System;

namespace TareasArquitecturaSoftware.Adapter
{
    public class Adapter
    {
        public static void MainAdapter()
        {            
            Adaptee adaptee = new Adaptee();
            ITarget target = new AdapteClass(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }
    }

    public interface ITarget
    {
        string GetRequest();
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // The AdapterClass makes the Adaptee's interface compatible with the Target's
    // interface.
    class AdapteClass: ITarget
    {
        private readonly Adaptee _adaptee;

        public AdapteClass(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}
