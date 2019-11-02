﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;

namespace Fenit.Toolbox.Yaml.Extension
{
    public static class Extensions
    {
        public static string SerializationYaml(this object srcDir)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new Serializer();
                serializer.Serialize(stringWriter, srcDir);
                return stringWriter.ToString();
            }
        }

        public static T DeserializationYaml<T>(this string @string)
        {
            var deserializer = new DeserializerBuilder()
                .Build();
            var contacts = deserializer.Deserialize<T>(@string);
            return contacts;
        }
    }
}