window.renderChart = (canvasId, chartData) => {
    console.log("renderChart() körs!", canvasId, chartData);

    var ctx = document.getElementById(canvasId);
    if (!ctx) {
        console.error("Canvas-elementet hittades inte:", canvasId);
        return;
    }

    if (window.myChart && typeof window.myChart.destroy === "function") {
        window.myChart.destroy();
    }

    window.myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: chartData.labels,
            datasets: [{
                label: 'Antal svar',
                data: chartData.data,
                backgroundColor: ['#000000', '#FFFFFF'],  // Svart och vitt
                borderColor: ['#FFFFFF', '#000000'],      // Vitt och svart kantlinje
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: { y: { beginAtZero: true } }
        }
    });

    console.log("Diagram renderat!");
};
