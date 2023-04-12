using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaUIChampionProject;

public partial class MainWindow : Window
{
    private bool _canGoBack = false;
    private List<UserControl> _perviousPages = new List<UserControl>() { };
    private UserControl _currentPage;
    
    public MainWindow()
    {
        InitializeComponent();
        _currentPage = PageOne;
    }

    private void PageTwoButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigate(PageTwo);
    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        NavigateBack();
    }
    
    

    private void Navigate(UserControl page, bool isBack = false)
    {
        if (!_currentPage.Equals(page))
        {
            _currentPage.IsVisible = false;
            if (!isBack)
            {
                _perviousPages.Add(_currentPage);
            }
            _currentPage = page;
            _currentPage.IsVisible = true;
            _canGoBack = true;
            OnNavigate();
        }
    }

    private void NavigateBack()
    {
        if (_canGoBack)
        {
            Navigate(_perviousPages.Last(), true);
            _perviousPages.Remove(_perviousPages.Last());
            if (_perviousPages.Count == 0)
            {
                _canGoBack = false;
            }
        }
        OnNavigate();
    }

    private void OnNavigate()
    {
        BackButton.IsEnabled = _canGoBack;
    }
}