using System;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Client;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication.UserCode
{
    public static class ErrorHandler
    {

        public static void Handle(IScreenObject screen, Exception exception)
        {
            if (exception is ValidationException)
            {
                var vex = (ValidationException)exception;

                var strings = vex.Message.Split('|');

                screen.ShowMessageBox(strings[1], strings[0], MessageBoxOption.Ok);
                return;
            }

            screen.ShowMessageBox(exception.Message, "Błąd", MessageBoxOption.Ok);
        }

    }
}
