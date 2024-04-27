﻿using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required]
        [MaxLength(30)]
        public string CatName { get; set; }

        public string DispalyOrder { get; set; }
    }
}


