using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodStore.Domain.Valueobjects;
[ComplexType]
public class Email : ValueObject
{
    [Column("Email")]
    [MaxLength(50)]
    public string Value { get; private set; }
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value), "Email cannot be null or empty.");
        if (!IsValidEmail(value))
            throw new ArgumentException(nameof(value), "Invalid Email format");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    private static bool IsValidEmail(string email)
    {
        // Regular Expression
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        // Makes it case-insensitive
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
}
