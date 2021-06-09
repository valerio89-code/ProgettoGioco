using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoGioco.Gioco2
{
    public static class ButtonsManager
    {
        public static async void ShowSequence(List<Button> buttons, int[] sequence, int difficulty)
        {
            await Task.Delay(1000);

            foreach (var number in sequence)
            {
                var btn = buttons.First(x => x.Text == number.ToString());
                btn.BorderColor = Color.Green;

                await Task.Delay(difficulty);

                btn.BorderColor = Color.White;

                await Task.Delay(difficulty);
            }

            EnableButtons(buttons);
        }

        public static void EnableButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
        }
        public static async Task ColorButton(Button btn, bool verifica)
        {
            btn.BorderColor = btn.BackgroundColor = verifica ? Color.Green : Color.Red;

            await Task.Delay(250);

            btn.BorderColor = btn.BackgroundColor = Color.White;
        }
    }
}
