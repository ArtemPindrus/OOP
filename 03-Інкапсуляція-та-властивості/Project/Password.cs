namespace Project;

public class Password {
    private int hash;

    /// <summary>
    /// Set the new password.
    /// </summary>
    /// <exception cref="ArgumentException">Password is less than 8 characters.</exception>
    public void Set(string password) {
        if (password.Length < 8) throw new ArgumentException("Password should be at least 8 characters long.");

        hash = password.GetHashCode();
    }

    /// <summary>
    /// Check if the password is correct.
    /// </summary>
    /// <param name="candidate">Candidate string to check.</param>
    public bool Check(string candidate) => hash == candidate.GetHashCode();
}