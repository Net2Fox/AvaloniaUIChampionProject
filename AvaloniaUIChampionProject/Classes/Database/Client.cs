using System;

namespace AvaloniaUIChampionProject.Classes;

public class Client
{
    public int ID { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
    public int PersonalDiscount { get; set; }
}