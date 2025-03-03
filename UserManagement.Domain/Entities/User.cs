namespace UserManagement.Domain.Entities.User
{ 
public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string ?LastName { get; set; }
    public string ?Email { get; set; }
    public int ContactNumber { get; set; }

    public ICollection<Product> Products { get; set; }
}
}

