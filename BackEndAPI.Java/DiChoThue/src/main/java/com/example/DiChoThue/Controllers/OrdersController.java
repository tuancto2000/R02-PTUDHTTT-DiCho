package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.DanhGia;
import com.example.DiChoThue.Entities.DonHang;
import com.example.DiChoThue.Entities.NguoiDung;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.NguoiDungModel;
import com.example.DiChoThue.Repository.DanhGiaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import javax.validation.Valid;

@RestController
@RequestMapping("/api/orders")
public class OrdersController {
    @Autowired
    private EntityManager entityManager;

    @Autowired
    private DanhGiaRepository danhGiaRepository;

    @GetMapping("/{orderId}/shipper")
    public ResponseEntity<NguoiDungModel> getShipperInfo(@PathVariable(value = "orderId") Integer orderId)
            throws ResourceNotFoundException {
        String sql = "Select new " + NguoiDungModel.class.getName()
                + "(nd.MA_NGUOI_DUNG, nd.TEN_NGUOI_DUNG, nd.NGAY_SINH, nd.SDT, nd.EMAIL) "
                + " from " + NguoiDung.class.getName() + " nd join " + DonHang.class.getName() + " dh"
                + " on nd.MA_NGUOI_DUNG = dh.MA_SHIPPER where dh.MA_DON_HANG = " + orderId;
        Query query = entityManager.createQuery(sql, NguoiDungModel.class);
        return ResponseEntity.ok().body((NguoiDungModel) query.getSingleResult());
    }

    @PostMapping("/{orderId}/rate")
    public ResponseEntity<DanhGia> addRate(@PathVariable(value = "orderId") Integer orderId,
                                           @Valid @RequestBody DanhGia danhGia) {
        return ResponseEntity.ok(danhGiaRepository.save(danhGia));
    }
}
