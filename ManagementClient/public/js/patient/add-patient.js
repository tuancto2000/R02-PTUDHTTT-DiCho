var yob = document.getElementById("yob");
var curYear = new Date().getFullYear();
yob.setAttribute("max", curYear);
yob.setAttribute("value", curYear);

$("#add-patient-form").submit(function (e) {
  e.preventDefault();
  if (
    checkName() &&
    checkId() &&
    checkProvince() &&
    checkDistrict() &&
    checkCommune() &&
    checkRelatedPatient() &&
    checkState() &&
    checkRelatedProvince() &&
    checkRelatedDistrict() &&
    checkRelatedCommune()
  ) {
    checkIdNumber($("#id").val(), () => {
      $.ajax({
        url: "/patient/add",
        method: "post",
        data: {
          name: $("#name").val(),
          id: $("#id").val(),
          yob: $("#yob").val(),
          province: $("#province").val(),
          district: $("#district").val(),
          commune: $("#commune").val(),
          state: $("#state").val(),
          related_patient: $("#related-patient").val(),
          related_province: $("#related-province").val(),
          related_district: $("#related-district").val(),
          related_commune: $("#related-commune").val(),
        },
        success: function (response) {
          location.href = "/patient";
        },
        error: function (response) {
          alert("server error");
        },
      });
    });
  }
});

jQuery(document).ready(function ($) {
  $("#province").change(async function (event) {
    $("#district").empty();
    $("#district").append(
      $("<option>", {
        value: "district-empty",
        text: "---Chọn quận / huyện---",
      })
    );

    $("#commune").empty();
    $("#commune").append(
      $("<option>", {
        value: "commune-empty",
        text: "---Chọn phường / xã---",
      })
    );

    if ($("#province").val() !== "province-empty") {
      $.ajax({
        url: "/address/get-district",
        method: "post",
        dataType: "json",
        data: { provinceId: $("#province").val() },
        success: function (response) {
          if (response.msg == "success") {
            response.data.forEach((element) => {
              let option = $("<option>", {
                value: element.id_huyen,
                text: element.ten_huyen,
              });
              $("#district").append(option);
            });
          }
        },
        error: function (response) {
          alert("server error");
        },
      });
    }
  });

  $("#district").change(async function (event) {
    $("#commune").empty();
    $("#commune").append(
      $("<option>", {
        value: "commune-empty",
        text: "---Chọn phường / xã---",
      })
    );

    if ($("#district").val() !== "district-empty") {
      $.ajax({
        url: "/address/get-commune",
        method: "post",
        dataType: "json",
        data: { districtId: $("#district").val() },
        success: function (response) {
          if (response.msg == "success") {
            response.data.forEach((element) => {
              let option = $("<option>", {
                value: element.id_xa,
                text: element.ten_xa,
              });
              $("#commune").append(option);
            });
          }
        },
        error: function (response) {
          alert("server error");
        },
      });
    }
  });

  $("#related-province").change(async function (event) {
    $("#related-district").empty();
    $("#related-district").append(
      $("<option>", {
        value: "related-district-empty",
        text: "---Chọn quận / huyện---",
      })
    );

    $("#related-commune").empty();
    $("#related-commune").append(
      $("<option>", {
        value: "related-commune-empty",
        text: "---Chọn phường / xã---",
      })
    );

    if ($("#related-province").val() !== "related-province-empty") {
      $.ajax({
        url: "/address/get-district",
        method: "post",
        dataType: "json",
        data: { provinceId: $("#related-province").val() },
        success: function (response) {
          if (response.msg == "success") {
            response.data.forEach((element) => {
              let option = $("<option>", {
                value: element.id_huyen,
                text: element.ten_huyen,
              });
              $("#related-district").append(option);
            });
          }
        },
        error: function (response) {
          alert("server error");
        },
      });
    }
  });

  $("#related-district").change(async function (event) {
    $("#related-commune").empty();
    $("#related-commune").append(
      $("<option>", {
        value: "related-commune-empty",
        text: "---Chọn phường / xã---",
      })
    );

    if ($("#related-district").val() !== "related-district-empty") {
      $.ajax({
        url: "/address/get-commune",
        method: "post",
        dataType: "json",
        data: { districtId: $("#related-district").val() },
        success: function (response) {
          if (response.msg == "success") {
            response.data.forEach((element) => {
              let option = $("<option>", {
                value: element.id_xa,
                text: element.ten_xa,
              });
              $("#related-commune").append(option);
            });
          }
        },
        error: function (response) {
          alert("server error");
        },
      });
    }
  });
});
