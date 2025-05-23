﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder.Fundamentals
{
public class Waypoint
    {
        private static Dictionary<int, Waypoint> savedDropCords = new Dictionary<int, Waypoint>();
        public double Lat;
        public double Long;
        public int DropAngle;
        public bool IsDropTarget = false;

        public Waypoint(double lat, double longitude, int dropAngle = 0, bool isDropTarget = false)
        {
            DropAngle = dropAngle;

            if (isDropTarget)
            {
                if (!savedDropCords.TryGetValue(dropAngle, out Waypoint wp))
                {
                    wp = PayloadCalculator.CalculateDropPoint(DropAngle);
                    savedDropCords[dropAngle] = wp;
                };

                lat = wp.Lat;
                longitude = wp.Long;
            }

            Lat = lat;
            Long = longitude;
            IsDropTarget = isDropTarget;
        }
    }
}
