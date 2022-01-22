package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.CuaHang;
import com.example.DiChoThue.Entities.DonHang;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.GetDeliveryHistoryModel;
import com.example.DiChoThue.Repository.NguoiDungRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import java.util.List;

@RestController
@RequestMapping("/api/deliveries")
public class DeliveriesController {
    @Autowired
    NguoiDungRepository nguoiDungRepository;

    @Autowired
    private EntityManager entityManager;

    @GetMapping("/history/{shipperId}")
    public ResponseEntity<List<GetDeliveryHistoryModel>> getAllDeliveryHistory(@PathVariable(value = "shipperId") Integer shipperId)
            throws ResourceNotFoundException {
        String sql = "Select new " + GetDeliveryHistoryModel.class.getName()
                + "(dh.ma_don_hang, dh.ma_cua_hang, ch.ten_cua_hang, dh.tongtien, dh.trang_thai, dh.ten_nguoi_nhan, dh.sdt, dh.dia_chi) "
                + " from " + DonHang.class.getName() + " dh join " + CuaHang.class.getName()
                + " ch on dh.ma_cua_hang = ch.ma_cua_hang where dh.ma_shipper = " + shipperId + " order by dh.ngay_mua";
        Query query = entityManager.createQuery(sql, GetDeliveryHistoryModel.class);
        return ResponseEntity.ok().body(query.getResultList());
    }
}
