package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.ChiTietGioHang;
import com.example.DiChoThue.Models.AddProductToCartModel;
import com.example.DiChoThue.Models.UpdateCartModel;
import com.example.DiChoThue.Repository.ChiTIetGioHangRepository;
import com.example.DiChoThue.Repository.GioHangRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.validation.Valid;
import java.util.List;
import java.util.Objects;

@RestController
@RequestMapping("/api/carts")
public class CartsController {
    @Autowired
    private EntityManager entityManager;

    @Autowired
    GioHangRepository gioHangRepository;

    @Autowired
    ChiTIetGioHangRepository chiTIetGioHangRepository;

    @GetMapping("/{userId}")
    public ResponseEntity<List<ChiTietGioHang>> getCart(@PathVariable(value = "userId") Integer userId) {
        int cartId = gioHangRepository.getCartId(userId);

        return ResponseEntity.ok(chiTIetGioHangRepository.getCartDetailsByCartId(cartId));
    }

    @PostMapping("/add-product")
    public ResponseEntity<Boolean> addProduct(@Valid @RequestBody AddProductToCartModel product) {
        int cartId = gioHangRepository.getCartId(product.getMa_nguoi_dung());

        try {
            int cartDetailId = chiTIetGioHangRepository.checkExistsProduct(cartId, product.getMa_sp());
            chiTIetGioHangRepository.updateQuantityByCartDetailId(product.getSo_luong(), cartDetailId);
        } catch (Exception e) {
            ChiTietGioHang chiTietGioHang = new ChiTietGioHang();
            chiTietGioHang.setMa_gio_hang(cartId);
            chiTietGioHang.setMa_sp(product.getMa_sp());
            chiTietGioHang.setSo_luong(product.getSo_luong());

            chiTIetGioHangRepository.save(chiTietGioHang).getId();
        }

        return ResponseEntity.ok(Boolean.TRUE);
    }

    @PostMapping("/update-cart")
    public ResponseEntity<Boolean> updateCart(@Valid @RequestBody UpdateCartModel updateCartModel) {
        int cartId = gioHangRepository.getCartId(updateCartModel.getMa_nguoi_dung());
        List<ChiTietGioHang> curCart = chiTIetGioHangRepository.getCartDetailsByCartId(cartId);
        List<ChiTietGioHang> newCart = updateCartModel.getChitietgiohang_list();

        if (newCart != null) {
            int i = 0;
            for (ChiTietGioHang ctgh : curCart) {
                if (!newCart.stream().filter(o -> Objects.equals(o.getMa_sp(), ctgh.getMa_sp())).findFirst().isPresent()) {
                    chiTIetGioHangRepository.delete(ctgh);
                } else {
                    chiTIetGioHangRepository.updateQuantity(newCart.get(i).getSo_luong(), cartId, newCart.get(i).getMa_sp());
                    i++;
                }
            }
        } else {
            for (ChiTietGioHang ctgh : curCart) {
                chiTIetGioHangRepository.delete(ctgh);
            }
        }

        return ResponseEntity.ok(Boolean.TRUE);
    }
}
