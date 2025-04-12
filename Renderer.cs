using OpenTK.Graphics.OpenGL;
using graficoU3D;
namespace graficoU3D
{
    public class Renderer
    {
        private Shader shader;

        public Renderer(Shader shader)
        {
            this.shader = shader;
        }

        public void Render(Mesh mesh)
        {
            shader.Use();
            mesh.Draw();
        }
    }
}
