src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.js";

var marksCanvas = document.getElementById("marksChart");

var marksData = {
  labels: ["Family", "Friends", "Self-Improvement", "Money", "Career", "Hobby", "Rest", "Health"],
  datasets: [{
    label: "January",
    backgroundColor: "rgba(200,0,0,0.2)",
    data: [65, 75, 70, 80, 60, 80, 10, 10]
  }, {
    label: "February",
    backgroundColor: "rgba(0,0,200,0.2)",
    data: [54, 65, 60, 70, 70, 75, 20, 20]
  }]
};

var radarChart = new Chart(marksCanvas, {
  type: 'radar',
  data: marksData
});