using System;
using System.Collections.Generic;
using System.Xml;
using AutoService_Order.DB;
using AutoService_Order.Models;
using AutoService_Order.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService_Order.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IServiceProvider _provider;
    [ObservableProperty] string autoName;
    [ObservableProperty] string clientName;
    [ObservableProperty] List<Service> services;
    [ObservableProperty] Service selectedService;
    
    public MainWindowViewModel(IServiceProvider provider, ServiceRepository repository)
    {
        _provider = provider;
        Services = repository.GetAllServces();
    }
    
    

    [RelayCommand]
    public void StartService()
    {
        if (SelectedService == null)
            return;
        var vm = ActivatorUtilities.CreateInstance<WorkWindowViewModel>(
            _provider, SelectedService, ClientName, AutoName);
                var win =  _provider.GetService<WorksWindow>();
                win.DataContext = vm;
                vm.CloseAction(win.Close);
                    win.Show();
    }
}