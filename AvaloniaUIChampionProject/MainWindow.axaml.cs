using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaUIChampionProject.Classes;
using AvaloniaUIChampionProject.Pages;

namespace AvaloniaUIChampionProject;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        NavigationService.SetStartPage(AuthPage);
        NavigationService.OnNavigate += OnOnNavigate;
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