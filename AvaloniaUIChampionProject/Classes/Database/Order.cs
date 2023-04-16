using System;

namespace AvaloniaUIChampionProject.Classes;

public class Order
{
    public int ID { get; set; }
    public int ExecutorID { get; set; }
    public int ClientID { get; set; }
    public int ManagerID { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int StatusID { get; set; }
    public string Description { get; set; }
    public int? TotalPrice { get; set; }
    public bool IsArchive { get; set; }
    public int CategoryID { get; set; }

    public User Executor { get; set; }
    public User Manager { get; set; }
    public Client Client { get; set; }
    public Status Status { get; set; }
    public Category Category { get; set; }

    public void Convert()
    {
        Executor = DatabaseConnection.RunQuery<User>($"SELECT * FROM User WHERE ID = '{ExecutorID}'");
        Manager = DatabaseConnection.RunQuery<User>($"SELECT * FROM User WHERE ID = '{ManagerID}'");
        Client = DatabaseConnection.RunQuery<Client>($"SELECT * FROM Client WHERE ID = '{ClientID}'");
        Status = DatabaseConnection.RunQuery<Status>($"SELECT * FROM Status WHERE ID = '{StatusID}'");
        Category = DatabaseConnection.RunQuery<Category>($"SELECT * FROM Category WHERE ID = '{CategoryID}'");
    }
}