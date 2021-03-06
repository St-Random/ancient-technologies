﻿using AncientTechnology.Core.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Control.Managers {
    public static class MainManagerExtensions {
        public static IVisualObject GetNearestObject(this MainManager manager, IVisualObject obj, float maxDistance = 500) {
            var objects = GetObjectsInSquare(manager, obj, maxDistance);
            var bounds = obj.Bounds;
            var nearest = objects.First();
            var nearestBounds = nearest.Bounds; // shitty optimization

            foreach (var o in objects.Skip(1)) {
                if (o.Bounds.GetDistanceSquared(bounds) < nearestBounds.GetDistance(bounds)) {
                    nearest = o;
                    nearestBounds = o.Bounds;
                }
            }

            return nearest;
        }

        public static IEnumerable<IVisualObject> GetObjectsInSquare(this MainManager manager, Vector2 position, float distance) {
            return GetObjectsInRectangle(manager, (int)(position.X - distance / 2), (int)(position.Y - distance / 2), (int)distance, (int)distance);
        }

        public static IEnumerable<IVisualObject> GetObjectsInSquare(this MainManager manager, IVisualObject obj, float distance) {
            return GetObjectsInSquare(manager, obj.Position, distance).Where(x => x != obj);
        }

        public static IEnumerable<IVisualObject> GetObjectsInRectangle(this MainManager manager, int x, int y, int width, int height) {
            return manager.GetObjectsInRectangle(new Rectangle(x, y, width, height));
        }
    }
}
