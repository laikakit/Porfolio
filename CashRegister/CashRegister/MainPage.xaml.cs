﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
        }
        async void CashRegisterButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CashRegisterPage());
        }
        //async void ManagerButton_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    await Navigation.PushAsync(new ManagerPage());
        //}
    }
}