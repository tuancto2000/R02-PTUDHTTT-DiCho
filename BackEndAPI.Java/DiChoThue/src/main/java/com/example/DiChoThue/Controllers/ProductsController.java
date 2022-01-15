package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.DanhMuc;
import com.example.DiChoThue.Entities.SanPham;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.SanPhamModel;
import com.example.DiChoThue.Repository.SanPhamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import javax.validation.Valid;
import java.util.List;

@RestController
@RequestMapping("/api/products")
public class ProductsController {
    @Autowired
    SanPhamRepository sanPhamRepository;

    @Autowired
    private EntityManager entityManager;

    @GetMapping("/store/{storeId}")
    public ResponseEntity<List<SanPhamModel>> getAllProductsOfStore(@PathVariable(value = "storeId") Integer storeId)
            throws ResourceNotFoundException {
        String sql = "Select new " + SanPhamModel.class.getName()
                + "(sp.ma_sp, dm.ma_dm, dm.ten_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
                + " dm on sp.ma_dm = dm.ma_dm where sp.ma_cua_hang = " + storeId;
        Query query = entityManager.createQuery(sql, SanPhamModel.class);
        return ResponseEntity.ok().body(query.getResultList());
    }

    @GetMapping("/{productId}")
    public ResponseEntity<SanPhamModel> getProductById(@PathVariable(value = "productId") Integer productId)
            throws ResourceNotFoundException {
        String sql = "Select new " + SanPhamModel.class.getName()
                + "(sp.ma_sp, dm.ma_dm, dm.ten_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
                + " dm on sp.ma_dm = dm.ma_dm where sp.ma_sp = " + productId;
        Query query = entityManager.createQuery(sql, SanPhamModel.class);
        return ResponseEntity.ok().body((SanPhamModel) query.getSingleResult());
    }

    @PostMapping
    public ResponseEntity<SanPham> createProduct(@Valid @RequestBody SanPham sanPham) {
        return ResponseEntity.ok(sanPhamRepository.save(sanPham));
    }

    @PutMapping("/{productId}")
    public ResponseEntity<SanPham> updateProduct(@PathVariable(value = "productId") Integer productId,
                                                 @Valid @RequestBody SanPham sanPhamDetail)
            throws ResourceNotFoundException {
        SanPham sanPham = sanPhamRepository.findById(productId)
                .orElseThrow(() -> new ResourceNotFoundException("Product not found for this id :: " + productId));

        sanPham.setTen_sp(sanPhamDetail.getTen_sp());
        sanPham.setMo_ta(sanPhamDetail.getMo_ta());
        sanPham.setGia_sp(sanPhamDetail.getGia_sp());
        sanPham.setSo_luong_con_lai(sanPham.getSo_luong_con_lai() + sanPhamDetail.getSo_luong_con_lai());
        sanPham.setMa_dm(sanPhamDetail.getMa_dm());

        return ResponseEntity.ok(sanPhamRepository.save(sanPham));
    }

    @DeleteMapping("/{productId}")
    public ResponseEntity<Boolean> deleteProduct(@PathVariable(value = "productId") Integer productId)
            throws ResourceNotFoundException {
        SanPham sanPham = sanPhamRepository.findById(productId)
                .orElseThrow(() -> new ResourceNotFoundException("Product not found for this id :: " + productId));

        sanPhamRepository.delete(sanPham);
        return ResponseEntity.ok(Boolean.TRUE);
    }
}
