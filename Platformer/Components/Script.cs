using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Components
{
    class Script : Component
    {
        public Script()
        {
            ComponentRegistry.Register<Script>(this);
            //Systems.ScriptSystem.Register(this);
            //Systems.CollisionSystem.CollisionEnter += OnCollision;
        }

        public virtual void OnCollision(Object sender, Systems.Collision collision)
        {
            Console.WriteLine("In Script OnCollision");
        }
    }
}
