﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HotelMVVM2020Demo.Common
{
    public class MessageDialogHelper
    {
        public static async void Show(string content, string title)
        {
            MessageDialog messageDialog = new MessageDialog(content, title);
            await messageDialog.ShowAsync();
        }
    }

}
