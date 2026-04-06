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
    
    private string _client;
    
    private IServiceProvider _serviceProvider;
    public ReceiptWindowViewModel(IServiceProvider serviceProvider, List<Work> works, string clientName)
    {
            _serviceProvider = serviceProvider;
            _works = works;
            _client = clientName;
    }

    public void WorksEnd()
    {
        foreach (var work in _works)
        {
            
        }

    }
}