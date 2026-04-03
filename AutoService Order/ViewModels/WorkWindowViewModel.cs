using System;
using System.Collections.Generic;
using System.Linq;
using AutoService_Order.DB;
using AutoService_Order.Models;
using AutoService_Order.Views;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService_Order.ViewModels;

public partial class WorkWindowViewModel :  ViewModelBase
{
    
    [ObservableProperty] List<CheckWork> _works;
    private IServiceProvider _serviceProvider;
    private Action _closeAction;
    
    public WorkWindowViewModel(IServiceProvider serviceProvider, WorkRepository  repository, Service selectedService, string clientName, string  autoName)
    {
        Works = repository.GetWorkByService(selectedService).Select(work => new CheckWork(work)).ToList();
        _serviceProvider = serviceProvider;
        
    }

    public void CloseAction(Action action)
    {
        _closeAction  = action;
    }
    
    [RelayCommand]
    public void Cancel()
    {
        _closeAction?.Invoke();
    }

    
    [RelayCommand]
    public void ReceiptWindow()
    {
        List<Work> worksIsCheck = new List<Work>();
        
        foreach (var workCheck in _works)
        {
            if (workCheck.IsChecked == true)
            {
                worksIsCheck.Add(workCheck.Work);
            }
        }
        if (worksIsCheck.Count == 0)
        {
            return;
        }
        var vm = ActivatorUtilities.CreateInstance<ReceiptWindowViewModel>(_serviceProvider, worksIsCheck);
        var win =  _serviceProvider.GetService<ReceiptWindow>();
        win.DataContext = vm;
        win.Show();
    }
}