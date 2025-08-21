using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Article
{
    public class ArticleRequestDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Makale başlığı boş olamaz.")]
        [StringLength(200, ErrorMessage = "Header en fazla 200 karakter olmalı.")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Makale içeriği boş olamaz.")]
        public string Content { get; set; }
    }
}
