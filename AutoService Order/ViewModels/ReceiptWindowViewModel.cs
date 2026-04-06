using System;
using System.Collections.Generic;
using AutoService_Order.DB;
using AutoService_Order.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoService_Order.ViewModels;

public partial class ReceiptWindowViewModel : ViewModelBase
{
    [ObservableProperty] private List<Work> _works;
    
    [ObservableProperty] private string _client;
    
    [ObservableProperty] private string _auto;
    
    [ObservableProperty] private decimal _total;
    
    private IServiceProvider _serviceProvider;
    public ReceiptWindowViewModel(IServiceProvider serviceProvider, List<Work> works, string clientName, string autoName)
    {
            _serviceProvider = serviceProvider;
            _works = works;
            _client = clientName;
            _auto = autoName;
            _total = TotalPrice();
    }

    
    public decimal TotalPrice()
    {
        decimal count = 0; 
        foreach (var work in _works)
        {
            count += work.Price;
        }
        return count;
    }
}