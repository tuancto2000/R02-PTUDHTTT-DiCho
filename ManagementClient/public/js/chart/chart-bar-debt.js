// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Bar Chart Example
const debtNode = document.getElementById("deptBarChart");
const TableDebt = document.getElementById('debt-Statistic-Table');

getTableData(debtNode, TableDebt);

function getTableData(node, Table) {
  const dataTable = [...Table.rows].map(t => [...t.children].map(u => u.innerText))
  dataTable.splice(0, 1);
  const data = dataTable.map((e, i) => parseInt(e[1].replace('.', ''))/1000);

  const data0 = data.filter(e => {return e > 0 && e < 500}).length;
  const data1 = data.filter(e => {return e >= 500 && e < 1000}).length;
  const data2 = data.filter(e => {return e >= 1000 && e < 2000}).length;
  const data3 = data.filter(e => {return e >= 2000 && e < 3000}).length;
  const data4 = data.filter(e => {return e >= 3000 && e < 5000}).length;
  const data5 = data.filter(e => {return e >= 5000}).length;

  const oData = {
    labels: ['0-500.000', '500.000-1.000.000', '1.000.000-2.000.000', '2.000.000-3.000.000', '3.000.000-5.000.000', '>5.000.000'],
    data: [data0, data1, data2, data3, data4, data5],
  }

  let max = Math.max(...oData.data);
  max = Math.ceil(max/10)*10;

  console.log(max)

  runChart(node, oData, 50);
}

function runChart(node, objData, max) {
    console.log(objData)
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