window.addEventListener('DOMContentLoaded', event => {
    // Simple-DataTables
    // https://github.com/fiduswriter/Simple-DataTables/wiki

    
    const datatablesSimple1 = document.getElementById('datatablesSimple');
    console.log(datatablesSimple1);
    
    if (datatablesSimple1) {
        new simpleDatatables.DataTable(datatablesSimple1);
    }
    const datatablesSimple2 = document.getElementById('lsDieuTri');
    if (datatablesSimple2) {
        new simpleDatatables.DataTable(datatablesSimple2);
    }
    const datatablesSimple3 = document.getElementById('nguoi_lien_quan_down');
    if (datatablesSimple3) {
        new simpleDatatables.DataTable(datatablesSimple3);
    }
    const datatablesSimple4 = document.getElementById('nguoi_lien_quan_up');
    if (datatablesSimple4) {
        new simpleDatatables.DataTable(datatablesSimple4);
    }
    
});

