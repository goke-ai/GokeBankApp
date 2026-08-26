using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JSInterop;

namespace Goke.Bank.Hyb.Services
{

    public class ThemeService
    {
        private readonly IJSRuntime _js;
        private string _currentTheme = "light";
        private const string StorageKey = "app-theme";

        public event Action<string>? OnThemeChanged;

        public ThemeService(IJSRuntime js)
        {
            _js = js;
        }

        public string CurrentTheme => _currentTheme;

        public async Task InitializeAsync()
        {
            var savedTheme = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);

            if (string.IsNullOrWhiteSpace(savedTheme))
                await DetectSystemThemeAsync();

            if (!string.IsNullOrWhiteSpace(savedTheme))
                _currentTheme = savedTheme;

            await ApplyThemeAsync(_currentTheme);
        }

        public async Task ToggleThemeAsync()
        {
            _currentTheme = _currentTheme == "light" ? "dark" : "light";
            await ApplyThemeAsync(_currentTheme);
        }

        public async Task SetThemeAsync(string theme)
        {
            _currentTheme = theme;
            await ApplyThemeAsync(theme);
        }

        private async Task ApplyThemeAsync(string theme)
        {
            await _js.InvokeVoidAsync("setBootstrapTheme", theme);
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, theme);

            OnThemeChanged?.Invoke(theme);
        }

        public async Task DetectSystemThemeAsync()
        {
#if ANDROID || IOS || MACCATALYST
            var systemTheme = App.Current.RequestedTheme == AppTheme.Dark ? "dark" : "light";
            await SetThemeAsync(systemTheme);
#endif
        }

    }

}
