(function () {
    const storageKey = "theme";

    function getSystemTheme() {
        return window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
    }

    function getStoredTheme() {
        return localStorage.getItem(storageKey);
    }

    function setTheme(theme) {
        document.documentElement.setAttribute("data-bs-theme", theme);
    }

    function applyStoredTheme() {
        const theme = getStoredTheme() || getSystemTheme();
        setTheme(theme);
    }

    window.themeManager = {
        setTheme(theme) {
            setTheme(theme);
        },

        getTheme() {
            return document.documentElement.getAttribute("data-bs-theme");
        },

        setStoredTheme(theme) {
            localStorage.setItem(storageKey, theme);
        },

        getStoredTheme() {
            return getStoredTheme();
        },

        getSystemTheme() {
            return getSystemTheme();
        },

        registerThemeChangeHandler(dotNetObjRef) {
            const mediaQuery = window.matchMedia("(prefers-color-scheme: dark)");

            mediaQuery.addEventListener("change", e => {
                if (getStoredTheme()) {
                    return;
                }

                const theme = e.matches ? "dark" : "light";
                setTheme(theme);
                dotNetObjRef.invokeMethodAsync("OnThemeChanged", theme);
            });
        },

        applyStoredTheme
    };

    applyStoredTheme();
    document.addEventListener("DOMContentLoaded", applyStoredTheme);
    document.addEventListener("enhancedload", applyStoredTheme);
})();