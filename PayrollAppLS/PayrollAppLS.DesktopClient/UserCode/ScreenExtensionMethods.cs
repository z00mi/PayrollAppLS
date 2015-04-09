using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.LightSwitch.Client;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication.UserCode
{
    public static class ScreenExtensionMethods
    {
        public static void HideModalCloseButton(this IScreenObject screen, string modalName)
        {
            screen.FindControl(modalName)
                .ControlAvailable += (s1, e1) =>
                {
                    var window = (ChildWindow)e1.Control;
                    window.HasCloseButton = false;
                };
        }

        public static void SuprresEnterKeyForUnderlyingControls(this IScreenObject screen, string[] controlNames)
        {
            foreach (var controlName in controlNames)
            {
                screen.FindControl(controlName)
                    .ControlAvailable += (s1, e1) =>
                    {
                        (e1.Control as UIElement)
                            .KeyUp += (s2, e2) =>
                            {
                                if (e2.Key == Key.Enter || e2.Key == Key.Escape)
                                    e2.Handled = true;
                            };
                    };
            }
        }
    }
}
