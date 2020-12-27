using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Opdracht3.Utilities
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:Opdracht3.Utilities"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:Opdracht3.Views;assembly=Opdracht3.Utilities"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Browse to and select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:FilteredListView/>
	///
	/// </summary>
	public class FilteredListView : ListView
	{
		static FilteredListView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FilteredListView),
						new FrameworkPropertyMetadata(typeof(FilteredListView)));
		}

		public Func<object, string, bool> FilterPredicate
		{
			get { return (Func<object, string, bool>)GetValue(FilterPredicateProperty); }
			set { SetValue(FilterPredicateProperty, value); }
		}
		public static readonly DependencyProperty FilterPredicateProperty =
			DependencyProperty.Register("FilterPredicate",
			typeof(Func<object, string, bool>), typeof(FilteredListView), new PropertyMetadata(null));

		public Subject<bool> FilterInputSubject = new Subject<bool>();

		public string FilterText
		{
			get { return (string)GetValue(FilterTextProperty); }
			set { SetValue(FilterTextProperty, value); }
		}
		public static readonly DependencyProperty FilterTextProperty =
			DependencyProperty.Register("FilterText",
				typeof(string),
				typeof(FilteredListView),
				new PropertyMetadata("",
					//This is the 'PropertyChanged' callback that's called 
					//whenever the Filter input text is changed
					(d, e) => (d as FilteredListView).FilterInputSubject.OnNext(true)));

		public FilteredListView()
		{
			SetDefaultFilterPredicate();
			InitThrottle();
		}

		private void SetDefaultFilterPredicate()
		{
			FilterPredicate = (obj, text) => obj.ToString().ToLower().Contains(text);
		}

		private void InitThrottle()
		{
			FilterInputSubject.Throttle(TimeSpan.FromMilliseconds(500))
				.ObserveOnDispatcher()
				.Subscribe(HandleFilterThrottle);
		}

		private void HandleFilterThrottle(bool b)
		{
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.ItemsSource);
			if (collectionView == null) return;
			collectionView.Filter = (item) => FilterPredicate(item, FilterText);
		}
	}
}
