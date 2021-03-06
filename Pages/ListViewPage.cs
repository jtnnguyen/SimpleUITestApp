﻿using System.Collections.Generic;

using Xamarin.Forms;

using SimpleUITestApp.Shared;

namespace SimpleUITestApp
{
	public class ListViewPage : BasePage
	{
		public ListViewPage()
		{
			Title = "List View Page";

			var listViewData = SampleDataModelFactory.GetSampleData();

			var cell = new DataTemplate(typeof(WhiteTextImageCell));
			cell.SetValue(TextCell.TextProperty, "Number");
			cell.SetBinding(ImageCell.DetailProperty, "Number");
			cell.SetValue(ImageCell.ImageSourceProperty, "Hash");

			var listView = new ListView
			{
				ItemTemplate = cell,
				ItemsSource = listViewData,
				BackgroundColor = Color.FromHex("#2980b9")
			};

			listView.ItemTapped += (s, e) =>
			{
				var item = e.Item;
				AnalyticsHelpers.TrackEvent(AnalyticsConstants.LIST_VIEW_ITEM_TAPPED, new Dictionary<string, string> {
					{ AnalyticsConstants.LIST_VIEW_ITEM_NUMBER, item.ToString() } 
				});

				DisplayAlert("Number Tapped", $"You Selected Number {item.ToString()}", "OK");
			};

			Content = listView;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			AnalyticsHelpers.TrackEvent(AnalyticsConstants.LIST_VIEW_PAGE_ON_APPEARING);
		}
	}
}


