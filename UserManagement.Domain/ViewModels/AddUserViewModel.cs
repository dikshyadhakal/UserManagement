﻿namespace UserManagement.Domain.ViewModels
{
    public class AddUserViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int ContactNumber { get; set; }

    }
}
