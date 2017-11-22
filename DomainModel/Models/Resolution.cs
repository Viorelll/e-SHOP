namespace DomainModel.Models
{
    using System;
    public class Resolution
    {
        [Obsolete]
        public Resolution()
        { }
        public Resolution(int width, int height)
        {
            if (width < 800)
            {
                throw new ArgumentException(nameof(width) + " must be greater.");
            }
            if (height < 600)
            {
                throw new ArgumentException(nameof(height) + " must be greater.");
            }

            Width = width;
            Height = height;
        }

        public int Width
        {
            get;
            set;
        }

        public virtual int Height
        {
            get;
            set;
        }
        public override string ToString() => $"{Width} x {Height}";


    }
}
