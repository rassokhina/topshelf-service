using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceCore.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
