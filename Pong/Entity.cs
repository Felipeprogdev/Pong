namespace Pong
{
    public delegate void EntityEvent(Entity entity);

    public class Entity
    {
        public event EntityEvent ChangeLocation;
        public event EntityEvent ChangeSize;
        public event EntityEvent ChangeVisibility;

        private PointF location;
        private SizeF size;
        private bool visible = true;

        public object Tag
        {
            get;
            set;
        }

        public PointF Location
        {
            get => location;
            set => SetLocation(value);
        }

        public SizeF Size
        {
            get => size;
            set => SetSize(value);
        }

        public bool Visible
        {
            get => visible;
            set => SetVisible(value);
        }

        public RectangleF Bounds
        {
            get => new(Location, Size);
            set => SetBounds(value);
        }

        public float Left
        {
            get => location.X;
            set => SetLocation(new PointF(value, location.Y));
        }

        public float Top
        {
            get => location.Y;
            set => SetLocation(new PointF(location.X, value));
        }

        public float Width
        {
            get => size.Width;
            set => SetSize(new SizeF(value, size.Height));
        }

        public float Height
        {
            get => size.Height;
            set => SetSize(new SizeF(size.Width, value));
        }

        public Entity()
        {
        }

        public Entity(PointF location, SizeF size)
        {
            Location = location;
            Size = size;
        }

        public bool IntersectsWith(Entity other)
        {
            return Bounds.IntersectsWith(other.Bounds);
        }

        private void SetBounds(RectangleF bounds)
        {
            SetLocation(bounds.Location);
            SetSize(bounds.Size);
        }

        private void SetLocation(PointF location)
        {
            this.location = location;

            ChangeLocation?.Invoke(this);
        }

        private void SetSize(SizeF size)
        {
            this.size = size;

            ChangeSize?.Invoke(this);
        }

        private void SetVisible(bool visible)
        {
            this.visible = visible;

            ChangeVisibility?.Invoke(this);
        }
    }
}