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
        set
        {
            _user = value;
            NameTextBlock.Text = value.Name;
        }
    }
    
    public ManagerPage()
    {
        InitializeComponent();
    }
}