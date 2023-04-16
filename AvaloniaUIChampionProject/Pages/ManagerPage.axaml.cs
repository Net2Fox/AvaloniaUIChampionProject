using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaUIChampionProject.Classes;

namespace AvaloniaUIChampionProject.Pages;

public partial class ManagerPage : UserControl
{
    private User _user;
    public User User
    {
        get { return _user; }
        set { _user = value; }
    }

    private List<Order> _orders;
    public List<Order> Orders
    {
        get { return _orders; }
        set { _orders = value; }
    }
    
    public ManagerPage()
    {
        InitializeComponent();
    }

    public void Loaded()
    {
        Orders = DatabaseConnection.RunQueryList<Order>("SELECT * FROM `Order`");
        OrdersDataGrid.Items = Orders;
    }
}