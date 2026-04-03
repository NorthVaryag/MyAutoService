using System;
using AutoService_Order.Models;

namespace AutoService_Order.ViewModels;

public class ReceiptWindowViewModel : ViewModelBase
{
    
    private IServiceProvider _serviceProvider;
    public ReceiptWindowViewModel(IServiceProvider serviceProvider, CheckWork checkWork)
    {
            _serviceProvider = serviceProvider;
            
    }
}