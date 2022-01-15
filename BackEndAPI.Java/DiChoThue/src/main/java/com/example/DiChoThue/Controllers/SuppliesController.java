package com.example.DiChoThue.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.persistence.EntityManager;

@RestController
@RequestMapping("/api/supplies")
public class SuppliesController {
    @Autowired
    private EntityManager entityManager;

//    @GetMapping("/commission/{storeId}")
//    public ResponseEntity<List<SanPhamModel>> getAllProductsOfStore(@PathVariable(value = "storeId") Integer storeId)
//            throws ResourceNotFoundException {
//        String sql = "Select new " + SanPhamModel.class.getName()
//                + "(sp.ma_sp, dm.ten_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta) "
//                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
//                + " dm on sp.ma_dm = dm.ma_dm where sp.ma_cua_hang = " + storeId;
//        Query query = entityManager.createQuery(sql, SanPhamModel.class);
//
//        return ResponseEntity.ok().body(query.getResultList());
//    }
}
