using System;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using AvaloniaUIChampionProject.Classes;
using MySql.Data.MySqlClient;

namespace AvaloniaUIChampionProject.Pages;

public partial class AuthPage : UserControl
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void LoginButton_OnClick(object? sender, RoutedEventArgs e)
    {
        User loggedUser = DatabaseConnection.RunQuery<User>($"SELECT * FROM User WHERE Login = '{LoginTextBox.Text}' AND Password = '{PasswordTextBox.Text}'");
        if (loggedUser.ID != 0)
        {
            MainWindow mainWindow = this.FindAncestorOfType<MainWindow>();
            mainWindow.ManagerPage.User = loggedUser;
            NavigationService.Navigate(mainWindow.ManagerPage);
        }
        else
        {
            LoginTextBox.Text = "чё за говно ты написал";
        }
    }
}