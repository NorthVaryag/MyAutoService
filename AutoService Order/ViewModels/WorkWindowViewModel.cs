using System;
using System.Collections.Generic;
using AutoService_Order.DB;
using AutoService_Order.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoService_Order.ViewModels;

public partial class WorkWindowViewModel :  ViewModelBase
{
    
    [ObservableProperty] List<Work> works;
    
    public WorkWindowViewModel(WorkRepository  repository, Service selectedService, String clientName, String  autoName)
    {
        Works = repository.GetWorkAll();
    }
}