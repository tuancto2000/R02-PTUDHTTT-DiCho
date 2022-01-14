package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.DonHang;
import com.example.DiChoThue.Entities.NguoiDung;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.NguoiDungModel;
import com.example.DiChoThue.Repository.NguoiDungRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.persistence.EntityManager;
import javax.persistence.Query;

@RestController
@RequestMapping("/api/deliveries")
public class DeliveriesController {
    @Autowired
    NguoiDungRepository nguoiDungRepository;

    @Autowired
    private EntityManager entityManager;



    @GetMapping("/shippers/{id}")
    public ResponseEntity<NguoiDungModel> getShipperInfo(@PathVariable(value = "id") Integer orderId)
            throws ResourceNotFoundException {
        String sql = "Select new " + NguoiDungModel.class.getName() //
                + "(e.MA_NGUOI_DUNG, e.TEN_NGUOI_DUNG,e.NGAY_SINH, e.DIA_CHI, e.SDT, e.EMAIL) " //
                + " from " + NguoiDung.class.getName() + " e join " + DonHang.class.getName() + " d" //
                + " on e.MA_NGUOI_DUNG = d.MA_SHIPPER where d.MA_DON_HANG = " + orderId;
        Query query = entityManager.createQuery(sql, NguoiDungModel.class);
        return ResponseEntity.ok().body((NguoiDungModel) query.getSingleResult());
    }
}
