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
    
    [ObservableProperty] private int _discount;
    
    [ObservableProperty] private decimal _tDPrice;
    
    private IServiceProvider _serviceProvider;
    public ReceiptWindowViewModel(IServiceProvider serviceProvider, List<Work> works, string clientName, string autoName)
    {
            _serviceProvider = serviceProvider;
            Works = works;
            Client = clientName;
            Auto = autoName;
            Total = TotalPrice();
            Discount = PriceDiscount();
            TDPrice = TotalDiscountPrice();
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

    public int PriceDiscount()
    {
        int count = 0;
        if (TotalPrice() >= 10000)
        {
            count = 10;
        }
        else if (TotalPrice() >= 5000)
        {
            count = 5;
        }
        return count;
    }    
    
    public decimal TotalDiscountPrice()
    {
        decimal price = TotalPrice();
        if (Discount != 0)
            price -= TotalPrice() * Discount / 100;
        return price;
    }

    [RelayCommand]
    public void SaveDB()
    {
        
    }
}