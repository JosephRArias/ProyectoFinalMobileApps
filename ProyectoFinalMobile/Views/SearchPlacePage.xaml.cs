﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPlacePage : ContentPage
	{
		public static readonly BindableProperty FocusOriginCommandProperty =
		  BindableProperty.Create(nameof(FocusOriginCommand), typeof(ICommand), typeof(SearchPlacePage), null, BindingMode.TwoWay);

		public ICommand FocusOriginCommand
		{
			get { return (ICommand)GetValue(FocusOriginCommandProperty); }
			set { SetValue(FocusOriginCommandProperty, value); }
		}

		public SearchPlacePage()
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			if (BindingContext != null)
			{
				FocusOriginCommand = new Command(OnOriginFocus);
			}
		}

		void OnOriginFocus()
		{
			originEntry.Focus();
		}
	}
}