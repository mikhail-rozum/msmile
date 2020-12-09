﻿using MSmile.Mobile.ViewModels;
using MSmile.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MSmile.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DifficultyLevelDetailPage), typeof(DifficultyLevelDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
