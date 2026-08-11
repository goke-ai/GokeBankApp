using Goke.Bank.App.Extensions;
using System.Windows.Input;

namespace Goke.Bank.App.Controls
{
    [ContentProperty(nameof(ContentLayout))]
    public partial class ScrollViewContentPage : AuthorizePage
    {
        public static readonly BindableProperty ContentLayoutProperty =
            BindableProperty.Create(
                nameof(ContentLayout),
                typeof(View),
                typeof(ScrollViewContentPage),
                null,
                propertyChanged: OnContentLayoutChanged);

        public static readonly BindableProperty AppearingCommandProperty =
            BindableProperty.Create(
                nameof(AppearingCommand),
                typeof(ICommand),
                typeof(ScrollViewContentPage));

        public static readonly BindableProperty NavigatedToCommandProperty =
            BindableProperty.Create(
                nameof(NavigatedToCommand),
                typeof(ICommand),
                typeof(ScrollViewContentPage));

        public static readonly BindableProperty NavigatedFromCommandProperty =
            BindableProperty.Create(
                nameof(NavigatedFromCommand),
                typeof(ICommand),
                typeof(ScrollViewContentPage));

        public static readonly BindableProperty RefreshCommandProperty =
            BindableProperty.Create(
                nameof(RefreshCommand),
                typeof(ICommand),
                typeof(ScrollViewContentPage));

        public static readonly BindableProperty IsRefreshingProperty =
            BindableProperty.Create(
                nameof(IsRefreshing),
                typeof(bool),
                typeof(ScrollViewContentPage),
                false,
                propertyChanged: OnIsRefreshingChanged);

        public static readonly BindableProperty IsBusyOverlayVisibleProperty =
            BindableProperty.Create(
                nameof(IsBusyOverlayVisible),
                typeof(bool),
                typeof(ScrollViewContentPage),
                false,
                propertyChanged: OnBusyChanged);

        public static readonly BindableProperty ProgressBarColorProperty =
            BindableProperty.Create(
                nameof(ProgressBarColor),
                typeof(Color),
                typeof(ScrollViewContentPage),
                Colors.DeepSkyBlue,
                propertyChanged: OnProgressBarColorChanged);

        public static readonly BindableProperty ProgressBarHeightProperty =
            BindableProperty.Create(
                nameof(ProgressBarHeight),
                typeof(double),
                typeof(ScrollViewContentPage),
                4d,
                propertyChanged: OnProgressBarHeightChanged);

        public static readonly BindableProperty ProgressBarTrackColorProperty =
            BindableProperty.Create(
                nameof(ProgressBarTrackColor),
                typeof(Color),
                typeof(ScrollViewContentPage),
                Colors.Transparent,
                propertyChanged: OnProgressBarTrackColorChanged);

        public static readonly BindableProperty BusyOverlayColorProperty =
            BindableProperty.Create(
                nameof(BusyOverlayColor),
                typeof(Color),
                typeof(ScrollViewContentPage),
                Colors.Black,
                propertyChanged: OnBusyOverlayAppearanceChanged);

        public static readonly BindableProperty BusyOverlayOpacityProperty =
            BindableProperty.Create(
                nameof(BusyOverlayOpacity),
                typeof(double),
                typeof(ScrollViewContentPage),
                0.4d,
                propertyChanged: OnBusyOverlayAppearanceChanged);

        public static readonly BindableProperty BusyIndicatorColorProperty =
            BindableProperty.Create(
                nameof(BusyIndicatorColor),
                typeof(Color),
                typeof(ScrollViewContentPage),
                Colors.White,
                propertyChanged: OnBusyIndicatorColorChanged);

        public static readonly BindableProperty ContentPaddingProperty =
            BindableProperty.Create(
                nameof(ContentPadding),
                typeof(Thickness),
                typeof(ScrollViewContentPage),
                new Thickness(0),
                propertyChanged: OnContentPaddingChanged);

        public static readonly BindableProperty ContentSpacingProperty =
            BindableProperty.Create(
                nameof(ContentSpacing),
                typeof(double),
                typeof(ScrollViewContentPage),
                10d,
                propertyChanged: OnContentSpacingChanged);

        public static readonly BindableProperty ScrollOrientationProperty =
            BindableProperty.Create(
                nameof(ScrollOrientation),
                typeof(ScrollOrientation),
                typeof(ScrollViewContentPage),
                Microsoft.Maui.ScrollOrientation.Vertical,
                propertyChanged: OnScrollOrientationChanged);

        public static readonly BindableProperty IsEmptyProperty =
            BindableProperty.Create(
                nameof(IsEmpty),
                typeof(bool),
                typeof(ScrollViewContentPage),
                false,
                propertyChanged: OnVisualStateChanged);

        public static readonly BindableProperty EmptyTextProperty =
            BindableProperty.Create(
                nameof(EmptyText),
                typeof(string),
                typeof(ScrollViewContentPage),
                "No data available.",
                propertyChanged: OnEmptyTextChanged);

        public static readonly BindableProperty EmptyViewProperty =
            BindableProperty.Create(
                nameof(EmptyView),
                typeof(View),
                typeof(ScrollViewContentPage),
                null,
                propertyChanged: OnEmptyViewChanged);

        public static readonly BindableProperty IsInitialLoadingProperty =
            BindableProperty.Create(
                nameof(IsInitialLoading),
                typeof(bool),
                typeof(ScrollViewContentPage),
                false,
                propertyChanged: OnVisualStateChanged);

        public static readonly BindableProperty InitialLoadingTextProperty =
            BindableProperty.Create(
                nameof(InitialLoadingText),
                typeof(string),
                typeof(ScrollViewContentPage),
                "Loading...",
                propertyChanged: OnInitialLoadingTextChanged);

        public static readonly BindableProperty InitialLoadingViewProperty =
            BindableProperty.Create(
                nameof(InitialLoadingView),
                typeof(View),
                typeof(ScrollViewContentPage),
                null,
                propertyChanged: OnInitialLoadingViewChanged);

        public static readonly BindableProperty IsPullToRefreshEnabledProperty =
            BindableProperty.Create(
                nameof(IsPullToRefreshEnabled),
                typeof(bool),
                typeof(ScrollViewContentPage),
                true,
                propertyChanged: OnVisualStateChanged);

        public static readonly BindableProperty InsetPaddingProperty =
            BindableProperty.Create(
                nameof(InsetPadding),
                typeof(Thickness),
                typeof(ScrollViewContentPage),
                new Thickness(0),
                propertyChanged: OnInsetPaddingChanged);

        public static readonly BindableProperty ApplyInsetPaddingToContentProperty =
            BindableProperty.Create(
                nameof(ApplyInsetPaddingToContent),
                typeof(bool),
                typeof(ScrollViewContentPage),
                false,
                propertyChanged: OnInsetPaddingModeChanged);

        public View ContentLayout
        {
            get => (View)GetValue(ContentLayoutProperty);
            set => SetValue(ContentLayoutProperty, value);
        }

        public ICommand AppearingCommand
        {
            get => (ICommand)GetValue(AppearingCommandProperty);
            set => SetValue(AppearingCommandProperty, value);
        }

        public ICommand NavigatedToCommand
        {
            get => (ICommand)GetValue(NavigatedToCommandProperty);
            set => SetValue(NavigatedToCommandProperty, value);
        }

        public ICommand NavigatedFromCommand
        {
            get => (ICommand)GetValue(NavigatedFromCommandProperty);
            set => SetValue(NavigatedFromCommandProperty, value);
        }

        public ICommand RefreshCommand
        {
            get => (ICommand)GetValue(RefreshCommandProperty);
            set => SetValue(RefreshCommandProperty, value);
        }

        public bool IsRefreshing
        {
            get => (bool)GetValue(IsRefreshingProperty);
            set => SetValue(IsRefreshingProperty, value);
        }

        public bool IsBusyOverlayVisible
        {
            get => (bool)GetValue(IsBusyOverlayVisibleProperty);
            set => SetValue(IsBusyOverlayVisibleProperty, value);
        }

        public Color ProgressBarColor
        {
            get => (Color)GetValue(ProgressBarColorProperty);
            set => SetValue(ProgressBarColorProperty, value);
        }

        public double ProgressBarHeight
        {
            get => (double)GetValue(ProgressBarHeightProperty);
            set => SetValue(ProgressBarHeightProperty, value);
        }

        public Color ProgressBarTrackColor
        {
            get => (Color)GetValue(ProgressBarTrackColorProperty);
            set => SetValue(ProgressBarTrackColorProperty, value);
        }

        public Color BusyOverlayColor
        {
            get => (Color)GetValue(BusyOverlayColorProperty);
            set => SetValue(BusyOverlayColorProperty, value);
        }

        public double BusyOverlayOpacity
        {
            get => (double)GetValue(BusyOverlayOpacityProperty);
            set => SetValue(BusyOverlayOpacityProperty, value);
        }

        public Color BusyIndicatorColor
        {
            get => (Color)GetValue(BusyIndicatorColorProperty);
            set => SetValue(BusyIndicatorColorProperty, value);
        }

        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set => SetValue(ContentPaddingProperty, value);
        }

        public double ContentSpacing
        {
            get => (double)GetValue(ContentSpacingProperty);
            set => SetValue(ContentSpacingProperty, value);
        }

        public ScrollOrientation ScrollOrientation
        {
            get => (ScrollOrientation)GetValue(ScrollOrientationProperty);
            set => SetValue(ScrollOrientationProperty, value);
        }

        public bool IsEmpty
        {
            get => (bool)GetValue(IsEmptyProperty);
            set => SetValue(IsEmptyProperty, value);
        }

        public string EmptyText
        {
            get => (string)GetValue(EmptyTextProperty);
            set => SetValue(EmptyTextProperty, value);
        }

        public View EmptyView
        {
            get => (View)GetValue(EmptyViewProperty);
            set => SetValue(EmptyViewProperty, value);
        }

        public bool IsInitialLoading
        {
            get => (bool)GetValue(IsInitialLoadingProperty);
            set => SetValue(IsInitialLoadingProperty, value);
        }

        public string InitialLoadingText
        {
            get => (string)GetValue(InitialLoadingTextProperty);
            set => SetValue(InitialLoadingTextProperty, value);
        }

        public View InitialLoadingView
        {
            get => (View)GetValue(InitialLoadingViewProperty);
            set => SetValue(InitialLoadingViewProperty, value);
        }

        public bool IsPullToRefreshEnabled
        {
            get => (bool)GetValue(IsPullToRefreshEnabledProperty);
            set => SetValue(IsPullToRefreshEnabledProperty, value);
        }

        public Thickness InsetPadding
        {
            get => (Thickness)GetValue(InsetPaddingProperty);
            set => SetValue(InsetPaddingProperty, value);
        }

        public bool ApplyInsetPaddingToContent
        {
            get => (bool)GetValue(ApplyInsetPaddingToContentProperty);
            set => SetValue(ApplyInsetPaddingToContentProperty, value);
        }

        private readonly Grid _rootGrid;
        private readonly Grid _busyOverlay;
        private readonly Grid _refreshProgressBar;
        private readonly BoxView _progressFill;
        private readonly RefreshView _refreshView;
        private readonly ScrollView _scrollView;
        private readonly Grid _contentHost;
        private readonly ContentView _emptyViewHost;
        private readonly ContentView _initialLoadingViewHost;
        private readonly Label _emptyTextLabel;
        private readonly Label _initialLoadingTextLabel;
        private readonly ActivityIndicator _busyIndicator;

        private bool _isInitialized;
        private int _refreshAnimationVersion;

        public ScrollViewContentPage(
            Thickness? padding = null,
            double spacing = 10,
            ScrollOrientation orientation = ScrollOrientation.Vertical)
        {
            var initialContent = CreateDefaultContent(orientation, padding ?? default, spacing);

            _scrollView = new ScrollView
            {
                Orientation = orientation,
                Content = initialContent
            };

            _refreshView = new RefreshView
            {
                Command = new Command(ExecuteRefresh),
                Content = _scrollView
            };

            _progressFill = new BoxView
            {
                WidthRequest = 0,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Fill
            };

            _refreshProgressBar = new Grid
            {
                IsVisible = false,
                Opacity = 0,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Children = { _progressFill }
            };

            _emptyTextLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            _emptyViewHost = new ContentView
            {
                IsVisible = false,
                Content = _emptyTextLabel,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            _initialLoadingTextLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var defaultInitialLoadingView = new VerticalStackLayout
            {
                Spacing = 12,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new ActivityIndicator
                    {
                        IsRunning = true,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    _initialLoadingTextLabel
                }
            };

            _initialLoadingViewHost = new ContentView
            {
                IsVisible = false,
                Content = defaultInitialLoadingView,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            _contentHost = new Grid();
            _contentHost.Add(_refreshView);
            _contentHost.Add(_emptyViewHost);
            _contentHost.Add(_initialLoadingViewHost);

            _busyIndicator = new ActivityIndicator
            {
                IsRunning = true,
                WidthRequest = 60,
                HeightRequest = 60,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            _busyOverlay = new Grid
            {
                IsVisible = false,
                InputTransparent = false,
                Children = { _busyIndicator }
            };

            _rootGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(ProgressBarHeight) },
                    new RowDefinition { Height = GridLength.Star }
                }
            };

            _rootGrid.Add(_refreshProgressBar);
            Grid.SetRow(_refreshProgressBar, 0);

            _rootGrid.Add(_contentHost);
            Grid.SetRow(_contentHost, 1);

            _rootGrid.Add(_busyOverlay);
            Grid.SetRowSpan(_busyOverlay, 2);

            Content = _rootGrid;
            ContentLayout = initialContent;

            _isInitialized = true;

            ContentPadding = padding ?? default;
            ContentSpacing = spacing;
            ScrollOrientation = orientation;

            UpdateScrollContent(ContentLayout);
            UpdateProgressBarColor(ProgressBarColor);
            UpdateProgressBarHeight(ProgressBarHeight);
            UpdateProgressBarTrackColor(ProgressBarTrackColor);
            UpdateBusyOverlayAppearance();
            UpdateBusyIndicatorColor(BusyIndicatorColor);
            UpdateBusyOverlayVisibility(IsBusyOverlayVisible);
            UpdateContentPadding();
            UpdateContentSpacing(ContentSpacing);
            UpdateScrollOrientation(ScrollOrientation);
            UpdateEmptyText(EmptyText);
            UpdateEmptyView(EmptyView);
            UpdateInitialLoadingText(InitialLoadingText);
            UpdateInitialLoadingView(InitialLoadingView);
            UpdateVisualState();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (AppearingCommand?.CanExecute(null) == true)
            {
                AppearingCommand.Execute(null);
            }
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (NavigatedToCommand?.CanExecute(null) == true)
            {
                NavigatedToCommand.Execute(null);
            }
        }

        protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
        {
            base.OnNavigatedFrom(args);

            if (NavigatedFromCommand?.CanExecute(null) == true)
            {
                NavigatedFromCommand.Execute(null);
            }
        }

        public Task ScrollToTopAsync(bool animated = true)
        {
            return _scrollView.ScrollToAsync(0, 0, animated);
        }

        public Task ScrollToAsync(double x, double y, bool animated = true)
        {
            return _scrollView.ScrollToAsync(x, y, animated);
        }

        public Task ScrollToAsync(Element element, ScrollToPosition position, bool animated = true)
        {
            return _scrollView.ScrollToAsync(element, position, animated);
        }

        private static void OnContentLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateScrollContent(newValue as View);
            }
        }

        private static async void OnIsRefreshingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is not ScrollViewContentPage page || !page._isInitialized)
            {
                return;
            }

            if ((bool)newValue)
            {
                await page.StartRefreshAnimationAsync();
            }
            else
            {
                await page.StopRefreshAnimationAsync();
            }
        }

        private static void OnBusyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateBusyOverlayVisibility((bool)newValue);
            }
        }

        private static void OnProgressBarColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is Color color)
            {
                page.UpdateProgressBarColor(color);
            }
        }

        private static void OnProgressBarHeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is double height)
            {
                page.UpdateProgressBarHeight(height);
            }
        }

        private static void OnProgressBarTrackColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is Color color)
            {
                page.UpdateProgressBarTrackColor(color);
            }
        }

        private static void OnBusyOverlayAppearanceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateBusyOverlayAppearance();
            }
        }

        private static void OnBusyIndicatorColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is Color color)
            {
                page.UpdateBusyIndicatorColor(color);
            }
        }

        private static void OnContentPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateContentPadding();
            }
        }

        private static void OnContentSpacingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is double spacing)
            {
                page.UpdateContentSpacing(spacing);
            }
        }

        private static void OnScrollOrientationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is ScrollOrientation orientation)
            {
                page.UpdateScrollOrientation(orientation);
            }
        }

        private static void OnEmptyTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is string text)
            {
                page.UpdateEmptyText(text);
            }
        }

        private static void OnEmptyViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateEmptyView(newValue as View);
            }
        }

        private static void OnInitialLoadingTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page && newValue is string text)
            {
                page.UpdateInitialLoadingText(text);
            }
        }

        private static void OnInitialLoadingViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateInitialLoadingView(newValue as View);
            }
        }

        private static void OnVisualStateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateVisualState();
            }
        }

        private static void OnInsetPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateContentPadding();
            }
        }

        private static void OnInsetPaddingModeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ScrollViewContentPage page)
            {
                page.UpdateContentPadding();
            }
        }

        private void ExecuteRefresh()
        {
            if (!IsPullToRefreshEnabled || IsInitialLoading || IsEmpty)
            {
                return;
            }

            RefreshCommand?.Execute(null);
        }

        private void UpdateScrollContent(View view)
        {
            if (!_isInitialized || view is null)
            {
                return;
            }

            _scrollView.Content = view;
            UpdateContentPadding();
            UpdateContentSpacing(ContentSpacing);
        }

        private void UpdateBusyOverlayVisibility(bool isVisible)
        {
            if (!_isInitialized)
            {
                return;
            }

            _busyOverlay.IsVisible = isVisible;
        }

        private void UpdateProgressBarColor(Color color)
        {
            if (!_isInitialized)
            {
                return;
            }

            _progressFill.BackgroundColor = color;
        }

        private void UpdateProgressBarHeight(double height)
        {
            if (!_isInitialized)
            {
                return;
            }

            var safeHeight = System.Math.Max(0, height);

            _progressFill.HeightRequest = safeHeight;
            _refreshProgressBar.HeightRequest = safeHeight;

            if (_rootGrid.RowDefinitions.Count > 0)
            {
                _rootGrid.RowDefinitions[0].Height = new GridLength(safeHeight);
            }
        }

        private void UpdateProgressBarTrackColor(Color color)
        {
            if (!_isInitialized)
            {
                return;
            }

            _refreshProgressBar.BackgroundColor = color;
        }

        private void UpdateBusyOverlayAppearance()
        {
            if (!_isInitialized)
            {
                return;
            }

            var alpha = (float)System.Math.Clamp(BusyOverlayOpacity, 0d, 1d);
            _busyOverlay.BackgroundColor = BusyOverlayColor.WithAlpha(alpha);
        }

        private void UpdateBusyIndicatorColor(Color color)
        {
            if (!_isInitialized)
            {
                return;
            }

            _busyIndicator.Color = color;
        }

        private void UpdateContentPadding()
        {
            if (!_isInitialized || ContentLayout is not Layout layout)
            {
                return;
            }

            layout.Padding = ApplyInsetPaddingToContent
                ? MergeThickness(ContentPadding, InsetPadding)
                : ContentPadding;
        }

        private void UpdateContentSpacing(double spacing)
        {
            if (!_isInitialized || ContentLayout is null)
            {
                return;
            }

            var safeSpacing = System.Math.Max(0, spacing);

            switch (ContentLayout)
            {
                case VerticalStackLayout verticalStackLayout:
                    verticalStackLayout.Spacing = safeSpacing;
                    break;
                case HorizontalStackLayout horizontalStackLayout:
                    horizontalStackLayout.Spacing = safeSpacing;
                    break;
                case StackLayout stackLayout:
                    stackLayout.Spacing = safeSpacing;
                    break;
            }
        }

        private void UpdateScrollOrientation(ScrollOrientation orientation)
        {
            if (!_isInitialized)
            {
                return;
            }

            _scrollView.Orientation = orientation;
        }

        private void UpdateEmptyText(string text)
        {
            if (!_isInitialized)
            {
                return;
            }

            _emptyTextLabel.Text = text;
        }

        private void UpdateEmptyView(View view)
        {
            if (!_isInitialized)
            {
                return;
            }

            _emptyViewHost.Content = view ?? _emptyTextLabel;
        }

        private void UpdateInitialLoadingText(string text)
        {
            if (!_isInitialized)
            {
                return;
            }

            _initialLoadingTextLabel.Text = text;
        }

        private void UpdateInitialLoadingView(View view)
        {
            if (!_isInitialized)
            {
                return;
            }

            _initialLoadingViewHost.Content = view ?? _initialLoadingViewHost.Content;
        }

        private void UpdateVisualState()
        {
            if (!_isInitialized)
            {
                return;
            }

            var showInitialLoading = IsInitialLoading;
            var showEmpty = !showInitialLoading && IsEmpty;
            var showContent = !showInitialLoading && !showEmpty;

            _initialLoadingViewHost.IsVisible = showInitialLoading;
            _emptyViewHost.IsVisible = showEmpty;
            _refreshView.IsVisible = showContent;
            _refreshView.IsEnabled = showContent && IsPullToRefreshEnabled;

            if (!showContent)
            {
                _refreshView.IsRefreshing = false;
            }
        }

        private static Thickness MergeThickness(Thickness basePadding, Thickness insetPadding)
        {
            return new Thickness(
                basePadding.Left + insetPadding.Left,
                basePadding.Top + insetPadding.Top,
                basePadding.Right + insetPadding.Right,
                basePadding.Bottom + insetPadding.Bottom);
        }

        private static View CreateDefaultContent(ScrollOrientation orientation, Thickness padding, double spacing)
        {
            return orientation == Microsoft.Maui.ScrollOrientation.Vertical
                ? new VerticalStackLayout
                {
                    Padding = padding,
                    Spacing = spacing
                }
                : new HorizontalStackLayout
                {
                    Padding = padding,
                    Spacing = spacing
                };
        }

        private async Task StartRefreshAnimationAsync()
        {
            if (IsInitialLoading || IsEmpty || !IsPullToRefreshEnabled)
            {
                return;
            }

            var version = ++_refreshAnimationVersion;

            _progressFill.AbortAnimation(nameof(StartRefreshAnimationAsync));
            _refreshView.IsRefreshing = true;
            _refreshProgressBar.IsVisible = true;
            _refreshProgressBar.Opacity = 0;
            _progressFill.WidthRequest = 0;

            await _refreshProgressBar.FadeToAsync(1, 200);

            if (version != _refreshAnimationVersion || !IsRefreshing)
            {
                return;
            }

            var totalWidth = _refreshProgressBar.Width > 0 ? _refreshProgressBar.Width : _rootGrid.Width;
            if (totalWidth > 0)
            {
                await _progressFill.WidthRequestTo(totalWidth, 600, Easing.CubicInOut);
            }
        }

        private async Task StopRefreshAnimationAsync()
        {
            _refreshAnimationVersion++;
            _progressFill.AbortAnimation(nameof(StartRefreshAnimationAsync));

            await _refreshProgressBar.FadeToAsync(0, 200);
            _refreshProgressBar.IsVisible = false;
            _progressFill.WidthRequest = 0;
            _refreshView.IsRefreshing = false;
        }
    }
}