﻿using System.ComponentModel.DataAnnotations;

namespace CardValidation.Models
{
    public class Card
    {
        [MinLength(16, ErrorMessage = "Invalid card length")]
        [MaxLength(16, ErrorMessage = "Invalid card length")]
        public string CardNumber { get; set; }
    }
}
