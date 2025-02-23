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
                backgroundColor: ['#000000', '#FFFFFF'],  
                borderColor: ['#FFFFFF', '#000000'],   
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

window.scrollToTop = () => {
    window.scrollTo(0, 0);
};


document.addEventListener("DOMContentLoaded", function () {
    // Hitta alla karusellknappar och stoppa dem från att ändra URL
    document.querySelectorAll(".carousel-control-prev, .carousel-control-next").forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault(); // Stoppar ändring av URL
        });
    });

    // Se till att sidan inte hoppar när karusellen byter bild
    document.querySelectorAll(".carousel").forEach(carousel => {
        carousel.addEventListener("slide.bs.carousel", function () {
            let scrollY = window.scrollY; // Spara scrollposition
            setTimeout(() => {
                window.scrollTo({ top: scrollY, behavior: "instant" }); // Återställ scrollpositionen
            }, 0);
        });
    });
});


