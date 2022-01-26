// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = "#292b2c";

// Pie Chart Example
const patientNode = document.getElementById("patientPieChart");

const f1 = parseInt($(".f1").text());
const f2 = parseInt($(".f2").text());
const f3 = parseInt($(".f3").text());

const total = (f1 + f2 + f3) / 100;
const percent = [f1 / total, f2 / total, f3 / total];

console.log(percent);

const myPieChart = new Chart(patientNode, {
  type: "pie",
  data: {
    labels: ["Đỏ", "Cam", "Xanh"],
    datasets: [
      {
        data: percent,
        backgroundColor: ["#e60e0e", "#ff7803", "#1d45f5"],
      },
    ],
  },
});
