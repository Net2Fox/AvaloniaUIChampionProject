using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaUIChampionProject.Classes;

namespace AvaloniaUIChampionProject;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        NavigationService.SetStartPage(AuthPage);
        NavigationService.OnNavigate += OnOnNavigate;
    }
    
    private void PageTwoButton_OnClick(object? sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(ManagerPage);
    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
    
    private void OnOnNavigate()
    {
        BackButton.IsEnabled = NavigationService.CanGoBack();
    }
}