package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.*;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.GetCommissionModel;
import com.example.DiChoThue.Models.GetOrderDetailModel;
import com.example.DiChoThue.Models.GetOrderHistoryModel;
import com.example.DiChoThue.Models.NguoiDungModel;
import com.example.DiChoThue.Repository.DanhGiaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import javax.validation.Valid;
import java.util.List;

@RestController
@RequestMapping("/api/orders")
public class OrdersController {
    @Autowired
    private EntityManager entityManager;

    @Autowired
    private DanhGiaRepository danhGiaRepository;

    @GetMapping("/{orderId}/detail")
    public ResponseEntity<List<GetOrderDetailModel>> getOrderDetail(@PathVariable(value = "orderId") Integer orderId)
            throws ResourceNotFoundException {
        String sql = "Select new " + GetOrderDetailModel.class.getName()
                + "(ctdh.id, sp.ma_sp, sp.ten_sp, ha.nguon_hinh_anh, ctdh.so_luong, ctdh.don_gia, ctdh.so_luong * ctdh.don_gia as thanh_tien) "
                + " from " + ChiTietDonHang.class.getName() + " ctdh join " + SanPham.class.getName() + " sp"
                + " on ctdh.ma_sp = sp.ma_sp join " + HinhAnh.class.getName() + " ha on sp.ma_sp = ha.ma_sp"
                + " where ha.mac_dinh = 1 and ctdh.ma_don_hang = " + orderId;
        Query query = entityManager.createQuery(sql, GetOrderDetailModel.class);
        return ResponseEntity.ok().body(query.getResultList());
    }

    @GetMapping("/{orderId}/shipper")
    public ResponseEntity<NguoiDungModel> getShipperInfo(@PathVariable(value = "orderId") Integer orderId)
            throws ResourceNotFoundException {
        String sql = "Select new " + NguoiDungModel.class.getName()
                + "(nd.ma_nguoi_dung, nd.ten_nguoi_dung, nd.ngay_sinh, nd.sdt, nd.email) "
                + " from " + NguoiDung.class.getName() + " nd join " + DonHang.class.getName() + " dh"
                + " on nd.ma_nguoi_dung = dh.ma_shipper where dh.ma_don_hang = " + orderId;
        Query query = entityManager.createQuery(sql, NguoiDungModel.class);
        return ResponseEntity.ok().body((NguoiDungModel) query.getSingleResult());
    }

    @PostMapping("/{orderDetailId}/rate")
    public ResponseEntity<DanhGia> addRate(@Valid @RequestBody DanhGia danhGia) {
        return ResponseEntity.ok(danhGiaRepository.save(danhGia));
    }

    @GetMapping("/history/{userId}")
    public ResponseEntity<List<GetOrderHistoryModel>> getOrderHistory(@PathVariable(value = "userId") Integer userId)
            throws ResourceNotFoundException {
        String sql = "Select new " + GetOrderHistoryModel.class.getName()
                + "(dh.ma_don_hang, dh.ma_cua_hang, ch.ten_cua_hang, dh.tongtien, dh.trang_thai, dh.ngay_mua) "
                + " from " + DonHang.class.getName() + " dh join " + CuaHang.class.getName()
                + " ch on dh.ma_cua_hang = ch.ma_cua_hang where dh.ma_nguoi_dung = " + userId + " order by dh.ngay_mua";
        Query query = entityManager.createQuery(sql, GetOrderHistoryModel.class);
        return ResponseEntity.ok().body(query.getResultList());
    }
}
