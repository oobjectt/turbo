﻿using System.Collections.Generic;
using Turbo.Core.Game.Rooms.Object;
using Turbo.Core.Game.Rooms.Object.Logic;
using Turbo.Core.Game.Rooms.Utils;

namespace Turbo.Rooms.Utils
{
    public class AffectedPoints
    {
        public static IList<IPoint> GetPoints(IRoomObjectFloor floorObject, IPoint point = null)
        {
            if (floorObject == null) return null;

            point ??= floorObject.Location;

            return GetPoints(floorObject.Logic?.FurnitureDefinition?.X ?? 0, floorObject.Logic?.FurnitureDefinition?.Y ?? 0, point);
        }

        public static IList<IPoint> GetPoints(int width, int length, IPoint point)
        {
            if (point == null || (width < 1) || (length < 1)) return null;

            IList<IPoint> points = new List<IPoint>();

            Rotation rotation = point.Rotation;

            if ((rotation == Rotation.East) || (rotation == Rotation.West))
            {
                (length, width) = (width, length);
            }

            for (int x = point.X; x < point.X + width; x++)
            {
                for (int y = point.Y; y < point.Y + length; y++)
                {
                    points.Add(new Point(x, y));
                }
            }

            return points;
        }

        public static IList<IPoint> GetPillowPoints(IRoomObjectFloor floorObject, IPoint point = null)
        {
            IList<IPoint> points = new List<IPoint>();

            point ??= floorObject.Location;

            points.Add(new Point(point.X, point.Y));

            if (floorObject.Logic.FurnitureDefinition.Y == 1) return points;

            Rotation rotation = point.Rotation;

            int x = rotation == Rotation.North ? point.X + 1 : point.X;
            int y = rotation == Rotation.East ? point.Y + 1 : point.Y;

            points.Add(new Point(x, y));

            return points;
        }
    }
}
