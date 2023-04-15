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
        MySqlConnection mySqlConnection = new MySqlConnection("server=sql7.freemysqlhosting.net;user=sql7612567;password=HeC3RxhgLI;database=sql7612567");
        mySqlConnection.Open();
        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM User WHERE Login = \'{LoginTextBox.Text}\' AND Password = \'{PasswordTextBox.Text}\'", mySqlConnection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dataReader);
        if (dt.Rows.Count != 0)
        {
            User loggedUser = new User();
            loggedUser.ID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
            loggedUser.Surname = Convert.ToString(dt.Rows[0]["Surname"]);
            loggedUser.Name = Convert.ToString(dt.Rows[0]["Name"]);
            loggedUser.Patronymic = Convert.ToString(dt.Rows[0]["Patronymic"]);
            loggedUser.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
            
            var mainWindow = this.FindAncestorOfType<Window>();
            (mainWindow as MainWindow).ManagerPage.User = loggedUser;
            NavigationService.Navigate((mainWindow as MainWindow).ManagerPage);
        }
    }
}