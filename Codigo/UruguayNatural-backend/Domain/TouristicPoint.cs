﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Region Region { get; set; }
        public List<TouristicPointsCategory> Categories { get; set; }
        public string Image { get; set; }

        public TouristicPoint()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is TouristicPoint))
            {
                return false;
            }
            return Name == ((TouristicPoint)obj).Name;
        }
    }
}
