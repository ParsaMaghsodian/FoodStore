using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore.Domain.Valueobjects;
[ComplexType]
public class Quantity : ValueObject
{
    [Column("Quantity")]
    public int Value { get; init; }

    public Quantity(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(value));
        if (value > int.MaxValue)
            throw new ArgumentException($"Quantity must be less than {int.MaxValue}.", nameof(value));

        Value = value;
    }
    private Quantity() { } // EF Core requires a parameterless constructor

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
