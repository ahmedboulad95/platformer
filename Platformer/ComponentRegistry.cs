using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Platformer
{
    class ComponentRegistry
    {
        private static Dictionary<Guid, List<object>> _componentsByType = new Dictionary<Guid, List<object>>();

        public static void Register<T>(T componentToAdd) where T : Components.Component
        {
            Guid typeGuid = typeof(T).GUID;
            Console.WriteLine("Registering component " + typeof(T));
            if(!_componentsByType.ContainsKey(typeGuid))
            {
                _componentsByType.Add(typeGuid, new List<object>());
            }
            _componentsByType[typeGuid].Add(componentToAdd);
        }

        public static List<T> GetAll<T>() where T : Components.Component
        {
            return _componentsByType[typeof(T).GUID].Cast<T>().ToList();
        }
    }
}
