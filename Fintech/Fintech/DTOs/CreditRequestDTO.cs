﻿namespace Fintech.DTOs
{
    public class CreditRequestDTO
    {
        public int Id { get; set; }
        public CustomerDTO? CustomerDto { get; set; } 
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? Imagen { get; set; }

    }
}
