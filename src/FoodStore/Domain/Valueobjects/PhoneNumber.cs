using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodStore.Domain.Valueobjects;
[ComplexType]
public class PhoneNumber :  ValueObject
{
    [Column("PhoneNumber")]
    public string Value { get; init; }
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be empty.");

        // Normalize: remove spaces and dashes
        value = value.Replace(" ", "").Replace("-", "");

        if (!IsValid(value))
            throw new ArgumentException("Invalid phone number format.");

        Value = value;
    }
    private PhoneNumber() { } // EF Core requires a parameterless constructor
    public static bool IsValid(string value)
    {
        // Accepts +CountryCode and 10–15 digits
        var pattern = @"^\+?[0-9]{10,15}$";
        return Regex.IsMatch(value, pattern);
    }
    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }
}
