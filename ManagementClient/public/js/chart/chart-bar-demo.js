// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Bar Chart Example
const packageNode = document.getElementById("packageBarChart");
const productNode = document.getElementById("productBarChart");
const oTablePac = document.getElementById('package-Statistic-Table');
const oTablePro = document.getElementById('product-Statistic-Table');

getTableData(packageNode, oTablePac);
getTableData(productNode, oTablePro);

function getTableData(node, oTable) {
  const dataTable = [...oTable.rows].map(t => [...t.children].map(u => u.innerText))
  dataTable.splice(0, 1);

  const oData = {
    labels: dataTable.map((e, i) => e[1]),
    data: dataTable.map((e, i) => e[2])
  }

  let max = oData.data[0];
  max = Math.ceil(max/10)*10;

  runChart(node, oData, max);
}

function runChart(node, objData, max) {
  const myLineChart = new Chart(node, {
    type: 'bar',
    data: {
      labels: objData.labels,
      datasets: [{
        label: "Số lượng",
        backgroundColor: "rgba(2,117,216,1)",
        borderColor: "rgba(2,117,216,1)",
        data: objData.data,
      }],
    },
    options: {
      scales: {
        xAxes: [{
          time: {
            unit: 'month'
          },
          gridLines: {
            display: false
          },
          ticks: {
            maxTicksLimit: 10
          }
        }],
        yAxes: [{
          ticks: {
            min: 0,
            max: max,
            maxTicksLimit: 10
          },
          gridLines: {
            display: true
          }
        }],
      },
      legend: {
        display: false
      }
    }
  });
}