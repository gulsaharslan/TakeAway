﻿namespace TakeAway.Catalog.Dtos.DailyDiscountDtos
{
    public class CreateDailyDiscountDto
    {
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

    }
}
