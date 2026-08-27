window.themeManager = {
    setTheme(theme) {
        document.documentElement.setAttribute('data-bs-theme', theme);
    },

    getTheme() {
        return document.documentElement.getAttribute('data-bs-theme');
    },

    setStorageTheme(theme) {
        localStorage.setItem('theme', theme);
    },

    getStorageTheme() {
        return localStorage.getItem('theme');
    },

    // Detects current system theme: "light" or "dark"
    getSystemTheme: function () {
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    },

    // Allows .NET to subscribe to theme changes
    registerThemeChangeHandler: function (dotNetObjRef) {
        const mediaQuery = window.matchMedia('(prefers-color-scheme: dark)');
        mediaQuery.addEventListener('change', e => {
            const theme = e.matches ? 'dark' : 'light';
            dotNetObjRef.invokeMethodAsync('OnThemeChanged', theme);
        });
    }
};