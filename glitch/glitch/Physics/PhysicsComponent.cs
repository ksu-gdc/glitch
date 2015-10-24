﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using glitch.Physics;

namespace glitch
{
    public enum PhysicsType
    {
        Player,
        StaticObject,
        Door
    }

    public class PhysicsComponent
    {
        public double gravityScale = 1.0;
        public Vector2 velocity = Vector2.Zero;
        public Hitbox hitBox;
        public PhysicsType type;

        public PhysicsComponent(int width, int height, PhysicsType type)
        {
            gravityScale = 1.0;
            velocity = Vector2.Zero;
            hitBox = new Hitbox(width, height);
            this.type = type;

            //PhysicsSystem.Instance.addComponent(this);
        }

        public void UpdateHitBoxPosition(int x, int y)
        {
            this.hitBox.UpdatePosition(x, y);
        }

        public void ReSize(int width, int height)
        {
            this.hitBox.ReSize(width, height);
        }

        public void ReSize(Point size)
        {
            this.ReSize(size.X, size.Y);
        }

        public void UpdateHitBoxPosition(Point pos)
        {
            this.hitBox.UpdatePosition(pos);
        }

        public Point ApplyVelocity(GameTime time, Point position)
        {
            Point newPoint = new Point(position.X + (int)(this.velocity.X * time.ElapsedGameTime.TotalSeconds), position.Y + (int)(this.velocity.Y * time.ElapsedGameTime.TotalSeconds));
            this.UpdateHitBoxPosition(newPoint);

            return newPoint;
        }
    }
}