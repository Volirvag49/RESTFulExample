﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static RESTFulExample.BLL.DTO.OrderDTO;

namespace RESTFulExample.API.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string LastName { get; set; }
    }

    public class AirVM
    {
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Provider { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string DepartureAirport { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string ArrivalAirport { get; set; }

        //Employee
        public int? TravellerId { get; set; }
    }

    public class TrainVM
    {
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Id { get; set; }
        [Required]
        public string Provider { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string DepartureStation { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string ArrivalStation { get; set; }

        //Employee
        public int? TravellerId { get; set; }
    }

    public class HotelVM
    {
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Id { get; set; }
        [Required]
        public string Provider { get; set; }
        [Required]
        public DateTime Checkin { get; set; }
        [Required]
        public DateTime Checkout { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }

        //Employee
        public int? TravellerId { get; set; }
    }

    public class CartVM
    {
        public string Id { get; set; }
        [Required]
        public int? EmployeeId { get; set; }
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string AirId { get; set; }
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string TrainId { get; set; }
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string HotelId { get; set; }
    }

    public class ServiceVM
    {
        public int? EmployeeId { get; set; }

        public IList<string> serviceIds { get; set; }
    }

    public class OrderVM
    {
        public string Id { get; set; }
        public int? CartId { get; set; }
        public string ServiceId { get; set; }
        public ServiceTipeVM ServiceTipe { get; set; }
    }

    public enum ServiceTipeVM : byte
    {
        Empty = 0,
        Air = 1,
        Train = 2,
        Hotel = 3
    }
}
