window.setBootstrapTheme = function (theme) {
    document.documentElement.setAttribute("data-bs-theme", theme);
};

window.getBootstrapTheme = function () {
    return document.documentElement.getAttribute("data-bs-theme");
};
