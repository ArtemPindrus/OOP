using System.Text.RegularExpressions;

namespace Project;

public class Email {
    private readonly Regex emailRegex = new(@"^([^@\s]+)@([^@\s.]+(\.[^@\s.]+)+)$");

    /// <summary>
    /// Get or set the email address. Must contain exactly one @, non-empty parts and a dot in domain.
    /// </summary>
    public string Address {
        get;
        set {
            Match match = emailRegex.Match(value);

            if (!match.Success) 
                throw new ArgumentException("Address should contain exactly one @, non-empty parts and a dot in domain.");

            field = value;
        }
    }

    public Email(string address) {
        Address = address;
    }

    /// <summary>
    /// User portion of the email address.
    /// </summary>
    public string User => Address.Substring(0, Address.IndexOf('@'));

    /// <summary>
    /// Domain portion of the email address.
    /// </summary>
    public string Domain => Address.Substring(Address.IndexOf('@') + 1);
}