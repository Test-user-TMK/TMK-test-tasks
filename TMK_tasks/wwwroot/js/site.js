$(document).ready(function () {
    if (window.location.href.includes('/order/index')) {
        var source = document.getElementById('manufacturer_search');
        var lst = document.getElementsByClassName('manufacturerTitle');

        function toggle_by_class(sourceData) {
            for (var i = 0; i < lst.length; i++) {
                if (!lst[i].innerHTML.toLowerCase().includes(sourceData.value.toLowerCase())) {
                    lst[i].parentElement.hidden = true;
                }
                else {
                    lst[i].parentElement.hidden = false;
                }
            }
        }

        const inputHandler = function (e) {
            toggle_by_class(source);
        }

        source.addEventListener('input', inputHandler);
    }

    if (window.location.href.includes('/order/positions/index')) {
        var steelTypeSource = document.getElementById('steelType_search');
        var diametrSource = document.getElementById('diameter_search');
        var sideWidthSource = document.getElementById('sideWidth_search');

        var lstSteelTypes = document.getElementsByClassName('steelType');
        var lstDiameters = document.getElementsByClassName('diameter');
        var lstSideWidths = document.getElementsByClassName('sideWidth');

        function toggle_steelType_by_class(steelTypeSourceData) {
            for (var i = 0; i < lstSteelTypes.length; i++) {
                if (!lstSteelTypes[i].innerHTML.toLowerCase().includes(steelTypeSourceData.value.toLowerCase())) {
                    lstSteelTypes[i].parentElement.hidden = true;
                }
                else {
                    lstSteelTypes[i].parentElement.hidden = false;
                }
            }
        }

        function toggle_diameter_by_class(diametrSourceData) {
            for (var i = 0; i < lstDiameters.length; i++) {
                if (!lstDiameters[i].innerHTML.toLowerCase().includes(diametrSourceData.value.toLowerCase())) {
                    lstDiameters[i].parentElement.hidden = true;
                }
                else {
                    lstDiameters[i].parentElement.hidden = false;
                }
            }
        }

        function toggle_sideWidth_by_class(sideWidthSourceData) {
            for (var i = 0; i < lstSideWidths.length; i++) {
                if (!lstSideWidths[i].innerHTML.toLowerCase().includes(sideWidthSourceData.value.toLowerCase())) {
                    lstSideWidths[i].parentElement.hidden = true;
                }
                else {
                    lstSideWidths[i].parentElement.hidden = false;
                }
            }
        }

        const steelTypeInputHandler = function (e) {
            toggle_steelType_by_class(steelTypeSource);
        }

        const diameterInputHandler = function (e) {
            toggle_diameter_by_class(diametrSource);
        }

        const sideWidthInputHandler = function (e) {
            toggle_sideWidth_by_class(sideWidthSource);
        }

        steelTypeSource.addEventListener('input', steelTypeInputHandler);
        diametrSource.addEventListener('input', diameterInputHandler);
        sideWidthSource.addEventListener('input', sideWidthInputHandler);
    }
});