var fadeTime = 100;

/* Assign actions */
$(document).on("change", '.product-quantity input', function () {
  updateQuantityPrice(this);
});

/* Recalculate cart */
function recalculateCart() {
  var subtotal = 0;

  /* Sum up row totals */
  $('.product').each(function () {
    subtotal += parseFloat($(this).children('.product-line-price').text());
  });


  /* Update totals display */
  $('.totals-value').fadeOut(fadeTime, function () {
    $('#cart-subtotal').html(subtotal);
    if (subtotal == 0) {
      $('.checkout').fadeOut(fadeTime);
    } else {
      $('.checkout').fadeIn(fadeTime);
    }
    $('.totals-value').fadeIn(fadeTime);
  });
}


/* Update quantity */
function updateQuantityPrice(quantityInput) {
  /* Calculate line price */
  var productRow = $(quantityInput).parent().parent();
  var price = parseFloat(productRow.children('.product-price').text());
  var quantity = $(quantityInput).val();
  var linePrice = price * quantity;

  /* Update line price display and recalc cart totals */
  productRow.children('.product-line-price').each(function () {
    $(this).fadeOut(fadeTime, function () {
      $(this).text(linePrice);
      recalculateCart();
      $(this).fadeIn(fadeTime);
    });
  });
}

$(document).on('click', '.decrease', function () {
  updateQuantity(this, 0);
})

$(document).on('click', '.increase', function () {
  updateQuantity(this, 1);
})

function updateQuantity(e, opt) {
  const input = $(e).parent().parent().children()[1];
  const quantityNode = $(input);
  let quantity = parseInt(quantityNode.val());
  const min = parseInt(quantityNode.attr('min'),);
  const max = parseInt(quantityNode.attr('max'));

  if (opt == 0) {
    if (quantity > min) {
      quantity = quantity - 1;
      quantityNode.val(quantity);
    }
  } else {
    if (quantity < max) {
      quantity = quantity + 1;
      quantityNode.val(quantity);
    }
  }

  updateQuantityPrice(quantityNode);
}


$('.btn-request-form').on("click", async function (e) {
  const id = $('form input[name="packageId"]').val();
  try {
    const data = await fetch(`http://127.0.0.1:3000/product-package/package-detail/${id}`)
    
    const package = await data.json();

    if(data.status != '200'){
      $('.shopping-cart .list-product').html(`<h4 class="text-center text-info my-4">${package.info}</h4>`);
      $('.shopping-cart .totals').addClass('d-none');
      return;
    }

    const info = package.info[0];

    $('.cart .package-name').text(`${info.ten_goi}`)
    
    let html = '';

    package.products.forEach(e => {
      const tong_tien = e.gia_tien * e.so_luong;

      let so_luong = e.so_luong > e.gioi_han_san_pham? e.gioi_han_san_pham : e.so_luong;

      html += `<div class="product">
      <div class="product-image">
          <img src="${e.url}">
      </div>
      <div class="product-details">
          <h5 class="product-title">${e.ten_sanpham}</h5>
          <p class="product-description" style="text-align:justify">${e.mo_ta}</p>
      </div>
      <div class="product-price mt-1">${e.gia_tien}</div>
      <div class="product-quantity d-flex justify-content-center align-items-center">
        <span><i class="fas fa-minus decrease"></i></span>
        <input type="number" name="product[]" value="${so_luong}" min="0" max="${e.gioi_han_san_pham}">
        <span><i class="fas fa-plus increase"></i></span>
      </div>
      <div class="product-line-price mt-1">${tong_tien}</div>
      </div>`

    })

    $('.shopping-cart .list-product').html(html);
    recalculateCart();
    $('.shopping-cart .totals').removeClass('d-none');
  } catch (error) {
    $('.shopping-cart .list-product').html('<h3 class="text-center text-secondary my-4">Lỗi rồi !!!</h3>');
    $('.shopping-cart .totals').addClass('d-none');
    console.log(error);
  }

})