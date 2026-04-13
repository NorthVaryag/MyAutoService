using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using AutoService_Order.DB;
using AutoService_Order.Models;
using AutoService_Order.Views;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService_Order.ViewModels;

public partial class ReceiptWindowViewModel : ViewModelBase
{
    [ObservableProperty] private List<Work> _works;
    
    [ObservableProperty] private string _client;
    
    [ObservableProperty] private string _auto;
    
    [ObservableProperty] private decimal _total;
    
    [ObservableProperty] private int _discount;
    
    [ObservableProperty] private decimal _tDPrice;
    
    private Action _closeAction;
    
    private IServiceProvider _serviceProvider;
    
    private OrderRepository _repository;
    [ObservableProperty] private Service _service;
    public ReceiptWindowViewModel(IServiceProvider serviceProvider, OrderRepository repository, Service service, List<Work> works, string clientName, string autoName)
    {
        _repository = repository;
            _serviceProvider = serviceProvider;
            Works = works;
            Client = clientName;
            Auto = autoName;
            Service = service;
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
   
    public void CloseAction(Action action)
    {
        _closeAction  = action;
    }
    
    [RelayCommand]
    public void ToStart()
    {
        var vm = ActivatorUtilities.CreateInstance<MainWindowViewModel>;
        var  win = _serviceProvider.GetRequiredService<MainWindow>();
        win.DataContext = vm;
        win.Show(); 
        _closeAction?.Invoke();
    }
    
    
    [RelayCommand]
    public void SaveDB()
    {
        Order order = new Order
        {
            ClientName = Client,
            CarModel = Auto,
            ServiceId = Service.Id,
            DiscountPercent = Discount,
            OrderDate = DateTime.Now,
            TotalAmount = TDPrice
        };
       
        _repository.InsertOrder(order, Works);
    }
}