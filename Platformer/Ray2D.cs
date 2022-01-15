using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace Platformer
{
    class Ray2D
    {
        public Vector2 position;
        public Vector2 direction;
        public Vector2 endpoint;
        public float length;
        public float angleRad;
        private List<Components.Collider> _colliders;

        public Ray2D(Vector2 position, Vector2 direction)
        {
            this.position = position;
            this.direction = direction;
            this.angleRad = (float)Math.Atan2(direction.Y - position.Y, direction.X - position.X);
            _colliders = ComponentRegistry.GetAll<Components.Collider>();
        }

        public Ray2D(Vector2 position, float angleRad = 0f)
        {
            this.position = position;
            this.angleRad = angleRad;
            this.direction = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad));
            _colliders = ComponentRegistry.GetAll<Components.Collider>();
        }

        public List<Components.Collider> Cast(float magnitude)
        {
            List<Components.Collider> intersectingColliders = new List<Components.Collider>();
            endpoint = position - new Vector2(direction.X * magnitude, direction.Y * magnitude);
            length = magnitude;
            //Console.WriteLine($"Start ({position.X}, {position.Y}) - End ({endpoint.X}, {endpoint.Y})");

            foreach (Components.Collider collider in _colliders)
            {
                //Console.WriteLine($"Collider position ({collider.Rect.X}, {collider.Rect.Y})");
                if (LineIntersectsRect((position, endpoint), collider.Rect))
                {
                    intersectingColliders.Add(collider);
                }
            }
            return intersectingColliders;
        }

        private bool LineIntersectsRect((Vector2 from, Vector2 to) target /*Point p1, Point p2*/, Rectangle r)
        {
            return LineIntersectsLine(target.from, target.to, new Vector2(r.X, r.Y), new Vector2(r.X + r.Width, r.Y)) ||
                   LineIntersectsLine(target.from, target.to, new Vector2(r.X + r.Width, r.Y), new Vector2(r.X + r.Width, r.Y + r.Height)) ||
                   LineIntersectsLine(target.from, target.to, new Vector2(r.X + r.Width, r.Y + r.Height), new Vector2(r.X, r.Y + r.Height)) ||
                   LineIntersectsLine(target.from, target.to, new Vector2(r.X, r.Y + r.Height), new Vector2(r.X, r.Y)) ||
                   (r.Contains(target.from) && r.Contains(target.to));
        }

        private bool LineIntersectsLine(Vector2 l1p1, Vector2 l1p2, Vector2 l2p1, Vector2 l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

            if (d == 0)
            {
                return false;
            }

            float r = q / d;

            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }

            return true;
        }
    }
}
