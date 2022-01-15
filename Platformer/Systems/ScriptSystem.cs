using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer.Systems
{
    class ScriptSystem : BaseSystem
    {
        private List<Components.Script> _scripts;

        public override void Start()
        {
            base.Start();

            _scripts = ComponentRegistry.GetAll<Components.Script>();

            foreach(Components.Script script in _scripts)
            {
                script.Start();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(Components.Script script in _scripts)
            {
                script.Update(gameTime);
            }
        }
    }
}
