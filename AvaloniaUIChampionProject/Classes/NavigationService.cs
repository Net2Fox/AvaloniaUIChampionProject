using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;

namespace AvaloniaUIChampionProject.Classes;

public static class NavigationService
{
    public delegate void Navigated();

    public static event Navigated? OnNavigate;

    private static bool _canGoBack = false;
    private static List<UserControl> _perviousPages = new List<UserControl>() { };
    private static UserControl _currentPage;

    public static void SetStartPage(UserControl page)
    {
        _currentPage = page;
    }
    
    public static void Navigate(UserControl page, bool isBack = false)
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
            OnNavigate?.Invoke();
        }
    }

    public static void GoBack()
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
        OnNavigate?.Invoke();
    }

    public static bool CanGoBack()
    {
        return _canGoBack;
    }
}