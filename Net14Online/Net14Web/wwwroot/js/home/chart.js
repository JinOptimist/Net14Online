$(document).ready(function () {
    let weatherPromise;

    init();

    function init() {
        google.charts.load('current', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        requestWeatherData();
    }

    $('.place-for-weather').change(function () {
        const val = $(this).val();
        if (val.length == 0) {
            // Взять данные о местоположении из браузера

            navigator.geolocation.getCurrentPosition(function (userGetlocation) {
                const latitude = userGetlocation.coords.latitude;
                const longitude = userGetlocation.coords.longitude;

                weatherPromise = $.get(`/api/weather/todayWeather?latitude=${latitude}&longitude=${longitude}`);
                drawChart();
            });
        } else {
            requestWeatherData();
            drawChart();
        }
    });

    function requestWeatherData() {
        const coordinate = JSON.parse($('.place-for-weather').val()).map(x => x + '');
        const latitude = coordinate[0];
        const longitude = coordinate[1];
        weatherPromise = $.get(`/api/weather/todayWeather?latitude=${latitude}&longitude=${longitude}`);
    }

    function drawChart() {
        // Set Options
        const options = {
            title: 'Погода на сегодня',
            hAxis: { title: 'Время' },
            vAxis: { title: 'Температура' },
            legend: 'none'
        };

        weatherPromise
            .then(function (dataFromServer) {
                // Set Data
                const arrayHourTemperature = dataFromServer
                    .temperaturesFor24Hours
                    .map((temperatureN, index) => [index, temperatureN]);
                //
                const data = google.visualization.arrayToDataTable([
                    ['Weather', 'Temperature'],
                    ...arrayHourTemperature]);

                // Draw
                const divForChart = document.getElementById('weatherChart');
                const chart = new google.visualization.LineChart(divForChart);
                chart.draw(data, options);
            });
    }
});
