ususing OpenTK;

namespace graficoU3D
{
    class Transform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);

        public Matrix4 GetModelMatrix()
        {
            Matrix4 translation = Matrix4.CreateTranslation(Position);
            Matrix4 rotationX = Matrix4.CreateRotationX(Rotation.X);
            Matrix4 rotationY = Matrix4.CreateRotationY(Rotation.Y);
            Matrix4 rotationZ = Matrix4.CreateRotationZ(Rotation.Z);
            Matrix4 scale = Matrix4.CreateScale(Scale);

            return scale * rotationX * rotationY * rotationZ * translation;
        }
    }
}
