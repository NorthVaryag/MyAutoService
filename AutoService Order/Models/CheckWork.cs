namespace AutoService_Order.Models;

public class CheckWork
{
    public bool IsChecked { get; set; }
    public Work Work { get; set; }

    public CheckWork(Work work)
    {
        Work = work;
    }
}