namespace ChartApp.Views;
using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ChartApp.ViewModels;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? param)
    {
        var name = param?.GetType().FullName!.Replace("ViewModel", "View");
        if (name == null)
        {
            return new TextBlock { Text = $"Not Found: {name}" };
        }

        var type = Type.GetType(name);

        if (type == null)
        {
            return new TextBlock { Text = $"Not Found: {name}" };
        }

        return (Control)Activator.CreateInstance(type)!;
    }

    public bool Match(object? data) => data is MainWindowViewModel;
}
