﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO
{
    public class IndexSubStandardDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public string? Code { get; set; }
        public int? MainStandardId { get; set; }
        public int ResultTypeId { get; set; }
    }
}
