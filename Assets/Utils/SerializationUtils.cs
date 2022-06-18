using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Utils
{
    public static class SerializationUtils
    {
        public static float DeserializeFloat(byte[] bytes) 
        {
            return BitConverter.ToSingle(bytes);
        }
        public static byte[] SerializeFloat(float value) 
        {
            return BitConverter.GetBytes(value);
        }
        
        public static UnityEngine.Vector3 ReadUnityEngine_Vector3(this BinaryReader reader) 
        {
            var self = new UnityEngine.Vector3();
            self.x = reader.ReadSingle();
            self.y = reader.ReadSingle();
            self.z = reader.ReadSingle();
            return self;
        }
        public static void Serialize(this UnityEngine.Vector3 self, BinaryWriter writer) 
        {
            writer.Write(self.x);
            writer.Write(self.y);
            writer.Write(self.z);
        }
    }
}