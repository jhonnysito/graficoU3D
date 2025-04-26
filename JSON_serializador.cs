using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace graficoU3D
{
    class JSON_serializador
    {
        // Serializar
        public static void Serializar(List<Vertice> vertices, string rutaArchivo)
        {
            try
            {
                string json = JsonConvert.SerializeObject(vertices, Formatting.Indented);
                File.WriteAllText(rutaArchivo, json);
                Console.WriteLine("Vértices serializados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al serializar los vértices: {ex.Message}");
            }
        }

        // Deserializar
        public static List<Vertice> Deserializar(string rutaArchivo)
        {
            try
            {
                string json = File.ReadAllText(rutaArchivo);
                var vertices = JsonConvert.DeserializeObject<List<Vertice>>(json);
                Console.WriteLine("Vértices deserializados correctamente.");
                return vertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar los vértices: {ex.Message}");
                return null;
            }
        }
    }
}
