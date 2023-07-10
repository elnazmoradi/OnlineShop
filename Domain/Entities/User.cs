namespace Domain.Entities
{
    public class User
    {
        public User()
        {}
        public User(Guid id, string firstName, string lastName, string phoneNumber, string address, string userName, string password, decimal balance)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            UserName = userName;
            Password = password;
            Balance = balance;
        }
        public User(Guid id, string firstName, string lastName, string phoneNumber, string address, string userName, decimal balance)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            UserName = userName;
            Balance = balance;
        }


        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public decimal Balance { get; set; }

    }
}
