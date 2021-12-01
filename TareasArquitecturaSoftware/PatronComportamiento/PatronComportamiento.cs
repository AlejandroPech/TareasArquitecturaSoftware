using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasArquitecturaSoftware.PatronComportamiento
{
    class Coche
    {
        public static void MainCoche()
        {
            var context = new Context(new Avanzando());
            context.Pericion1();
            context.Peticion2();
        }
    }
    class Context
    {
        // A reference to the current state of the Context.
        private EstadoActualCoche _estadoActual = null;

        public Context(EstadoActualCoche state)
        {
            this.TransitionTo(state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(EstadoActualCoche state)
        {
            Console.WriteLine($"El coche ha realizado la accion {state.GetType().Name}.");
            this._estadoActual = state;
            this._estadoActual.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public void Pericion1()
        {
            this._estadoActual.Estado1Coche();
        }

        public void Peticion2()
        {
            this._estadoActual.Estado2Coche();
        }
    }

    // The base State class declares methods that all Concrete State should
    // implement and also provides a backreference to the Context object,
    // associated with the State. This backreference can be used by States to
    // transition the Context to another State.
    abstract class EstadoActualCoche
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract void Estado1Coche();

        public abstract void Estado2Coche();
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class Avanzando : EstadoActualCoche
    {
        public override void Estado1Coche()
        {
            Console.WriteLine("El coche esta avanzando pero se va a detener");
            this._context.TransitionTo(new Detenido());
        }

        public override void Estado2Coche()
        {
            Console.WriteLine("El coche se encuentra avanzando");
        }
    }

    class Detenido : EstadoActualCoche
    {
        public override void Estado1Coche()
        {
            Console.Write("El coche se encuentra detenido");
        }

        public override void Estado2Coche()
        {
            Console.WriteLine("El coche se encuentra detenido pero empezara a avanzar");
            this._context.TransitionTo(new Avanzando());
        }
    }
}
