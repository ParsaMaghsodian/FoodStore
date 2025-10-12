using FoodStore.Domain.Valueobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore.Infrastructure.DataModels;

public class Customer
{
    public int Id { get; set; }
    // Foreign Key
    public int OrderId { get; set; }

    // Navigation Property
    public ICollection<Order> ? Order { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required Email Email { get; set; }

    public required PhoneNumber PhoneNumber { get; set; } 

    public string? Address { get; set; }
}
