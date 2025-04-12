using graficoU3D;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace graficoU3D
{
    class Game : GameWindow
    {
        private Objeto objetoT;
        private Escenario escenario;
        private Stopwatch tiempoAplicacion;
        private Parte cuboBase;
        private Parte cuboIzq;
        private Parte cuboDer;
        private float angulo = 0.0f;
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) {
            escenario = new Escenario();
            //InicializarEscenario();

            DibujarLetraConJson();
            //var poligonos = Vertice.CrearPoligonos();
            //List<Vertice> verticesParaSerializar = new List<Vertice>();

            // Extraer los vértices de cada polígono
            //foreach (KeyValuePair<string, Poligono> poligono in poligonos)
            //{
              //  verticesParaSerializar.AddRange(poligono.Value.GetVertices());
            //}

            // Serializar a JSON usando Newtonsoft
            //string json = JsonConvert.SerializeObject(verticesParaSerializar, Formatting.Indented);

            // Guardar en archivo
            //File.WriteAllText("vertices.json", json);

            // Si querés deserializar después:
            //List<Vertice> verticesDeserializados = JsonConvert.DeserializeObject<List<Vertice>>(File.ReadAllText("vertices.json"));
            //var poligonos = CrearPoligonosDesdeVertices(vertices);
        }
        private void InicializarEscenario()
        {

            //objetoT = CrearObjetoT();
            //escenario.Add(1, objetoT);  // Añadir el objeto al escenario
            List<Vertice> vertices = JsonConvert.DeserializeObject<List<Vertice>>(File.ReadAllText("vertices.json"));
            Dictionary<string, Poligono> poligonos = CrearPoligonosDesdeVertices(vertices);
            var cuboBase = CrearCuboDesdePoligonos(poligonos);
            var objetoT = new Objeto();
            objetoT.Add(1, cuboBase);
            escenario.Add(1, objetoT);
            /*
            // Otra figura desplazada a la derecha
            var u2Poligonos = Vertice.CrearPoligonos(7f, 0f, 0f);
            var parteU2 = CrearCuboDesdePoligonos(u2Poligonos);
            var objetoU2 = new Objeto();
            objetoU2.Add(1, parteU2);
            escenario.Add(2, objetoU2);

            // Otra más a la izquierda
            var u3Poligonos = Vertice.CrearPoligonos(0f, -7f, 0f);
            var parteU3 = CrearCuboDesdePoligonos(u3Poligonos);
            var objetoU3 = new Objeto();
            objetoU3.Add(1, parteU3);
            escenario.Add(3, objetoU3);
            */
        }
        private Dictionary<string, Poligono> CrearPoligonosDesdeVertices(List<Vertice> vertices)
        {
            var poligonos = new Dictionary<string, Poligono>();

            // Asume que cada 4 vértices forman un polígono
            int numPoligonos = vertices.Count / 4;
            for (int i = 0; i < numPoligonos; i++)
            {
                var verts = new List<Vertice>
        {
            new Vertice(vertices[i * 4 + 0].X, vertices[i * 4 + 0].Y, vertices[i * 4 + 0].Z),
            new Vertice(vertices[i * 4 + 1].X, vertices[i * 4 + 1].Y, vertices[i * 4 + 1].Z),
            new Vertice(vertices[i * 4 + 2].X, vertices[i * 4 + 2].Y, vertices[i * 4 + 2].Z),
            new Vertice(vertices[i * 4 + 3].X, vertices[i * 4 + 3].Y, vertices[i * 4 + 3].Z),
        };
                Console.WriteLine("Este es un comentario");
                string nombrePoligono = $"poligono{i + 1}";
                poligonos[nombrePoligono] = new Poligono();
            }

            return poligonos;
        }
        private Parte CrearCuboDesdePoligonos(Dictionary<string, Poligono> poligonos)
        {
            var parte = new Parte();
            parte.Add(1, poligonos["poligono1"]);
            parte.Add(2, poligonos["poligono2"]);
            parte.Add(3, poligonos["poligono3"]);
            parte.Add(4, poligonos["poligono4"]);
            parte.Add(5, poligonos["poligono5"]);
            parte.Add(6, poligonos["poligono6"]);
            parte.Add(7, poligonos["poligono7"]);
            parte.Add(8, poligonos["poligono8"]);
            parte.Add(9, poligonos["poligono9"]);
            parte.Add(10, poligonos["poligono10"]);
            parte.Add(11, poligonos["poligono11"]);
            parte.Add(12, poligonos["poligono12"]);
            parte.Add(13, poligonos["poligono13"]);
            parte.Add(14, poligonos["poligono14"]);
            parte.Add(15, poligonos["poligono15"]);
            parte.Add(16, poligonos["poligono16"]);
            parte.Add(17, poligonos["poligono17"]);
            parte.Add(18, poligonos["poligono18"]);
            return parte;
        }
        /*
        private Parte CrearCuboDesdePoligonos(Dictionary<string, Poligono> poligonos)
        {
            var parte = new Parte();
            parte.Add(1, poligonos["base"]);
            parte.Add(2, poligonos["izquierdo"]);
            parte.Add(3, poligonos["derecho"]);
            parte.Add(4, poligonos["frontal"]);
            parte.Add(5, poligonos["trasera"]);
            parte.Add(6, poligonos["superior"]);
            parte.Add(7, poligonos["base2"]);
            parte.Add(8, poligonos["izquierdo2"]);
            parte.Add(9, poligonos["derecho2"]);
            parte.Add(10, poligonos["frontal2"]);
            parte.Add(11, poligonos["trasera2"]);
            parte.Add(12, poligonos["superior2"]);
            parte.Add(13, poligonos["base3"]);
            parte.Add(14, poligonos["izquierdo3"]);
            parte.Add(15, poligonos["derecho3"]);
            parte.Add(16, poligonos["frontal3"]);
            parte.Add(17, poligonos["trasera3"]);
            parte.Add(18, poligonos["superior3"]);
            return parte;
        }
        */
        private Objeto CrearObjetoT()
        {
            var objeto = new Objeto();
            cuboBase = crearCuboBase();
            objeto.Add(1, cuboBase);
            return objeto;
        }

        private Parte crearCuboBase()
        {
            var cuboBase = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            cuboBase.Add(1, poligonos["base"]);
            cuboBase.Add(2, poligonos["izquierdo"]);
            cuboBase.Add(3, poligonos["derecho"]);
            cuboBase.Add(4, poligonos["frontal"]);
            cuboBase.Add(5, poligonos["trasera"]);
            cuboBase.Add(6, poligonos["superior"]);
            cuboBase.Add(7, poligonos["base2"]);
            cuboBase.Add(8, poligonos["izquierdo2"]);
            cuboBase.Add(9, poligonos["derecho2"]);
            cuboBase.Add(10, poligonos["frontal2"]);
            cuboBase.Add(11, poligonos["trasera2"]);
            cuboBase.Add(12, poligonos["superior2"]);
            cuboBase.Add(13, poligonos["base3"]);
            cuboBase.Add(14, poligonos["izquierdo3"]);
            cuboBase.Add(15, poligonos["derecho3"]);
            cuboBase.Add(16, poligonos["frontal3"]);
            cuboBase.Add(17, poligonos["trasera3"]);
            cuboBase.Add(18, poligonos["superior3"]);
            return cuboBase;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-10, 12, -10, 10, -15, 15);
            // Establecer la matriz de modelo/visión
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            // Coloca la cámara lejos y más arriba, mirando hacia abajo
            //GL.Rotate(35f, 1f, 0f, 0f);   // Primero rotamos (vista inclinada)
            //GL.Rotate(15f, 0f, 1f, 0f);   // Rotamos en Y para ver mejor los lados
            //GL.Translate(0f, -2f, -8f);   // Luego alejamos/bajamos la cámara
            //tiempoAplicacion = Stopwatch.StartNew();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            // 🔄 Aplica rotación antes de dibujar
            //GL.Rotate(angulo, 0.0f, 1.0f, 0.0f); // Gira sobre el eje Y
            GL.Rotate(angulo, 1.0f, 0.0f, 0.0f); // Gira sobre el eje Y
            //GL.Rotate(angulo, 0.0f, 0.0f, 1.0f); // Gira sobre el eje Y
            DibujarEjes();
            escenario.Draw();

            SwapBuffers();
            // 🔁 Aumenta el ángulo para el próximo frame
            angulo += 1.0f;
        }

        private void DibujarLetraConJson()
        {
            List<Poligono> poligonos = new List<Poligono>();
            var verticesDeserializados = JSON_serializador.Deserializar("vertices.json");

            int id = 0;
            int contador = 0;
            Poligono nuevoPoligono = new Poligono();

            foreach (var vertice in verticesDeserializados)
            {
                nuevoPoligono.Add(id++, vertice);
                contador++;

                if (contador % 4 == 0)
                {
                    nuevoPoligono.Color = new Color4(1.0f, 1.0f, 0.0f, 1.0f);
                    poligonos.Add(nuevoPoligono); // Guardamos el polígono completo

                    // Creamos uno nuevo desde cero
                    nuevoPoligono = new Poligono();
                    

                    id = 0; // Reiniciar IDs por polígono, opcional
                }
            }

            // Asegurarse de que hay suficientes polígonos
            Parte nuevaParte = new Parte();
            for (int j = 0; j < poligonos.Count; j++)
            {
                nuevaParte.Add(j, poligonos[j]);
            }

            Objeto nuevoObjeto = new Objeto();
            nuevoObjeto.Add(1, nuevaParte);

            escenario.Add(1, nuevoObjeto);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState teclado = Keyboard.GetState();
            if (teclado.IsKeyDown(Key.Left))
                angulo -= 1.0f;
            if (teclado.IsKeyDown(Key.Right))
                angulo += 1.0f;
            //ProbarAnimacion();
        }
        private void DibujarEjes()
        {
            GL.LineWidth(4.0f);
            GL.Begin(PrimitiveType.Lines);

            // Eje X 
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(-5.0f, 0.0f, 0.0f);
            GL.Vertex3(5.0f, 0.0f, 0.0f);

            // Eje Y 
            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, -2.0f, 0.0f);
            GL.Vertex3(0.0f, 2.0f, 0.0f);

            // Eje Z 
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, -5.0f);
            GL.Vertex3(0.0f, 0.0f, 5.0f);

            GL.End();
            GL.LineWidth(1.0f);
        }
        
    }
}
