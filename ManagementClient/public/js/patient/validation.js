function checkName() {
  var reg = /^[a-zA-Z ]{2,}$/;
  var name = $("#name").val();

  if (!reg.test(removeAscent(name))) {
    $("#name-danger").attr("hidden", false);
    return false;
  }

  $("#name-danger").attr("hidden", true);
  return true;
}

function removeAscent(str) {
  if (str === null || str === undefined) return str;
  str = str.toLowerCase();
  str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
  str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
  str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
  str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
  str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
  str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
  str = str.replace(/đ/g, "d");
  return str;
}

function checkId() {
  var idType = $("#idType").val();
  var id = $("#id").val();
  var reg;

  switch (idType) {
    case "idCard":
      reg = /[0-9]{9}/;
      if (!reg.test(id)) {
        $("#id-danger").text("CMND không đúng định dạng");
        $("#id-danger").attr("hidden", false);
        return false;
      }
      break;
    case "citiIdCard":
      reg = /[0-9]{12}/;
      if (!reg.test(id)) {
        $("#id-danger").text("CCCD không đúng định dạng");
        $("#id-danger").attr("hidden", false);
        return false;
      }
      break;
  }

  $("#id-danger").attr("hidden", true);
  return true;
}

function checkProvince() {
  var province = $("#province").val();

  if (province === "province-empty") {
    $("#province-danger").attr("hidden", false);
    return false;
  }

  $("#province-danger").attr("hidden", true);
  return true;
}

function checkDistrict() {
  var district = $("#district").val();

  if (district === "district-empty") {
    $("#district-danger").attr("hidden", false);
    return false;
  }

  $("#district-danger").attr("hidden", true);
  return true;
}

function checkCommune() {
  var commune = $("#commune").val();

  if (commune === "commune-empty") {
    $("#commune-danger").attr("hidden", false);
    return false;
  }

  $("#commune-danger").attr("hidden", true);
  return true;
}

function checkState() {
  var state = $("#state").val();

  if (state === "state-empty") {
    $("#state-danger").attr("hidden", false);
    return false;
  }

  $("#state-danger").attr("hidden", true);
  return true;
}

function checkRelatedPatient() {
  var relatedPatient = $("#related-patient").val();

  if (relatedPatient === "related-patient-empty") {
    $("#related-patient-danger").attr("hidden", false);
    return false;
  }

  $("#related-patient-danger").attr("hidden", true);
  return true;
}

function checkRelatedProvince() {
  var province = $("#related-province").val();

  if (province === "related-province-empty") {
    $("#related-province-danger").attr("hidden", false);
    return false;
  }

  $("#related-province-danger").attr("hidden", true);
  return true;
}

function checkRelatedDistrict() {
  var district = $("#related-district").val();

  if (district === "related-district-empty") {
    $("#related-district-danger").attr("hidden", false);
    return false;
  }

  $("#related-district-danger").attr("hidden", true);
  return true;
}

function checkRelatedCommune() {
  var commune = $("#related-commune").val();

  if (commune === "related-commune-empty") {
    $("#related-commune-danger").attr("hidden", false);
    return false;
  }

  $("#related-commune-danger").attr("hidden", true);
  return true;
}

function checkPlace() {
  var place = $("#place").val();

  if (place === "place-empty") {
    $("#place-danger").attr("hidden", false);
    return false;
  }

  $("#place-danger").attr("hidden", true);
  return true;
}

function checkIdNumber(idNumber, callback) {
  $.ajax({
    url: "/patient/check-id-number",
    method: "get",
    data: {
      idNumber: idNumber,
    },
    success: function (response) {
      if (response.check == true) {
        $("#id-danger").text("CCCD/CCCD đã tồn tại");
        $("#id-danger").attr("hidden", false);
      } else {
        $("#id-danger").attr("hidden", true);
        callback();
      }
    },
    error: function (response) {
      alert("server error");
    },
  });
}
