﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest { get; set; }


        public List<PointsOfInterestDto> PointOfInterest { get; set; }
        = new List<PointsOfInterestDto>();
    }
}
