using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarBrandName { get; set; }
        public string CarColorName { get; set; }
        public int DailyPrice { get; set; }

    }
}
