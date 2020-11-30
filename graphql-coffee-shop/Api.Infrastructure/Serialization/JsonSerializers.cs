using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Serialization
{
    public static class JsonSerializers
    {
        public static JsonSerializerSettings MenuModelSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            SerializationBinder = new KnownTypesBinder
            {
                KnownTypes = new List<Type>
                {
                    typeof(SubMenuModel)
                }
            }
        };

        public static JsonSerializerSettings SubMenuModelSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            SerializationBinder = new KnownTypesBinder
            {
                KnownTypes = new List<Type>
                {
                    typeof(MenuModel)
                }
            }
        };
    }
}